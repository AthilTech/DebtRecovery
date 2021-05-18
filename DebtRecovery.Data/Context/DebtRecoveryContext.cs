using DebtRecovery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlClient;

namespace DebtRecovery.Data.Context
{
    public class DebtRecoveryContext : DbContext
    {
        public DebtRecoveryContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSets 
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillTrip> BillTrips { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityInstance> ActivityInstances { get; set; }
        public DbSet<Promise> Promises { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<History> Histories { get; set; }

        #endregion 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region DataSeed:

            //Roles
            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleId = new Guid("4D2BC0D0-F738-4BA5-B48B-C2DB92B0BCF1"), Label = "Admin" },
                new Role() { RoleId = new Guid("45E6A625-BA74-437B-8956-5316915202AC"), Label = "Admin" });

            //Managers
            modelBuilder.Entity<Manager>().HasData(
                new Manager() { UserId = new Guid("14FA108F-986C-44CA-968C-92DE280A4F05"), Name = "Athil", LastName = "Belhadj", PhoneNumber = "23040785", Email = "Athil Belhadj/SIEGE/POULINA" },
                new Manager() { UserId = new Guid("8BECB2C9-1F49-4780-9382-C5D434BE11FB"), Name = "Achref", LastName = "Souissi", PhoneNumber = "92365587", Email = "Achref Souissi/SIEGE/POULINA" });

            //Agents
            modelBuilder.Entity<Agent>().HasData(
                new Agent() { UserId = new Guid("FB2B536C-B4CB-485E-B65F-30679CF0410B"), Name = "Rami", LastName = "Toumi", PhoneNumber = "33256698", Email = "Rami Toumi/SIEGE/POULINA", FK_Manager = new Guid("8BECB2C9-1F49-4780-9382-C5D434BE11FB") },
                new Agent() { UserId = new Guid("4B437FAF-71A2-47D3-AC14-4088F6A37204"), Name = "Safouane", LastName = "Ben jeddi", PhoneNumber = "982544567", Email = "Safouane Ben Jeddi/SIEGE/POULINA", FK_Manager = new Guid("8BECB2C9-1F49-4780-9382-C5D434BE11FB") });

            //scenarios
            modelBuilder.Entity<Scenario>().HasData(
                new Scenario() { ScenarioId = new Guid("9BEBB407-74DF-4F82-96C8-BB523A99B3E3"), ScenarioLabel = "Standard avec une seule Rélance", IsActive = true, IsCentralized = true }
                );

            //activities
            modelBuilder.Entity<Activity>().HasData(
                new Activity() { ActivityId = new Guid("E0F36A4F-7044-46E7-90B1-923D0737544E"), ActivityLabel = "Prévenance", Type = "thoughtfulness", isActive = true, BeforeDays = 5, AfterDays = 0, Media = "email", Order = 0, Model = "model 1", IsAuto = true, FK_Scenario = new Guid("9BEBB407-74DF-4F82-96C8-BB523A99B3E3") },
                new Activity() { ActivityId = new Guid("4F4D26BF-E2CF-4D52-8F2B-182B6DC71638"), ActivityLabel = "Rélance n°1", Type = "relaunch", isActive = true, BeforeDays = 0, AfterDays = 3, Media = "email", Order = 1, Model = "model 2", IsAuto = true, FK_Scenario = new Guid("9BEBB407-74DF-4F82-96C8-BB523A99B3E3") },
                new Activity() { ActivityId = new Guid("{264E6890-90D2-423E-B795-607499E31A3F}"), ActivityLabel = "Rémerciement", Type = "thanks", isActive = true, BeforeDays = 0, AfterDays = 5, Media = "email", Order = 2, Model = "model 3", IsAuto = true, FK_Scenario = new Guid("9BEBB407-74DF-4F82-96C8-BB523A99B3E3") }
);
            //customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { CustomerId = new Guid("A2730FA7-D7E0-40F0-BB5F-75092D8C5583"), LegalIdentifier = "MLK025F001", Name = "Magazin Generale", Contact = "Sfaxi Arij", PhoneNumber = "71256587", FaxNumber = "70861236", Litigation = false, Email = "Mg@tunis.com.tn", FK_Agent = new Guid("FB2B536C-B4CB-485E-B65F-30679CF0410B"), FK_Scenario = new Guid("9BEBB407-74DF-4F82-96C8-BB523A99B3E3") },
                new Customer() { CustomerId = new Guid("{17F50CF3-3BAA-490E-8716-06C4921F9AFE}"), LegalIdentifier = "RCK023MJ556", Name = "PV Mazraa sidi Thabet", Contact = "Ouni Ramzi", PhoneNumber = "23256587", FaxNumber = "70256354", Litigation = false, Email = "thabet25@gmail.com", FK_Agent = new Guid("FB2B536C-B4CB-485E-B65F-30679CF0410B"), FK_Scenario = new Guid("9BEBB407-74DF-4F82-96C8-BB523A99B3E3") }
       );

