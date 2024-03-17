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
using System.Security.Cryptography.X509Certificates;

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

        public Group GetById(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Group group = _groupRepository.GetById((int)id);

            if (group is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            return group;
        }

       
        public void Update(int? id, Group data)
        {
            
            

            
            
        }

        public List<Group> GetAllWhithExpression(Func<Group, bool> predicate)
        {
            return _groupRepository.GetAllWhithExpression(predicate);
        }
        

    }
}
