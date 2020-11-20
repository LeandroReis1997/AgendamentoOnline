using SchedulingMeetings.Web.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Service
{
    public class SchedulingService
    {
        private string BASE_URL = "https://localhost:44355/webapi/scheduling/";

        public Task<HttpResponseMessage> AddRoomScheduling(Scheduling scheduling)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PostAsJsonAsync("create", scheduling);
        }

        public Task<HttpResponseMessage> DeleteRoomScheduling(Guid schedulingIdentity)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.DeleteAsync("delete/" + schedulingIdentity);
        }

        public Task<HttpResponseMessage> EditRoomScheduling(Guid schedulingIdentity, Scheduling scheduling)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PutAsJsonAsync("update/" + schedulingIdentity, scheduling);
        }

        public Task<HttpResponseMessage> GetAllScheduling()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync("getall");
        }

        public Task<HttpResponseMessage> GetByRoomScheduling(string nameRoom)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync($"getbyroomscheduling/{nameRoom}");
        }

        public Task<HttpResponseMessage> GetByschedulingIdentity(Guid schedulingIdentity)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync($"getbyschedulingidentity/{schedulingIdentity}");
        }
    }
}
