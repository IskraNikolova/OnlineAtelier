namespace OnlineAtelier.Data.Mocks
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;
    using Common.Repository;

    public class FakeDeletableApplicationUserRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        protected IQueryable<T> Query;

        public FakeDeletableApplicationUserRepository(FakeOnlineAtelierDbContext fakeOnlineAtelierDbContext)
            : base(new FakeOnlineAtelierDbContext())
        {
            this.Set = new HashSet<T>();
            this.Query = this.Set.AsQueryable();
        }

        public FakeDeletableApplicationUserRepository() 
            : this(new FakeOnlineAtelierDbContext())
        {
        }

        public HashSet<T> Set { get; set; }

        public override void Add(T entity)
        {
            this.Set.Add(entity);
        }

        public override T GetById(int id)
        {
            return this.Set.FirstOrDefault();
        }

        public override IQueryable<T> All()
        {
            return this.Query;
        }

        public override void Delete(T entity)
        {
            this.Set.Remove(entity);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.Query;
        }

        public void ActualDelete(T entity)
        {
            this.Set.Remove(entity);
        }

        public override void Update(T entity)
        {
        }
    }
}
