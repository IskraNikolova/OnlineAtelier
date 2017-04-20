namespace OnlineAtelier.Services.Contracts
{
    public interface IDeletable : IService
    {
        void Delete(int id);
    }
}