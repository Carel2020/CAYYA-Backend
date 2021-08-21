using CAYYA_Backend.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public class AdministratorService : IAdministratorService
    {
        private string filepath = "C:\\Users\\Carel Njanko\\source\\repos\\CAYYA-Backend\\CAYYA-Backend\\cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public AdministratorService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public Task blockUser()
        {
            throw new NotImplementedException();
        }

        public async Task CreateResource(Resources resource)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Resources");
            await collectionReference.AddAsync(resource);

        }

        public async Task CreateUser(User user)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("User");
            await collectionReference.AddAsync(user);

        }

        public async Task DeleteResource(string resourceID)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Resources").Document(resourceID);
            await documentReference.DeleteAsync();
        }

        public async Task DeleteUser(string userID)
        {
            DocumentReference documentReference = _firestoreDb.Collection("User").Document(userID);
            await documentReference.DeleteAsync();
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

        public async Task<List<User>> listUser()
        {
            Query userQuery = _firestoreDb.Collection("User");
            QuerySnapshot UserQuerySnapshot = await userQuery.GetSnapshotAsync();
            List<User> listUser = new List<User>();

            foreach (DocumentSnapshot documentSnapshot in UserQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> user = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(user);
                    User newUser = JsonConvert.DeserializeObject<User>(json);
                    newUser.userID = documentSnapshot.Id;
                    listUser.Add(newUser);
                }

            }
            return listUser;
        }

        public async Task UpdateUser(User User)
        {
            DocumentReference documentReference = _firestoreDb.Collection("User").Document(User.userID);
           await documentReference.SetAsync(User, SetOptions.Overwrite);
        }

        public Task validateResource()
        {
            throw new NotImplementedException();
        }
    }
}
