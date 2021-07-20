using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DealershipPlatformApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DealerLead;

namespace DealershipPlatformApp.Controllers
{
    //ED- this tag says everything in HomeController is only Viewable to user's who are authorized
    // [Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DealerLeadDBContext _context;

        public HomeController(ILogger<HomeController> logger, DealerLeadDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.NeedToRegister = false;

            //Basically I will get the oid using the getOID;
            ////do a SQL statement to check the DealerLeadUsers table to see if the user is already there, then I will send them to a Registration page to register if they're not in the database

            if (User.Identity.IsAuthenticated)
            {
                if (!CheckIfUserIsInDB())
                {
                    ViewBag.NeedToRegister = true;
                    //RedirectToAction("Registration");
                }
            }
            
            return View();
        }
        [AllowAnonymous]
        public IActionResult Registration()
        {
            //Basically I will get the oid using the getOID;
            ////do a SQL statement to check the DealerLeadUsers table to see if the user is already there, then I will send them to a Registration page to register if they're not in the database
           CreateUserInDB();

           return RedirectToAction("Index");
        }

        private Guid GetOID()
        {
            // var guid = this.User.Claims.ToList().ElementAt(2);//.ToString();
             return new Guid( this.User.Claims.ToList().ElementAt(2).ToString().Split(":")[2].Trim());
            //return DealerLead.Web.Models.IdentityHelper.GetAzureOIDToken();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        //[AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool CheckIfUserIsInDB() {
            var oid = GetOID();
            if (_context.DealerLeadUser.FirstOrDefault(x => x.AzureADId == oid)== null) {
                return false;
            }
            else {
                return true;
            }
        }
        public void CreateUserInDB() {
            DealerLeadUser dealerLead = new DealerLeadUser();
            dealerLead.AzureADId=GetOID();
            _context.DealerLeadUser.Add(dealerLead);
            _context.SaveChanges();
        }
    }
}
