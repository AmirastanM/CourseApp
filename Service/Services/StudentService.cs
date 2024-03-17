﻿using Domain.Models;
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
            if (id is null) throw new ArgumentNullException();

            Student student = _studentRepository.GetById((int)id);

            if (student is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _studentRepository.Delete(student);
        }

        public List<Student> GetByAge(int age)
        {
            return AppDbContext<Student>.datas.Where(m => m.Age == age).ToList();
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
