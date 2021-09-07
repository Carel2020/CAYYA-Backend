using CAYYA_Backend.Models;
using CAYYA_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CAYYA_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IJwtAuthenticationService jwtAuthenticationService;
        public AuthentificationController(IJwtAuthenticationService jwtAuthenticationService)
        {
            this.jwtAuthenticationService = jwtAuthenticationService;

        }

        // GET: api/<AuthentificationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "New Jersey", "New York" };
        }

        // GET api/<AuthentificationController>/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "New Jersey";
        }
/**
        // POST api/<AuthentificationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthentificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthentificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
**/

        [AllowAnonymous]
        [HttpPost ("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            var token = await jwtAuthenticationService.Authenticate
                (user.pseudo, user.password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
