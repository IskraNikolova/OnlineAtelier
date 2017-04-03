namespace OnlineAtelier.Services
{
    using Contracts;
    using Data.Common.Repository;
    using Models;
    using Models.Models;

    public class UserPictureService : IUserPictureService
    {
        private readonly IRepository<UserPicture> userPictures;

        public UserPictureService(IRepository<UserPicture> userPictures)
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
    }
}
