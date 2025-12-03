using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using DnsClient;

namespace EmailValidation.Services
{
    public class AdvancedEmailValidator
    {
        public bool IsValidFormat(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public string GetDomain(string email)
        {
            return email.Split('@')[1].ToLower();
        }

        public bool IsDomainValid(string domain)
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

        public bool HasMxRecords(string domain)
        {
            try
            {
                var lookup = new LookupClient();
                var result = lookup.Query(domain, QueryType.MX);

                return result.Answers.MxRecords().Any();
            }
            catch
            {
                return false;
            }
        }

        public string ValidateEmail(string email)
        {
            if (!IsValidFormat(email))
                return "Invalid email format";

            string domain = GetDomain(email);

            if (!IsDomainValid(domain))
                return $" Domain does not exist: {domain}";

            if (!HasMxRecords(domain))
                return $"No mail server (MX record) found for: {domain}";

            return " Email format and domain are valid";
        }
    }
}
