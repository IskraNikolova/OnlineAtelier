namespace OnlineAtelier.Data.Mocks
{
    using System.Linq;
    using Common.Models;
    using Models.Models;

    public class FakeDeletableRepository<T> : FakeDeletableApplicationUserRepository<T>
        where T : class, IDeletableEntity, IIdEntity
    {
        protected IQueryable<T> Query;

        public FakeDeletableRepository()
            : base(new FakeOnlineAtelierDbContext())
        {
        }

        public override T GetById(int id)
        {
            var en = this.Set.FirstOrDefault(e => e.Id ==  id);
            return en;
        }
    }
}