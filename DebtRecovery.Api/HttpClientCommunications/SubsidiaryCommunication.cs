using CounterManagement.Domain.ForeignDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CounterManagement.Api.HTTPClientCommunication
{
    public class SubsidiaryCommunication
    {
        HttpClient _httpClient = new HttpClient();
        public SubsidiaryDTO GetSubsidiaryById(Guid? idsubsidiary)
        {

            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:56354/api/Trip/ + idsubsidiary).Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SubsidiaryDTO>(responseBody);
        }



        public SubsidiaryDTO GetAllSubsidiaries()
        {

            HttpResponseMessage response = _httpClient.GetAsync("http://192.168.160.57:8053/GlobalEnergyGateWay/api/subsidiary/subsidiary/").Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SubsidiaryDTO>(responseBody);
        }



      
    

    }
}
