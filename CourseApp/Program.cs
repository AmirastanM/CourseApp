

using CourseApp.Controllers;
using Service.Services.Helpers.Enams;
using Service.Services.Helpers.Extensions;
using System.Diagnostics;
using System.Reflection.Emit;



GroupController groupController = new();
StudentController studentController = new();

while (true)
{
    GetMenues();

    Operation: string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);

    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.GroupCreate:
                groupController.Create();
                break;
            case (int)OperationType.GroupEdit:
                //----
                break;
            case (int)OperationType.GroupDelete:
                groupController.Delete();
                break;                
            case (int)OperationType.GetGroupById:
                groupController.GetById();
                break;               
            case (int)OperationType.GetAllGroups:
                groupController.GetAll();
                break;
            case (int)OperationType.GetAllGroupsByTeacher:
                groupController.GetAllByTeacher();
                break;
            case (int)OperationType.GetAllGroupsByRoom:
                groupController.GetAllByRoom();
                break;
            case (int)OperationType.SearchGroupsByName:
                groupController.SearchGroupByName();
                break;
            case (int)OperationType.StudentCreate:
                studentController.Create();
                break;
            case (int)OperationType.StudentEdit:
                //---
                break;
            case (int)OperationType.StudentDelete:
                studentController.Delete();
                break;
            case (int)OperationType.GetAllStudents:
                studentController.GetAllStudents();
                break;
            case (int)OperationType.GetStudentById:
                studentController.GetById();
                break;
            case (int)OperationType.GetStudentByAge:
                //---
                break;
            case (int)OperationType.GetAllStudentByGroup:
                //---
                break;
            case (int)OperationType.SearchStudentByNameOrSurname:
                //---
                break;



            default:
                ConsoleColor.Red.WriteConsole("This operation is not avialable, please choose correct operation again");
                goto Operation;

        }

    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }
}







void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Please choose operation : \n 1 - GroupCreate\r\n 2 - GroupEdit\r\n 3 - GroupDelete\r\n" +
        " 4 - GetGroupById\r\n 5 - GetAllGroups\r\n 6 - GetAllGroupsByTeacher\r\n 7 - GetAllGroupsByRoom\r\n" +
        " 8 - SearchGroupsByName\r\n 9 - StudentCreate,\r\n 10 - StudentEdit,\r\n 11 - StudentDelete,\r\n 12 - GetAllStudents" +
        " 13 - GetStudentById,\r\n 14 - GetStudentByAge,\r\n 15 - GetAllStudentByGroup,\r\n 16 - SearchStudentByNameOrSurname   ");
}