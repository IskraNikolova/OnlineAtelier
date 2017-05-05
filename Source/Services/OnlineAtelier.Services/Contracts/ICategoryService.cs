namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Categories;

    public interface ICategoryService : IService
    {
        IEnumerable<string> GetAllCategories();


        Category GetCategory(string name);

        void AddNewCategory(AddCategoryBm bm);
    }
}