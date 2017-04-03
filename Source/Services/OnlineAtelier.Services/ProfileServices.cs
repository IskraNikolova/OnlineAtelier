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
        private readonly IRepository<Order> orders;

        public ProfileServices(IRepository<ApplicationUser> users, IRepository<Order> orders)
        {
            this.users = users;
            this.orders = orders;

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

        public IEnumerable<ProfileOrdersViewModel> GetOrders(string id)
        {
            var currentOrders = this.orders.All()
                .Where(o => o.ApplicationUser.Id == id)
                .ToList();

            var ordersModel = new List<ProfileOrdersViewModel>();
            foreach (var item in currentOrders)
            {
                var order = new ProfileOrdersViewModel()
                {
                    Id = item.Id,
                    Details = item.Details,
                    Category = item.Category,
                    AppearanceName = item.Appearance.Name,
                    AppearancePrice = item.Appearance.Price,
                    CreatedOn = item.CreatedOn,
                    GaleryPictures = item.GaleryPictures,
                    UserPictures = item.UserPictures
                };

                ordersModel.Add(order);
            }

            return ordersModel;
        }
    }
}