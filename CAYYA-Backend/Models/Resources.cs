using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace CAYYA_Backend.Models
{
    [FirestoreData]
    public class Resources
    {
        public string resourceID { set; get; }
        [FirestoreProperty]
        public string resourceName { set; get; }
        [FirestoreProperty]
        public DateTime resourceDate { set; get; }
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
