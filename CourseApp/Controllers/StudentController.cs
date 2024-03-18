using Service.Services;
using Service.Services.Helpers.Extensions;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            int age;
            bool isCorrectIdFormat = int.TryParse(ageStr, out age);
            if (isCorrectIdFormat)
            {
                if (string.IsNullOrEmpty(ageStr))
                {
                    ConsoleColor.Red.WriteConsole("Id cant't be empty, please write again");
                    goto Age;
                }

            }

        }

        public void GetAllStudents()

        {
            var response = _groupService.GetAll();
            if(response is null)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
            foreach (var item in response)
            {
                string data = $"Student name: {item.Name}, Student surname: {item.Teacher}, Student age: {item.Room}";
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
                    {   _studentService.GetByAge(age);
                        var result =_studentService.GetByAge(age);
                        if(result == null)
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
            }
        }

    }
}
