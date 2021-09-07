using AutoMapper;
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
        private string filepath = "your path";
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
            //resource.resourceDate = Timestamp.GetCurrentTimestamp();
            resource.resourceDate = Timestamp.GetCurrentTimestamp();
            await collectionReference.AddAsync(resource);
        }
        public async Task<List<ResourceCustomersSend>> listResources()
        {
            Query resourceQuery = _firestoreDb.Collection("Resources");
            QuerySnapshot resourceQuerySnapshot = await resourceQuery.GetSnapshotAsync();
            List<ResourceCustomersSend> listResource = new List<ResourceCustomersSend>();
            
            foreach (DocumentSnapshot documentSnapshot in resourceQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> resource = documentSnapshot.ToDictionary();
                    string date = resource["resourceDate"].ToString();
                    
                    string data2 = date.Remove(11);


                    int index = date.IndexOf(data2);
                    string cleanPath = (index < 0)
                        ? date
                        : date.Remove(index, data2.Length);

                    DateTime ts = DateTime.Parse(cleanPath);
            
                    string json = JsonConvert.SerializeObject(resource);
                    RessourceReceive newResource = JsonConvert.DeserializeObject<RessourceReceive>(json);

                    newResource.resourceID = documentSnapshot.Id;
                    ResourceCustomersSend resourceCustomersSend = new ResourceCustomersSend();
                    resourceCustomersSend.resourceDate = ts;
                    resourceCustomersSend.resourceDescription = newResource.resourceDescription;
                    resourceCustomersSend.resourceName = newResource.resourceName;
                    resourceCustomersSend.resourcePath = newResource.resourcePath;
                    resourceCustomersSend.resourceState = newResource.resourceState;
                    resourceCustomersSend.resourceID = newResource.resourceID;
                    resourceCustomersSend.category = newResource.category;
                    resourceCustomersSend.comments = newResource.comments;
                    resourceCustomersSend.sender = newResource.sender;
             
             /**       var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<ResourceCustomersSend, RessourceReceive>();
                    });
                    IMapper iMapper = config.CreateMapper();
                    var source = new ResourceCustomersSend();
                    var destination = iMapper.Map<ResourceCustomersSend, RessourceReceive>(source);

                    /**                 resources.resourceDate    = Convert.ToInt64(UnixTimeStamp).ToString();

                     resources.resourceDate = Convert.(resource["resourceDate"].ToString());
                    newResource.resourceDate = new DateTime();
                    string resourcedate = resource["resourceDate"].ToString();
                    string resourcedate = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                    DateTime.parse(timestamp.toDate().toString())
                     DateTime result = DateTime.ParseExact(Timestamp.ToString().Replace("Timestamp:", "").Trim(), "yyyy-MM-ddTHH:mm:ss.ffffffK", null);
                    **/

                    listResource.Add(resourceCustomersSend);
                }

            }
            return listResource;
        }

        public async Task DeleteResource(string resourceID)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Resources").Document(resourceID);
            await documentReference.DeleteAsync();
        }

        public async Task UpdateResource(Resources resources)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Resources").Document(resources.resourceID);
            resources.resourceDate = Timestamp.GetCurrentTimestamp();
            await documentReference.SetAsync(resources, SetOptions.Overwrite);
        }

        public async Task<Resources> GetResource(string resourceID)
        {
            try
            {
                DocumentReference documentReference = _firestoreDb.Collection("Resources").Document(resourceID);
                DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    /**
                    Resources resources = snapshot.ConvertTo<Resources>();
                    resources.resourceID = snapshot.Id;
                    return resources;
                    **/

                   
                    Dictionary<string, object> resource = snapshot.ToDictionary();
                    string date = resource["resourceDate"].ToString();

                    string data2 = date.Remove(11);

                    int index = date.IndexOf(data2);
                    string cleanPath = (index < 0)
                        ? date
                        : date.Remove(index, data2.Length);

                    DateTime ts = DateTime.Parse(cleanPath);

                    string json = JsonConvert.SerializeObject(resource);
                    RessourceReceive newResource = JsonConvert.DeserializeObject<RessourceReceive>(json);

                    newResource.resourceID = snapshot.Id;
                    ResourceCustomersSend resourceCustomersSend = new ResourceCustomersSend();
                    resourceCustomersSend.resourceDate = ts;
                    resourceCustomersSend.resourceDescription = newResource.resourceDescription;
                    resourceCustomersSend.resourceName = newResource.resourceName;
                    resourceCustomersSend.resourcePath = newResource.resourcePath;
                    resourceCustomersSend.resourceState = newResource.resourceState;
                    resourceCustomersSend.resourceID = newResource.resourceID;
                    resourceCustomersSend.category = newResource.category;
                    resourceCustomersSend.comments = newResource.comments;
                    resourceCustomersSend.sender = newResource.sender;

                    return resourceCustomersSend;
                    
                }
                else
                {
                    return new Resources();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Resources> Search(string resourceID)
        {
            try
            {
                DocumentReference documentReference = _firestoreDb.Collection("Resources").Document(resourceID);
                DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    /**
                    Resources resources = snapshot.ConvertTo<Resources>();
                    resources.resourceID = snapshot.Id;
                    return resources;
                    **/


                    Dictionary<string, object> resource = snapshot.ToDictionary();
                    string date = resource["resourceDate"].ToString();

                    string data2 = date.Remove(11);

                    int index = date.IndexOf(data2);
                    string cleanPath = (index < 0)
                        ? date
                        : date.Remove(index, data2.Length);

                    DateTime ts = DateTime.Parse(cleanPath);

                    string json = JsonConvert.SerializeObject(resource);
                    RessourceReceive newResource = JsonConvert.DeserializeObject<RessourceReceive>(json);

                    newResource.resourceID = snapshot.Id;
                    ResourceCustomersSend resourceCustomersSend = new ResourceCustomersSend();
                    resourceCustomersSend.resourceDate = ts;
                    resourceCustomersSend.resourceDescription = newResource.resourceDescription;
                    resourceCustomersSend.resourceName = newResource.resourceName;
                    resourceCustomersSend.resourcePath = newResource.resourcePath;
                    resourceCustomersSend.resourceState = newResource.resourceState;
                    resourceCustomersSend.resourceID = newResource.resourceID;
                    resourceCustomersSend.category = newResource.category;
                    resourceCustomersSend.comments = newResource.comments;
                    resourceCustomersSend.sender = newResource.sender;

                    return resourceCustomersSend;

                }
                else
                {
                    return new Resources();
                }
            }
            catch
            {
                throw;
            }
        }

        /**
       protected async Task SearchEmployee()
       {
           await GetEmployeeList();
           if (searchString != "")
           {
               empList = empList.Where(
               x => x.EmployeeName.IndexOf(searchString,
               StringComparison.OrdinalIgnoreCase) != -1).ToList();
           }
       }
**/
    }
}
