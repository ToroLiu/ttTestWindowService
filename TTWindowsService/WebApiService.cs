using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Diagnostics;

using Topshelf;

namespace TTWindowsService
{
    public class WebApiService : ServiceControl
    {
        private readonly HttpSelfHostServer _server;
        private readonly HttpSelfHostConfiguration _config;

        private const string EventSource = "WebApiService";

        public WebApiService(Uri address)
        {
            if (!EventLog.SourceExists(EventSource))
            {
                EventLog.CreateEventSource(EventSource, "Application");
            }
            EventLog.WriteEntry(EventSource, string.Format("Create a service at {0}", address.ToString()));

            _config = new HttpSelfHostConfiguration(address);
            _config.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional });
            
            AttributeRoutingConfig.RegisterRoutes(_config);

            _server = new HttpSelfHostServer(_config);
        }

        public bool Start(HostControl hostControl)
        {
            EventLog.WriteEntry(EventSource, "Opening Web Api Service.");
            _server.OpenAsync();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            EventLog.WriteEntry(EventSource, "Close Web Api Service.");

            _server.CloseAsync().Wait();
            _server.Dispose();

            return true;
        }
    }
}
