namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categories;

        public CategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IEnumerable<string> GetAllCategories()
        {
            var allCategories = this.categories
                .All()
                .Select(c => c.Name)
                .ToList();

            return allCategories;
        }

        public Category GetCategory(string name)
        {
            var category = this.categories.All()
                .FirstOrDefault(a => a.Name == name);

            return category;
        }
    }
}