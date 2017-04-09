namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;

    public interface IAppearanceService : IService
    {
        IEnumerable<string> GetAllAppearances();

        Appearance GetAppearence(string name);
    }
}