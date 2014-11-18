[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PetAdopt.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PetAdopt.Web.App_Start.NinjectWebCommon), "Stop")]

namespace PetAdopt.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using PetAdopt.Data;
    using PetAdopt.Data.Repositories;
    using PetAdopt.Models;
    using PetAdopt.Web.Infrastructure.Caching;
    using PetAdopt.Web.Infrastructure.Populators;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            
            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));
            kernel.Bind<IPetAdoptData>().To<PetAdoptData>();
            kernel.Bind<IPetAdoptDbContext>().To<PetAdoptDbContext>();

            kernel.Bind<IRepository<User>>().To<EFRepository<User>>();

            kernel.Bind<IRepository<PetType>>().To<DeletableEntityRepository<PetType>>();
            kernel.Bind<IRepository<Pet>>().To<DeletableEntityRepository<Pet>>();
            kernel.Bind<IRepository<PetCandidature>>().To<DeletableEntityRepository<PetCandidature>>();
            kernel.Bind<IRepository<Message>>().To<DeletableEntityRepository<Message>>();
            kernel.Bind<IRepository<Notification>>().To<DeletableEntityRepository<Notification>>();
            //kernel.Bind(typeof(IPetAdoptData)).To(typeof(PetAdoptData));

            //kernel.Bind(typeof(IRepository<>)).To(typeof(EFRepository<>));

            kernel.Bind(typeof(IDeleteablePetAdoptData)).To(typeof(DeleteablePetAdoptData));

            kernel.Bind<ICacheService>().To<InMemoryCache>();
            kernel.Bind<IDropDownListPopulator>().To<DropDownListPopulator>();
        }

        public static object IRepository { get; set; }
    }
}
