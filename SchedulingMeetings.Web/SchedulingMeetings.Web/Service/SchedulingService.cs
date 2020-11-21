using Newtonsoft.Json;
using SchedulingMeetings.Web.DTO.Scheduling;
using SchedulingMeetings.Web.HttpClientAddres;
using SchedulingMeetings.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Service
{
    public class SchedulingService
    {

        public async Task<SchedulingDTO> AddRoomScheduling(SchedulingViewModel scheduling)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync($"scheduling/create", scheduling);
            return JsonConvert.DeserializeObject<SchedulingDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<SchedulingDTO> DeleteRoomScheduling(Guid schedulingIdentity)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync($"scheduling/delete/{schedulingIdentity}");
            return JsonConvert.DeserializeObject<SchedulingDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<SchedulingDTO> EditRoomScheduling(Guid schedulingIdentity, SchedulingViewModel scheduling)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PutAsJsonAsync($"scheduling/update/{schedulingIdentity}", scheduling);
            return JsonConvert.DeserializeObject<SchedulingDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<SchedulingListDTO>> GetAllScheduling()
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("scheduling/");
            return JsonConvert.DeserializeObject<List<SchedulingListDTO>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<SchedulingListDTO>> GetBySchedulingRoomIdentity(Guid roomIdentity)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"scheduling/getbyschedulingroomidentity/{roomIdentity}");
            return JsonConvert.DeserializeObject<IEnumerable<SchedulingListDTO>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<SchedulingListDTO> GetByschedulingIdentity(Guid schedulingIdentity)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"scheduling/{schedulingIdentity}");
            return JsonConvert.DeserializeObject<SchedulingListDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
