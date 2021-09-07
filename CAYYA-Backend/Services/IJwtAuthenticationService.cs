using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public interface IJwtAuthenticationService
    {
        Task<string> Authenticate(string username, string password);
    }
}
