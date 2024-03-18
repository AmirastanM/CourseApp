using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Data;
using Service.Services.Helpers.Constants;
using Service.Services.Helpers.Exceptions;
using Domain.Models;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        

        int count = 1;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
           
        }

        public void Create(Student data)
        {
            if (data is null) throw new ArgumentNullException();
            data.Id = count;
            _studentRepository.Create(data);
            count++;           
        }

        public void Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Student student = _studentRepository.GetById((int)id);

            if (student is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _studentRepository.Delete(student);
        }       

        public List<Student> GetByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Student student = _studentRepository.GetById((int)id);

            if (student is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            return student;
        }        

        public void Update(int? id, Student data)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public List<Student> GetAllWhithExpression(Func<Student, bool> predicate)
        {
           return _studentRepository.GetAllWhithExpression(predicate);
        }

      


    }
}
