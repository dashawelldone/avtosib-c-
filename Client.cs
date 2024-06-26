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
using System.Xml.Linq;
using Windows.Devices.Sensors;

namespace Avtosib
{
    public class Client
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phonenumber { get; set; }
        public string password { get; set; }
        public string liststring { get => $"{id}, {name}, {surname}, {phonenumber}"; }

}
public class Clients
{
        public static Client Profile { get; private set; }
        public static async Task<ObservableCollection<Client>> getAll()
        {
            var result = await App.HttpClient.GetAsync($"{App.API_DOMAIN}/client/list");
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            var clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(body);
            return clients;
        }

        public static async Task Add(Client client)
        {
            var body = JsonConvert.SerializeObject(client);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/client/add", httpContent);
        }

        public static async Task Update(Client client)
        {
            var body = JsonConvert.SerializeObject(client);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/client/update", httpContent);
        }

        public static async Task Delete(Client client)
        {
            var result = await App.HttpClient.DeleteAsync($"{App.API_DOMAIN}/client/delete/{client.id}");
            result.EnsureSuccessStatusCode();
        }

        public static void Logout()
        {
            Clients.Profile = null;
        }
    }
}



