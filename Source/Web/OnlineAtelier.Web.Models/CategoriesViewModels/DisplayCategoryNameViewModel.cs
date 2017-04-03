namespace OnlineAtelier.Web.Models.CategoriesViewModels
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DisplayCategoryNameViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}
