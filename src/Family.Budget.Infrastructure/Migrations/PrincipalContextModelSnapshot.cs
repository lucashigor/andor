﻿// <auto-generated />
using System;
using Family.Budget.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Family.Budget.Infrastructure.Migrations
{
    [DbContext(typeof(PrincipalContext))]
    partial class PrincipalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTimeOffset>("FirstMovement")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastMovement")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Account", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountCategory", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AccountCategory", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountPaymentMethod", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "PaymentMethodId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("AccountPaymentMethod", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountSubCategory", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "SubCategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("AccountSubCategory", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountUser", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "UserId");

                    b.ToTable("AccountUser", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.Invite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AccountId1")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId1");

                    b.ToTable("Invite", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Admin.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTimeOffset?>("FinalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("character varying(2500)");

                    b.HasKey("Id");

                    b.ToTable("Configuration", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.CashFlow.CashFlow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("numeric");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Expenses")
                        .HasColumnType("numeric");

                    b.Property<decimal>("FinalBalancePreviousMonth")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ForecastExpenses")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ForecastUpcomingRevenues")
                        .HasColumnType("numeric");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.Property<decimal>("MonthRevenues")
                        .HasColumnType("numeric");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CashFlow", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeactivationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Category", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Currencies.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Currency", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.FinancialMovement.FinancialMovement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("FinancialMovement", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Notifications.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Opened")
                        .HasColumnType("boolean");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Notification", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.PaymentMethods.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeactivationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Registrations.Registration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CheckCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset>("RegisterDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Registration", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.SubCategories.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeactivationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DefaultPaymentMethodId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DefaultPaymentMethodId");

                    b.ToTable("SubCategory", "budget");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.Account", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.Currencies.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountCategory", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.Accounts.Account", "Account")
                        .WithMany("Categories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Family.Budget.Domain.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountPaymentMethod", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.Accounts.Account", "Account")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Family.Budget.Domain.Entities.PaymentMethods.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountSubCategory", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.Accounts.Account", "Account")
                        .WithMany("SubCategories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Family.Budget.Domain.Entities.SubCategories.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.AccountUser", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.Accounts.Account", "Account")
                        .WithMany("UserIds")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.Invite", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.Accounts.Account", null)
                        .WithMany("Invites")
                        .HasForeignKey("AccountId1");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.FinancialMovement.FinancialMovement", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.PaymentMethods.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Family.Budget.Domain.Entities.SubCategories.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.SubCategories.SubCategory", b =>
                {
                    b.HasOne("Family.Budget.Domain.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Family.Budget.Domain.Entities.PaymentMethods.PaymentMethod", "DefaultPaymentMethod")
                        .WithMany()
                        .HasForeignKey("DefaultPaymentMethodId");

                    b.Navigation("Category");

                    b.Navigation("DefaultPaymentMethod");
                });

            modelBuilder.Entity("Family.Budget.Domain.Entities.Accounts.Account", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Invites");

                    b.Navigation("PaymentMethods");

                    b.Navigation("SubCategories");

                    b.Navigation("UserIds");
                });
#pragma warning restore 612, 618
        }
    }
}
