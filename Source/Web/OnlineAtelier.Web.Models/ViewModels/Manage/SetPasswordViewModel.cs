namespace OnlineAtelier.Web.Models.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "Полето за парола е задължително.")]
        [StringLength(100, ErrorMessage = "{0}та трябва да съдържа най-малко {2} символа.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори нова парола")]
        [Compare("NewPassword", ErrorMessage = "Няма съвпадение на символите.")]
        public string ConfirmPassword { get; set; }
    }
}