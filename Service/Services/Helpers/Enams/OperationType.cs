using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Helpers.Enams
{
    public enum OperationType
    {
        GroupCreate = 1,
        GroupEdit,
        GroupDelete,
        GetGroupById,
        GetAllGroups,
        GetAllGroupsByTeacher,
        GetAllGroupsByRoom,        
        SearchGroupsByName,
        StudentCreate,
        StudentEdit,
        StudentDelete,
        GetAllStudents,
        GetStudentById,
        GetStudentByAge,
        GetAllStudentByGroup,
        SearchStudentByNameOrSurname

    }
}
