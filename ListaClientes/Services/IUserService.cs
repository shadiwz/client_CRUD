using System.Collections.Generic;

namespace ListaClientes.Services
{
    public interface IUserServices
    {
        List<User> Get();
        User Get(string name);
        User Create(User user);
        long Update(string id, User user);
        long Remove(string id);
    }
}