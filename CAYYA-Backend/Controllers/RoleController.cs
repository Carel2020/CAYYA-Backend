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
    public class RoleController : Controller
    {
        private string filepath = "C:\\Users\\Carel Njanko\\source\\repos\\CAYYA-Backend\\CAYYA-Backend\\cayya-resources-021fb5292151.json";
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
        // GET: RoleController
        public async Task<IActionResult> Index()
        {
            List<Role> listRole = await _roleService.listRole();
            return View(listRole);
        }

        // GET: RoleController/Create
        public async Task<IActionResult> CreateRole(Role role)
        {
            await _roleService.CreateRole(role);
            return RedirectToAction(nameof(Index));
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
