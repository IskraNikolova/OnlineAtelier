namespace OnlineAtelier.Services.Models
{
    using AutoMapper;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Publications;
    using Web.Models.ViewModels.Publications;

    public class PublicationService : IPublicationsService
    {
        private readonly IRepository<Publication> publications;

        public PublicationService(IRepository<Publication> publications)
        {
            this.publications = publications;
        }

        public void AddPublication(PublicationBm publication)
        {
            var entity = Mapper.Map<PublicationBm, Publication>(publication);
            this.publications.Add(entity);
            this.publications.SaveChanges();
        }

        public CreatePublicationVm GetViewModel(int? id)
        {
            var entity = this.publications.GetById((int)id);
            var vModel = Mapper.Map<Publication, CreatePublicationVm>(entity);
            return vModel;
        }

        public void Edit(PublicationBm model)
        {
            var entity = this.publications.GetById(model.Id);

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.PhotoUrl = model.PhotoUrl;

            this.publications.Update(entity);
            this.publications.SaveChanges();
        }

        public DetailsPublicationVModel GetDetailsPublicationVModel(int id)
        {
            var entity = this.publications.GetById(id);
            var model = Mapper.Map<Publication, DetailsPublicationVModel>(entity);

            return model;
        }

        public void Delete(int id)
        {
            var entity = this.publications.GetById(id);
            this.publications.Delete(entity);
            this.publications.SaveChanges();
        }
    }
}
