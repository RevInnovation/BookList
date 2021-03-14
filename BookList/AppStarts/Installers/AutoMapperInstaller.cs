using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Webservice.AppStarts.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            var profiles = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(Profile).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract && x.Namespace.Contains("Mappings"))
            .Select(Activator.CreateInstance)
            .Cast<Profile>()
            .ToList();
            services.AddAutoMapper(x =>
            {
                foreach (Profile profile in profiles)
                {
                    x.AddProfile(profile);
                }
            });
        }
    }
}
