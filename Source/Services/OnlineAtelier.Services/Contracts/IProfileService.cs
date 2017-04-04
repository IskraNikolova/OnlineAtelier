namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Models;
    using Web.Models.ViewModels.Acount;

    public interface IProfileService : IService
    {
        ApplicationUser GetUser(string id);

        ProfilePageViewModel GetProfilePageViewModel(string userId);
    }
}