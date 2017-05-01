namespace OnlineAtelier.Web.Models.ViewModels.Figures
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class FigureVm : IMapFrom<Figure>
    {
        [Required(ErrorMessage = "Въведи име на модела.")]
        [DisplayName("Име на модела")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Името не може да е по-късо от {1}, символа.", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
