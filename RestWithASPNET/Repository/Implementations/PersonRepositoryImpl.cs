using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Implementations
{
    public class PersonRepositoryImpl : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepositoryImpl(MySqlContext context) : base(context)
        {
        }

        public IList<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            else
                return FindAll();
        }


    }
}
