using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingMeetings.Web.Models;
using SchedulingMeetings.Web.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly IMapper _mapper;

        public UserAdminController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var userAdminService = new UserAdminService();
            var users = await userAdminService.GetAllUsers
            ().Result.Content.ReadAsAsync<List<UserAdmin>>();
            return View(users);
        }

        public IActionResult Login()
        {
            return View();
        }

        [Route("adduser")]
        public IActionResult AddUser()
        {
            return View("create", new UserAdmin());
        }

        [HttpPost]
        [Route("createuser")]
        public async Task<IActionResult> CreateUser(UserAdmin userAdmin)
        {
            var userAdminService = new UserAdminService();
            var createUser = await userAdminService.AddUsers(userAdmin);
            return RedirectToAction("Index", createUser);
        }

        [HttpGet]
        [Route("updateuser/{id}")]
        public IActionResult EditUser(Guid id)
        {
            var userAdminService = new UserAdminService();
            var user = userAdminService.GetByUsersIdentity
                (id).Result.Content.ReadAsAsync<UserAdmin>().Result;
            return View("Edit", user);
        }

        [HttpPost]
        [Route("updateuser/{id}")]
        public async Task<IActionResult> EditUser(Guid id, UserAdmin userAdmin)
        {
            var userAdminService = new UserAdminService();
            var update = await userAdminService.EditUsers(id, userAdmin);
            return RedirectToAction("Index", update);
        }

        [Route("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var userAdminService = new UserAdminService();
            await userAdminService.DeleteUsers(id);
            return RedirectToAction("Index");
        }
    }
}