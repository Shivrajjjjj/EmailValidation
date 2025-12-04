using Microsoft.AspNetCore.Mvc;
using EmailValidation.Models;
using EmailBlockerLib;
using System;

namespace EmailValidation.Controllers
{
    public class ContactController : Controller
    {
        private static readonly List<ContactModel> SubmittedForms = new();
        private static readonly List<BlockedEmailInfo> BlockedEmailDetails = new();

        // GET
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        // POST: Submit (THIS MATCHES YOUR FORM)
        [HttpPost]
        [HttpPost]
        public IActionResult Submit(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "❌ Invalid form details.";
                TempData["Status"] = "danger";

                ViewBag.BlockedEmailDetails = BlockedEmailDetails;
                return View("Index", model);
            }

            string email = model.Email.Trim().ToLower();
            string domain = email.Split('@')[1];

            string host = DummyEmailChecker.GetHostName();
            string ip = DummyEmailChecker.GetLocalIPAddress();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            bool isBlocked = DummyEmailChecker.IsBlocked(email);

            if (isBlocked)
            {
                // Store in list for table
                BlockedEmailDetails.Add(new BlockedEmailInfo
                {
                    Email = email,
                    Domain = domain,
                    HostName = host,
                    IPAddress = ip,
                    TriggerTime = time,
                    Reason = "Blocked by rule"
                });

                TempData["Message"] = "❌ Email Blocked!";
                TempData["Status"] = "danger";

                ViewBag.BlockedEmailDetails = BlockedEmailDetails;
                return View("Index", new IndexViewModel());
            }

            TempData["Message"] = "✔ Email Submitted Successfully!";
            TempData["Status"] = "success";

            ViewBag.BlockedEmailDetails = BlockedEmailDetails;
            return View("Index", new IndexViewModel());
        }


    }
}
