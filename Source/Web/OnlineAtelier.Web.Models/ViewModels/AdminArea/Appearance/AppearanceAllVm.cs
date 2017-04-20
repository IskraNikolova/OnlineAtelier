namespace OnlineAtelier.Web.Models.ViewModels.AdminArea.Appearance
{
    using System.ComponentModel;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AppearanceAllVm : IMapFrom<Appearance>
    {
        public int Id { get; set; }

        [DisplayName("Вид на продукт")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
