using DAO;
using Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Http;
using Titanium.Web.Proxy.Models;

namespace NSFW_ProxyGUI {
    class CustomProxy {
        private readonly ProxyServer proxyServer;
        private readonly IDictionary<Guid, HeaderCollection> requestHeaderHistory = new ConcurrentDictionary<Guid, HeaderCollection>();
        private readonly IDictionary<Guid, HeaderCollection> responseHeaderHistory = new ConcurrentDictionary<Guid, HeaderCollection>();
        private string BackendAPI;
        private string SystemProxyHost;
        private int? SystemProxyPort;
        public StringBuilder Log = new StringBuilder();
        private int Port;
        private JavaScriptSerializer JsSerializer = new JavaScriptSerializer();
        private readonly BlacklistDAO blDAO = new BlacklistDAO();
        private readonly BlockingHandleDAO bhDAO = new BlockingHandleDAO();
        private List<Blacklist> blacklist;
        private double SensitiveLvl = H_Bound;
        private static double H_Bound = 0.5;
        private static double L_Bound = 0;
        public CustomProxy() {
            proxyServer = new ProxyServer();
            proxyServer.ExceptionFunc = exception => Log.Append(exception.Message).Append("\n");
            proxyServer.TrustRootCertificate = true;
            proxyServer.ForwardToUpstreamGateway = true;
        }

        public void StartProxy(int Port, string BackendAPI, string SystemProxyHost, int? SystemProxyPort, double SensitiveLvl) {
            //-------------------------------------
            this.Log = new StringBuilder();
            this.Port = Port;
            this.BackendAPI = BackendAPI;
            this.SystemProxyHost = SystemProxyHost;
            this.SystemProxyPort = SystemProxyPort;
            this.SensitiveLvl = Math.Min(H_Bound, Math.Max(L_Bound, SensitiveLvl));
            blacklist = blDAO.GetBlacklist();
            //-------------------------------------
            proxyServer.BeforeRequest += OnRequest;
            proxyServer.BeforeResponse += OnResponse;
            proxyServer.TunnelConnectRequest += OnTunnelConnectRequest;
            proxyServer.TunnelConnectResponse += OnTunnelConnectResponse;
            proxyServer.ServerCertificateValidationCallback += OnCertificateValidation;
            proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;
            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, this.Port, true) {
                ExcludedHttpsHostNameRegex = new List<string>{
                    this.BackendAPI
                },
            };
            proxyServer.AddEndPoint(explicitEndPoint);
            if (this.SystemProxyHost != null && this.SystemProxyPort != null) {
                proxyServer.UpStreamHttpProxy = new ExternalProxy() {
                    HostName = this.SystemProxyHost,
                    Port = this.SystemProxyPort.GetValueOrDefault()
                };
                proxyServer.UpStreamHttpsProxy = new ExternalProxy() {
                    HostName = this.SystemProxyHost,
                    Port = this.SystemProxyPort.GetValueOrDefault()
                };
            }
            proxyServer.Start();
            proxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            proxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
            foreach (var endPoint in proxyServer.ProxyEndPoints) {
                Log.Append("Listening on " + endPoint.GetType().Name + " endpoint at Ip " + endPoint.IpAddress + " and port: " + endPoint.Port + " ").Append("\n");
            }
        }

        public void Stop() {
            proxyServer.TunnelConnectRequest -= OnTunnelConnectRequest;
            proxyServer.TunnelConnectResponse -= OnTunnelConnectResponse;
            proxyServer.BeforeRequest -= OnRequest;
            proxyServer.BeforeResponse -= OnResponse;
            proxyServer.ServerCertificateValidationCallback -= OnCertificateValidation;
            proxyServer.ClientCertificateSelectionCallback -= OnCertificateSelection;
            proxyServer.Stop();
        }

        private async Task OnTunnelConnectRequest(object sender, TunnelConnectSessionEventArgs e) {
            Log.Append("Tunnel to: " + e.WebSession.Request.Host).Append("\n");
        }

        private async Task OnTunnelConnectResponse(object sender, TunnelConnectSessionEventArgs e) {
        }

        public async Task OnRequest(object sender, SessionEventArgs e) {
            Log.Append("Active Client Connections:" + ((ProxyServer)sender).ClientConnectionCount).Append("\n");
            Log.Append("Request: " + e.WebSession.Request.Url).Append("\n");
            requestHeaderHistory[e.Id] = e.WebSession.Request.RequestHeaders;

            if (e.WebSession.Request.HasBody) {
                var bodyBytes = await e.GetRequestBody();
                await e.SetRequestBody(bodyBytes);
                string bodyString = await e.GetRequestBodyAsString();
                await e.SetRequestBodyString(bodyString);
            }
            foreach (var item in blacklist) {
                if (e.WebSession.Request.RequestUri.AbsoluteUri.Contains(item.Domain)) {
                    await e.Ok(Encoding.ASCII.GetBytes(bhDAO.GetBlockingHandle().HTMLPage));
                }
            }
            
        }

        private class NSFW_Score {
            public string err { get; set; }
            public double score { get; set; }
        }

        public async Task OnResponse(object sender, SessionEventArgs e) {
            Log.Append("Active Client Connections:" + ((ProxyServer)sender).ClientConnectionCount).Append("\n");
            responseHeaderHistory[e.Id] = e.WebSession.Response.ResponseHeaders;
            if (e.WebSession.Response.ContentType != null && e.WebSession.Response.ContentType.Trim().ToLower().Contains("image")) {
                //---------------------------------------------------
                HttpClient httpClient = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();
                byte[] arr = await e.GetResponseBody();
                form.Add(new ByteArrayContent(arr, 0, arr.Length), "image", "img" + DateTime.Now.Ticks);
                HttpResponseMessage response = await httpClient.PostAsync(this.BackendAPI + "/upload", form);
                response.EnsureSuccessStatusCode();
                httpClient.Dispose();
                string result = response.Content.ReadAsStringAsync().Result;
                NSFW_Score res = JsSerializer.Deserialize<NSFW_Score>(result);
                Log.Append("Result: " + result).Append("\n");
                //-------------------------------------------------
                if (res.score >= SensitiveLvl) {
                    byte[] ImgArr = Utility.ImgByteArr(Image.FromFile(bhDAO.GetBlockingHandle().Image));
                    await e.SetResponseBody(ImgArr);
                    await e.SetResponseBodyString(ImgArr.ToString());
                } else {
                    var bodyBytes = await e.GetResponseBody();
                    await e.SetResponseBody(bodyBytes);
                    string body = await e.GetResponseBodyAsString();
                    await e.SetResponseBodyString(body);
                }
            } else {
                var bodyBytes = await e.GetResponseBody();
                await e.SetResponseBody(bodyBytes);
                string body = await e.GetResponseBodyAsString();
                await e.SetResponseBodyString(body);
            }
        }

        public Task OnCertificateValidation(object sender, CertificateValidationEventArgs e) {
            if (e.SslPolicyErrors == SslPolicyErrors.None) {
                e.IsValid = true;
            }
            return Task.FromResult(0);
        }

        public Task OnCertificateSelection(object sender, CertificateSelectionEventArgs e) {
            return Task.FromResult(0);
        }
    }
}
