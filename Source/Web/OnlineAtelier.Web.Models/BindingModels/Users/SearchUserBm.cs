namespace OnlineAtelier.Web.Models.BindingModels.Users
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class SearchUserBm : IMapFrom<ApplicationUser>
    {
        public string FirstName { get; set; }
    }
}
