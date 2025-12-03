using EmailBlockerLib;

namespace EmailValidation.Services
{
    public class EmailBlockService
    {
        public bool CheckEmail(string email)
        {
            return DummyEmailChecker.IsBlocked(email);
        }
    }
}
