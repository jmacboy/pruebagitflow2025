using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.StoredModel.Entities
{
    [Table("item")]
    internal class ItemStoredModel
    {
        [Key]
        [Column("itemId")]
        public Guid Id { get; set; }

        [Column("itemName")]
        [StringLength(250)]
        [Required]
        public string ItemName { get; set; }

        [Column("stock")]
        [Required]      
        public int Stock { get; set; }

        [Column("unitaryCost", TypeName = "decimal(18,2)")]
        [Required]
        public decimal UnitaryCost { get; set; }
    }
}
