using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    [FirestoreData]
    public class Tarification
    {
        public string tarificationID { set; get; }
        [FirestoreProperty]
        public string tarificationName { set; get; }
        [FirestoreProperty]
        public string tarificationDescription { set; get; }
    }
}
