using System.Text.RegularExpressions;

namespace Messenger.Validation
{
    public class RegisterModelValidator
    {
        public bool IsUsernameCorrect(string username)
        {
            return !string.IsNullOrEmpty(username);
        }

        private Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public bool IsEmailCorrect(string email)
        {
            Regex validEmailRegex = CreateValidEmailRegex();
            return validEmailRegex.IsMatch(email);
        }

        public bool IsPasswordCorrect(string password)
        {
            return password.Length > 7;
        }
    }
}
