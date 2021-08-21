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
    public class AdministratorController : Controller
    {
        private string filepath = "C:\\Users\\Carel Njanko\\source\\repos\\CAYYA-Backend\\CAYYA-Backend\\cayya-resources-021fb5292151.json";
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

        // GET: AdministratorController
        public async Task<IActionResult> Index()
        {
            List<User> listUser = await _administratorService.listUser();
            return View(listUser);
        }

        // GET: AdministratorController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministratorController/Create
        public async Task<IActionResult> CreateUser(User user)
        {
            await _administratorService.CreateUser(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await _administratorService.UpdateUser(user);
            return RedirectToAction(nameof(Index));
        }
        // POST: AdministratorController/Create

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

        // GET: AdministratorController/Delete/5
        public async Task<IActionResult> DeleteUser(string UserID)
        {
            await _administratorService.DeleteResource(UserID);
            return RedirectToAction(nameof(Index));
        }

        // POST: AdministratorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
