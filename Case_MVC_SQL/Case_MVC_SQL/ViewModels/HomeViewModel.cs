using Case_MVC_SQL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case_MVC_SQL.ViewModels
{
    public class HomeViewModel
    {
        public List<CreditCard> AllCreditCards { get; set; }

        public List<string> AllCardTypes { get; set; }

        [Required]
        public string NewCardType { get; set; }
        [Required]
        public string NewCardNumber { get; set; }
        [Required]
        public int NewExpMonth { get; set; }
        [Required]
        public int NewExpYear { get; set; }

        public PagingViewModel PagingViewModel { get; set; } = new PagingViewModel();
    }
}
