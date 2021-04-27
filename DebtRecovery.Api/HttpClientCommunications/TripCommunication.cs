using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using DebtRecovery.Api.DTOs.ForeignDTOs;


namespace DebtRecovery.Api.HttpClientCommunications
{
    public class TripCommunication
    {
        HttpClient _httpClient = new HttpClient();
        public TripDTO GetTripById(Guid? idtrip)
        {

            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:56354/api/Trip/" + idtrip).Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TripDTO>(responseBody);
        }



        public TripDTO GetAllTrips()
        {

            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:56354/api/Trip").Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TripDTO>(responseBody);
        }






    }
}
