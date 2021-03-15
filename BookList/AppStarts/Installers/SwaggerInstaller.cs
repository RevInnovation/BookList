using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Webservice.AppStarts.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MY API", Version = "V1" }));
        }
    }
}
