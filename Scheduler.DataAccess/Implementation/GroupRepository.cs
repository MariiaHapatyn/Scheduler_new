using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Scheduler.DataAccess.Implementation
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly SchedulerContext _context;

        public GroupRepository(SchedulerContext context)
        {
            _context = context;
        }

        public IQueryable<Group> GetAll()
        {
            return _context.Group;
        }

        public IQueryable<Group> Get(Expression<Func<Group, bool>> predicate)
        {
            return _context.Group.Where(predicate);
        }

        public virtual IQueryable<Group> GetAll(IQueryable<int> id)
        {
            HashSet<int> groupId = new HashSet<int>(id);

            return _context.Group
                .Where(p => groupId.Contains(p.GroupId));
        }

        public void Create(Group entity)
        {
            _context.Group.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Group group = _context.Group.Find(id);
            if(group != null)
            {
                _context.Group.Remove(group);
                _context.SaveChanges();
            }
        }
        
        public void Update(Group group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("Group entity not found");
            }
            _context.Group.Update(group);
            _context.SaveChanges();
        }

        public virtual bool Any(Func<Group, bool> predicate)
        {
            return _context.Group.Any(predicate);
        }

        public Group FindAsNoTracking(int id)
        {
           return _context.Group
                .Where(g =>g.GroupId == id)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public Group Find(Func<Group, bool> predicate)
        {
            return _context.Group
                .Where(predicate)
                .SingleOrDefault();
        }

        public Group Find(int id)
        {
            return _context.Group
                .Where(g=>g.GroupId == id)
                .SingleOrDefault();
        }
    }
}
