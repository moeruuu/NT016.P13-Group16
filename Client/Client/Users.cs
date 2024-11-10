using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace exercise3
{
    public class Users
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Fullname")]
        public string FullName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Profilepicture")]
        public byte[] Profilepicture { get; set; }

        [JsonProperty("Bio")]
        public string Bio { get; set; }
    }
}