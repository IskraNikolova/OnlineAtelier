namespace OnlineAtelier.Services.Contracts
{
    using OnlineAtelier.Models.Models;
    using Web.Models.ViewModels.Users;

    public interface IUserService : IService
    {
        ApplicationUser GetUser(string id);

        ProfileViewModel GetProfileViewModel(string userId);
    }
}