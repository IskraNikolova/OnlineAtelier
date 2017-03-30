﻿namespace OnlineAtelier.Services
{
    using System.IO;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models;
    using Web.Models.AcountViewModels;

    public class ProfileServices : IProfileService
    {
        private IRepository<ApplicationUser> users;

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
                Email = user.Email,
                UserPhoto = user.UserPhoto,
                Orders = user.Orders
            };

            return model;
        }
    }
}
