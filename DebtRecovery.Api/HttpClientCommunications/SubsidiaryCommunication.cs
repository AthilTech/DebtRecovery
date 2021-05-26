using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using DebtRecovery.Api.DTOs.ForeignDTOs;


namespace DebtRecovery.Api.HttpClientCommunications
{
    public class SubsidiaryCommunication
    {
        HttpClient _httpClient = new HttpClient();
        public SubsidiaryDTO GetSubsidiaryById(Guid? idsubsidiary)
        {
       

            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44384/api/Subsidiary/" + idsubsidiary).Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SubsidiaryDTO>(responseBody);
        }
        



        public SubsidiaryDTO GetAllSubsidiaries()
        {

            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44384/api/Subsidiary").Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SubsidiaryDTO>(responseBody);
        }



      
    

    }
}
