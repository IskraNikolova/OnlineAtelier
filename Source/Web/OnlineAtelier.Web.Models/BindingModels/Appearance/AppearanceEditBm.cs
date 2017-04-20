namespace OnlineAtelier.Web.Models.BindingModels.Appearance
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AppearanceEditBm : IMapFrom<Appearance>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}