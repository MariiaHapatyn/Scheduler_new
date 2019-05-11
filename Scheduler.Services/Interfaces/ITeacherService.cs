using Scheduler.DTO.Models;
using System.Collections.Generic;

namespace Scheduler.Services.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<TeacherDto> Get();
        void Create(TeacherDto teacherDto);
        void Delete(int id);
        void Update(TeacherDto teacherDto);
        bool Any(int id);
        TeacherDto Find(int id);
    }
}
