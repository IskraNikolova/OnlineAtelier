﻿namespace OnlineAtelier.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models;
    using Web.Models.ViewModels.UsersPicture;

    public class UserOrderPicturesService : IUserPictureService
    {
        private readonly IRepository<UserPicture> userPictures;

        public UserOrderPicturesService(IRepository<UserPicture> userPictures)
        {
            this.userPictures = userPictures;
        }

        public void AddPicture(byte[] content, int id)
        {
            var picture = new UserPicture()
            {
                UserPictures = content,
                OrderId = id
            };

            this.userPictures.Add(picture);
            this.userPictures.SaveChanges();
        }

        public IEnumerable<UserPictureViewModel> AllUserPicture(int orderId)
        {
            var models = this.userPictures.All()
                .Where(p => p.OrderId == orderId)
                .Project()
                .To<UserPictureViewModel>();

            return models;
        }

        public byte[] TakePhotoFromOrder(int userPictureId, int orderId)
        {
            var pictures = this.AllUserPicture(orderId);
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