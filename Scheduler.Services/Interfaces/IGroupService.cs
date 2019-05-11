using Scheduler.DTO.Models;
using System.Collections.Generic;

namespace Scheduler.Services.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> Get();
        void Create(GroupDto groupDto);
        void Delete(int id);
        void Update(GroupDto groupDto);
        bool Any(int id);
        GroupDto Find(int id);
    }
}
