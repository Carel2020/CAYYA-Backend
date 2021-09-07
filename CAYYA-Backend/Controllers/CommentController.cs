using CAYYA_Backend.Models;
using CAYYA_Backend.Services;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private string filepath = "your path ";
        private string projectID;
        private FirestoreDb _firestoreDb;
        private readonly ICommentService _commentService;

        //constructor
        public CommentController(ICommentService CommentService)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
            _commentService = CommentService;
        }

        [HttpGet]
        // GET: CommentController
        public async Task<IEnumerable<Comments>> Index()
        {
            List<Comments> listComment = await _commentService.listComment();
            return listComment;
        }

        [HttpPost]
        // POST: CommentController/Create
        public async Task<IActionResult> CreateComment([FromBody] Comments comments)
        {
            await _commentService.CreateComment(comments);
            return Ok(comments);
        }

        [HttpPut("{CommentID}")]
        //PUT: CommentController/Update
        public async Task<IActionResult> UpdateComment(string CommentID, [FromBody] Comments comments)
        {
            await _commentService.UpdateComment(comments);
            return Ok(comments);
        }

        [HttpDelete("{commentID}")]
        // GET: RoleController/Delete
        public async Task<IActionResult> DeleteComment([FromBody] string commentID)
        {
            await _commentService.DeleteComment(commentID);
            return Ok(commentID);
        }

        [HttpGet("{id}")]
        public Task<Comments> Get(string id)
        {
            return _commentService.GetCommentData(id);
        }
    }
}
