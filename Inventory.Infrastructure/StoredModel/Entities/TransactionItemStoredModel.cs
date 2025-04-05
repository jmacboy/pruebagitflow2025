using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.StoredModel.Entities
{
    [Table("transactionItem")]
    internal class TransactionItemStoredModel
    {
        [Key]
        [Column("transactionItemId")]
        public Guid Id { get; set; }

        [Required]
        [Column("itemId")]
        public Guid ItemId { get; set; }
        public ItemStoredModel Item { get; set; }


        [Required]
        [Column("transactionId")]
        public Guid TransactionId { get; set; }
        public TransactionStoredModel Transaction { get; set; }


        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("unitaryCost", TypeName = "decimal(18,2)")]
        public decimal UnitaryCost { get; set; }

        [Required]
        [Column("subTotal", TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

    }
}
