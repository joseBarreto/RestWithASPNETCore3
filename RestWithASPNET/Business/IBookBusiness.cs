using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        Book Create(Book Book);
        Book FindById(long? id);
        IList<Book> FindAll();
        Book Update(Book Book);
        void Delete(long id);
        bool Exist(long? id);
    }
}
