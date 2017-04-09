namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    public class AppearancesService : IAppearanceService
    {
        private readonly IRepository<Appearance> appearances;

        public AppearancesService(IRepository<Appearance> appearances)
        {
            this.appearances = appearances;
        }

        public IEnumerable<string> GetAllAppearances()
        {
            var allAppearances = this.appearances
                .All()
                .Select(a => a.Name)
                .ToList();

            return allAppearances;
        }

        public Appearance GetAppearence(string name)
        {
            var appearance = this.appearances.All()
                .FirstOrDefault(a => a.Name == name);

            return appearance;
        }
    }
}