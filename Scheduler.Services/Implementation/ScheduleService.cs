using AutoMapper;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using Scheduler.DataAccess.Models.Enums;
using Scheduler.DTO.Models;
using Scheduler.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Services.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IRepository<Schedule> scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public IEnumerable<SchedulerDto> Get()
        {
            var scheduleDto = _scheduleRepository
                .GetAll()
                .Select(schedule => _mapper.Map<SchedulerDto>(schedule))
                .ToList();
            return scheduleDto;
        }

        public bool IsDuplicate(int teacherId, Lesson lesson)
        {
           // _scheduleRepository.GetAll().FirstOrDefault(s=>s.TeacherId != teacherId && s.Lesson != lesson);


            return _scheduleRepository.GetAll().FirstOrDefault(s => s.TeacherId == teacherId && s.Lesson == lesson) != null;
        }

        public virtual void Create(SchedulerDto scheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleDto);
            _scheduleRepository.Create(schedule);
        }

        public virtual void Delete(int id)
        {
            _scheduleRepository.Delete(id);
        }

        public virtual void Update(SchedulerDto scheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleDto);
            var prevTaskItem = _scheduleRepository.FindAsNoTracking(schedule.ScheduleId);

            _scheduleRepository.Update(schedule);
        }

        public virtual bool Any(int id)
        {
            return _scheduleRepository.Any(e => e.ScheduleId == id);
        }

        public virtual SchedulerDto Find(int id)
        {
            var schedule = _scheduleRepository.Find(id);
            var scheduleDto = _mapper.Map<SchedulerDto>(schedule);

            return scheduleDto;
        }
    }
}
