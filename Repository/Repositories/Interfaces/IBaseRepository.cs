using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id); // GetById, GetByAge
        List<T> GetAllWhithExpression(Func<T, bool> predicate); // GetAllByTeacher, GetAllGroupsByRoom, GetAllStudentsByGroup , Search
        List<T> GetAll();

    }
}
