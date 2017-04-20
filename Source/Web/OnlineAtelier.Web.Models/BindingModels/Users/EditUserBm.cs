namespace OnlineAtelier.Web.Models.BindingModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class EditUserBm : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [Display(Name = "Избери файл")]
        public byte[] UserPhoto { get; set; }
    }
}
