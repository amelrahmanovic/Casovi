using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer
{
    public class OsobaDAL
    {
        private string URL;
        HttpClient client = new HttpClient();
        public OsobaDAL(string _URL)
        {
            URL = _URL;
        }
        public async Task<List<Osoba>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Osoba>>(json);
        }
        public async Task<Osoba> GetByIdAsync(int id)
        {
            var request2 = new HttpRequestMessage(HttpMethod.Get, URL + id.ToString());
            var response2 = await client.SendAsync(request2);
            response2.EnsureSuccessStatusCode();
            string json2 = await response2.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Osoba>(json2);
        }
        public async Task
InsertAsync(Osoba o)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL);
            var content = JsonConvert.SerializeObject(o);
            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //Console.WriteLine("Rezultat:");
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
        public async void UpdateAsync(Osoba o)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + o.Id.ToString());
            var contentjson = JsonConvert.SerializeObject(o);
            var content = new StringContent(contentjson, null, "application/json");
            request.Content = content;
            var response5 = await client.SendAsync(request);
            response5.EnsureSuccessStatusCode();

            //Console.WriteLine("Poruka");
            //Console.WriteLine(await response5.Content.ReadAsStringAsync());
        }
        public async Task
DeleteAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, URL + id.ToString());
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

    }
}
