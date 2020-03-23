using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace beaverNet.POS.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<beaverNet.POS.WebApp.Models.POS.Customer> Customer { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.Vendor> Vendor { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.Product> Product { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.SalesOrder> SalesOrder { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.GoodsReceive> GoodsReceive { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.InvenTran> InvenTran { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.PurchaseOrderLine> PurchaseOrderLine { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.SalesOrderLine> SalesOrderLine { get; set; }
        public DbSet<beaverNet.POS.WebApp.Models.POS.GoodsReceiveLine> GoodsReceiveLine { get; set; }
    }
}
