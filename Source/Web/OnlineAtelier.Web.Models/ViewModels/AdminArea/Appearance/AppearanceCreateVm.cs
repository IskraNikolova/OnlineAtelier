namespace OnlineAtelier.Web.Models.ViewModels.AdminArea.Appearance
{
    using System.ComponentModel.DataAnnotations;
    using BindingModels.Appearance;
    using Infrastructure.Mapping;

    public class AppearanceCreateVm : IMapFrom<AppearanceCreateBm>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Попълни наименование на продукта.")]
        [StringLength(100, ErrorMessage = "Името не може да е по-късо от {1}, символа.", MinimumLength = 3)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Попълни цена на продукта.")]
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Попълни количество/брой на продукта.")]
        [Display(Name = "Количество")]
        public int CookiesCount { get; set; }

        [Display(Name = "Кутия със стандартен размер сладки ли е?")]
        public bool IsBoxOfNormalSize { get; set; }
    }
}