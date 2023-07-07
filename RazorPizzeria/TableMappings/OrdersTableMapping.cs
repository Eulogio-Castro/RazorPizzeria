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
            builder.HasKey("Id");
            builder.Property(o => o.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.OrderDate).HasColumnName("OrderDate");
            builder.Property(o => o.CustomerID).HasColumnName("CustomerID");
            builder.HasIndex(o => o.CustomerID);
            builder.HasMany(o => o.Pizzas)
                .WithOne(o => o.PizzaOrder)
                .HasForeignKey(o => o.PizzaOrderId)
                .IsRequired();
        //        .HasMany(e => e.Posts)
        //.WithOne(e => e.Blog)
        //.HasForeignKey(e => e.BlogId)
        }
    }
}
