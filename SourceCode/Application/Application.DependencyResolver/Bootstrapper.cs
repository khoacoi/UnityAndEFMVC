using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Application.DAL.Contract;
using Application.DAL;
using Application.Domain.ContactModule.ProfileAggregate;
using Application.Repository.ProfileModule;
using Application.Manager.Contract;
using Application.Manager.Implementation;
using Application.Common.Logging;
using Application.Common.Validator;
using Application.Common.Localization;
using Application.Domain.ContactModule.AddressAggregate;
using Application.Domain.ContactModule.PhoneAggregate;
using Application.Domain.ContactModule.ProfileAddressAggregate;
using Application.Domain.ContactModule.ProfilePhoneAggregate;
using Application.Manager.Contract.ContactModule;
using Application.Manager.Implementation.ContactModule;
using Application.Manager.Contract.ProductModule;
using Application.Manager.Implementation.ProductModule;
using Application.Domain.Product.CategoryAggregate;
using Application.Repository.ProductModule;
using System.Web.Http;

namespace Application.DependencyResolver
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //Resolve API Controllers
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);
            RegisterFacilities(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IQueryableUnitOfWork, UnitOfWork>((new PerThreadLifetimeManager()));
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IAddressTypeRepository, AddressTypeRepository>();
            container.RegisterType<IPhoneTypeRepository, PhoneTypeRepository>();
            container.RegisterType<IPhoneRepository, PhoneRepository>();
            container.RegisterType<IProfileAddressRepository, ProfileAddressRepository>();
            container.RegisterType<IProfilePhoneRepository, ProfilePhoneRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();

            container.RegisterType<IContactManager, ContactManager>();
            container.RegisterType<ICategoryManager, CategoryManager>();
        }

        private static void RegisterFacilities(IUnityContainer container)
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            LocalizerFactory.SetCurrent(new ResxLocalizerFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }
    }
}