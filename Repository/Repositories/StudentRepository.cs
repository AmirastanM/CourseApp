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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> GetAllByGroupId(int groupId)
        {
            return AppDbContext<Student>.datas.FindAll(m => m.Group.Id == groupId);
        }

        public Student GetByAge(int age)
        {
            return AppDbContext<Student>.datas.FirstOrDefault(m => m.Age == age);
        }
    }
}
