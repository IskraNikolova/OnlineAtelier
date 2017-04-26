namespace OnlineAtelier.Data.Interfaces
{
    using System.Data.Entity;
    using Models.Models;
    using Models.Models.Comments;

    public interface IOnlineAtelierDbContext
    {
        IDbSet<OrderComment> OrderComments { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<PostComment> PostComments { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Appearance> Appearances { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<PhotosOrder> UserPictures { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Figure> Figures { get; set; }

        int SaveChanges();
    }
}