            #endregion

            #region Settings: set Primary keys

            modelBuilder.Entity<Role>()
              .HasKey(r => r.RoleId);

            modelBuilder.Entity<User>()
             .HasKey(u => u.UserId);

            modelBuilder.Entity<Bill>()
            .HasKey(b => b.BillId);

            modelBuilder.Entity<BillTrip>()
                .HasKey(bt => bt.BillTripId);

            modelBuilder.Entity<Payment>()
            .HasKey(pa => pa.PaymentId);

            modelBuilder.Entity<Promise>()
            .HasKey(pr => pr.PromiseId);

            modelBuilder.Entity<History>()
            .HasKey(h => h.HistoryId);

            modelBuilder.Entity<Note>()
            .HasKey(n => n.NoteId);

            modelBuilder.Entity<Scenario>()
            .HasKey(s => s.ScenarioId);

            modelBuilder.Entity<Activity>()
            .HasKey(a => a.ActivityId);

            modelBuilder.Entity<Customer>()
            .HasKey(cc => cc.CustomerId);



            #endregion

            #region  Settings: set one to many relations

            // configures one-to-many role-user relationship
            modelBuilder.Entity<User>()
                .HasOne<Role>(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.FK_Role);

            modelBuilder.Entity<Activity>()
                   .HasOne<Scenario>(s => s.Scenario)
                   .WithMany(a => a.Activities)
                   .HasForeignKey(a => a.FK_Scenario);

            modelBuilder.Entity<ActivityInstance>()
                   .HasOne<Activity>(a => a.ScenarioActivity)
                   .WithMany(i => i.ActivityInstances)
                   .HasForeignKey(a => a.Fk_ScenarioActivity)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ActivityInstance>()
                  .HasOne<Bill>(a => a.Bill)
                  .WithMany(i => i.ActivityInstances)
                  .HasForeignKey(a => a.FK_bill)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Agent>()
                   .HasOne<Manager>(ra => ra.Manager)
                   .WithMany(ce => ce.Agents)
                   .HasForeignKey(ra => ra.FK_Manager)
                   .OnDelete(DeleteBehavior.ClientNoAction);
            ;

            modelBuilder.Entity<Customer>()
                   .HasOne<Agent>(ag => ag.Agent)
                   .WithMany(cl => cl.Customers)
                    .HasForeignKey(ag => ag.FK_Agent);

            //bill and Customerrelationship is mising 

            modelBuilder.Entity<Bill>()
                    .HasOne<Customer>(cc => cc.Customer)
                    .WithMany(b => b.Bills)
                    .HasForeignKey(cc => cc.FK_Customer);

            modelBuilder.Entity<BillTrip>()
                    .HasOne<Bill>(b => b.Bill)
                    .WithMany(bt => bt.BillTrips)
                    .HasForeignKey(b => b.FK_Bill);

            modelBuilder.Entity<Promise>()
                .HasOne<Bill>(b => b.Bill)
                .WithMany(p => p.Promises)
                .HasForeignKey(b => b.FK_Bill);

            modelBuilder.Entity<Payment>()
                    .HasOne<Bill>(b => b.Bill)
                    .WithMany(y => y.Payments)
                    .HasForeignKey(b => b.FK_Bill);

            modelBuilder.Entity<Note>()
                   .HasOne<Bill>(b => b.Bill)
                   .WithMany(n => n.Notes)
                   .HasForeignKey(b => b.FK_Bill);

            modelBuilder.Entity<History>()
               .HasOne<Bill>(b => b.Bill)
               .WithMany(n => n.Histories)
               .HasForeignKey(b => b.FK_Bill);


            modelBuilder.Entity<Customer>()
            .HasOne<Scenario>(sc => sc.Scenario)
            .WithMany(cl => cl.Customers)
            .HasForeignKey(sc => sc.FK_Scenario)
            .OnDelete(DeleteBehavior.ClientSetNull);







            #endregion

            #region  Settings: set one to one relations 


            #endregion

            #region  Settings: set one to Zero and zero to one relations

            #endregion

            #region maxlength 
            #endregion
        }
    }
}
