using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billingsystem2
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string ItemType { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal DefaultTaxRate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
