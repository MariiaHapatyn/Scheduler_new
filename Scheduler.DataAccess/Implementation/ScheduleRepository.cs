using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Scheduler.DataAccess.Implementation
{
    public class ScheduleRepository: IRepository<Schedule>
    {
        private readonly SchedulerContext _context;

        public ScheduleRepository(SchedulerContext context)
        {
            _context = context;
        }

        public IQueryable<Schedule> GetAll()
        {
            return _context.Schedule
                .Include(s => s.Group)
                .Include(s => s.Room)
                .Include(s => s.Teacher);
        }

        public IQueryable<Schedule> Get(Expression<Func<Schedule, bool>> predicate)
        {
            return _context.Schedule.Where(predicate);
        }

        public virtual IQueryable<Schedule> GetAll(IQueryable<int> id)
        {
            HashSet<int> scheduleId = new HashSet<int>(id);

            return _context.Schedule
                .Where((Expression<Func<Schedule, bool>>)(t => scheduleId.Contains((int)t.ScheduleId)));
        }

        public void Create(Schedule entity)
        {
            _context.Schedule.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Schedule schedule = _context.Schedule.Find(id);
            if (schedule != null)
            {
                _context.Schedule.Remove(schedule);
                _context.SaveChanges();
            }
        }

        public void Update(Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException("Schedule entity not found");
            }
            _context.Schedule.Update(schedule);
            _context.SaveChanges();
        }

        public virtual bool Any(Func<Schedule, bool> predicate)
        {
            return _context.Schedule.Any(predicate);
        }

        public Schedule FindAsNoTracking(int id)
        {
            return _context.Schedule
                 .Where(t => t.ScheduleId == id)
                 .AsNoTracking()
                 .SingleOrDefault();
        }

        public Schedule Find(Func<Schedule, bool> predicate)
        {
            return _context.Schedule
                .Where(predicate)
                .SingleOrDefault();
        }

        public Schedule Find(int id)
        {
            return _context.Schedule
                .Include(s => s.Group)
                .Include(s => s.Room)
                .Include(s => s.Teacher)
                .Where(t => t.ScheduleId == id)
                .SingleOrDefault();
        }
    }
}
