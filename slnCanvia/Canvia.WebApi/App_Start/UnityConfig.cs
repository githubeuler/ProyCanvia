using Canvia.Business.Contract;
using Canvia.Business.Implementation;
using Canvia.Data.Factory.Contract;
using Canvia.Data.Factory.Implementation;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Canvia.WebApi
{
    public class UnityConfig
    {
        //public static void RegisterComponents()
        //{

        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICanviaDAOFactory, CanviaDAOFactory>();
            container.RegisterType<IPersonaLogic, PersonaLogic>();
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        // register all your components with the container here
        // it is NOT necessary to register your controllers

        // e.g. container.RegisterType<ITestService, TestService>();

        //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        //}
    }
}