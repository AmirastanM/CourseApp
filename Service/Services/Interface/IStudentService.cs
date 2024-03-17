using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IStudentService
    {
        void Create(Student data);
        void Update(int? id, Student data);
        void Delete(int? id);
        Student GetById(int? id);
        List<Student> GetByAge(int age);
        List<Student> GetByGroupId(int groupId);
        List<Student> SearchByNameOrSurname(string searchtext);
    }
}
