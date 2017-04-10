namespace OnlineAtelier.Services.Contracts
{
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Users;
    using Web.Models.ViewModels.Users;

    public interface IUserService : IService
    {
        ApplicationUser GetUser(string id);

        ProfileViewModel GetProfileViewModel(string userId);

        EditUserVm GetEditVm(string userId);

        void Edit(EditUserBm bind, byte[] imageBytes);
    }
}