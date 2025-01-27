using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Domain.Entities
{
    public class User
    {
        public UserId Id { get; set; }
        public UserEmail Email { get; set; }
        public UserPassword Password { get; set; }
        public UserFirstName FirstName { get; set; }
        public UserLastName LastName { get; set; }

        // Constructor sin parámetros para EF
        public User() { }

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
