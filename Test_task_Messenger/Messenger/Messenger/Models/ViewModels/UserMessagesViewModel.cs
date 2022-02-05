using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models.ViewModels
{
    public class UserMessagesViewModel
    {
        public User User { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
