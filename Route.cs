using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Avtosib
{
    public class Route
    {
        public int id { get; set; }
        public int? itineraryId { get; set; }

    }

    public class Routes
    {
        public static async Task<ObservableCollection<Route>> getAll()
        {
            var result = await App.HttpClient.GetAsync($"{App.API_DOMAIN}/route/list");
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            var routes = JsonConvert.DeserializeObject<ObservableCollection<Route>>(body);
            return routes;
        }

        public static async Task Add(Route route) 
        {
            var body = JsonConvert.SerializeObject(route);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/route/add", httpContent);

        }

        public static async Task Update(Route route)
        {
            var body = JsonConvert.SerializeObject(route);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/catalog/update", httpContent);
        }

        public static async Task Delete(Route route)
        {
            var result = await App.HttpClient.DeleteAsync($"{App.API_DOMAIN}/catalog/delete/{route.id}");
            result.EnsureSuccessStatusCode();
        }
    }
}


