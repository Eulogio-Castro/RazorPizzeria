using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorPizzeria.Models;

namespace RazorPizzeria.TableMappings
{

    public class CustomersTableMapping : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey("CustomerID");
            builder.Property(c => c.CustomerID).HasColumnName("CustomerID").IsRequired();
            builder.Property(c => c.CustomerName).HasColumnName("CustomerName").IsRequired();
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.Property(c => c.AddressLine1).HasColumnName("AddressLine1");
            builder.Property(c => c.AddressLine2).HasColumnName("AddressLine2");
            builder.Property(c => c.City).HasColumnName("City");
            builder.Property(c => c.State).HasColumnName("State");
            builder.Property(c => c.PostalCode).HasColumnName("PostalCode");
        }
    }
}
