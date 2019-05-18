using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Implementation;
using Scheduler.DataAccess.Models;

namespace Scheduler.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly SchedulerContext _context;

        public ScheduleController(SchedulerContext context)
        {
            _context = context;
        }

        // GET: Schedule
        public async Task<IActionResult> Index()
        {
            var schedulerContext = _context.Schedule.Include(s => s.Group).Include(s => s.Room).Include(s => s.Teacher);
            return View(await schedulerContext.ToListAsync());
        }

        // GET: Schedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Group)
                .Include(s => s.Room)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedule/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupId");
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId");
            return View();
        }

        // POST: Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,RoomId,GroupId,TeacherId,Day,Lesson")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupId", schedule.GroupId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", schedule.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", schedule.TeacherId);
            return View(schedule);
        }

        // GET: Schedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupId", schedule.GroupId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", schedule.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", schedule.TeacherId);
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId,RoomId,GroupId,TeacherId,Day,Lesson")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "GroupId", "GroupId", schedule.GroupId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", schedule.RoomId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", schedule.TeacherId);
            return View(schedule);
        }

        // GET: Schedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Group)
                .Include(s => s.Room)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.ScheduleId == id);
        }
    }
}
