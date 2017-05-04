namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Users;
    using Web.Models.ViewModels.Users;

    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> users;

        public UserService(IRepository<ApplicationUser> users)
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

        public ProfileViewModel GetProfileViewModel(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            var profileViewModel = Mapper.Map<ApplicationUser, ProfileViewModel>(user);

            return profileViewModel;
        }

        public EditUserVm GetEditVm(string id)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == id);

            var editVm = Mapper.Map<ApplicationUser, EditUserVm>(user);

            return editVm;
        }

        public void Edit(EditUserBm bind, byte[] imageBytes)
        {
            var entity = this.users
                .All()
                .FirstOrDefault(u => u.Id == bind.Id);

            if (imageBytes != null)
            {
                entity.UserPhoto = imageBytes;
            }

            this.users.Update(entity);
            this.users.SaveChanges();
        }

        public string GetSearchUserId(SearchUserBm bm)
        {           
            var user = this.users
                .All()
                .FirstOrDefault(u => (u.FirstName + " " + u.LastName).ToLower() == bm.FirstName.ToLower().Trim());

            return user?.Id;
        }

        public IEnumerable<DisplayAllUsersVm> GetSearchUsers(string query)
        {
            var models =  this.users
                .All()
                .Where(m => (m.FirstName + " " + m.LastName).Contains(query))
                .Project().To<DisplayAllUsersVm>()
                .ToList();

            return models;
        }

        public IEnumerable<DisplayAllUsersVm> GetAllUsers()
        {
            var usersVm = this.users.All().Project().To<DisplayAllUsersVm>();
            return usersVm;
        }

        public InCartViewModel GetOrderCount(string id)
        {
            var user = this.users.All().FirstOrDefault(u => u.Id == id);
            var model = new InCartViewModel()
            {
                OrderCount = user.Orders.Where(o => o.IsАccepted).ToList().Count
            };

            return model;
        }
    }
}