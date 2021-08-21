using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Models
{
    [FirestoreData]
    public class Notification
    {
        public int NotificationID { set; get; }
        [FirestoreProperty]
        public string description { set; get; }
        [FirestoreProperty]
        public string notificationType { set; get; }
    }
}
