using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Entities;

namespace AppLogin.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
