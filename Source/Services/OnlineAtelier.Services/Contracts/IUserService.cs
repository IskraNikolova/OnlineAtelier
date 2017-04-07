namespace OnlineAtelier.Services.Contracts
{
    using OnlineAtelier.Models.Models;
    using Web.Models.ViewModels.Acount;

    public interface IUserService : IService
    {
        ApplicationUser GetUser(string id);

        ProfilePageViewModel GetProfilePageViewModel(string userId);
    }
}