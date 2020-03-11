using RestWithASPNET.Data.Converter;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Data.Converters
{
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;

            return new PersonVO
            {
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                Id = origin.Id,
                LastName = origin.LastName
            };
        }

        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;

            return new Person
            {
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                Id = origin.Id,
                LastName = origin.LastName
            };
        }

        public IList<PersonVO> ParseList(IList<Person> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public IList<Person> ParseList(IList<PersonVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
