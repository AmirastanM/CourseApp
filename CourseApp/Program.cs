

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
                studentController.GetAll();
                break;
            case (int)OperationType.GetStudentById:
                studentController.GetById();
                break;
            case (int)OperationType.GetStudentByAge:
                studentController.GetByAge();
                break;
            case (int)OperationType.GetAllStudentByGroup:
                studentController.GetAllByGroup();
                break;
            case (int)OperationType.SearchStudentByNameOrSurname:
                studentController.SearchByNameOrSurname();
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
    ConsoleColor.Cyan.WriteConsole("Please choose operation :" +
        "\n  1 - GroupCreate                                  9 - StudentCreate\n"+
        "    2 - GroupEdit                                    10 - StudentEdit\n"+
        "    3 - GroupDelete                                  11 - StudentDelete\n"+
        "    4 - GetGroupById                                 12 - GetAllStudents\n"+
        "    5 - GetAllGroups                                 13 - GetStudentById\n"+
        "    6 - GetAllGroupsByTeacher                        14 - GetStudentByAge\n"+
        "    7 - GetAllGroupsByRoom                           15 - GetAllStudentByGroup\n"+
        "    8 - SearchGroupsByName                           16 - SearchStudentByNameOrSurname");
    
}