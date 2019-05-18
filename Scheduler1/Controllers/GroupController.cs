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
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dto = _groupService.Get();
            return View(dto);
        }

        public IActionResult Details(int id)
        {
            var groupDto = _groupService.Find(id);
            if (groupDto == null)
            {
                return NotFound();
            }

            return View(groupDto);
        }

        public IActionResult Delete(int id)
        {
            var groupDto = _groupService.Find(id);
            if (groupDto == null)
            {
                return NotFound();
            }

            return View(groupDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_groupService.Any(id))
            {
                return NotFound();
            }

            _groupService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,NumberOfStudents")] GroupDto groupDto)
        {
            if (ModelState.IsValid)
            {
                _groupService.Create(groupDto);

                return RedirectToAction(nameof(Index));
            }

            return View(groupDto);
        }

        public IActionResult Edit(int id)
        {

            var groupDto = _groupService.Find(id);
            if (groupDto == null)
            {
                return NotFound();
            }

            return View(groupDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GroupId,Name,NumberOfStudents")] GroupDto groupDto)
        {
            if (id != groupDto.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _groupService.Update(groupDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_groupService.Any(groupDto.GroupId))
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
            return View(groupDto);
        }
    }
}
