[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineAtelier.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineAtelier.Web.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineAtelier.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Data.Common.Repository;
    using System.Data.Entity;
    using Data;
    using OnlineAtelier.Models.Models.Comments;
    using OnlineAtelier.Models.Models;
    using Services.Contracts;
    using Services.Models;

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
            kernel.Bind(typeof(IRepository<OrderComment>)).To(typeof(DeletableEntityRepository<OrderComment>));
            kernel.Bind(typeof(IRepository<Image>)).To(typeof(DeletableEntityRepository<Image>));
            kernel.Bind(typeof(IRepository<PostComment>)).To(typeof(DeletableEntityRepository<PostComment>));
            kernel.Bind(typeof(IRepository<Category>)).To(typeof(DeletableEntityRepository<Category>));
            kernel.Bind(typeof(IRepository<Appearance>)).To(typeof(DeletableEntityRepository<Appearance>));
            kernel.Bind(typeof(IRepository<PhotosOrder>)).To(typeof(DeletableEntityRepository<PhotosOrder>));
            kernel.Bind(typeof(IRepository<Order>)).To(typeof(DeletableEntityRepository<Order>));
            kernel.Bind(typeof(IRepository<Post>)).To(typeof(DeletableEntityRepository<Post>));
            kernel.Bind(typeof(IRepository<Figure>)).To(typeof(DeletableEntityRepository<Figure>));
            kernel.Bind(typeof(IUserService)).To(typeof(UserService));
            kernel.Bind(typeof(IOrderService)).To(typeof(OrderService));
            kernel.Bind(typeof(ICommentService)).To(typeof(CommentService));
            kernel.Bind(typeof(IPhotosOrderService)).To(typeof(PhotosOrderService));
            kernel.Bind(typeof(IPostService)).To(typeof(PostService));
            kernel.Bind(typeof(ICategoryService)).To(typeof(CategoryService));
            kernel.Bind(typeof(IAppearanceService)).To(typeof(AppearancesService));
            kernel.Bind(typeof(IFigureService)).To(typeof(FigureService));

            kernel.Bind(typeof(IRepository<ApplicationUser>)).To(typeof(DeletableEntityRepository<ApplicationUser>));


            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));

            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            // kernel.Bind(typeof(ISanitizer)).To(typeof(HtmlSanitizerAdapter));
        }
    }
}
