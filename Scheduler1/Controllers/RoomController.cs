using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Scheduler.DataAccess.Implementation;
using Scheduler.DataAccess.Models;
using Scheduler.DTO.Models;
using Scheduler.Services.Interfaces;

namespace Scheduler.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: Room/Details/5
        public IActionResult Details(int id)
        {
            var roomDto = _roomService.Find(id);
            if (roomDto == null)
            {
                return NotFound();
            }

            return View(roomDto);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoomId,RoomNumberd,Adress,Capacity,Type")] RoomDto roomDto)
        {
            if (ModelState.IsValid)
            {
                _roomService.Create(roomDto);
                return RedirectToAction(nameof(Index));
            }
            return View(roomDto);
        }

        // GET: Room/Edit/5
        public IActionResult Edit(int id)
        {
            var roomDto = _roomService.Find(id);
            if (roomDto == null)
            {
                return NotFound();
            }
            return View(roomDto);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RoomId,RoomNumberd,Adress,Capacity,Type")] RoomDto roomDto)
        {
            if (id != roomDto.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _roomService.Update(roomDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_roomService.Any(roomDto.RoomId))
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
            return View(roomDto);
        }

        // GET: Room/Delete/5
        public IActionResult Delete(int id)
        {
            var roomDto = _roomService.Find(id);
            if (roomDto == null)
            {
                return NotFound();
            }

            return View(roomDto);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_roomService.Any(id))
            {
                return NotFound();
            }

            _roomService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
