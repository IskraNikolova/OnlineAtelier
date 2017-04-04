namespace OnlineAtelier.Web.Models.ViewModels.Acount
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class ProfilePageViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}