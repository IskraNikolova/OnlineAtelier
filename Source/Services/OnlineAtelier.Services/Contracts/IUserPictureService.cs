namespace OnlineAtelier.Services.Contracts
{
    public interface IUserPictureService
    {
        void AddPicture(byte[] content, int id);
    }
}
