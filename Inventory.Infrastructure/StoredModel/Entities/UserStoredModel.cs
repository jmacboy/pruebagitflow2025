using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.StoredModel.Entities;

[Table("user")]
internal class UserStoredModel
{
    [Key]
    [Column("userId")]
    public Guid Id { get; set; }

    [Column("fullName")]
    [StringLength(250)]
    [Required]
    public string FullName { get; set; }
}
