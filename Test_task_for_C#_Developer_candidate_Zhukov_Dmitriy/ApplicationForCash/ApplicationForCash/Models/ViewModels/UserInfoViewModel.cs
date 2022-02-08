using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForCash.Models.ViewModels
{
    public class UserInfoViewModel
    {
        public User User { get; set; }
        public List<CashRequest> CashRequests { get; set; }
    }
}
