using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    public class RessourceReceive
    {
        public string resourceID { set; get; }
        [FirestoreProperty]
        public string resourceName { set; get; }
        [FirestoreProperty]
        public string resourcePath { set; get; }

        [FirestoreProperty]
        public Boolean resourceState { set; get; }
        [FirestoreProperty]
        public string resourceDescription { set; get; }
        [FirestoreProperty]
        public Category category { get; set; }
        [FirestoreProperty]
        public UserModel sender { get; set; }
        [FirestoreProperty]
        public List<Comments> comments { get; set; }
    }
}
