namespace OnlineAtelier.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models;
    using Web.Models.AcountViewModels;
    using Web.Models.ProfilePageModels;

    public class ProfileServices : IProfileService
    {
        private readonly IRepository<ApplicationUser> users;

        public ProfileServices(IRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public ApplicationUser GetUser(string id)
        {                  
            var user = this.users.All().FirstOrDefault(u => u.Id == id);
            return user;
        }

        public ProfilePageViewModel GetProfilePageViewModel(string userId)
        {
            var user =
            this.users.All()
                .FirstOrDefault(u => u.Id == userId);

            var model = new ProfilePageViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserPhoto = user.UserPhoto,
                FullName = user.FirstName + " " + user.LastName,
                Orders = user.Orders
            };

            return model;
        }
    }
}