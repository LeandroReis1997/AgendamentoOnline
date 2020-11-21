using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingMeetings.Web.Service;
using SchedulingMeetings.Web.ViewModels;
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
            ().Result.Content.ReadAsAsync<List<UserAdminViewModel>>();
            return View(users);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]UserAdminViewModel userAdmin)
        {
            var userAdminService = new UserAdminService();
            var clienteDB = userAdminService.Login(userAdmin.Email, userAdmin.Password);


            if (clienteDB != null)
            {
                //_loginCliente.Login(clienteDB);

                return new RedirectResult(Url.Action(nameof(HomeController)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário não encontrado, verifique o e-mail e senha digitado!";
                return View();
            }
        }

        [Route("adduser")]
        public IActionResult AddUser()
        {
            return View("create", new UserAdminViewModel());
        }

        [HttpPost]
        [Route("createuser")]
        public async Task<IActionResult> CreateUser(UserAdminViewModel userAdmin)
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
                (id).Result.Content.ReadAsAsync<UserAdminViewModel>().Result;
            return View("Edit", user);
        }

        [HttpPost]
        [Route("updateuser/{id}")]
        public async Task<IActionResult> EditUser(Guid id, UserAdminViewModel userAdmin)
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