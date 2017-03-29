namespace OnlineAtelier.Services
{
    using System.IO;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models;
    using Web.Models.AcountViewModels;

    public class ProfileServices : IProfileService
    {
        private IRepository<ApplicationUser> users;

        public ProfileServices(IRepository<ApplicationUser> users)
        {
            this.users = users;
            
        }

        public ApplicationUser GetUser(string id)
        {                  
            var user = this.users.All().FirstOrDefault(u => u.Id == id);
            return user;
        }

        public ProfilePageViewModel GetProfilePageViewModel(string userId)
        {
            var user =
            this.users.All()
                .Project()
                .To<ProfilePageViewModel>()
                .FirstOrDefault(u => u.Id == userId);

            return user;
        }

        public byte[] GetImageData(string fileName)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(fileName);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);

            return imageData;
        }

    }
}
