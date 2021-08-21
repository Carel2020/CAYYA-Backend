using CAYYA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public interface IAdministratorService: ISenderService
    {
        public Task validateResource();
        public Task blockUser();
        public Task CreateUser(User user);
        public Task DeleteUser(string userID);
        public Task UpdateUser(User user);
        public Task<List<User>> listUser();
    }
}
