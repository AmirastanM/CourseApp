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
        GetAllGroupsByTeacher,
        GetAllGroupsByRoom,
        GetAllGroups,
        SearchGroupsByName
    }
}
