using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Логин:")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль:")]
        public string Password { get; set; }

        public int? RoleID { get; set; }
        public Role Role { get; set; }
    }
}
