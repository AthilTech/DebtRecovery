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
    [Migration("20210512113855_v2")]
    partial class v2
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

                    b.Property<string>("ActivityLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AfterDays")
                        .HasColumnType("int");

                    b.Property<int>("BeforeDays")
                        .HasColumnType("int");

                    b.Property<Guid>("FK_Scenario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAuto")
                        .HasColumnType("bit");

                    b.Property<string>("Media")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ActivityId");

                    b.HasIndex("FK_Scenario");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            ActivityId = new Guid("e0f36a4f-7044-46e7-90b1-923d0737544e"),
                            ActivityLabel = "Prévenance",
                            AfterDays = 0,
                            BeforeDays = 5,
                            FK_Scenario = new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"),
                            IsAuto = true,
                            Media = "email",
                            Model = "model 1",
                            Order = 0,
                            Type = "thoughtfulness",
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isActive = true
                        },
                        new
                        {
                            ActivityId = new Guid("4f4d26bf-e2cf-4d52-8f2b-182b6dc71638"),
                            ActivityLabel = "Rélance n°1",
                            AfterDays = 3,
                            BeforeDays = 0,
                            FK_Scenario = new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"),
                            IsAuto = true,
                            Media = "email",
                            Model = "model 2",
                            Order = 1,
                            Type = "relaunch",
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isActive = true
                        },
                        new
                        {
                            ActivityId = new Guid("264e6890-90d2-423e-b795-607499e31a3f"),
                            ActivityLabel = "Rémerciement",
                            AfterDays = 5,
                            BeforeDays = 0,
                            FK_Scenario = new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"),
                            IsAuto = true,
                            Media = "email",
                            Model = "model 3",
                            Order = 2,
                            Type = "thanks",
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isActive = true
                        });
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.ActivityInstance", b =>
                {
                    b.Property<Guid>("ActivityInstanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Fk_ScenarioActivity")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAuto")
                        .HasColumnType("bit");

                    b.HasKey("ActivityInstanceId");

                    b.HasIndex("Fk_ScenarioActivity");

                    b.ToTable("ActivityInstances");
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

                    b.Property<Guid>("FK_Customer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Scenario_State")
                        .HasColumnType("bit");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("BillId");

                    b.HasIndex("FK_Customer");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.BillTrip", b =>
                {
                    b.Property<Guid>("BillTripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_Trip")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BillTripId");

                    b.HasIndex("FK_Bill");

                    b.ToTable("BillTrips");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FK_Agent")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FK_Scenario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Litigation")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("FK_Agent");

                    b.HasIndex("FK_Scenario");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("a2730fa7-d7e0-40f0-bb5f-75092d8c5583"),
                            Contact = "Sfaxi Arij",
                            Email = "Mg@tunis.com.tn",
                            FK_Agent = new Guid("fb2b536c-b4cb-485e-b65f-30679cf0410b"),
                            FK_Scenario = new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"),
                            FaxNumber = "70861236",
                            LegalIdentifier = "MLK025F001",
                            Litigation = false,
                            Name = "Magazain Generale",
                            PhoneNumber = "71256587"
                        },
                        new
                        {
                            CustomerId = new Guid("17f50cf3-3baa-490e-8716-06c4921f9afe"),
                            Contact = "Ouni Ramzi",
                            Email = "thabet25@gmail.com",
                            FK_Agent = new Guid("fb2b536c-b4cb-485e-b65f-30679cf0410b"),
                            FK_Scenario = new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"),
                            FaxNumber = "70256354",
                            LegalIdentifier = "RCK023MJ556",
                            Litigation = false,
                            Name = "PV Mazraa sidi Thabet",
                            PhoneNumber = "23256587"
                        });
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.History", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ScenarioActivity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HistoryId");

                    b.HasIndex("FK_Bill");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FK_Bill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NoteSubject")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("4d2bc0d0-f738-4ba5-b48b-c2db92b0bcf1"),
                            Label = "Admin"
                        },
                        new
                        {
                            RoleId = new Guid("45e6a625-ba74-437b-8956-5316915202ac"),
                            Label = "Admin"
                        });
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Scenario", b =>
                {
                    b.Property<Guid>("ScenarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCentralized")
                        .HasColumnType("bit");

                    b.Property<string>("ScenarioLabel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScenarioId");

                    b.ToTable("Scenarios");

                    b.HasData(
                        new
                        {
                            ScenarioId = new Guid("9bebb407-74df-4f82-96c8-bb523a99b3e3"),
                            IsActive = true,
                            IsCentralized = true,
                            ScenarioLabel = "Standard avec une seule Rélance"
                        });
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FK_Role")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FK_Subsidiary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icn")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<Guid?>("FK_Manager")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("FK_Manager");

                    b.HasDiscriminator().HasValue("Agent");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("fb2b536c-b4cb-485e-b65f-30679cf0410b"),
                            Email = "Rami Toumi/SIEGE/POULINA",
                            LastName = "Toumi",
                            Name = "Rami",
                            PhoneNumber = "33256698",
                            FK_Manager = new Guid("8becb2c9-1f49-4780-9382-c5d434be11fb")
                        },
                        new
                        {
                            UserId = new Guid("4b437faf-71a2-47d3-ac14-4088f6a37204"),
                            Email = "Safouane Ben Jeddi/SIEGE/POULINA",
                            LastName = "Ben jeddi",
                            Name = "Safouane",
                            PhoneNumber = "982544567",
                            FK_Manager = new Guid("8becb2c9-1f49-4780-9382-c5d434be11fb")
                        });
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Manager", b =>
                {
                    b.HasBaseType("DebtRecovery.Domain.Models.User");

                    b.HasDiscriminator().HasValue("Manager");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("14fa108f-986c-44ca-968c-92de280a4f05"),
                            Email = "Athil Belhadj/SIEGE/POULINA",
                            LastName = "Belhadj",
                            Name = "Athil",
                            PhoneNumber = "23040785"
                        },
                        new
                        {
                            UserId = new Guid("8becb2c9-1f49-4780-9382-c5d434be11fb"),
                            Email = "Achref Souissi/SIEGE/POULINA",
                            LastName = "Souissi",
                            Name = "Achref",
                            PhoneNumber = "92365587"
                        });
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Activity", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Scenario", "Scenario")
                        .WithMany("Activities")
                        .HasForeignKey("FK_Scenario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.ActivityInstance", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Activity", "Activity")
                        .WithMany("ActivityInstances")
                        .HasForeignKey("Fk_ScenarioActivity")
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Bill", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("FK_Customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.BillTrip", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Bill", "Bill")
                        .WithMany("BillTrips")
                        .HasForeignKey("FK_Bill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Customer", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Agent", "Agent")
                        .WithMany("Customers")
                        .HasForeignKey("FK_Agent");

                    b.HasOne("DebtRecovery.Domain.Models.Scenario", "Scenario")
                        .WithMany("Customers")
                        .HasForeignKey("FK_Scenario");
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
                        .HasForeignKey("FK_Role");
                });

            modelBuilder.Entity("DebtRecovery.Domain.Models.Agent", b =>
                {
                    b.HasOne("DebtRecovery.Domain.Models.Manager", "Manager")
                        .WithMany("Agents")
                        .HasForeignKey("FK_Manager")
                        .OnDelete(DeleteBehavior.ClientNoAction);
                });
#pragma warning restore 612, 618
        }
    }
}