using System.Text.RegularExpressions;
using System.Net;

namespace EmailBlockerLib
{
    public static class DummyEmailChecker
    {
        private static readonly HashSet<string> BlockedEmails = new(StringComparer.OrdinalIgnoreCase)
        {
            "mail@test.com",
            "mail@dummy.com",
            "mail@new.com",
            "admin@fake.com",
            "contact@spamdomain.com"
        };

        private static readonly HashSet<string> BlockedDomains = new(StringComparer.OrdinalIgnoreCase)
        {
            "test.com",
            "dummy.com",
            "fake.com",
            "spamdomain.com",
            "blockthis.com"
        };

        private static readonly HashSet<string> AllowedDomains = new(StringComparer.OrdinalIgnoreCase)
        {
            "gmail.com",
            "yahoo.com",
            "outlook.com",
            "hotmail.com",
            "novadule.com",
            "protonmail.com",
            "icloud.com"
        };

        private static readonly List<Regex> BlockedPatterns = new()
        {
            new Regex(@"@dummy\.com$", RegexOptions.IgnoreCase),
            new Regex(@"@test\.com$", RegexOptions.IgnoreCase),
            new Regex(@"@fake\.", RegexOptions.IgnoreCase)
        };

        public static bool IsBlocked(string email)
        {
            email = email.Trim().ToLower();

            var domain = email.Split('@')[1];

            // 1️⃣ Exact email block
            if (BlockedEmails.Contains(email))
                return true;

            // 2️⃣ Blocked domain
            if (BlockedDomains.Contains(domain))
                return true;

            // 3️⃣ Pattern block
            if (BlockedPatterns.Any(p => p.IsMatch(email)))
                return true;

            // 4️⃣ Allowed domain explicitly approved
            if (AllowedDomains.Contains(domain))
                return false;

            // 5️⃣ For other domains → validate domain existence
            return !IsDomainValid(domain);
        }

        private static bool IsDomainValid(string domain)
        {
            try
            {
                Dns.GetHostEntry(domain);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
