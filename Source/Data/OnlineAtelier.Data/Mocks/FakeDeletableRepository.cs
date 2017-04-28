namespace OnlineAtelier.Data.Mocks
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;
    using Common.Repository;
    using Interfaces;
    using Models.Models;

    public class FakeDeletableRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity, IIdEntity
    {
        protected Dictionary<object, object> Set2;
        //public HashSet<T> Set;
        protected IQueryable<T> Query;

        public FakeDeletableRepository()
            : base(new FakeOnlineAtelierDbContext())
        {
            this.Set2 = new Dictionary<object, object>();
            this.Set = new HashSet<T>();
            this.Query = this.Set.AsQueryable();
        }

        public HashSet<T> Set { get; set; }

        public override void Add(T entity)
        {
            this.Set.Add(entity);
        }

        public override T GetById(int id)
        {
            var en = this.Set.FirstOrDefault(e => e.Id ==  id);
            return en;
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

        private void RemoveByValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue someValue)
        {
            List<TKey> itemsToRemove = new List<TKey>();

            foreach (var pair in dictionary)
            {
                if (pair.Value.Equals(someValue))
                    itemsToRemove.Add(pair.Key);
            }

            foreach (TKey item in itemsToRemove)
            {
                dictionary.Remove(item);
            }
        }
    }
}