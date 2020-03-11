using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long? id);
        IList<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
        bool Exist(long? id);
    }
}
