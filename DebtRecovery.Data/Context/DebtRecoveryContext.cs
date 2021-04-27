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
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Bill_Trip> Bill_Trips { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Promise> Promises { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<History> Histories { get; set; }

        #endregion 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DataSeed:

            #endregion

            #region Settings: set Primary keys

            modelBuilder.Entity<Role>()
              .HasKey(r => r.RoleId);

            modelBuilder.Entity<User>()
             .HasKey(u => u.UserId);

            modelBuilder.Entity<Bill>()
            .HasKey(b => b.BillId);

            modelBuilder.Entity<Bill_Trip>()
                .HasKey(bt => bt.Bill_TripId);

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

            modelBuilder.Entity<Client>()
            .HasKey(cc => cc.ClientId);



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

            modelBuilder.Entity<Agent>()
                   .HasOne<Manager>(ra => ra.Manager)
                   .WithMany(ce => ce.Agents)
                   .HasForeignKey(ra => ra.FK_Manager);

            modelBuilder.Entity<Client>()
                   .HasOne<Agent>(ag => ag.Agent)
                   .WithMany(cl => cl.Clients)
                    .HasForeignKey(ag => ag.FK_Agent);

            //bill and client relationship is mising 

            modelBuilder.Entity<Bill>()
                    .HasOne<Client>(cc => cc.Client)
                    .WithMany(b => b.Bills)
                    .HasForeignKey(cc => cc.FK_Client);

            modelBuilder.Entity<Bill_Trip>()
                    .HasOne<Bill>(b=> b.Bill)
                    .WithMany(bt => bt.Bill_Trips)
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

            modelBuilder.Entity<Client>()
            .HasOne<Scenario>(sc => sc.Scenario)
            .WithMany(cl => cl.Clients)
            .HasForeignKey(sc => sc.FK_Scenario);







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
