using EmailBlockerLib;
using EmailValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailValidation.Controllers;

public class ContactController : Controller
{
    private static readonly List<ContactModel> SubmittedForms = new();
    private static readonly List<string> BlockedEmails = new();

    public IActionResult Index()
    {
        return View(new ContactModel());
    }

    [HttpPost]
    public IActionResult Submit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        if (DummyEmailChecker.IsBlocked(model.Email))
        {
            BlockedEmails.Add(model.Email);
            return RedirectToAction("BlockedEmail");
        }

        SubmittedForms.Add(model);
        return RedirectToAction("FormSubmitted");
    }

    public IActionResult FormSubmitted()
    {
        return View();
    }

    public IActionResult BlockedEmail()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        var dashboardData = new DashboardViewModel
        {
            TotalSubmissions = SubmittedForms.Count + BlockedEmails.Count,
            SuccessfulRegistrations = SubmittedForms.Count,
            BlockedEmailAttempts = BlockedEmails.Count,
            SubmittedForms = SubmittedForms,
            BlockedEmails = BlockedEmails
        };

        return View(dashboardData);
    }
}