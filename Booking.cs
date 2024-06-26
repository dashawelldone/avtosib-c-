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
    public class Booking
    {
        public int? id { get; set; }
        public  string date { get; set; }
        public int schedulerowId { get; set; }
        public int clientId { get; set; }

        public string liststring { get => $" {date}, {schedulerowId}, {clientId}"; }
    }

    public class Bookings
    {
        public static async Task<ObservableCollection<Booking>> getAll()
        {
            var result = await App.HttpClient.GetAsync($"{App.API_DOMAIN}/booking/list");
            result.EnsureSuccessStatusCode();
            var body = await result.Content.ReadAsStringAsync();
            var bookings = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(body);
            return bookings;
        }

        public static async Task Add(Booking booking)
        {
            var body = JsonConvert.SerializeObject(booking);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/booking/add", httpContent);

        }

        public static async Task Update(Booking booking)
        {
            var body = JsonConvert.SerializeObject(booking);

            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var result = await App.HttpClient.PostAsync($"{App.API_DOMAIN}/booking/update", httpContent);
        }

        public static async Task Delete(Booking booking)
        {
            var result = await App.HttpClient.DeleteAsync($"{App.API_DOMAIN}/booking/delete/{booking.id}");
            result.EnsureSuccessStatusCode();
        }
    }
}
