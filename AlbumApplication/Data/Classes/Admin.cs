using AlbumApplication.ValidationsClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace AlbumApplication.Data.Classes
{
    public class Admin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; } = null!;



    }
}
