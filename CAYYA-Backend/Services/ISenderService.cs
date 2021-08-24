using CAYYA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public interface ISenderService
    {
        //create new resource
        public Task CreateResource(Resources resource);
        public Task UpdateResource(Resources resources);
        //delete a resource
        public Task DeleteResource(string resourceID);
        //get a single resource
        public Task<Resources> GetResource(string resourceID);
        //get the list of all resources like the read operation
        public Task<List<Resources>> listResources();
    }
}
