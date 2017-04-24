namespace OnlineAtelier.Web.Models.ViewModels.Users
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DisplayAllUsersVm : IMapFrom<ApplicationUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
