using Inventory.Domain.Items;
using Inventory.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.DomainModel.Config
{
    internal class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("item");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasColumnName("itemId");

            builder.Property(x => x.Stock)
                .HasColumnName("stock");

            builder.Property(x => x.Name)
                .HasColumnName("itemName");

            var converter = new ValueConverter<CostValue, decimal>(
                costValue => costValue.Value, // CostValue to decimal
                cost => new CostValue(cost) // decimal to CostValue
            );

            builder.Property(x => x.UnitaryCost)
                .HasConversion(converter)
                .HasColumnName("unitaryCost");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);

        }
    }
}
