namespace OnlineAtelier.Web.Models.ViewModels.Publications
{
    using System.ComponentModel;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class CreatePublicationVm : IMapFrom<Publication>
    {
        public int Id { get; set; }

        [DisplayName("URL")]
        public string PhotoUrl { get; set; }

        [DisplayName("Заглавие")]
        public string Title { get; set; }

        [DisplayName("Съдържание")]
        public string Content { get; set; }
    }
}
