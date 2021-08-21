using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    [FirestoreData]
    public class Role
    {
        public string roleID { set; get; }
        [FirestoreProperty]
        public string rolename { set; get; }
    }
}
