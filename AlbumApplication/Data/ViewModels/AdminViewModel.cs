using AlbumApplication.Data.Classes;
using AlbumApplication.ValidationsClasses;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace AlbumApplication.Data.ViewModels
{
    public class AdminViewModel
    {
        [Required(ErrorMessage = "Username Required")]
        [MinLength(8, ErrorMessage = "Username Must be at least 8 characters!")]
        public string Username { get; set; } = null!;



        [Required(ErrorMessage = "Password Required")]
        [PasswordValidation(ErrorMessage = "The password must be at least 8 characters long. It must contain at least 2 uppercase letters. It must contain at least 3 lower-case letters! Must contain at least 2 of the characters (exclamation), : (colon), +(plus), *(asterisk). (There can be more than one of the same character)")]
        public string Password { get; set; } = null!;



        [Compare("Password", ErrorMessage = "Password Donot Match")]
        [Required(ErrorMessage = "Please Write The Password's Copy")]
        public string PasswordAgain { get; set; } = null;
    }
}
