namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;

    public interface ICategoryService : IService
    {
        IEnumerable<string> GetAllCategories();


        Category GetCategory(string name);
    }
}