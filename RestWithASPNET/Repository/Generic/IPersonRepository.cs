using RestWithASPNET.Model;
using RestWithASPNET.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
        IList<Person> FindByName(string firstName, string lastName);
    }
}
