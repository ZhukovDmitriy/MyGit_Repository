using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForCash.Models.ViewModels
{
    public class CashRequestViewModel
    {
        public User User { get; set; }
        public CashRequest CashRequest { get; set; }
        public int SelectedDepartmentID { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public int Amount { get; set; }
        public string SelectedCurrency { get; set; }
        public List<string> Currency { get; set; }
    }
}
