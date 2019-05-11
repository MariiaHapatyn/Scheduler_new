using Scheduler.DTO.Models;
using System.Collections.Generic;

namespace Scheduler.Services.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<RoomDto> Get();
        void Create(RoomDto roomDto);
        void Delete(int id);
        void Update(RoomDto roomDto);
        bool Any(int id);
        RoomDto Find(int id);
    }
}
