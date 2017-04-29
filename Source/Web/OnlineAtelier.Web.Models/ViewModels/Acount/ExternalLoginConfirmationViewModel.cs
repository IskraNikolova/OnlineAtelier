namespace OnlineAtelier.Web.Models.ViewModels.Acount
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Моля, попълнете валиден мейл адрес.")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля, попълнете Вашето име.")]
        [StringLength(20, ErrorMessage = "{0}то трябва да е поне {2} символа.", MinimumLength = 2)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Моля, попълнете Вашата фамилия.")]
        [StringLength(20, ErrorMessage = "{0}та трябва да е поне {2} символа.", MinimumLength = 2)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}
