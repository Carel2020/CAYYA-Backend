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
        public string commentID { set; get; }
        [FirestoreProperty]
        public string commentDetails { set; get; }
        [FirestoreProperty]
        public DateTime commentDate { set; get; }
        [FirestoreProperty]
        public Resources resource { get; set; }
        [FirestoreProperty]
        public UserModel UserModel { get; set; }
    }
}
