using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    [FirestoreData]
    public class User
    {
        public string userID { set; get; }
        [FirestoreProperty]
        //pseudo represents user name as well as company name
        public string pseudo { set; get; }
        [FirestoreProperty]
        public string password { set; get; }
        [FirestoreProperty]
        public string email { set; get; }
        [FirestoreProperty]
        public int age { set; get; }
        /*[FirestoreProperty]
        public string companyType { set; get; }*/
        [FirestoreProperty]
        public int contact { set; get; }
        [FirestoreProperty]
        public string gender { set; get; }
        [FirestoreProperty]
        public string clientFirstName { set; get; }
        [FirestoreProperty]
        public string clientLastName { set; get; }
        [FirestoreProperty]
        public string Picture { set; get; }
        [FirestoreProperty]
        public Role role { get; set; }
        [FirestoreProperty]
        public Tarification tarification { get; set; }
        [FirestoreProperty]
        public Notification notification { get; set; }
    }
}
