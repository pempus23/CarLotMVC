using AutoLotDAL.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;

namespace AutoLotDAL.EF
{

    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt",true);
        public AutoLotEntities() : base("name=AutoLotEntities")
        {
            //DbInterception.Add(new ConsoleWriterInterceptor());
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);

            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Cars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);
        }
        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }

        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            var context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            {
                if((item.Entity as Inventory) != null)
                {
                    var entity = (Inventory)item.Entity;
                    if (entity.Color == "Red")
                    {
                        Console.WriteLine("Not Red");
                        item.RejectPropertyChanges(nameof(entity.Color));
                    }
                }
            }
        }
        private void OnObjectMaterialized(object sender, System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {
        }
    }
}
