namespace OnlineAtelier.Web.Models.BindingModels.Appearance
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AppearanceCreateBm : IMapFrom<Appearance>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CookiesCount { get; set; }

        public bool IsBoxOfNormalSize { get; set; }
    }
}