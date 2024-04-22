using Prosales.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosales.Controler
{
    public class Prosalescontext : DbContext
    {
        public static string Con()
        {
            string Connectionstring;
            try
            {
                //Data Source=DESKTOP-HE5C4RQ\SQLEXPRESS;Initial Catalog=Prosales;Integrated Security=True
                Connectionstring = @"Data Source=DESKTOP-HE5C4RQ\SQLEXPRESS;Initial Catalog=Prosales;Integrated Security=True";
            }
            catch (Exception)
            {
                Connectionstring = "Data Source=192.168.3.180;Initial Catalog=Prosales;Persist Security Info=True;User ID=PCServicesAdministrator;Password=PCS2020";
            }
            return Connectionstring;
        }
        public Prosalescontext() : base(Con())
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<TOSale> TOSales { get; set; }
        public DbSet<TOCustomer> TOCustomers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cash> Cashes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TOSupplier> TOSuppliers { get; set; }
        public DbSet<PQR> PQRS { get; set; }
        public DbSet<Sold> Solds { get; set; }
        public DbSet<Serialnumber> Serialnumbers { get; set; }
        public DbSet<PSR> PSRS { get; set; }
        public DbSet<PSRBarcode> PSRBarcodes { get; set; }
        public DbSet<PSRSeriale> PSRSeriales { get; set; }
        public DbSet<Damegd> Damegds { get; set; }
    }
}
