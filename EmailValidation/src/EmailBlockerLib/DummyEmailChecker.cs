using System.Text.RegularExpressions;

namespace EmailBlockerLib;

public static class DummyEmailChecker
{
    // List of dummy emails not allowed
    private static readonly HashSet<string> BlockedEmails = new(StringComparer.OrdinalIgnoreCase)
    {
        "mail@test.com",
        "mail@dummy.com",
        "mail@new.com"
    };

    // List of blocked email patterns (e.g., domains)
    private static readonly List<Regex> BlockedPatterns = new()
    {
        new Regex(@"@dummy\.com$", RegexOptions.IgnoreCase),
        new Regex(@"@test\.com$", RegexOptions.IgnoreCase)
    };

    public static bool IsBlocked(string email)
    {
        email = email.Trim().ToLower();

        // Check exact matches
        if (BlockedEmails.Contains(email))
        {
            return true;
        }

        // Check patterns
        return BlockedPatterns.Any(pattern => pattern.IsMatch(email));
    }
}