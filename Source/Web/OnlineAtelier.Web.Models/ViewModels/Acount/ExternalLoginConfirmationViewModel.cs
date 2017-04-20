namespace OnlineAtelier.Web.Models.ViewModels.Acount
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Моля, попълнете валиден мейл адрес.")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}
