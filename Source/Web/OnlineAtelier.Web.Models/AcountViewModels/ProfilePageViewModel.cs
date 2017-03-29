namespace OnlineAtelier.Web.Models.AcountViewModels
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;

    public class ProfilePageViewModel 
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}
