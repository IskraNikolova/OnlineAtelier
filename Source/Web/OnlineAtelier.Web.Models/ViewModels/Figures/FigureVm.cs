namespace OnlineAtelier.Web.Models.ViewModels.Figures
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class FigureVm : IMapFrom<Figure>
    {
        public string Name { get; set; }
    }
}
