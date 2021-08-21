using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    [FirestoreData]
    public class Comments
    {
        public string CommentID { set; get; }
        [FirestoreProperty]
        public string commentDetails { set; get; }
        [FirestoreProperty]
        public DateTime commentDate { set; get; }
        public Resources resource { get; set; }
        public UserModel user { get; set; }
    }
}
