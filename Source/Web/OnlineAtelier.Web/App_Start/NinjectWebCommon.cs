[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineAtelier.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineAtelier.Web.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineAtelier.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Data;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using OnlineAtelier.Models.Models.Comments;
    using Data.Common.Repository;
    using OnlineAtelier.Models;
    using OnlineAtelier.Models.Models;
    using Services.Contracts;
    using Services;

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
            kernel.Bind<DbContext>().To<ApplicationDbContext>();
            kernel.Bind(typeof(IRepository<Album>)).To(typeof(DeletableEntityRepository<Album>));
            kernel.Bind(typeof(IRepository<Comment>)).To(typeof(DeletableEntityRepository<Comment>));
            kernel.Bind(typeof(IRepository<Category>)).To(typeof(DeletableEntityRepository<Category>));
            kernel.Bind(typeof(IRepository<Appearance>)).To(typeof(DeletableEntityRepository<Appearance>));
            kernel.Bind(typeof(IRepository<UserPicture>)).To(typeof(DeletableEntityRepository<UserPicture>));
            kernel.Bind(typeof(IRepository<Order>)).To(typeof(DeletableEntityRepository<Order>));
            kernel.Bind(typeof(IRepository<Picture>)).To(typeof(DeletableEntityRepository<Picture>));
            kernel.Bind(typeof(IRepository<Publication>)).To(typeof(DeletableEntityRepository<Publication>));
            kernel.Bind(typeof(IProfileService)).To(typeof(ProfileServices));
            kernel.Bind(typeof(IOrderService)).To(typeof(OrderService));
            kernel.Bind(typeof(ICommentService)).To(typeof(CommentService));
            kernel.Bind(typeof(IUserPictureService)).To(typeof(UserOrderPicturesService));

            kernel.Bind(typeof(IRepository<ApplicationUser>)).To(typeof(DeletableEntityRepository<ApplicationUser>));


            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));

            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

           // kernel.Bind(typeof(ISanitizer)).To(typeof(HtmlSanitizerAdapter));
        }        
    }
}
