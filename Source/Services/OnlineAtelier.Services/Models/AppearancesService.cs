namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Appearance;
    using Web.Models.ViewModels.AdminArea.Appearance;

    public class AppearancesService : IAppearanceService
    {
        private readonly IRepository<Appearance> appearances;

        public AppearancesService(IRepository<Appearance> appearances)
        {
            this.appearances = appearances;
        }

        public IEnumerable<string> GetAllNameOfAppearances()
        {
            var allAppearances = this.appearances
                .All()
                .Select(a => a.Name)
                .ToList();

            return allAppearances;
        }

        public Appearance GetAppearence(string name)
        {
            var appearance = this.appearances
                .All()
                .FirstOrDefault(a => a.Name == name);

            return appearance;
        }

        public void AddAppearance(AppearanceCreateBm bind)
        {
            var entity = Mapper.Map<AppearanceCreateBm, Appearance>(bind);

            this.appearances.Add(entity);
            this.appearances.SaveChanges();
        }

        public ICollection<AppearanceAllVm> All()
        {
            var all = this.appearances
                .All()
                .Project()
                .To<AppearanceAllVm>()
                .ToList();

            return all;
        }

        public AppearanceAllVm GetAppearanceAllVm(int? id)
        {
            var entity = this.appearances.GetById((int)id);
            if (entity == null)
            {
                return null;
            }

            var model = Mapper.Map<Appearance, AppearanceAllVm>(entity);

            return model;
        }

        public void Edit(AppearanceEditBm bind)
        {
            var entity = this.appearances.GetById(bind.Id);
            entity.Name = bind.Name;
            entity.Price = bind.Price;

            this.appearances.Update(entity);
            this.appearances.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.appearances.GetById(id);
            this.appearances.Delete(entity);
            this.appearances.SaveChanges();
        }

        public AppearanceCreateVm GetAppearanceCreateVm(AppearanceCreateBm bm)
        {
            var model = Mapper.Map<AppearanceCreateBm, AppearanceCreateVm>(bm);
            return model;
        }

        public AppearanceEditVm GetAppearanceEditVm(int? id)
        {
            var entity = this.appearances.GetById((int)id);
            if (entity == null)
            {
                return null;
            }

            var model = Mapper.Map<Appearance, AppearanceEditVm>(entity);

            return model;
        }
    }
}