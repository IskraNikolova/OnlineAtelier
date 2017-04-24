namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Posts;
    using Web.Models.ViewModels.AdminArea.Posts;
    using Web.Models.ViewModels.Posts;

    public class PostService : IPostService
    {
        private readonly IRepository<Post> posts;

        public PostService(IRepository<Post> posts)
        {
            this.posts = posts;
        }

        public void AddPublication(PostBm post, Category category)
        {
            var image = new Image()
            {
                Url = post.PhotoUrl
            };

            var entity = Mapper.Map<PostBm, Post>(post);
            entity.CategoryId = category.Id;
            entity.Image = image;

            this.posts.Add(entity);
            this.posts.SaveChanges();
        }

        public CreatePostsVm GetViewModel(int? id)
        {
            var entity = this.posts.GetById((int)id);
            var vModel = Mapper.Map<Post, CreatePostsVm>(entity);
            return vModel;
        }

        public void Edit(PostBm model)
        {
            var entity = this.posts.GetById(model.Id);

            entity.Title = model.Title;
            entity.Content = model.Content;
            if (model.PhotoUrl != null)
            {
                entity.Image = new Image()
                {
                    Url = model.PhotoUrl
                };
            }
            

            this.posts.Update(entity);
            this.posts.SaveChanges();
        }

        public DetailsPostsVModel GetDetailsPostVModel(int id)
        {
            var entity = this.posts.GetById(id);
            var model = Mapper.Map<Post, DetailsPostsVModel>(entity);

            return model;
        }

        public void Delete(int id)
        {
            var entity = this.posts.GetById(id);
            this.posts.Delete(entity);
            this.posts.SaveChanges();
        }

        public IEnumerable<IndexPostsVm> All()
        {
            var model = this.posts
                .All()
                .Project()
                .To<IndexPostsVm>()
                .OrderByDescending(p => p.CreatedOn)
                .Take(10)
                .ToList();

            return model;
        }

        public List<ICollection<PostVm>> GroupByCategory()
        {
            var all = this.posts
                .All()
                .GroupBy(p => p.Category.Name)
                .ToList();

            List<ICollection<PostVm>> postVm = new List<ICollection<PostVm>>();

            foreach (var grouping in all)
            {
                ICollection<PostVm> album = new List<PostVm>();
                foreach (var post in grouping)
                {
                    var model = Mapper.Map<Post, PostVm>(post);
                    album.Add(model);
                }

                postVm.Add(album);
            }
            
            return postVm;
        }

        public IEnumerable<GalleryPostVm> GetPostsByCategory(int id)
        {
            var model = this.posts
                .All()
                .Where(p => p.CategoryId == id)
                .Project()
                .To<GalleryPostVm>();

            return model;
        }

        public IEnumerable<IndexPostsVm> GetIndexPosts()
        {
            var indexPostsVm = this.posts
                .All()
                .Project()
                .To<IndexPostsVm>()
                .OrderByDescending(p => p.CreatedOn)
                .ToList();

            return indexPostsVm;
        }
    }
}