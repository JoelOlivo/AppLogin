using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(UserPassword userPassword);
    }
}
