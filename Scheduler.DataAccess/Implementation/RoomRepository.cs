using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Scheduler.DataAccess.Implementation
{
    public class RoomRepository : IRepository<Room>
    {
        private readonly SchedulerContext _context;

        public RoomRepository(SchedulerContext context)
        {
            _context = context;
        }

        public IQueryable<Room> GetAll()
        {
            return _context.Room;
        }

        public IQueryable<Room> Get(Expression<Func<Room, bool>> predicate)
        {
            return _context.Room.Where(predicate);
        }

        public virtual IQueryable<Room> GetAll(IQueryable<int> id)
        {
            HashSet<int> roomId = new HashSet<int>(id);

            return _context.Room
                .Where(p => roomId.Contains(p.RoomId));
        }

        public void Create(Room entity)
        {
            _context.Room.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = _context.Room.Find(id);
            if (room != null)
            {
                _context.Room.Remove(room);
                _context.SaveChanges();
            }
        }

        public void Update(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException("Room entity not found");
            }
            _context.Room.Update(room);
            _context.SaveChanges();
        }

        public virtual bool Any(Func<Room, bool> predicate)
        {
            return _context.Room.Any(predicate);
        }

        public Room FindAsNoTracking(int id)
        {
            return _context.Room
                 .Where(r => r.RoomId == id)
                 .AsNoTracking()
                 .SingleOrDefault();
        }

        public Room Find(Func<Room, bool> predicate)
        {
            return _context.Room
                .Where(predicate)
                .SingleOrDefault();
        }

        public Room Find(int id)
        {
            return _context.Room
                .Where(r => r.RoomId == id)
                .SingleOrDefault();
        }
    }
}
