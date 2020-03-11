using RestWithASPNET.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long? id);
        IList<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exist(long? id);
    }
}
