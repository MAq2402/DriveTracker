using DriveTracker.App_Start;
using DriveTracker.DbContexts;
using DriveTracker.Repositories;
using DriveTracker.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;

namespace DriveTracker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterSingleton<AppDbContext, AppDbContext>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICarRepository, CarRepository>();
            container.RegisterType<IAppRepository, AppRepository>();
            container.RegisterType<IJourneyRepository, JourneyRepository>();
            container.RegisterType<IPassengerRouteRepository, PassengerRouteRepository>();
            container.RegisterType<IPaymentRepository, PaymentRepository>();

            container.RegisterType<IPaymentService, PaymentService>();
            container.RegisterType<IJourneyService, JourneyService>();
            container.RegisterType<IUserService, UserService>();
            

            config.DependencyResolver = new UnityResolver(container);
            // Konfiguracja i usługi składnika Web API

            // Trasy składnika Web API
            config.MapHttpAttributeRoutes();


            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
