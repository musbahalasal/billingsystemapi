using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billingsystem2
{
    public abstract class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public string ItemName { get; set; }= string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public decimal TaxRate { get; set; }
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public virtual decimal GetSubTotal()
        {
            decimal baseTotal = UnitPrice * Quantity;
            return baseTotal + (baseTotal * TaxRate);
        }
    }
}
