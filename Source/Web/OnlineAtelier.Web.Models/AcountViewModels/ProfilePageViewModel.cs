namespace OnlineAtelier.Web.Models.AcountViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using OnlineAtelier.Models.Models;

    public class ProfilePageViewModel 
    {
        public string Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string FullName { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}
