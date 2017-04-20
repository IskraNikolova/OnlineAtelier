namespace OnlineAtelier.Web.Models.ViewModels.AdminArea.Appearance
{
    using System.ComponentModel.DataAnnotations;
    using BindingModels.Appearance;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AppearanceEditVm : IMapFrom<Appearance>, IMapFrom<AppearanceEditBm>
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Името не може да е по-късо от {2}, символа.", MinimumLength = 3)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "{0}та трябва да е между {1}.00лв. и {2}.00лв.")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
