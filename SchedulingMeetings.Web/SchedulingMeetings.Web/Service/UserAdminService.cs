using Newtonsoft.Json;
using SchedulingMeetings.Web.DTO.UserAdmin;
using SchedulingMeetings.Web.HttpClientAddres;
using SchedulingMeetings.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Service
{
    public class UserAdminService
    {
        public async Task<UserAdminDTO> AddUsers(UserAdminViewModel user)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync($"useradmin/create", user);
            return JsonConvert.DeserializeObject<UserAdminDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<UserAdminDTO> DeleteUsers(Guid userIdentity)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync($"useradmin/delete/{userIdentity}");
            return JsonConvert.DeserializeObject<UserAdminDTO>(await response.Content.ReadAsStringAsync());
        }

        public async  Task<UserAdminDTO> EditUsers(Guid usersIdentity, UserAdminViewModel user)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PutAsJsonAsync($"useradmin/update/{usersIdentity}", user);
            return JsonConvert.DeserializeObject<UserAdminDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<UserAdminListDTO>> GetAllUsers()
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"useradmin/");
            return JsonConvert.DeserializeObject<List<UserAdminListDTO>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<UserAdminListDTO> GetByEmail(string email)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"useradmin/getbyemail/{email}");
            return JsonConvert.DeserializeObject<UserAdminListDTO>(await response.Content.ReadAsStringAsync());
        }
        //public Task<HttpResponseMessage> Login(string email, string senha)
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri(BASE_URL);
        //    client.DefaultRequestHeaders.Accept.Add(new
        //        MediaTypeWithQualityHeaderValue("application/json"));
        //    return client.GetAsync($"login/{email}/{senha}");
        //}

        public async Task<UserAdminListDTO> GetByUsersIdentity(Guid userIdentity)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"useradmin/{userIdentity}");
            return JsonConvert.DeserializeObject<UserAdminListDTO>(await response.Content.ReadAsStringAsync());
        }      
    }
}
