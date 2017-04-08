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

    public class PhotosOrderService : IPhotosOrderService
    {
        private readonly IRepository<PhotosOrder> userPictures;

        public PhotosOrderService(IRepository<PhotosOrder> userPictures)
        {
            this.userPictures = userPictures;
        }

        public void AddPictureToOrder(byte[] content, int id)
        {
            var picture = new PhotosOrder()
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

            UserPictureViewModel photo = pictures
                .FirstOrDefault(p => p.Id == userPictureId);

            return photo.UserPictures;
        }

        public byte[] TakePhoto(int userPictureId)
        {
            var picture = this.userPictures
                .All()
                .FirstOrDefault(p => p.Id == userPictureId);

            UserPictureViewModel photo = Mapper.Map<PhotosOrder, UserPictureViewModel>(picture);

            return photo.UserPictures;
        }

        public PhotosOrder GetEntity(int? id)
        {
            return this.userPictures.GetById((int)id);
        }

        public void Delete(int id)
        {
            var entity = this.userPictures.GetById(id);
            this.userPictures.Delete(entity);
            this.userPictures.SaveChanges();
        }
    }
}