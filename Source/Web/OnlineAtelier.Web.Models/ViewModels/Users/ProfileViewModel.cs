namespace OnlineAtelier.Web.Models.ViewModels.Users
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class ProfileViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}