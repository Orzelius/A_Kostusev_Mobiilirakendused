using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SecondProject.Core {
    public class DataService {

        public static async Task<dynamic> GetDataService(string query) {
            HttpClient Client = new HttpClient();
            var response = await Client.GetStringAsync(query);

            dynamic data = null;
            if(response != null) {
                data = JsonConvert.DeserializeObject<WeatherInfo>(response);
            }
            return (data);
        }
    }
}
