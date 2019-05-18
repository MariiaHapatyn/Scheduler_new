﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Implementation;
using Scheduler.DataAccess.Models;
using Scheduler.DTO.Models;
using Scheduler.Services.Interfaces;

namespace Scheduler.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: Schedule
        public IActionResult Index()
        {
            var dto = _scheduleService.Get();
            return View(dto);            
        }

        // GET: Schedule/Details/5
        public IActionResult Details(int id)
        {
            var scheduleDto = _scheduleService.Find(id);
            if (scheduleDto == null)
            {
                return NotFound();
            }

            return View(scheduleDto);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ScheduleId,RoomId,GroupId,TeacherId,Day,Lesson")] SchedulerDto scheduleDto)
        {
            if (ModelState.IsValid)
            {
                _scheduleService.Create(scheduleDto);
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleDto);
        }

        // GET: Schedule/Edit/5
        public IActionResult Edit(int id)
        {
            
            var schedule =  _scheduleService.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ScheduleId,RoomId,GroupId,TeacherId,Day,Lesson")] SchedulerDto scheduleDto)
        {
            if (id != scheduleDto.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _scheduleService.Update(scheduleDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_scheduleService.Any(scheduleDto.ScheduleId))
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
            return View(scheduleDto);
        }

        // GET: Schedule/Delete/5
        public IActionResult Delete(int id)
        {
            var scheduleDto =  _scheduleService.Find(id);
            if (scheduleDto == null)
            {
                return NotFound();
            }

            return View(scheduleDto);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_scheduleService.Any(id))
            {
                return NotFound();
            }

            _scheduleService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
