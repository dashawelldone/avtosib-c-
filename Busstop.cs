using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Avtosib.Services
{

    public class Busstop
    {
        public int? id { get; set; }
        public string name { get; set; }
        public int? itineraryId { get; set; }
        public string liststring { get => $"{name}"; }

    }

    public class Busstops
    {
        public static async Task<ObservableCollection<Busstop>> getAll()
        {
            var result = await App.HttpClient.GetAsync($"{App.API_DOMAIN}/busstop/list");
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            var busstops = JsonConvert.DeserializeObject<ObservableCollection<Busstop>>(body);
            return busstops;
        }

        public static async Task Add(Busstop busstop)
        {
            var body = JsonConvert.SerializeObject(busstop);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/busstop/add", httpContent);

        }

        public static async Task Update(Busstop busstop)
        {
            var body = JsonConvert.SerializeObject(busstop);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/busstop/update", httpContent);
        }

        public static async Task Delete(Busstop busstop)
        {
            var result = await App.HttpClient.DeleteAsync($"{App.API_DOMAIN}/busstop/delete/{busstop.id}");
            result.EnsureSuccessStatusCode();
        }
    }
}
