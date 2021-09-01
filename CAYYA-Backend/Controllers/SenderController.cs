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
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private string filepath = "cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly ISenderService _senderService;

        //constructor
        public SenderController(ISenderService senderService)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
            _senderService = senderService;
        }
        [HttpGet]
        // GET: SenderController
        public async Task<IEnumerable<ResourceCustomersSend>> Index()
        {
            List<ResourceCustomersSend> listResource = await _senderService.listResources();
            return listResource;
        }

        [HttpGet("{ResourceID}")]
        public async Task<Resources> GetResource([FromBody] string resourceID)
        {
            return await _senderService.GetResource(resourceID);
        }

        // GET: SenderController/Create
        [HttpPost]
        public async Task<IActionResult> CreateResource([FromBody] Resources resource)
        {
            await _senderService.CreateResource(resource);
            return Ok(resource);
        }

        /*        [HttpGet]
                public IActionResult CreateResource()
                {
                    return View();
                }
        */

        [HttpDelete("{id}")]
        // GET: SenderController/Delete
        public async Task<IActionResult> DeleteResource([FromBody] string resourceID)
        {
            await _senderService.DeleteResource(resourceID);
            return Ok(resourceID);
        }

        //PUT: SenderCController/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResource([FromBody] Resources resources)
        {
            await _senderService.UpdateResource(resources);
            return Ok(resources);
        }
    }
}
