using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Transactions.GetTransaccionById
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime CancelDate { get; set; }
        public string Type { get; set; }

        public decimal TotalCost { get; set; }
    }
}
