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
    public class RoleController : ControllerBase
    {
        private string filepath = "cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly IRoleService _roleService;

        //constructor
        public RoleController(IRoleService roleService)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
            _roleService = roleService;
        }

        [HttpGet]
        // GET: RoleController
        public async Task<IEnumerable<Role>> Index()
        {
            List<Role> listRole = await _roleService.listRole();
            return listRole;
        }

        [HttpPost]
        // POST: RoleController/Create
        public async Task<IActionResult> Create([FromBody] Role role)
        {
            await _roleService.CreateRole(role);
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] Role role)
        {
            await _roleService.UpdateRole(role);
            return Ok(role);
        }

        [HttpDelete("{roleID}")]
        // GET: RoleController/Delete
        public async Task<IActionResult> DeleteRole([FromBody] string roleID)
        {
            await _roleService.DeleteRole(roleID);
            return Ok(roleID);
        }

    }
}
