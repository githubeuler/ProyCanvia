using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Canvia.WebApi.Startup))]
namespace Canvia.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            AreaRegistration.RegisterAllAreas();
            HttpConfiguration config = new HttpConfiguration();
            appBuilder.UseWebApi(config);
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
            WebApiConfig.Register(config);

        }
    }
}