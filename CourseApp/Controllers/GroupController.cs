using Domain.Models;
using Service.Services;
using Service.Services.Helpers.Extensions;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseApp.Controllers
{
    internal class GroupController
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public GroupController()
        {
            _groupService = new GroupService();
            _studentService = new StudentService();
        }
        public void Create()
        {

            ConsoleColor.Cyan.WriteConsole("Add group name: ");
        Group: string groupName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Group;
            }
            

            var result = _groupService.GetAll();
            foreach (var item in result)
            {
                if (item.Name.ToLower() == groupName.ToLower().Trim())
                {
                    ConsoleColor.Red.WriteConsole("This name already is exsist");
                    goto Group;
                }
            }

            ConsoleColor.Cyan.WriteConsole("Add teacher name: ");
        Teacher: string teacherName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teacherName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Teacher;
            }
            if (!Regex.IsMatch(teacherName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Input format is wrong, please write again");
                goto Teacher;
            }
            if(teacherName.Length <= 2)
            {
                ConsoleColor.Red.WriteConsole("Name can't be short than 2 char");
                goto Teacher;
            }

            ConsoleColor.Cyan.WriteConsole("Add room name: ");
        Room: string roomName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(roomName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Room;
            }

            {
                try
                {
                    _groupService.Create(new Domain.Models.Group { Name = groupName.Trim(), Teacher = teacherName.Trim(), Room = roomName.Trim()});
                    ConsoleColor.Green.WriteConsole("Data successfully added");
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Group;
                }



            }

        }

        public void GetAll()
        {
            var response = _groupService.GetAll();


            foreach (var item in response)
            {
                string data = $"Group Id: {item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                Console.WriteLine(data);
            }
        }

        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Please add group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (string.IsNullOrEmpty(idStr))
            {
                ConsoleColor.Red.WriteConsole("Id cant't be empty, please write again");
                goto Id;
            }
            if (isCorrectIdFormat)
            {
                try
                {
                    _groupService.Delete(id);
                    var students = _studentService.GetAllWhithExpression(m => m.Group.Id == id);

                    if (students != null)
                    {
                        foreach (var student in students)
                        {
                            _studentService.Delete(student.Id);
                        }
                    }

                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }

            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please write again");
                goto Id;
            }
        }

        public void GetById()
        {
            ConsoleColor.Cyan.WriteConsole("Please add group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                if (string.IsNullOrEmpty(idStr))
                {
                    ConsoleColor.Red.WriteConsole("Id cant't be empty, please write again");
                    goto Id;
                }
                if (isCorrectIdFormat)
                {
                    try
                    {
                        _groupService.GetById(id);
                        var result = _groupService.GetById(id);
                        string data = $"Id: {result.Id}, Group name: {result.Name}, Group Room: {result.Room}";
                        Console.WriteLine(data);
                    }
                    catch (Exception ex)
                    {
                        ConsoleColor.Red.WriteConsole(ex.Message);
                        goto Id;
                    }
                }

                else
                {
                    ConsoleColor.Red.WriteConsole("Id is not exsist");
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Input format is wrong, please enter correct format again");
                goto Id;
            }

        }

        public void GetAllByTeacher()
        {
            ConsoleColor.Cyan.WriteConsole("Please add teacher name:");
        Teacher: string teacherName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teacherName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Teacher;
            }
            try
            {
                var result = _groupService.GetAllWhithExpression(m => m.Teacher.Trim().ToLower() == teacherName.Trim().ToLower());
                if (result.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Teacher not found");
                }

                foreach (var item in result)
                {
                    string data = $"Id: {item.Id} Group name: {item.Name}, Group Room: {item.Room}";
                    Console.WriteLine(data);
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Teacher;
            }        
            
        }

        public void GetAllByRoom()
        {
            ConsoleColor.Cyan.WriteConsole("Please add room name:");
        Room: string roomName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(roomName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Room;
            }
            try
            {
                var result = _groupService.GetAllWhithExpression(m => m.Room == roomName.Trim().ToLower());
                if (result.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Room is not found");
                }

                foreach (var item in result)
                {
                    string data = $"Id: {item.Id} Group name: {item.Name}, Group Room: {item.Room}";
                    Console.WriteLine(data);
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Room;
            }
        }

        public void SearchGroupByName()
        {
            ConsoleColor.Cyan.WriteConsole("Please add group name:");

        SearchByGroupName: string textStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(textStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto SearchByGroupName;
            }
            try
            {
                var result = _groupService.GetAllWhithExpression(m => m.Name.ToLower().Trim().Contains(textStr.ToLower().Trim()));
                if (result.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Group is not found");
                    goto SearchByGroupName;
                }              

                foreach (var item in result)
                {
                    string data = $"Id: {item.Id} Group name: {item.Name}, Group Room: {item.Room}";
                    Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto SearchByGroupName;
            }

            

        }
       
    }
}


     
 

