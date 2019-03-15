using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MessageSending.Models
{
    public class ClientMessage
    {
        [Required(ErrorMessage = "Заполните поле")]
        public string Message { get; set; }
    }
}