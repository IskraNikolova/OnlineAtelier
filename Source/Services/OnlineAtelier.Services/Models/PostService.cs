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
    using Web.Models.ViewModels.Posts;

    public class PostService : IPostService
    {
        private readonly IRepository<Post> publications;

        public PostService(IRepository<Post> publications)
        {
            this.publications = publications;
        }

        public void AddPublication(PostBm post, Category category)
        {
            var entity = Mapper.Map<PostBm, Post>(post);
            entity.CategoryId = category.Id;
            this.publications.Add(entity);
            this.publications.SaveChanges();
        }

        public CreatePostsVm GetViewModel(int? id)
        {
            var entity = this.publications.GetById((int)id);
            var vModel = Mapper.Map<Post, CreatePostsVm>(entity);
            return vModel;
        }

        public void Edit(PostBm model)
        {
            var entity = this.publications.GetById(model.Id);

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.PhotoUrl = model.PhotoUrl;

            this.publications.Update(entity);
            this.publications.SaveChanges();
        }

        public DetailsPostsVModel GetDetailsPostVModel(int id)
        {
            var entity = this.publications.GetById(id);
            var model = Mapper.Map<Post, DetailsPostsVModel>(entity);

            return model;
        }

        public void Delete(int id)
        {
            var entity = this.publications.GetById(id);
            this.publications.Delete(entity);
            this.publications.SaveChanges();
        }

        public IEnumerable<IndexPostsVm> All()
        {
            var model = this.publications
                .All()
                .Project()
                .To<IndexPostsVm>()
                .ToList();

            return model;
        }
    }
}