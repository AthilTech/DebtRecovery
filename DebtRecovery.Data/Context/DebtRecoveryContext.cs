using DebtRecovery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Data.Context
{
    public class DebtRecoveryContext: DbContext
    {
        public DebtRecoveryContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSets
        
        public DbSet<RecoveryAgent> RecoveryAgent { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Client> Client { get; set; }
       
        public DbSet<Note> Note { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Promise> Promise { get; set; }
        public DbSet<RecoveryManager> RecoveryManager { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Scenario> Scenario { get; set; }
        public DbSet<Bill_Trip> bill_Trip { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<History> History { get; set; }



        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DataSeed:

            #endregion

            #region Settings: set Primary keys

           

            modelBuilder.Entity<Activity>()
                    .HasKey(a => a.ActivityId);


            modelBuilder.Entity<Bill>()
                        .HasKey(b => b.BillId);

            modelBuilder.Entity<Client>()
                      .HasKey(c => c.ClientId);

            modelBuilder.Entity<Note>()
                .HasKey(n => n.NoteId);

            modelBuilder.Entity<Payment>()
               .HasKey(p => p.PaymentID);

            modelBuilder.Entity<Promise>()
              .HasKey(p => p.PromissId);

            modelBuilder.Entity<Role>()
              .HasKey(r => r.RoleId);

            modelBuilder.Entity<Scenario>()
             .HasKey(s => s.ScenarioId);

            modelBuilder.Entity<Bill_Trip>()
             .HasKey(s => s.Bill_TripId);

            modelBuilder.Entity<User>()
          .HasKey(s => s.UserId);

            modelBuilder.Entity<History>()
       .HasKey(s => s.HistoryId);


            #endregion

            #region  Settings: set one to many relations

            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.FK_Role);


            modelBuilder.Entity<RecoveryAgent>()
               .HasOne(r => r.RecoveryManager)
               .WithMany(a => a.RecoveryAgents)
               .HasForeignKey(a => a.FK_Manager);

            modelBuilder.Entity<Client>()
                   .HasOne(a => a.RecoveryAgent)
                   .WithMany(c => c.Clients)
                   .HasForeignKey(c => c.FK_Agent);


            modelBuilder.Entity<Bill>()
                    .HasOne(c => c.client)
                    .WithMany(b => b.Bills)
                    .HasForeignKey(b => b.FK_Client);


            modelBuilder.Entity<Payment>()
                     .HasOne(b => b.Bill)
                     .WithMany(p => p.Payments)
                     .HasForeignKey(p => p.FK_Bill);


            modelBuilder.Entity<Promise>()
                    .HasOne(b => b.Bill)
                    .WithMany(p => p.Promesses)
                    .HasForeignKey(p => p.FK_Bill);
          

            modelBuilder.Entity<Note>()
                     .HasOne(b => b.Bill)
                     .WithMany(n => n.Notes)
                     .HasForeignKey(p => p.FK_Bill);

            modelBuilder.Entity<History>()
                  .HasOne(b => b.Bill)
                  .WithMany(n => n.histories)
                  .HasForeignKey(p => p.FK_Bill);

       /*     modelBuilder.Entity<Promise>()
                .HasOne(b => b.Payment)
                .WithMany(n => n.Promises)
                .HasForeignKey(p => p.FK_Payment)
            .OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<Client>()
              .HasOne(b => b.scenario)
              .WithMany(n => n.Clients)
              .HasForeignKey(p => p.FK_Scenario);

            modelBuilder.Entity<Activity>()
             .HasOne(b => b.Scenario)
             .WithMany(n => n.Activities)
             .HasForeignKey(p => p.FK_Scenario);

            modelBuilder.Entity<Bill_Trip>()
           .HasOne(b => b.Bill)
           .WithMany(n => n.Bill_Trips)
           .HasForeignKey(p => p.FK_Bill);
            #endregion

            #region  Settings: set one to one relations






            #endregion

            #region  Settings: set one to Zero and zero to one relations


            #endregion
        }
    }
}
