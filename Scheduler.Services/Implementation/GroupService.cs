using AutoMapper;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using Scheduler.DTO.Models;
using Scheduler.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IRepository<Group> groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public IEnumerable<GroupDto> Get()
        {
            var groupDto = _groupRepository
                .GetAll()
                .Select(group => _mapper.Map<GroupDto>(group))
                .ToList();
            return groupDto;
        }

        public virtual void Create(GroupDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            _groupRepository.Create(group);
        }

        public virtual void Delete(int id)
        {
            _groupRepository.Delete(id);
        }

        public virtual void Update(GroupDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            var prevTaskItem = _groupRepository.FindAsNoTracking(group.GroupId);

            _groupRepository.Update(group);
        }

        public virtual bool Any(int id)
        {
            return _groupRepository.Any(e => e.GroupId == id);
        }

        public virtual GroupDto Find(int id)
        {
            var group = _groupRepository.Find(id);
            var groupDto = _mapper.Map<GroupDto>(group);

            return groupDto;
        }
    }
}
