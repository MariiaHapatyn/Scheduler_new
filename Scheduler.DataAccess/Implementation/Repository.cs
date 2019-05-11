﻿//using Microsoft.EntityFrameworkCore;
//using Scheduler.DataAccess.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace Scheduler.DataAccess.Implementation
//{
//    public class Repository<TEntity> : IRepository<TEntity>
//       where TEntity : class
//    {
//        protected readonly DbContext Context;

//        public Repository(DbContext context)
//        {
//            Context = context;
//        }

//        public IQueryable<TEntity> GetAll()
//        {
//            return Context.Set<TEntity>();
//        }

//        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
//        {
//            return Context.Set<TEntity>().Where(predicate);
//        }

//        public void Create(TEntity entity)
//        {
//            Context.Set<TEntity>().Add(entity);
//        }

//        public void Add(IEnumerable<TEntity> entities)
//        {
//            Context.Set<TEntity>().AddRange(entities);
//        }

//        public void Delete(TEntity entity)
//        {
//            Context.Set<TEntity>().Remove(entity);
//        }

//        public void Delete(IEnumerable<TEntity> entities)
//        {
//            Context.Set<TEntity>().RemoveRange(entities);
//        }

//        public void Update(TEntity entity)
//        {
//            Context.Set<TEntity>().Update(entity);
//        }
//    }
//}
