namespace OnlineAtelier.Services.Contracts
{
    using Web.Models.BindingModels.Publications;
    using Web.Models.ViewModels.Publications;


    public interface IPublicationsService : IService
    {
        void AddPublication(PublicationBm publication);

        CreatePublicationVm GetViewModel(int? id);

        void Edit(PublicationBm model);

        DetailsPublicationVModel GetDetailsPublicationVModel(int id);

        void Delete(int id);
    }
}