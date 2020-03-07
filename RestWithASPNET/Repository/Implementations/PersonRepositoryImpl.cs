using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepositoryImpl(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            try
            {
                if (Exist(id))
                {
                    var result = FindById(id);
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        public IList<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long? id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            try
            {
                if (Exist(person.Id))
                {
                    var result = FindById(person.Id);
                    _context.Entry(result).CurrentValues.SetValues(person); 
                    _context.SaveChanges();
                }
                else
                {
                    return null;
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }
      
    }
}
