using NetExercise.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using static NetExercise.UnityDI.UnityModel;

namespace NetExercise
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Unity configuration
            var container = new UnityContainer();
            container.RegisterType<ISaveToFile, SaveToXMLFile>("XML");
            container.RegisterType<ISaveToFile, SaveToCsvFile>("CSV");
            container.RegisterType<IGetModel, TextProcessor>();
            config.DependencyResolver = new UnityResolver(container);

            //this
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
        }
    }
}
