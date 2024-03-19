using Domain.Models;
using Repository.Data;
using Service.Services;
using Service.Services.Helpers.Extensions;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Group = Domain.Models.Group;

namespace CourseApp.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public StudentController()
        {
            _studentService = new StudentService();
            _groupService = new GroupService();
        }

        public void Create()
        {
            if (_groupService.GetAll().Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Group is not exsist, please create group: ");
                return;
            }
            ConsoleColor.Cyan.WriteConsole("Add student name: ");
        StudentName: string studentName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(studentName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto StudentName;
            }
            if (!Regex.IsMatch(studentName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Input format is wrong, please write again");
                goto StudentName;
            }
            if (studentName.Length <= 2)
            {
                ConsoleColor.Red.WriteConsole("Name can't be short than 2 char");
                goto StudentName;
            }

            ConsoleColor.Cyan.WriteConsole("Add student surname: ");
        StudentSurName: string studentSurName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(studentSurName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto StudentSurName;
            }
            if (!Regex.IsMatch(studentSurName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Input format is wrong, please write again");
                goto StudentSurName;
            }
            if (studentSurName.Length <= 4)
            {
                ConsoleColor.Red.WriteConsole("Name can't be short than 2 char");
                goto StudentSurName;
            }

            ConsoleColor.Cyan.WriteConsole("Please add student age:");
        Age: string ageStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Age cant't be empty, please write again");
                goto Age;
            }
            int age;
            bool isCorrectIdFormat = int.TryParse(ageStr, out age);
            if (isCorrectIdFormat)
            {
                
                if (age < 15 || age > 50)
                {
                    ConsoleColor.Red.WriteConsole("This age is not possible to add group, please enter correct age");
                    goto Age;
                }                

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong, please add again");
                goto Age;

            }

            var response = _groupService.GetAll();
            foreach (var item in response)
            {
                Console.WriteLine($"Group Id: {item.Id}, Group name: {item.Name}, Group Room: {item.Room}, Teacher name: {item.Teacher}");
            }
        IdGroup: ConsoleColor.Cyan.WriteConsole("Please add exsist id group: ");
            var idOfGroup = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idOfGroup, out id);
            if (isCorrectId)
            {
                if (string.IsNullOrWhiteSpace(idOfGroup))
                {
                    ConsoleColor.Red.WriteConsole("Id cant't be empty, please write again");
                    goto IdGroup;
                }
                Group group = _groupService.GetById(id);
                _studentService.Create(new Student { Name = studentName, Surname = studentSurName, Age = age, Group = group });

            }


        }

        public void GetAll()

        {
            var response = _studentService.GetAll();
            if (!response.Any())

            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
            foreach (var item in response)
            {
                string data = $"Student name: {item.Name}, Student surname: {item.Surname}, Student age: {item.Age}, Student Group: {item.Group.Name}";
                Console.WriteLine(data);
            }
        }

        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Please add student id:");
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
                    _studentService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Student succsessfully deleted");
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
            ConsoleColor.Cyan.WriteConsole("Please add student id:");
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
                        _studentService.GetById(id);
                        var result = _studentService.GetById(id);
                        string data = $"Id: {result.Id}, Student name: {result.Name}, Student Age: {result.Age}";
                        Console.WriteLine(data);
                    }
                    catch (Exception ex)
                    {
                        ConsoleColor.Red.WriteConsole(ex.Message);
                        goto Id;
                    }
                }
               
                
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Format is wrong, please write again");
                goto Id;

            }
        }

        public void GetByAge()
        {
            ConsoleColor.Cyan.WriteConsole("Please add age:");
        Age: string ageStr = Console.ReadLine();
            int age;
            bool isCorrectIdFormat = int.TryParse(ageStr, out age);
            if (isCorrectIdFormat)
            {
                if (string.IsNullOrEmpty(ageStr))
                {
                    ConsoleColor.Red.WriteConsole("Id cant't be empty, please write again");
                    goto Age;
                }
                if (isCorrectIdFormat)
                {
                    try

                    {
                        var result = _studentService.GetAllWhithExpression(m => m.Age == age);

                        if (result.Count == 0)
                        {
                            ConsoleColor.Red.WriteConsole("Not exsist, please add again different age");
                            goto Age;
                        }


                        foreach (var item in result)
                        {
                            string data = $"Id: {item.Id}, Student name: {item.Name}, Studen surname: {item.Surname}Student Age: {item.Age}";
                            Console.WriteLine(data);
                        }

                    }

                    catch (Exception ex)
                    {
                        ConsoleColor.Red.WriteConsole(ex.Message);
                        goto Age;
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Data not found please write again.");
                    goto Age;

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Input format is wrong, please enter correct format again");
                goto Age;
            }
        }            
    
        public void SearchByNameOrSurname()
        {
            ConsoleColor.Cyan.WriteConsole("Please add student name or surname:");

        Search: string textStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(textStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Search;
            }
            try
            {
                var result = _studentService.GetAllWhithExpression(m => m.Name.ToLower().Trim().Contains(textStr.ToLower().Trim()) || m.Surname.ToLower().Trim().Contains(textStr.ToLower().Trim()));
                if (result.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data not found");
                    goto Search;
                }

                foreach (var item in result)
                {
                    string data = $"Id: {item.Id} Student name: {item.Name}, Student Surname: {item.Surname}, Student age: {item.Age}";
                    Console.WriteLine(data);
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Search;
            }
        }

        public void GetAllByGroupId()
        {
            while (true)
            {
                ConsoleColor.Cyan.WriteConsole("Please add Group Id:");
            GroupId: string groupIdStr = Console.ReadLine();
                int id;

                if (string.IsNullOrWhiteSpace(groupIdStr))
                {
                    ConsoleColor.Red.WriteConsole("Input can't be empty");
                    goto GroupId;
                }
                if (!int.TryParse(groupIdStr, out id))
                {
                    ConsoleColor.Red.WriteConsole("Input format is wrong, please add correct format");
                    goto GroupId;
                }
                try
                {
                   
                    List<Student> result = _studentService.GetAllWhithExpression(m => m.Group.Id == id);
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            string data = $"Id: {item.Id} Student name: {item.Name}, Student Surname: {item.Surname}, Student age: {item.Age}";
                            Console.WriteLine(data);
                        }
                    

                        
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Group not found");
                    }
                    break;

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto GroupId;
                }
            }
        }

    }
}
