using Newtonsoft.Json;
using SchedulingMeetings.Web.DTO.Room;
using SchedulingMeetings.Web.HttpClientAddres;
using SchedulingMeetings.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Service
{
    public class RoomService
    {
        public async Task<RoomDTO> AddRoom(RoomViewModel room)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync($"room/create", room);
            return JsonConvert.DeserializeObject<RoomDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<RoomDTO> DeleteRoom(Guid roomIdentity)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync($"room/delete/{roomIdentity}");
            return JsonConvert.DeserializeObject<RoomDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<RoomDTO> EditRoom(Guid roomIdentity, RoomViewModel room)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PutAsJsonAsync($"room/update/{roomIdentity}", room);
            return JsonConvert.DeserializeObject<RoomDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<RoomListDTO>> GetAllRoom()
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("room/");
            return JsonConvert.DeserializeObject<IEnumerable<RoomListDTO>>(await response.Content.ReadAsStringAsync());
        }

        public Task<HttpResponseMessage> GetByRoom(string nameRoom)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync($"getbyroom/{nameRoom}");
        }

        public async Task<RoomListDTO> GetByRoomIdentity(Guid roomIdentity)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"room/{roomIdentity}");
            return JsonConvert.DeserializeObject<RoomListDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
