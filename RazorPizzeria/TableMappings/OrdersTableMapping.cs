using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorPizzeria.Models;

namespace RazorPizzeria.TableMappings
{

    public class OrdersTableMapping : IEntityTypeConfiguration<PizzaOrderModel>
    {
        public void Configure(EntityTypeBuilder<PizzaOrderModel> builder)
        {
            builder.ToTable("Orders");
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.PizzaName).HasColumnName("PizzaName").IsRequired(); 
            builder.Property(c => c.FinalPrice).HasColumnName("FinalPrice");
            builder.Property(c => c.OrderDate).HasColumnName("OrderDate");
        }
    }
}
