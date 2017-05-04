namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Users;
    using Web.Models.ViewModels.Users;

    public interface IUserService : IService
    {
        ApplicationUser GetUser(string id);

        ProfileViewModel GetProfileViewModel(string userId);

        EditUserVm GetEditVm(string id);

        void Edit(EditUserBm bind, byte[] imageBytes);

        string GetSearchUserId(SearchUserBm bm);

        IEnumerable<DisplayAllUsersVm> GetSearchUsers(string query);

        IEnumerable<DisplayAllUsersVm> GetAllUsers();

        InCartViewModel GetOrderCount(string id);
    }
}