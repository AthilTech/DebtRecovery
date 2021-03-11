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
        public DbSet<TestModel> Counter { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DataSeed:

            #endregion

            #region Settings: set Primary keys

            modelBuilder.Entity<TestModel>()
                        .HasKey(tm => tm.TestModelId);

            #endregion

            #region  Settings: set one to many relations

            

            #endregion

            #region  Settings: set one to one relations


           



            #endregion

            #region  Settings: set one to Zero and zero to one relations


            #endregion
        }
    }
}
