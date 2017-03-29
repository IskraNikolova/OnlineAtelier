namespace OnlineAtelier.Web.Models.AcountViewModels
{
    using System.Collections.Generic;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class ProfilePageViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public byte[] UserPhoto { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
