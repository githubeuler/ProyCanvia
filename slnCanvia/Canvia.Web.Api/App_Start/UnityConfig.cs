
using Canvia.Business.Contract;
using Canvia.Business.Implementation;
using Canvia.Data.Factory.Contract;
using Canvia.Data.Factory.Implementation;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Canvia.Web.Api.App_Start
{
    public class UnityConfig
    {
         public static void RegisterComponents()
         {
             var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICanviaDAOFactory, CanviaDAOFactory>();
            container.RegisterType<IPersonaLogic, PersonaLogic>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
         }
        
    }
}