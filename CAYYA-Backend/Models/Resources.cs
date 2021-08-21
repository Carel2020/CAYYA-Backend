using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Category category { get; set; }
        public UserModel sender { get; set; }
        public List<Comments> comments { get; set; }
    }
}
