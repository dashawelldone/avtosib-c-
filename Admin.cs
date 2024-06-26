using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using Avtosib;
using System.Net.Http;
using System.Net;

namespace Avtosib
{
    public class Admin
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phonenumber { get; set; }
        public string password { get; set; }

        public string liststring { get => $"{id}, {name}, {surname}, {phonenumber}"; }

    }


    public class Admins
    {
        public static async Task<ObservableCollection<Admin>> getAll()
        {
            var result = await App.HttpClient.GetAsync($"{App.API_DOMAIN}/admin/list");
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            var admins = JsonConvert.DeserializeObject<ObservableCollection<Admin>>(body);
            return admins;
        }

        public static async Task Add(Admin admin)
        {
            var body = JsonConvert.SerializeObject(admin);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/admin/add", httpContent);
        }

        public static async Task Update(Admin admin)
        {
            var body = JsonConvert.SerializeObject(admin);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/admin/update", httpContent);
        }

        public static async Task Delete(Admin admin)
        {
            var result = await App.HttpClient.DeleteAsync($"{App.API_DOMAIN}/admin/delete/{admin.id}");
            result.EnsureSuccessStatusCode();
        }

      

    }
}


