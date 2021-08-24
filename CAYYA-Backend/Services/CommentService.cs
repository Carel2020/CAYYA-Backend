using CAYYA_Backend.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public class CommentService : ICommentService
    {
        private string filepath = "cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        //constructor
        public CommentService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task CreateComment(Comments comment)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Comments");
            await collectionReference.AddAsync(comment);
        }

        public async Task DeleteComment(string commentID)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Comments").Document(commentID);
            await documentReference.DeleteAsync();
        }

        public async Task<List<Comments>> listComment()
        {
            Query commentQuery = _firestoreDb.Collection("Comments");
            QuerySnapshot commentQuerySnapshot = await commentQuery.GetSnapshotAsync();
            List<Comments> listComment = new List<Comments>();

            foreach (DocumentSnapshot documentSnapshot in commentQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> comment = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(comment);
                    Comments newComment = JsonConvert.DeserializeObject<Comments>(json);
                    newComment.commentID = documentSnapshot.Id;
                    listComment.Add(newComment);
                }
            }
            return listComment;
        }

        public async Task UpdateComment(Comments comment)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Comments").Document(comment.commentID);
            await documentReference.SetAsync(comment, SetOptions.Overwrite);
        }
    }
}
