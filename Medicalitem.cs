using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billingsystem2
{
    public class MedicalItem:InvoiceItem
    {
        public string MedicalApprovalcode { get; set; } = string.Empty;
    }
}
