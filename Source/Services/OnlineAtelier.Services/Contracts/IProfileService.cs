namespace OnlineAtelier.Services.Contracts
{
    using Models.Models;
    using Web.Models.AcountViewModels;

    public interface IProfileService : IService
    {
        byte[] GetImageData(string fileName);

        ApplicationUser GetUser(string id);

        ProfilePageViewModel GetProfilePageViewModel(string userId);
    }
}