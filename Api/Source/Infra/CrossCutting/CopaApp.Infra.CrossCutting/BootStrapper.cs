using CopaApp.Application.Service;
using CopaApp.Domain.Repository;
using CopaApp.Domain.Service;
using CopaApp.Infra.CrossCutting.Helpers;
using CopaApp.Infra.Data;
using CopaApp.Infra.Data.Interface;
using CopaApp.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CopaApp.Infra.CrossCutting
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Service
            services.AddScoped<IEquipeService, EquipeService>();
            services.AddScoped<ICopaService, CopaService>();

            // Repository
            services.AddScoped<IEquipeRepository, EquipeRepository>();

            //Context
            services.AddSingleton(typeof(IContext), new Context());

            //UnitOfWork
            services.AddSingleton(typeof(IUnitOfWork), new UnitOfWork(DataContext.Get()));
        }
    }
}
