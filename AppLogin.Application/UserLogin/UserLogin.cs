using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.ValueObjects;
using AppLogin.Application.Interfaces;

namespace AppLogin.Application.UserLogin
{
    public class UserLogin
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtGenerator _jwtGenerator;

        public UserLogin(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<string> Execute(string email, string password)
        {
            //Verifica la existencia del usuario
            var user = await _userRepository.GetByEmail(new UserEmail(email));
            if (user == null)
            {
                throw new UnauthorizedAccessException("El email no está registrado");
            }

            //Verifica la contraseña
            var passwordHash = _passwordHasher.Hash(new UserPassword(password));
            if (user.Password.Value != passwordHash)
            {
                throw new UnauthorizedAccessException("La contraseña no es correcta");
            }

            //Generar Token
            var token = _jwtGenerator.GenerateToken(user);
            return token;
        }
    }
}
