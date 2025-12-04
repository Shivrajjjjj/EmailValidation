using EmailBlockerLib;
using EmailValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


public class BlockedEmailsController : Controller
{
    public IActionResult Index()
    {
        // Example data, in real scenario fetch from log/storage
        ViewBag.SubmittedFormsDetails = new List<BlockedEmailViewModel>
    {
        new BlockedEmailViewModel
        {
            Email = "user@test.com",
            Domain = "test.com",
            Host = "host1",
            IPAddress = "192.168.1.50",
            TriggerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Reason = "Exact Email Blocked"
        }
    };

        ViewBag.BlockedEmailDetails = new List<BlockedEmailViewModel>
    {
        new BlockedEmailViewModel
        {
            Email = "admin@fake.com",
            Domain = "fake.com",
            Host = "host2",
            IPAddress = "10.0.0.5",
            TriggerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Reason = "Blocked Domain"
        }
    };

        return View();
    }

}
