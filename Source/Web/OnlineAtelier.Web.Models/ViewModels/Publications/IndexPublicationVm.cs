namespace OnlineAtelier.Web.Models.ViewModels.Publications
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class IndexPublicationVm : IMapFrom<Publication>
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
