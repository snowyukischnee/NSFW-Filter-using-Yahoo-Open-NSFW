using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSFW_ProxyGUI {
    public partial class Form1 : Form {

        private readonly CustomProxy proxy;
        private bool SystemProxyLocked;
        private bool BackendAPILocked;
        private bool Started;

        public Form1() {
            InitializeComponent();
            StartStopBtn.BackColor = Color.Green;
            this.proxy = new CustomProxy();
            this.SystemProxyLocked = true;
            this.BackendAPILocked = true;
            this.Started = false;
            SystemProxyAddressTxt.Enabled = !this.SystemProxyLocked;
            SystemProxyPortTxt.Enabled = !this.SystemProxyLocked;
            SystemProxyLockBtn.Text = !this.SystemProxyLocked ? "Lock" : "Unock";
            BackendAPITxt.Enabled = !this.BackendAPILocked;
            BackendAPILockBtn.Text = !this.BackendAPILocked ? "Lock" : "Unlock";
        }

        private void SystemProxyLockBtn_Click(object sender, EventArgs e) {
            this.SystemProxyLocked = !this.SystemProxyLocked;
            SystemProxyAddressTxt.Enabled = !this.SystemProxyLocked;
            SystemProxyPortTxt.Enabled = !this.SystemProxyLocked;
            SystemProxyLockBtn.Text = !this.SystemProxyLocked ? "Lock" : "Unock";
        }

        private void BackendAPILockBtn_Click(object sender, EventArgs e) {
            this.BackendAPILocked = !this.BackendAPILocked;
            BackendAPITxt.Enabled = !this.BackendAPILocked;
            BackendAPILockBtn.Text = !this.BackendAPILocked ? "Lock" : "Unlock";
        }

        private void StartStopBtn_Click(object sender, EventArgs e) {
            if (!this.Started) {
                this.proxy.StartProxy(
                    Utility.ParseNInt(PortTxt.Text, 8000), 
                    BackendAPITxt.Text, 
                    SystemProxyAddressTxt.Text, 
                    Utility.ParseNInt(SystemProxyPortTxt.Text),
                    0.5 - 0.1 * SensitivityLevel.Value
                );
                this.SystemProxyLocked = true;
                SystemProxyAddressTxt.Enabled = !this.SystemProxyLocked;
                SystemProxyPortTxt.Enabled = !this.SystemProxyLocked;
                SystemProxyLockBtn.Text = !this.SystemProxyLocked ? "Lock" : "Unock";
                SystemProxyLockBtn.Enabled = false;
                this.BackendAPILocked = true;
                BackendAPITxt.Enabled = !this.BackendAPILocked;
                BackendAPILockBtn.Text = !this.BackendAPILocked ? "Lock" : "Unlock";
                BackendAPILockBtn.Enabled = false;
                SensitivityLevel.Enabled = false;
            } else {
                this.proxy.Stop();
                SystemProxyLockBtn.Enabled = true;
                BackendAPILockBtn.Enabled = true;
                SensitivityLevel.Enabled = true;
            }
            this.Started = !this.Started;
            StartStopBtn.Text = !this.Started ? "Start" : "Stop";
            StartStopBtn.BackColor = !this.Started ? Color.Green : Color.Red;
            PortTxt.Enabled = !this.Started;
        }

        private void LogBtn_Click(object sender, EventArgs e) {
            new LogForm(this.proxy.Log).ShowDialog();
        }

        private void BlacklistBtn_Click(object sender, EventArgs e) {
            new BlacklistForm().ShowDialog();
        }
    }
}
