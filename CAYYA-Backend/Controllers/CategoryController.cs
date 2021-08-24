using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CAYYA_Backend.Data;
using CAYYA_Backend.Models;
using Google.Cloud.Firestore;
using CAYYA_Backend.Services;

namespace CAYYA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private string filepath = "cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly ICategoryService _categoryService;

        //constructor
        public CategoryController(ICategoryService categoryService)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
            _categoryService = categoryService;
        }

        [HttpGet]
        // GET: CategoryController - get the list of categories
        public async Task<IEnumerable<Category>> Index()
        {
            List<Category> listCategory = await _categoryService.listCategory();
            return listCategory;
        }

        [HttpPost]
        // POST: CategoryController/Create
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            await _categoryService.CreateCategory(category);
            return Ok(category);
        }

        [HttpPut("{CategoryID}")]
        //PUT: CategoryController/Update
        public async Task<IActionResult> UpdateCategory(string CategoryID, [FromBody] Category category)
        {
            await _categoryService.UpdateCategory(category);
            return Ok(category);
        }

        [HttpDelete("{CategoryID}")]
        // GET: CategoryController/Delete
        public async Task<IActionResult> DeleteCategory([FromBody] string categoryID)
        {
            await _categoryService.DeleteCategory(categoryID);
            return Ok(categoryID);
        }
    }
}
