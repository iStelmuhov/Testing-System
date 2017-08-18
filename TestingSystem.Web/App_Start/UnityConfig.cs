using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TestingSystem.Dependencies;
using TestingSystem.Repository.EntityFramework;
using Unity.Mvc5;
using TestingSystem.Web.Controllers;

namespace TestingSystem.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            var dbContex=new TestSystemDbContext();
            ContainerBoostraper.RegisterTypes(container,dbContex);
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}