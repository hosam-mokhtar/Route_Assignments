using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction.Layer;

namespace Service.Layer
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
            #region Mapping Register

            //builder.Services.AddAutoMapper(p => p.AddProfile(new ProductProfile()));
            //builder.Services.AddAutoMapper(p => p.AddProfiles(new ProductProfile(), ));

            //OR Dynamic 
            //Version AutoMapper 14.0.0
            //builder.Services.AddAutoMapper(typeof(ServiceLayerAssemblyReference).Assembly);

            //Latest Version AutoMapper 15.1.0
            /*builder.*/Services.AddAutoMapper((x) => { }, typeof(ServiceLayerAssemblyReference).Assembly);

            #endregion

            /*builder.*/Services.AddScoped<IServiceManager, ServiceManager>();


            return Services;
        }
    }
}
