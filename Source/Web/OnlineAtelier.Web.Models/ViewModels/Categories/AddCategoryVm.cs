namespace OnlineAtelier.Web.Models.ViewModels.Categories
{
    using OnlineAtelier.Models.Models;
    using Infrastructure.Mapping;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AddCategoryVm : IMapFrom<Category>
    {
        [Required(ErrorMessage = "Задай име на категорията")]
        [DisplayName("Име на категорията")]
        public string Name { get; set; }
    }
}