namespace OnlineAtelier.Web.Models.BindingModels.Figures
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class FigureBm : IMapFrom<Figure>
    {
        public string Name { get; set; }
    }
}