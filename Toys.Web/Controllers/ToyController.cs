using System;
using Microsoft.AspNetCore.Mvc;
using Toys.Web.Controllers;
using Toys.Data;
using Toys.Data.Data;
using Toys.Data.Repositories;
using Toys.Web;
using Toys.Web.Services;

namespace Toys.Web.Controllers
{
    public class ToyController : Controller
    {
        private readonly IToyService toyService;

        public ToyController(IToyService toyService)
        {
            this.toyService = toyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(toyService.GetToyPage(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(toyService.GetToyPage(currentPageIndex));
        }
    }
}
