using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorPizzeria.Models;

namespace RazorPizzeria.TableMappings
{
    public class PizzasTableMapping : IEntityTypeConfiguration<PizzasModel>
    {
        public void Configure(EntityTypeBuilder<PizzasModel> builder)
        {
            builder.ToTable("PizzasModel");
            builder.HasKey("Id");
            builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
            builder.Property(o => o.ImageTitle).HasColumnName("ImageTitle");
            builder.Property(o => o.PizzaName).HasColumnName("PizzaName");
            builder.Property(o => o.BasePrice).HasColumnName("BasePrice");
            builder.Property(o => o.HasPizzaSauce).HasColumnName("HasPizzaSauce");
            builder.Property(o => o.HasCheese).HasColumnName("HasCheese");
            builder.Property(o => o.HasPepperoni).HasColumnName("HasPepperoni");
            builder.Property(o => o.HasMushroom).HasColumnName("HasMushroom");
            builder.Property(o => o.HasTuna).HasColumnName("HasTuna");
            builder.Property(o => o.HasPineapple).HasColumnName("HasPineapple");
            builder.Property(o => o.HasHam).HasColumnName("HasHam");
            builder.Property(o => o.HasBeef).HasColumnName("HasBeef");
            builder.Property(o => o.FinalPrice).HasColumnName("FinalPrice");

        //            .HasOne(e => e.Blog)
        //.WithMany(e => e.Posts)
        //.HasForeignKey(e => e.BlogId)
        //.IsRequired();
        }
    }
}
