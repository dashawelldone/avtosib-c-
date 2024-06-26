using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Devices.Sensors;

namespace Avtosib.Services
{
    public class Itinerary
    {
        public int? id { get; set; }

        public string number { get; set; }
        public ObservableCollection<Busstop> busstops { get; set; }

        public string liststring { get => $" {number}"; }
        public override string ToString() => $"{number}";
    }

    public class Itinerarys
    {
        public static async Task<ObservableCollection<Itinerary>> getAll()
        {
            var result = await App.HttpClient.GetAsync($"{App.API_DOMAIN}/itinerary/list");
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            var itinerarys = JsonConvert.DeserializeObject<ObservableCollection<Itinerary>>(body);
            return itinerarys;
        }

        public static async Task Add(Itinerary itinerary)
        {
            var body = JsonConvert.SerializeObject(itinerary);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/itinerary/add", httpContent);

        }

        public static async Task Update(Itinerary itinerary)
        {
            var body = JsonConvert.SerializeObject(itinerary);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/itinerary/update", httpContent);
        }

        public static async Task Delete(Itinerary itinerary)
        {
            var result = await App.HttpClient.DeleteAsync($"{App.API_DOMAIN}/itinerary/delete/{itinerary.id}");
            result.EnsureSuccessStatusCode();
        }
    }
}
