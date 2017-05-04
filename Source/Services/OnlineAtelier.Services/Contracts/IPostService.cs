namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Posts;
    using Web.Models.ViewModels.AdminArea.Posts;
    using Web.Models.ViewModels.Posts;


    public interface IPostService : IDeletable
    {
        void AddPublication(PostBm post, Category category);

        CreatePostsVm GetViewModel(int? id);

        EditPostVm GetEditViewModel(int? id);

        void Edit(EditPostBm model);

        DetailsPostsVModel GetDetailsPostVModel(int id);

        IEnumerable<IndexPostsVm> All();

        List<ICollection<PostVm>> GroupByCategory();

        IEnumerable<GalleryPostVm> GetPostsByCategory(int id);

        IEnumerable<IndexPostsVm> GetIndexPosts();

        void Vote(VotePostBm postBm);
    }
}