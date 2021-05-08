using System.Collections.Generic;

namespace ListaClientes.Services
{
    public interface IUserServices
    {
        List<User> Get(FilterUser filterUser);
        User Get(string id);
        User Create(User user);
        long Update(string id, User user);
        long Remove(string id);
    }
}