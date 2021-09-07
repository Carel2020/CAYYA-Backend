using CAYYA_Backend.Models;
using Google.Cloud.Firestore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CAYYA_Backend.Services
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private string filepath = "your path";
        private string projectID;
        private FirestoreDb _firestoreDb;
        /**
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1"}, {"test2", "password2"}
        };
        **/

        private readonly string key;
        
        public JwtAuthenticationService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public JwtAuthenticationService(string key)
        {
            this.key = key;
        }
        public async Task<string> Authenticate(string username, string password)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "cayya-resources";
            _firestoreDb = FirestoreDb.Create(projectID);

            Query userQuery = _firestoreDb.Collection("User");
            QuerySnapshot UserQuerySnapshot = await userQuery.GetSnapshotAsync();
            bool find = false;
            foreach (DocumentSnapshot documentSnapshot in UserQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> user = documentSnapshot.ToDictionary();
                    string pseudo = user["pseudo"].ToString();
                    string password2 = user["password"].ToString();
                    /**string json = JsonConvert.SerializeObject(user);
                    User newUser = JsonConvert.DeserializeObject<User>(json);
                    **/
                    if (pseudo == username && password2 == password)
                        find = true;

                }

            }
            if (!find)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenkey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
