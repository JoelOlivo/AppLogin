using AppLogin.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Domain.User.Entities
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<Boolean> Update(User user);
        Task<Boolean> Delete(User user);
        Task<User> GetById(UserId id);
        Task<User> GetByEmail(UserEmail email);
        Task<List<User>> GetAll();
    }
}
