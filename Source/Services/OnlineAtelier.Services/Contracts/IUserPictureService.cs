namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.ViewModels.UsersPicture;

    public interface IUserPictureService
    {
        void AddPicture(byte[] content, int id);

        IEnumerable<UserPictureViewModel> AllUserPicture(int orderId);

        byte[] TakePhoto(int userPictureId, int orderId);
    }
}
