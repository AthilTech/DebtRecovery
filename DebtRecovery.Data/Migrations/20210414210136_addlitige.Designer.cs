﻿// <auto-generated />
using System;
using DebtRecovery.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DebtRecovery.Data.Migrations
{
    [DbContext(typeof(DebtRecoveryContext))]
    [Migration("20210414210136_addlitige")]
    partial class addlitige
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DebtRecovery.Domain.Models.Activity", b =>
                {
                    b.Property<Guid>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Auto")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FK_Scenario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Media")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.HasIndex("FK_Scenario");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Bill", b =>
                {
                    b.Property<Guid>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FK_Client")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NbPayments")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Scenario_State")
                        .HasColumnType("bit");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("BillId");

                    b.HasIndex("FK_Client");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Bill_Trip", b =>
                {
                    b.Property<Guid>("TripBillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_Trip")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripBillId");

                    b.HasIndex("FK_Bill");

                    b.ToTable("Bill_Trips");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_Agent")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_Scenario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel_f")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel_m")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("litige")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.HasIndex("FK_Agent");

                    b.HasIndex("FK_Scenario");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.History", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agent_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bill_Num")
                        .HasColumnType("int");

                    b.Property<string>("Client")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HistoryId");

                    b.HasIndex("FK_Bill");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteId");

                    b.HasIndex("FK_Bill");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountToPay")
                        .HasColumnType("float");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PayedAmount")
                        .HasColumnType("float");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("FK_Bill");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Promise", b =>
                {
                    b.Property<Guid>("PromiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountPromised")
                        .HasColumnType("float");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PromiseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PromiseId");

                    b.HasIndex("FK_Bill");

                    b.ToTable("Promises");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Login")
                        .HasColumnType("int");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Scenario", b =>
                {
                    b.Property<Guid>("ScenarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScenarioId");

                    b.ToTable("Scenarios");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_Role")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("FK_Role");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Agent", b =>
                {
                    b.HasBaseType("DebtRecovery.Domain.Models.User");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FK_Manager")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("FK_Manager");

                    b.HasDiscriminator().HasValue("Agent");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Manager", b =>
                {
                    b.HasBaseType("DebtRecovery.Domain.Models.User");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Activity", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Scenario", "Scenario")
                        .WithMany("Activities")
                        .HasForeignKey("FK_Scenario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Bill", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Client", "Client")
                        .WithMany("Bills")
                        .HasForeignKey("FK_Client")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Bill_Trip", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Bill", "Bill")
                        .WithMany("Bill_Trips")
                        .HasForeignKey("FK_Bill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Client", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Agent", "Agent")
                        .WithMany("Clients")
                        .HasForeignKey("FK_Agent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DebtRecovery.Domain.Models.Scenario", "Scenario")
                        .WithMany("Clients")
                        .HasForeignKey("FK_Scenario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.History", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Bill", "Bill")
                        .WithMany("Histories")
                        .HasForeignKey("FK_Bill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Note", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Bill", "Bill")
                        .WithMany("Notes")
                        .HasForeignKey("FK_Bill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Payment", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Bill", "Bill")
                        .WithMany("Payments")
                        .HasForeignKey("FK_Bill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Promise", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Bill", "Bill")
                        .WithMany("Promises")
                        .HasForeignKey("FK_Bill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.User", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("FK_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Agent", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Manager", "Manager")
                        .WithMany("Agents")
                        .HasForeignKey("FK_Manager");
                });
#pragma warning restore 612, 618
        }
    }
}
