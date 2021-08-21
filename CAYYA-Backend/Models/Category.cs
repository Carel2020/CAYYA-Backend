using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    [FirestoreData]
    public class Category
    {
        public string categoryID { set; get; }
        [FirestoreProperty]
        public string categoryName { set; get; }
        [FirestoreProperty]
        public string categoryDescription { set; get; }
    }
}
