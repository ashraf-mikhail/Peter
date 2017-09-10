using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Bussiness;
using DataAccess;
using DataAccess.Interface;
using Microsoft.Owin.Security.OAuth;
using Service.Logging;

namespace Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            log4net.Config.XmlConfigurator.Configure();
            config.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter), new MyProjectTracer());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region Autofac
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<BookRepository>().As<IBookRepository>().SingleInstance();
            builder.Register(c => new ProductManager(c.Resolve<IProductDataAccess>()));
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ProductDataAccess>().As<IProductDataAccess>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            
            //var builder = new ContainerBuilder();

            //// Get your HttpConfiguration.
            //var config = GlobalConfiguration.Configuration;


            //// You can register controllers all at once using assembly scanning...
            ////builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //// ...or you can register individual controlllers manually.
            //builder.RegisterType<ProductsController>().InstancePerRequest();

            //builder.Register(c => new ProductManager(c.Resolve<IProductDataAccess>()));
            //builder.RegisterType<ProductManager>().As<IProductManager>();
            //builder.RegisterType<ProductDataAccess>().As<IProductDataAccess>();

            //// OPTIONAL: Register the Autofac filter provider.
            ////builder.RegisterWebApiFilterProvider(config);

            //// Set the dependency resolver to be Autofac.
            //var container = builder.Build();
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion
        }
    }
}
