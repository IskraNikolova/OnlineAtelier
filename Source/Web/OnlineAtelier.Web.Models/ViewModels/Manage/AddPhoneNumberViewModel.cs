namespace OnlineAtelier.Web.Models.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class AddPhoneNumberViewModel
    {
        [Required(ErrorMessage = "Моля, попълнете телефон за връзка.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string Number { get; set; }
    }
}