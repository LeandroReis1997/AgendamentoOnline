﻿using SchedulingMeetings.Web.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Service
{
    public class RoomService 
    {
        private string BASE_URL = "https://localhost:44355/webapi/room/";

        public Task<HttpResponseMessage> AddRoom(Room room)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PostAsJsonAsync("create", room);
        }

        public Task<HttpResponseMessage> DeleteRoom(Guid roomIdentity)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.DeleteAsync("delete/" + roomIdentity);
        }

        public Task<HttpResponseMessage> EditRoom(Guid roomIdentity, Room room)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PutAsJsonAsync("update/" + roomIdentity, room);
        }

        public Task<HttpResponseMessage> GetAllRoom()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync("getall");
        }

        public Task<HttpResponseMessage> GetByRoom(string nameRoom)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync($"getbyroom/{nameRoom}");
        }

        public Task<HttpResponseMessage> GetByRoomIdentity(Guid roomIdentity)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync($"getbyroomidentity/{roomIdentity}");
        }
    }
}
