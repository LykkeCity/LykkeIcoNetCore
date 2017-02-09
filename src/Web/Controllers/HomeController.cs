﻿using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILykkeIcoRegistrationsRepository _lykkeIcoRegistrationsRepository;

        public HomeController(ILykkeIcoRegistrationsRepository lykkeIcoRegistrationsRepository)
        {
            _lykkeIcoRegistrationsRepository = lykkeIcoRegistrationsRepository;
        }

        public IActionResult Index()
        {

            if (!Request.IsHttps)
                return Redirect("https://"+Request.Host);

            return View();
        }

        [HttpPost("/Submit")]
        public async Task<IActionResult> Submit(IcoRegistrationModel model)
        {

            model.Ip = HttpContext.Connection.RemoteIpAddress.ToString();
            await _lykkeIcoRegistrationsRepository.RegisterAsync(model);
            return RedirectToAction("Success");

        }

        [HttpGet("/Success")]
        public IActionResult Success()
        {
            return View();
        }

    }
}
