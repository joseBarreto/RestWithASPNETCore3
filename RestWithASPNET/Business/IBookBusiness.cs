using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO Book);
        BookVO FindById(long? id);
        IList<BookVO> FindAll();
        BookVO Update(BookVO Book);
        void Delete(long id);
        bool Exist(long? id);
    }
}
