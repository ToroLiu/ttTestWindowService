using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using Topshelf;
using Topshelf.HostConfigurators;
using Topshelf.ServiceConfigurators;

namespace TTWindowsService
{
    static class Program
    {
        private static readonly string _kServiceAddress = "http://localhost:9999";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            HostFactory.Run(x => {
                x.Service<WebApiService>(
                    setting => new WebApiService(new Uri(_kServiceAddress)),
                    conf => { });

                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetServiceName("Toro.WebService");
                x.SetDisplayName("Toro.WebService");
                x.SetDescription("Run Web Api Windows Service for testing.");

                x.DependsOnEventLog();
            });
        }
    }
}
