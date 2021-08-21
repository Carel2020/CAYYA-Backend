using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    public class UserModel
    {
        public string userID { set; get; }
        [FirestoreProperty]
        public string pseudo { set; get; }
    }
}
