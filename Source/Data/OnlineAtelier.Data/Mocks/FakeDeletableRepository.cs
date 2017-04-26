namespace OnlineAtelier.Data.Mocks
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Common.Models;
    using Common.Repository;

    public class FakeDeletableRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity, new()
    {
        protected HashSet<T> Set;
        protected IQueryable<T> Query;

        public FakeDeletableRepository() 
            : base(new FakeOnlineAtelierDbContext())
        {
            this.Set = new HashSet<T>();
            this.Query = this.Set.AsQueryable();
        }

        public override void Add(T entity)
        {
            this.Set.Add(entity);
        }

        public override T GetById(int id)
        {
            return this.Set.FirstOrDefault()?? new T();
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
    }
}
