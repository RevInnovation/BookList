using Boilerplate.Helpers.Repository;
using Boilerplate.InfrastructureLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Webservice.AppStarts.Installers
{
    public class InfrastructureLayerInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<DatabaseEntities>(opts => opts.UseLazyLoadingProxies().UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection")));
            services.AddScoped<DatabaseEntities>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, DatabaseEntities>();
        }
    }
}
