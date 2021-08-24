using CAYYA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public interface ICategoryService
    {
        public Task CreateCategory(Category category);
        public Task UpdateCategory(Category category);
        public Task DeleteCategory(string categoryID);
        public Task<List<Category>> listCategory();
    }
}
