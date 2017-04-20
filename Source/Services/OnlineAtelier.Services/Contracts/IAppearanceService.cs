namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Appearance;
    using Web.Models.ViewModels.AdminArea.Appearance;

    public interface IAppearanceService : IDeletable
    {
        IEnumerable<string> GetAllNameOfAppearances();

        Appearance GetAppearence(string name);

        void AddAppearance(AppearanceCreateBm bind);

        ICollection<AppearanceAllVm> All();

        AppearanceAllVm GetAppearanceAllVm(int? id);

        AppearanceEditVm GetAppearanceEditVm(int? id);

        void Edit(AppearanceEditBm bind);

        AppearanceCreateVm GetAppearanceCreateVm(AppearanceCreateBm bm);
    }
}