using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace EmailBlockerLib
{
    public static class DummyEmailChecker
    {
        // ---------------------------------------------------------
        // BLOCKED EMAILS
        // ---------------------------------------------------------
        private static readonly HashSet<string> BlockedEmails = new(StringComparer.OrdinalIgnoreCase)
        {
            "mail@test.com",
            "mail@dummy.com",
            "mail@new.com",
            "admin@fake.com",
            "contact@spamdomain.com"
        };

        // ---------------------------------------------------------
        // BLOCKED DOMAINS
        // ---------------------------------------------------------
        private static readonly HashSet<string> BlockedDomains = new(StringComparer.OrdinalIgnoreCase)
        {
            "test.com",
            "dummy.com",
            "fake.com",
            "spamdomain.com",
            "blockthis.com",
            "mail.ru",
            "igurant1.online"
        };

        // ---------------------------------------------------------
        // ALLOWED SAFE DOMAINS (always allowed)
        // ---------------------------------------------------------
        private static readonly HashSet<string> AllowedDomains = new(StringComparer.OrdinalIgnoreCase)
        {
            "gmail.com",
            "yahoo.com",
            "outlook.com",
            "hotmail.com",
            "novadule.com",
            "protonmail.com",
            "icloud.com",
            "aol.com",
            "live.com",
            "msn.com"
        };

        // ---------------------------------------------------------
        // BLOCKED EMAIL PATTERNS
        // ---------------------------------------------------------
        private static readonly List<Regex> BlockedPatterns = new()
        {
            new Regex(@"@dummy\.com$", RegexOptions.IgnoreCase),
            new Regex(@"@test\.com$", RegexOptions.IgnoreCase),
            new Regex(@"@fake\.", RegexOptions.IgnoreCase)
        };

        // ---------------------------------------------------------
        // BLOCKED IP Rules (Single IP + CIDR)
        // ---------------------------------------------------------
        private static readonly List<string> BlockedIPRules = new()
        {
            "192.168.1.100",
            "10.0.0.5",
            "172.16.0.0/24"
        };

        // IP Ranges
        private static readonly List<(string StartIP, string EndIP)> BlockedIPRanges = new()
        {
            ("192.168.1.1", "192.168.1.255"),
            ("10.0.0.1", "10.0.0.50")
        };

        // =========================================================
        // MAIN LOGIC
        // =========================================================
        public static bool IsBlocked(string email)
        {
            email = email.Trim().ToLower();
            var domain = email.Split('@')[1];
            string ip = GetLocalIPAddress();
            string hostName = GetHostName();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Logging function
            void LogBlocked(string reason)
            {
                Console.WriteLine($"❌ BLOCKED: {reason}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Domain: {domain}");
                Console.WriteLine($"Host: {hostName}");
                Console.WriteLine($"IP: {ip}");
                Console.WriteLine($"Time: {time}");
                Console.WriteLine(new string('-', 60));
            }

            // 1️⃣ Allowed domains always pass (override every rule)
            if (AllowedDomains.Contains(domain))
            {
                return false;
            }

            // 2️⃣ Exact Email Block
            if (BlockedEmails.Contains(email))
            {
                LogBlocked("Exact Email Block");
                return true;
            }

            // 3️⃣ Blocked Domain Check
            if (BlockedDomains.Contains(domain))
            {
                LogBlocked("Blocked Domain");
                return true;
            }

            // 4️⃣ Pattern Block Check
            if (BlockedPatterns.Any(p => p.IsMatch(email)))
            {
                LogBlocked("Pattern Match Block");
                return true;
            }

            // 5️⃣ IP Restriction
            if (IsIPBlocked(ip))
            {
                LogBlocked("IP Blocked by Rule/Range/CIDR");
                return true;
            }

            // 6️⃣ DNS Check
            if (!IsDomainValid(domain))
            {
                LogBlocked("Invalid or Non-Resolvable Domain");
                return true;
            }

            return false; // ALLOWED
        }

        // ---------------------------------------------------------
        // IP BLOCK CHECKING
        // ---------------------------------------------------------
        public static bool IsIPBlocked(string ip)
        {
            foreach (string rule in BlockedIPRules)
            {
                // Single IP
                if (!rule.Contains("-") && !rule.Contains("/"))
                {
                    if (ip == rule) return true;
                }

                // CIDR
                if (rule.Contains("/"))
                {
                    if (IsInCIDRRange(ip, rule)) return true;
                }
            }

            // IP Ranges
            if (IsIPInRange(ip)) return true;

            return false;
        }

        private static bool IsIPInRange(string ip)
        {
            return BlockedIPRanges.Any(r => IsWithinRange(ip, r.StartIP, r.EndIP));
        }

        private static bool IsWithinRange(string ip, string startIP, string endIP)
        {
            var ipParts = ip.Split('.').Select(int.Parse).ToArray();
            var startParts = startIP.Split('.').Select(int.Parse).ToArray();
            var endParts = endIP.Split('.').Select(int.Parse).ToArray();

            for (int i = 0; i < 4; i++)
            {
                if (ipParts[i] < startParts[i] || ipParts[i] > endParts[i])
                    return false;
            }

            return true;
        }

        private static bool IsInCIDRRange(string ip, string cidr)
        {
            var parts = cidr.Split('/');
            uint baseIP = ToUInt(parts[0]);
            uint mask = uint.MaxValue << (32 - int.Parse(parts[1]));

            return (ToUInt(ip) & mask) == (baseIP & mask);
        }

        private static uint ToUInt(string ip)
        {
            return (uint)ip.Split('.')
                .Select(byte.Parse)
                .Aggregate(0, (acc, part) => (acc << 8) + part);
        }

        // ---------------------------------------------------------
        // DNS CHECK
        // ---------------------------------------------------------
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

        // ---------------------------------------------------------
        // HOST & IP INFO
        // ---------------------------------------------------------
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }
    }
}
