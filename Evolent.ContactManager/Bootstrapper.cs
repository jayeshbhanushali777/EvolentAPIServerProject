using Microsoft.Practices.Unity;
using Resolver;
using System.Web.Http;
using Unity.Mvc3;

namespace Evolent.ContactManager
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //register dependency resolver for ContactManager
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "Evolent*.dll");

        }
    }
}