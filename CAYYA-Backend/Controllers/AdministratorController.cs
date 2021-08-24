using CAYYA_Backend.Models;
using CAYYA_Backend.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : Controller
    {
        private string filepath = "cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly IAdministratorService _administratorService;

        //constructor
        public AdministratorController(IAdministratorService administratorService)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
            _administratorService = administratorService;
        }

        [HttpGet]
        // GET: AdministratorController
        public async Task<IEnumerable<User>> Index()
        {
            List<User> listUser = await _administratorService.listUser();
            return listUser;
        }

        [HttpPost]
        // GET: AdministratorController/Create
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _administratorService.CreateUser(user);
            return Ok(user);
        }

        [HttpPut("{UserID}")]
        public async Task<IActionResult> UpdateUser(string UserID, [FromBody] User user)
        {
            await _administratorService.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("{UserID}")]
        // GET: AdministratorController/Delete/5
        public async Task<IActionResult> DeleteUser([FromBody] string UserID)
        {
            await _administratorService.DeleteResource(UserID);
            return Ok(UserID);
        }
    }
}
