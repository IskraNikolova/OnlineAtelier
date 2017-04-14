namespace OnlineAtelier.Services.Models
{
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Users;
    using Web.Models.ViewModels.Users;

    public class UserServices : IUserService
    {
        private readonly IRepository<ApplicationUser> users;

        public UserServices(IRepository<ApplicationUser> users)
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

        public EditUserVm GetEditVm(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);
            var editVm = Mapper.Map<ApplicationUser, EditUserVm>(user);

            return editVm;
        }

        public void Edit(EditUserBm bind, byte[] imageBytes)
        {
            var entity = this.users.All().FirstOrDefault(u => u.Id == bind.Id);

            if (imageBytes != null)
            {
                entity.UserPhoto = imageBytes;
            }


            entity.PhoneNumber = bind.PhoneNumber;
            entity.Email = bind.Email;
            entity.UserName = bind.Email;

            this.users.Update(entity);
            this.users.SaveChanges();
        }

        public string GetSearchUserId(SearchUserBm bm)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.FirstName == bm.FirstName);
            
            return user.Id;
        }
    }
}