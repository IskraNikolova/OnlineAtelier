namespace OnlineAtelier.Web.Models.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Стара парола")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0}та трябва да е поне {2} символа дълга.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори нова парола")]
        [Compare("NewPassword", ErrorMessage = "Няма съвпадение на паролите")]
        public string ConfirmPassword { get; set; }
    }
}