using System.ComponentModel.DataAnnotations;

namespace AlbumApplication.ValidationsClasses
{
    public class PasswordValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            string password = value.ToString();

            if ( password.Length < 8)
                return false;

            int upperCaseCount = password.Count(c => char.IsUpper(c));
            if (upperCaseCount < 2)
                return false;

            int lowerCaseCount = password.Count(c => char.IsLower(c));
            if (lowerCaseCount < 3)
                return false;
            
            int specialCharCount = password.Count(c => "!:+*".Contains(c));
            if (specialCharCount < 2)
                return false;

            return true;
        }
    }
}
