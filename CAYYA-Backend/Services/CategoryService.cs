using CAYYA_Backend.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public class CategoryService : ICategoryService
    {
        private string filepath = "cayya-resources-021fb5292151.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        public CategoryService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public async Task CreateCategory(Category category)
        {
            CollectionReference collectionReference = _firestoreDb.Collection("Category");
            await collectionReference.AddAsync(category);
        }

        public async Task DeleteCategory(string categoryID)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Category").Document(categoryID);
            await documentReference.DeleteAsync();
        }
        //Get the list of category present in the firestore
        public async Task<List<Category>> listCategory()
        {
            Query categoryQuery = _firestoreDb.Collection("Category");
            QuerySnapshot categoryQuerySnapshot = await categoryQuery.GetSnapshotAsync();
            List<Category> listCategory = new List<Category>();

            foreach (DocumentSnapshot documentSnapshot in categoryQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> category = documentSnapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(category);
                    Category newCategory = JsonConvert.DeserializeObject<Category>(json);
                    newCategory.categoryID = documentSnapshot.Id;
                    listCategory.Add(newCategory);
                }
            }
            return listCategory;
        }

        public async Task UpdateCategory(Category category)
        {
            DocumentReference documentReference = _firestoreDb.Collection("Category").Document(category.categoryID);
            await documentReference.SetAsync(category, SetOptions.Overwrite);
        }
    }
}
