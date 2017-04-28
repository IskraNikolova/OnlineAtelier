namespace OnlineAtelier.Web.Models.BindingModels.Users
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class EditUserBm : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}