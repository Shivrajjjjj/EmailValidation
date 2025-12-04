using System.Collections.Generic;

namespace EmailValidation.Models
{
    public class DashboardViewModel
    {
        public int TotalSubmissions { get; set; }
        public int SuccessfulRegistrations { get; set; }
        public int BlockedEmailAttempts { get; set; }

        public List<ContactModel> SubmittedForms { get; set; } = new();
        public List<string> BlockedEmails { get; set; } = new();

        // Detailed blocked info records
        public List<BlockedEmailInfo> BlockedEmailDetails { get; set; } = new();
    }
}
