using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
