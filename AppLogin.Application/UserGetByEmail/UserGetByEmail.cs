using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.Entities;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Application.UserGetByEmail
{
    public class UserGetByEmail
    {
        private readonly IUserRepository _userRepository;

        public UserGetByEmail(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(string email)
        {
            //Verifica la existencia del usuario
            var user = await _userRepository.GetByEmail(new UserEmail(email));
            if (user == null)
            {
                throw new InvalidOperationException("El usuario no existe");
            }

            return user;
        }


    }
}
