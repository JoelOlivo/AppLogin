using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Entities;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Domain.Interfaces
{
    public interface IUserRepository
    {
        //Agregar métodos CRUD
        Task<User> Add(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);
        Task<User> GetById(UserId id);
        Task<User> GetByEmail(UserEmail email);
        Task<List<User>> GetAll();
    }
}
