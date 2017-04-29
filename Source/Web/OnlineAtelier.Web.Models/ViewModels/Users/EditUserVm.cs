namespace OnlineAtelier.Web.Models.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class EditUserVm : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}