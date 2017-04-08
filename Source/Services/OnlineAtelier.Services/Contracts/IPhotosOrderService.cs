namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;
    using Web.Models.ViewModels.UsersPicture;

    public interface IPhotosOrderService : IService
    {
        void AddPictureToOrder(byte[] content, int id);

        IEnumerable<UserPictureViewModel> AllUserPictures(int orderId);

        byte[] TakePhotoFromOrder(int userPictureId, int orderId);

        byte[] TakePhoto(int userPictureId);

        PhotosOrder GetEntity(int? id);

        void Delete(int id);
    }
}