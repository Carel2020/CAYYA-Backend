using CAYYA_Backend.Models;
using CAYYA_Backend.Services;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Controllers
{
    public class SenderController : Controller
    {
        private string filepath = "C:\\Users\\Carel Njanko\\source\\repos\\CAYYA-Backend\\CAYYA-Backend\\cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly ISenderService _senderService;
        FirebaseClient client;

        private readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "021fb529215102ba20153a9d592499cbe719c21b",
            BasePath = "/"
        };

        //constructor
        public SenderController(ISenderService senderService)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
            _senderService = senderService;
        }

        // GET: SenderController
        public async Task<IActionResult> Index()
        {
            List<Resources> listResource = await _senderService.listResources();
            return View(listResource);
        }

        // GET: SenderController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: SenderController/Create
        [HttpGet]
        public async Task<IActionResult> CreateResource(Resources resource)
        {
            await _senderService.CreateResource(resource);
            //return RedirectToAction(nameof(Index));
            return View();
        }

        // POST: SenderController/Create
        [HttpPost]
        public ActionResult Create(Resources resources)
        {
            try
            {
                AddResourceToFirestore(resources);
                ModelState.AddModelError(string.Empty, "Added Resource Successful");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message); 
            }
            return View();
        }

        private void AddResourceToFirestore(Resources resources)
        {
            client = new FireSharp.FirebaseClient(config);
            var data = resources;
            PushResponse response = client.Push("Resource/", data);
            data.resourceID = response.Result.name;
            SetResponse setResponse = client.Set("Resource/" + data.resourceID, data);
        }

        // GET: SenderController/Delete/5
        public async Task<IActionResult> Delete(string resourceID)
        {
            await _senderService.DeleteResource(resourceID);
            return RedirectToAction(nameof(Index));
        }

        // POST: SenderController/Delete/5
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
