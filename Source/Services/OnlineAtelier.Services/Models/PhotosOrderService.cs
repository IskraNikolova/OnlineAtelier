namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.ViewModels.UsersPicture;

    public class PhotosOrderService : IUserPictureService
    {
        private readonly IRepository<UserPicture> userPictures;

        public PhotosOrderService(IRepository<UserPicture> userPictures)
        {
            this.userPictures = userPictures;
        }

        public void AddPictureToOrder(byte[] content, int id)
        {
            var picture = new UserPicture()
            {
                UserPictures = content,
                OrderId = id
            };

            this.userPictures.Add(picture);
            this.userPictures.SaveChanges();
        }

        public IEnumerable<UserPictureViewModel> AllUserPictures(int orderId)
        {
            var models = this.userPictures.All()
                .Where(p => p.OrderId == orderId)
                .Project()
                .To<UserPictureViewModel>();

            return models;
        }

        public byte[] TakePhotoFromOrder(int userPictureId, int orderId)
        {
            var pictures = this.AllUserPictures(orderId);
            UserPictureViewModel photo = pictures.FirstOrDefault(p => p.Id == userPictureId);

            return photo.UserPictures;
        }

        public byte[] TakePhoto(int userPictureId)
        {
            var picture = this.userPictures.All().ToList().FirstOrDefault(p => p.Id == userPictureId);
            UserPictureViewModel photo = Mapper.Map<UserPicture, UserPictureViewModel>(picture);

            return photo.UserPictures;
        }
    }
}