﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IGroupService
    {
        void Create(Group data);
        void Update(int? id, Group data);
        void Delete(int? id);
        Group GetById(int? id);
        List<Group> GetAllByTeacher(string teacher);
        List<Group> GetAllByRoom(string room);
        List<Group> GetAll();
        List<Group> SearchByName(string searchText);

    }
}