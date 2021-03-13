using Boilerplate.ApplicationLayer.Books;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Boilerplate.Webservice.AppStarts.Installers
{
    public class ApplicationLayerInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.RegisterAssemblyPublicNonGenericClasses(assemblies: Assembly.GetAssembly(typeof(IBookService)))
                .Where(x => !x.IsInterface && !x.IsAbstract && x.Name.EndsWith("Service") && x.Namespace.Contains("ApplicationLayer"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Transient);
        }
    }
}
