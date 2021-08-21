using CAYYA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public interface IRoleService
    {
        public Task CreateRole(Role role);
        public Task<List<Role>> listRole();
    }
}
