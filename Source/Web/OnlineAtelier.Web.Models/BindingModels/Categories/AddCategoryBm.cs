namespace OnlineAtelier.Web.Models.BindingModels.Categories
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AddCategoryBm : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
