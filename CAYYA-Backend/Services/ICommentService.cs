using CAYYA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public interface ICommentService
    {
        public Task CreateComment(Comments comment);
        public Task UpdateComment(Comments comment);
        public Task DeleteComment(string commentID);
        public Task<List<Comments>> listComment();
    }
}
