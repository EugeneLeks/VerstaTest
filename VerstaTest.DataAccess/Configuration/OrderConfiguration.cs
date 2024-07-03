using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerstaTest.DataAccess.Entities;

namespace VerstaTest.DataAccess.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddresserCity).IsRequired();
            builder.Property(x => x.AddresserAddress).IsRequired();
            builder.Property(x => x.RecipientCity).IsRequired();
            builder.Property(x => x.RecipientAddress).IsRequired();
            builder.Property(x => x.CargoWeight).IsRequired();
            builder.Property(x => x.ReceiveDate).IsRequired();
        }
    }
}
