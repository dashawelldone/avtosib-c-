using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Avtosib.Services
{
    public class Schedulerow
    {
        public int? id { get; set; }
        public string time { get; set; }
        public string routeId { get; set; }
        public string busstopId { get; set; }
        public string liststring { get => $" {routeId}, {busstopId}, {time}" ; }

        public override string ToString() => $"{routeId}, {busstopId}, {time}";
    }

    public class Schedulerows
    {
        public static async Task<ObservableCollection<Schedulerow>> getAll()
        {
            var result = await App.HttpClient.GetAsync($"{App.API_DOMAIN}/schedulerow/list");
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            var schedulerows = JsonConvert.DeserializeObject<ObservableCollection<Schedulerow>>(body);
            return schedulerows;
        }

        public static async Task Add(Schedulerow schedulerow)
        {
            var body = JsonConvert.SerializeObject(schedulerow);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/schedulerow/add", httpContent);

        }

        public static async Task Update(Schedulerow schedulerow)
        {
            var body = JsonConvert.SerializeObject(schedulerow);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/schedulerow/update", httpContent);
        }

        public static async Task Delete(Schedulerow schedulerow)
        {
            var result = await App.HttpClient.DeleteAsync($"{App.API_DOMAIN}/schedulerow/delete/{schedulerow.id}");
            result.EnsureSuccessStatusCode();
        }
    }
}

       