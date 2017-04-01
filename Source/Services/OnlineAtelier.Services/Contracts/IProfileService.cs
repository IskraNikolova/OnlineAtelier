namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Models;
    using Web.Models.AcountViewModels;
    using Web.Models.ProfilePageModels;

    public interface IProfileService : IService
    {
        ApplicationUser GetUser(string id);

        ProfilePageViewModel GetProfilePageViewModel(string userId);
        IEnumerable<ProfileOrdersViewModel> GetOrders(string id);
    }
}