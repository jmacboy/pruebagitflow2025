using Inventory.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.DomainModel.Config;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("userId");

        builder.Property(x => x.FullName)
            .HasColumnName("fullName");

        builder.Ignore("_domainEvents");
        builder.Ignore(x => x.DomainEvents);

    }
}
