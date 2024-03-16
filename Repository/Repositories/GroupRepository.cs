using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> GetAllByRoom(string room)
        {
            return AppDbContext<Group>.datas.FindAll(m => m.Room == room);
        }

        public List<Group> GetAllByTeacher(string teacher)
        {
            return AppDbContext<Group>.datas.FindAll(m => m.Teacher == teacher);
        }
    }
}
