using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.User.ValueObjects;

namespace AppLogin.Domain.User.Entities
{
    public class User
    {
        public UserId Id { get; }
        public UserEmail Email { get; }
        public UserPassword Password { get; }
        public UserFirstName FirstName { get; }
        public UserLastName LastName { get; }

        public User(UserId id, UserEmail email, UserPassword password, UserFirstName firstName, UserLastName lastName)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
