//namespace OnlineAtelier.Data.Mocks
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Collections.ObjectModel;
//    using System.Data.Entity;
//    using System.Linq;

//    public class FakeDbSet<T> : IDbSet<T>, IQueryable, IEnumerable<T> where T : class
//    {
//        protected HashSet<T> Set;
//        protected IQueryable Query;

//        public FakeDbSet()
//        {
//            this.Set = new HashSet<T>();
//            this.Query = this.Set.AsQueryable();//todo remove all this
//        }

//        public T Add(T entity)
//        {
//            this.Set.Add(entity);
//            return entity;
//        }

//        public T Remove(T entity)
//        {
//            this.Set.Remove(entity);
//            return entity;
//        }

//        System.Linq.Expressions.Expression IQueryable.Expression
//        {
//            get { return this.Query.Expression; }
//        }

//        IQueryProvider IQueryable.Provider
//        {
//            get { return this.Query.Provider; }
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return this.Set.GetEnumerator();
//        }

//        IEnumerator<T> IEnumerable<T>.GetEnumerator()
//        {
//            return this.Set.GetEnumerator();
//        }

//        public Type ElementType { get; }

//        public T Find(params object[] keyValues)
//        {
//            throw new NotImplementedException();
//        }

//        public T Attach(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public T Create()
//        {
//            throw new NotImplementedException();
//        }

//        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
//        {
//            throw new NotImplementedException();
//        }

//        public ObservableCollection<T> Local { get; }
//    }
//}