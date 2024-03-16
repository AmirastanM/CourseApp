using Domain.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public void Create(Student data)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Student GetByAge(int age)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchByNameOrSurname(string searchtext)
        {
            throw new NotImplementedException();
        }

        public void Update(int? id, Student data)
        {
            throw new NotImplementedException();
        }
    }
}
