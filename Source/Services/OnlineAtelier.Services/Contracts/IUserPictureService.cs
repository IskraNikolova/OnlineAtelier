namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.ViewModels.UsersPicture;

    public interface IUserPictureService
    {
        void AddPictureToOrder(byte[] content, int id);

        IEnumerable<UserPictureViewModel> AllUserPictures(int orderId);

        byte[] TakePhotoFromOrder(int userPictureId, int orderId);

        byte[] TakePhoto(int userPictureId);
    }
}