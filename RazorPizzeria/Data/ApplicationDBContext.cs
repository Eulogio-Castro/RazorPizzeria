using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Models;
using RazorPizzeria.TableMappings;
using System.Data.Common;

namespace RazorPizzeria.Data
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<PizzaOrderModel> Orders { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new OrdersTableMapping());
            base.OnModelCreating(modelBuilder);

        }
    }
}
