namespace OnlineAtelier.Data.Mocks
{
    using System.Data.Entity;
    using Interfaces;
    using Models.Models;
    using Models.Models.Comments;

    public class FakeOnlineAtelierDbContext : DbContext, IOnlineAtelierDbContext
    {
        public IDbSet<OrderComment> OrderComments { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<PostComment> PostComments { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Appearance> Appearances { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<PhotosOrder> UserPictures { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Figure> Figures { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
