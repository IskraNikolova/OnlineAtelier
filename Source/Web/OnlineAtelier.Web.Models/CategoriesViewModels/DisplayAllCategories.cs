namespace OnlineAtelier.Web.Models.CategoriesViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class DisplayAllCategories
    { 

        public int Id { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }
    }
}
