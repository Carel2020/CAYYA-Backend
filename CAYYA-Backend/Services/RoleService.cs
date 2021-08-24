using CAYYA_Backend.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public class RoleService : IRoleService
    {
        private string filepath = "cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public RoleService ()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
        }
        public async Task CreateRole(Role role)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Role");
            await collectionReference.AddAsync(role);
        }

        public async Task DeleteRole(string roleID)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Role").Document(roleID);
            await documentReference.DeleteAsync();
        }

        //list of roles
        public async Task<List<Role>> listRole()
        {
            Query roleQuery = _firestoreDb.Collection("Role");
            QuerySnapshot roleQuerySnapshot = await roleQuery.GetSnapshotAsync();
            List<Role> listRole = new List<Role>();

            foreach (DocumentSnapshot documentSnapshot in roleQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> role = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(role);
                    Role newRole = JsonConvert.DeserializeObject<Role>(json);
                    newRole.roleID = documentSnapshot.Id;
                    listRole.Add(newRole);
                }
            }
            return listRole;
        }

        public async Task UpdateRole(Role role)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Role").Document(role.roleID);
            await documentReference.SetAsync(role, SetOptions.Overwrite);
        }
    }
}
