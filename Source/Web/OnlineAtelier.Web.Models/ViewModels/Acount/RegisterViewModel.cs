namespace OnlineAtelier.Web.Models.ViewModels.Acount
{
    using System.ComponentModel.DataAnnotations;
    using Manage;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Моля, попълнете валиден мейл адрес.")]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }


        [Display(Name = "Снимка на профила")]
        [DataType(DataType.Upload)]
        public byte[] UserPhoto { get; set; }

        [Required(ErrorMessage = "Моля, попълнете Вашето име.")]
        [StringLength(20, ErrorMessage = "{0}то трябва да е поне {2} символа.", MinimumLength = 2)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Моля, попълнете Вашата фамилия.")]
        [StringLength(20, ErrorMessage = "{0}та трябва да е поне {2} символа.", MinimumLength = 2)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        
        public AddPhoneNumberViewModel PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето за парола е задължително.")]
        [StringLength(100, ErrorMessage = "{0}та трябва да съдържа най-малко {2} символа.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("Password", ErrorMessage = "Няма съвпадение на символите.")]
        public string ConfirmPassword { get; set; }
    }
}
