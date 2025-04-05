using Inventory.Domain.Shared;
using Inventory.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.DomainModel.Config
{
    internal class TransactionConfig : IEntityTypeConfiguration<Transaction>,
        IEntityTypeConfiguration<TransactionItem>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatorId)
                .HasColumnName("userCreatorId");

            builder.Property(x => x.Id)
                .HasColumnName("transactionId");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creationDate");

            builder.Property(x => x.CompletedDate)
                .HasColumnName("completedDate");

            builder.Property(x => x.CancelDate)
                 .HasColumnName("cancelDate");

            var typeConverter = new ValueConverter<TransactionType, string>(
                typeEnumValue => typeEnumValue.ToString(),
                type => (TransactionType)Enum.Parse(typeof(TransactionType), type)
            );

            builder.Property(x => x.Type)
                 .HasConversion(typeConverter)
                 .HasColumnName("transactionType");


            var statusConverter = new ValueConverter<TransactionStatus, string>(
                statusEnumValue => statusEnumValue.ToString(),
                status => (TransactionStatus)Enum.Parse(typeof(TransactionStatus), status)
            );

            builder.Property(x => x.Status)
                 .HasConversion(statusConverter)
                 .HasColumnName("status");

            var costConverter = new ValueConverter<CostValue, decimal>(
                costValue => costValue.Value,
                cost => new CostValue(cost)
            );

            builder.Property(x => x.TotalCost)
                .HasColumnName("totalCost")
                .HasConversion(costConverter);

            builder.HasMany(typeof(TransactionItem), "_items");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Items);
        }

        public void Configure(EntityTypeBuilder<TransactionItem> builder)
        {
            builder.ToTable("transactionItem");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("transactionItemId");

            builder.Property(x => x.ItemId)
                .HasColumnName("itemId");

            var quantityConverter = new ValueConverter<TransactionQuantity, int>(
                quantityValue => quantityValue.Value,
                quantity => new TransactionQuantity(quantity)
            );

            builder.Property(x => x.Quantity)
                .HasColumnName("quantity")
                .HasConversion(quantityConverter);

            var costConverter = new ValueConverter<CostValue, decimal>(
                costValue => costValue.Value,
                cost => new CostValue(cost)
            );

            builder.Property(x => x.UnitaryCost)
                .HasColumnName("unitaryCost")
                .HasConversion(costConverter);

            builder.Property(x => x.SubTotal)
                .HasColumnName("subTotal")
                .HasConversion(costConverter);
        }
    }
}
