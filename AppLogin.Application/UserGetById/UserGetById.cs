using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Entities;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Application.UserGetById
{
    public class UserGetById
    {
        private readonly IUserRepository _userRepository;

        public UserGetById(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(Guid id)
        {
            //Verifica la existencia del usuario
            var user = await _userRepository.GetById(new UserId(id));
            if (user == null)
            {
                throw new InvalidOperationException("El usuario no existe");
            }

            return user;
        }
    }
}
