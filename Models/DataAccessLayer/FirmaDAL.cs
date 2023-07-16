using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer
{
    public class FirmaDAL
    {
        private string URL;
        HttpClient client = new HttpClient();

        #region Konsturktori

        //1. OsobaDAL dal = new OsobaDAL(string)/OsobaDAL()
        //2. Funkcije
        public FirmaDAL(string _URL)
        {
            URL = _URL;
        }
        public FirmaDAL()
        {
            URL = "http://localhost:51756/api/Firma/";
        }

        #endregion


        #region Funkcije
        public async Task<List<Firma>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            var lista = JsonConvert.DeserializeObject<List<Firma>>(json);

            return lista;
        }
        #endregion
    }
}
