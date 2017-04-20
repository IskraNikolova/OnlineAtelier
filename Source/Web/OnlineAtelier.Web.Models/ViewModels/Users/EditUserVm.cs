namespace OnlineAtelier.Web.Models.ViewModels.Users
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class EditUserVm : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}
