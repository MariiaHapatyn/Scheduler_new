using Microsoft.AspNetCore.Mvc;
using Scheduler.Services.Interfaces;
using Scheduler.DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Scheduler.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dto = _teacherService.Get();
            return View(dto);
        }

        // GET: Teacher/Details/5
        public IActionResult Details(int id)
        {
            var teacherDto = _teacherService.Find(id);
            if (teacherDto == null)
            {
                return NotFound();
            }

            return View(teacherDto);
        }

        // GET: Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TeacherId,Name,Position")] TeacherDto teacherDto)
        {
            if (ModelState.IsValid)
            {
                _teacherService.Create(teacherDto);

                return RedirectToAction(nameof(Index));
            }
            return View(teacherDto);
        }

        // GET: Teacher/Edit/5
        public IActionResult Edit(int id)
        {
            var teacherDto = _teacherService.Find(id);
            if (teacherDto == null)
            {
                return NotFound();
            }

            return View(teacherDto);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TeacherId,Name,Position")] TeacherDto teacherDto)
        {
            if (id != teacherDto.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _teacherService.Update(teacherDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_teacherService.Any(teacherDto.TeacherId))
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
            return View(teacherDto);
        }

        // GET: Teacher/Delete/5
        public IActionResult Delete(int id)
        {

            var teacherDto = _teacherService.Find(id);
            if (teacherDto == null)
            {
                return NotFound();
            }

            return View(teacherDto);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_teacherService.Any(id))
            {
                return NotFound();
            }

            _teacherService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
