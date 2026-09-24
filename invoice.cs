using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billingsystem2
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string? Notes { get; set; }

       //leave it for tmr 
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public decimal TotalAmount { get; set; }
        public int Id { get; set; }
    }
}
