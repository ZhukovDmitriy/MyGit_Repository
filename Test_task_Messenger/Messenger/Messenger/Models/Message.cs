using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
