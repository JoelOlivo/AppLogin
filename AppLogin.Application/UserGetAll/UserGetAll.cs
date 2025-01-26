using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Entities;
using AppLogin.Domain.Interfaces;

namespace AppLogin.Application.UserGetAll
{
    public class UserGetAll
    {
        private readonly IUserRepository _userRepository;

        public UserGetAll(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Execute()
        {
            //Verifica la existencia de usuarios
            var users = await _userRepository.GetAll();
            if (users == null)
            {
                throw new InvalidOperationException("No hay usuarios registrados");
            }

            return users;
        }
    }
}
