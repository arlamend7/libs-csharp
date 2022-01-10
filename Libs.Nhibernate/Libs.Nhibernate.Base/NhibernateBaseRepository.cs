using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Libs.Nhibernate.Base
{
    public class NhibernateBaseRepository<T>
    {
        public ISession Session;

        protected NhibernateBaseRepository(ISession session)
        {
            Session = session;
        }

        public T Save(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public T Edit(T entity)
        {
            Session.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public void Delete(IEnumerable<T> entity)
        {
            foreach (T entidade in entity)
            {
                Session.Delete(entidade);
            }
        }

        public void Insert(T entity)
        {
            Session.Save(entity);
        }

        public void Insert(IEnumerable<T> entity)
        {
            foreach (T entidade in entity)
            {
                Session.Save(entidade);
            }
        }

        public IQueryable<T> Query()
        {
            return Session.Query<T>();
        }

        public T Get(int id)
        {
            return Session.Get<T>(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return Query().Where(expression).SingleOrDefault();
        }

        public void Refresh(T entity)
        {
            Session.Refresh(entity);
        }
    }
}
