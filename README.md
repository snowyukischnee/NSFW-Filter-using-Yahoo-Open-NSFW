# NSFW Filter using Yahoo Open NSFW
## Introduction
>This project is a proxy server that block NSFW image by using Yahoo's Open NSFW model \
>The interface's been writen in C# using [.NET](https://www.microsoft.com/net/ ".NET")
framework with [Titanium Web Proxy](https://github.com/justcoding121/Titanium-Web-Proxy "Titanium Web Proxy"), while the API server's been writen in Javascript by using [NodeJS](https://nodejs.org/en/ "NodeJS")
and [ExpressJS](https://expressjs.com/ "ExpressJS") \
>The core of the project, Yahoo's [Open NSFW](https://github.com/yahoo/open_nsfw "Open NSFW") model is the core in order to process image that is NSFW or not

## Description
Create a proxy server to handle all HTTP request and response in order to block NSFW content \
NSFW content divided into 2 following type:
+ Image
+ Website

While websites can be blocked by provide a list of banned sites, images can only be filter by running Open NSFW model, get score and pass score back to the proxy server. Based on that score, proxy server decide allow or not allow this image pass through

## Usage
First, install [VMware](https://www.vmware.com/ "VMware") on Windows

Then, download and install [Ubuntu 17.xx](https://www.ubuntu.com/download/desktop "Ubuntu 17.xx") on VMware in order to host API Server and NSFW core because some libraries requires by NSFW core is not exist on Windows

Next, Install [Caffe](http://caffe.berkeleyvision.org/ "caffe") and other package required by Yahoo's [Open NSFW](https://github.com/yahoo/open_nsfw "Open NSFW") on Ubuntu 17.xx on VMware

>[Tutorial](https://gist.github.com/nikitametha/c54e1abecff7ab53896270509da80215 "Tutorial") install Caffe on Ubuntu without GPU support, work perfectly fine in Ubuntu 17.xx

Copy all content in the **Backend** folder to Ubuntu's Desktop, then browse to **backend_api** folder
and install all required packages
```sh
$ cd backend_api
$ npm install
```

And finally, start the API Server

```sh
$ npm start
```

Switch back to Windows, browse into **NSFW_ProxyGUI** 
folder, run script **db_generate.sql** to generate database (**Note**: this project using **MSSQLServer**)

Then open **NSFW_ProxyGUI.sln** file in **Visual Studio** to open project and run **NSFW_ProxyGUI** project

Enter API link into section **API Server**

>__Example:__ `http://192.168.20.1:3000/upload` \
>`192.168.20.1` is your running VM's IP Address that can be obtained using the following command
>```sh
>$ ip addr show
>```
>`3000` is the port that API Server hosted in. In this project, port `3000` is the default port of API Server \
>`/upload` is the path to send POST request with image attached to process

Finally, Press **Start**

## Instructions
Provide proxy information into `Proxy` section if Windows is running under proxy \
Provide API Server into `API Server` section in order to enable filter images feature \
Provide "Blacklist" websites into `Blacklist` section to block some websites \
Change `Sensitivity` level to change the "sensitive" of the model

## Notes
> For more further information about this project, please read the code or contact me via email or social network
## References
[NodeJS](https://nodejs.org/en/ "NodeJS") \
[ExpressJS](https://expressjs.com/ "ExpressJS") \
[VMware](https://www.vmware.com/ "VMware") \
[Ubuntu 17.xx](https://www.ubuntu.com/download/desktop "Ubuntu 17.xx") \
[.NET](https://www.microsoft.com/net/ ".NET") \
[Caffe](http://caffe.berkeleyvision.org/ "caffe") \
[Titanium Web Proxy](https://github.com/justcoding121/Titanium-Web-Proxy "Titanium Web Proxy") \
[Open NSFW](https://github.com/yahoo/open_nsfw "Open NSFW") \
[Tutorial install Caffe on Ubuntu](https://gist.github.com/nikitametha/c54e1abecff7ab53896270509da80215 "Tutorial") 
## Author
Tuannhse04791