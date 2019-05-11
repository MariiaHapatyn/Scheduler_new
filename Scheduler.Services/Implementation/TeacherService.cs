using AutoMapper;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using Scheduler.DTO.Models;
using Scheduler.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Services.Implementation
{
    public class TeacherService:ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(IRepository<Teacher> teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public IEnumerable<TeacherDto> Get()
        {
            var teacherDto = _teacherRepository
                .GetAll()
                .Select(teacher => _mapper.Map<TeacherDto>(teacher))
                .ToList();
            return teacherDto;
        }

        public virtual void Create(TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            _teacherRepository.Create(teacher);
        }

        public virtual void Delete(int id)
        {
            _teacherRepository.Delete(id);
        }

        public virtual void Update(TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            var prevTaskItem = _teacherRepository.FindAsNoTracking(teacher.TeacherId);

            _teacherRepository.Update(teacher);
        }

        public virtual bool Any(int id)
        {
            return _teacherRepository.Any(e => e.TeacherId == id);
        }

        public virtual TeacherDto Find(int id)
        {
            var teacher = _teacherRepository.Find(id);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return teacherDto;
        }
    }
}
