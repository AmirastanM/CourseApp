using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Helpers.Constants;
using Service.Services.Helpers.Exceptions;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private int count = 1;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public void Create(Group data)
        {
            if (data is null) throw new ArgumentNullException();
            data.Id = count;
            _groupRepository.Create(data);
            count++;
        }

        public void Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Group group = _groupRepository.GetById((int)id);

            if (group is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _groupRepository.Delete(group);
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> GetAllByRoom(string room)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllByTeacher(string teacher)
        {
            throw new NotImplementedException();
        }

        public Group GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Group> SearchByName(string searchText)
        {
            throw new NotImplementedException();
        }

        public void Update(int? id, Group data)
        {
            throw new NotImplementedException();
        }
    }
}
