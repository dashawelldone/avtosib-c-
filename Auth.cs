using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Avtosib.Services
{
    class ProfileResult
    {
        public Admin UserAdmin { get; set; }
        public Client UserClient { get; set; }
    }
    public class Credentials
    {
        public string phonenumber { get; set; }
        public string password { get; set; }
    }
    class Auth
    {
        public static Admin UserAdmin;
        public static Client UserClient;

        public static async Task<bool> SignIn(string phonenumber, string password)
        {
            var credentials = new Credentials
            {
                phonenumber = phonenumber,
                password = password
            };
            var body = JsonConvert.SerializeObject(credentials);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/auth", httpContent);
            result.EnsureSuccessStatusCode();
            var resultBody = await result.Content.ReadAsStringAsync();
            var profiles = JsonConvert.DeserializeObject<ProfileResult>(resultBody);
            if (profiles.UserAdmin != null) {
                UserAdmin = profiles.UserAdmin;
                return true;
            }
            if (profiles.UserClient != null)
            {
                UserClient = profiles.UserClient;
                return false;
            }
            throw new Exception("Unauthorized");
        }
    }
}
