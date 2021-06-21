using System;
using System.Collections.Generic;

#nullable disable

namespace Case_MVC_SQL.Models
{
    public partial class CreditCard
    {
        public int CreditCardId { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
