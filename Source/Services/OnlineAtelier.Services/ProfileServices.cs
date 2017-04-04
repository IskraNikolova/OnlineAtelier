namespace OnlineAtelier.Services
{
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models;
    using Web.Models.ViewModels.Acount;

    public class ProfileServices : IProfileService
    {
        private readonly IRepository<ApplicationUser> users;

        public ProfileServices(IRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public ApplicationUser GetUser(string id)
        {                  
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == id);

            return user;
        }

        public ProfilePageViewModel GetProfilePageViewModel(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            var profileViewModel = Mapper.Map<ApplicationUser, ProfilePageViewModel>(user);

            return profileViewModel;
        }
    }
}