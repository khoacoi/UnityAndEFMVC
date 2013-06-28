using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Application.DAL.Contract;
using Application.DAL;
using Application.Domain.ProfileModule.ProfileAggregate;
using Application.Repository.ProfileModule;
using Application.Manager.Contract;
using Application.Manager.Implementation;
using Application.Common.Logging;
using Application.Common.Validator;
using Application.Common.Localization;
using Application.Domain.ProfileModule.AddressAggregate;
using Application.Domain.ProfileModule.PhoneAggregate;
using Application.Domain.ProfileModule.ProfileAddressAggregate;
using Application.Domain.ProfileModule.ProfilePhoneAggregate;

namespace Application.DependencyResolver
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));

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
            container.RegisterType<IQueryableUnitOfWork, UnitOfWork>();
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IAddressTypeRepository, AddressTypeRepository>();
            container.RegisterType<IPhoneTypeRepository, PhoneTypeRepository>();
            container.RegisterType<IPhoneRepository, PhoneRepository>();
            container.RegisterType<IProfileAddressRepository, ProfileAddressRepository>();
            container.RegisterType<IProfilePhoneRepository, ProfilePhoneRepository>();
            container.RegisterType<IContactManager, ContactManager>();
        }

        private static void RegisterFacilities(IUnityContainer container)
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            LocalizerFactory.SetCurrent(new ResxLocalizerFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }
    }
}