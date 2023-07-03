using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Areas.Identity.Data;
using RazorPizzeria.Models;
using RazorPizzeria.TableMappings;
using System.Data.Common;

namespace RazorPizzeria.Data
{
    public class ApplicationDBContext: IdentityDbContext<RazorPizzeriaUser>
    {
        public DbSet<PizzaOrderModel> Orders { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new OrdersTableMapping())
                        .ApplyConfiguration(new CustomersTableMapping())
                        .ApplyConfiguration(new PizzasTableMapping());
            base.OnModelCreating(modelBuilder);

        }
    }
}
