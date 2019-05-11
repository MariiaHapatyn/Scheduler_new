using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Scheduler.DataAccess.Implementation
{
    public class TeacherRepository:IRepository<Teacher>
    {
        private readonly SchedulerContext _context;

        public TeacherRepository(SchedulerContext context)
        {
            _context = context;
        }

        public IQueryable<Teacher> GetAll()
        {
            return _context.Teacher;
        }

        public IQueryable<Teacher> Get(Expression<Func<Teacher, bool>> predicate)
        {
            return _context.Teacher.Where(predicate);
        }

        public virtual IQueryable<Teacher> GetAll(IQueryable<int> id)
        {
            HashSet<int> teacherId = new HashSet<int>(id);

            return _context.Teacher
                .Where(t => teacherId.Contains(t.TeacherId));
        }

        public void Create(Teacher entity)
        {
            _context.Teacher.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = _context.Teacher.Find(id);
            if (teacher != null)
            {
                _context.Teacher.Remove(teacher);
                _context.SaveChanges();
            }
        }

        public void Update(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException("Teacher entity not found");
            }
            _context.Teacher.Update(teacher);
            _context.SaveChanges();
        }

        public virtual bool Any(Func<Teacher, bool> predicate)
        {
            return _context.Teacher.Any(predicate);
        }

        public Teacher FindAsNoTracking(int id)
        {
            return _context.Teacher
                 .Where(t => t.TeacherId == id)
                 .AsNoTracking()
                 .SingleOrDefault();
        }

        public Teacher Find(Func<Teacher, bool> predicate)
        {
            return _context.Teacher
                .Where(predicate)
                .SingleOrDefault();
        }

        public Teacher Find(int id)
        {
            return _context.Teacher
                .Where(t => t.TeacherId == id)
                .SingleOrDefault();
        }
    }
}
