namespace OnlineAtelier.Web.Models.ViewModels.Acount
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Моля, попълнете валиден мейл адрес.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето за парола е задължително.")]
        [StringLength(100, ErrorMessage = "{0}та трябва да съдържа най-малко {2} символа.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}
