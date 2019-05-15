﻿using Scheduler.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Services.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<SchedulerDto> Get();
        void Create(SchedulerDto roomDto);
        void Delete(int id);
        void Update(SchedulerDto roomDto);
        bool Any(int id);
        SchedulerDto Find(int id);
    }
}
