using AutoMapper;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using Scheduler.DTO.Models;
using Scheduler.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRepository<Room> roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public IEnumerable<RoomDto> Get()
        {
            var roomDto = _roomRepository
                .GetAll()
                .Select(room => _mapper.Map<RoomDto>(room))
                .ToList();
            return roomDto;
        }

        public virtual void Create(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _roomRepository.Create(room);
        }

        public virtual void Delete(int id)
        {
            _roomRepository.Delete(id);
        }

        public virtual void Update(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            var prevTaskItem = _roomRepository.FindAsNoTracking(room.RoomId);

            _roomRepository.Update(room);
        }

        public virtual bool Any(int id)
        {
            return _roomRepository.Any(e => e.RoomId == id);
        }

        public virtual RoomDto Find(int id)
        {
            var room = _roomRepository.Find(id);
            var roomDto = _mapper.Map<RoomDto>(room);

            return roomDto;
        }
    }
}
