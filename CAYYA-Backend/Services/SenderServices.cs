using CAYYA_Backend.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public class SenderServices : ISenderService
    {
        private string filepath = "C:\\Users\\Carel Njanko\\source\\repos\\CAYYA-Backend\\CAYYA-Backend\\cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public SenderServices()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
        }
        //create resource
        public async Task CreateResource(Resources resource)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Resources");
            await collectionReference.AddAsync(resource);
           
        }
        public async Task<List<Resources>> listResources()
        {
            Query resourceQuery = _firestoreDb.Collection("Resources");
            QuerySnapshot resourceQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<Resources> listResource = new List<Resources>();

            foreach (DocumentSnapshot documentSnapshot in resourceQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> resource = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(resource);
                    Resources newResource = JsonConvert.DeserializeObject<Resources>(json);
                    newResource.resourceID = documentSnapshot.Id;
                    listResource.Add(newResource);
                }

            }
            return listResource;
        }

        [HttpDelete]
        public async Task DeleteResource(string resourceID)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Resources").Document(resourceID);
            await documentReference.DeleteAsync();
        }
    }
}
