namespace OnlineAtelier.Web.Models.ViewModels.Categories
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DisplayAllCategoriesViewModel : IMapFrom<Category>
    { 

        public int Id { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }
    }
}
