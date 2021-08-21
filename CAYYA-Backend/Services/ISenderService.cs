using CAYYA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public interface ISenderService
    {
        public Task CreateResource(Resources resource);
        public Task DeleteResource(string resourceID);
        public Task<List<Resources>> listResources();
    }
}
