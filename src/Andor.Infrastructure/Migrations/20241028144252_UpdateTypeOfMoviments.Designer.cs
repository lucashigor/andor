﻿// <auto-generated />
using System;
using Andor.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Andor.Infrastructure.Migrations
{
    [DbContext(typeof(PrincipalContext))]
    [Migration("20241028144252_UpdateTypeOfMoviments")]
    partial class UpdateTypeOfMoviments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Andor.Application.Engagement.Budget.Invites.Saga.InviteSagaState", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GuestEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("GuestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InviteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InvitingId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CorrelationId");

                    b.ToTable("InviteSagaState", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Administrations.Configurations.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("character varying(2500)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Configuration", "Administration");
                });

            modelBuilder.Entity("Andor.Domain.Administrations.Languages.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Language", "Administration");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Consented")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.ToTable("Permission", "Communication");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Rule", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Rule", "Communication");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ContentLanguage")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Partner")
                        .HasColumnType("integer");

                    b.Property<Guid>("RuleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("character varying(2500)");

                    b.HasKey("Id");

                    b.HasIndex("RuleId");

                    b.ToTable("Template", "Communication");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Users.Recipient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("PreferredEmail")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.HasKey("Id");

                    b.ToTable("Recipient", "Communication");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<DateTime?>("FirstMovement")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastMovement")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Account", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountCategory", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AccountCategory", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountPaymentMethod", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "PaymentMethodId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("AccountPaymentMethod", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountSubCategory", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "SubCategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("AccountSubCategory", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountUser", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AccountUser", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeactivationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Category", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Currencies.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Currency", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Invites.Invite", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<Guid?>("GuestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InvitingId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("GuestId");

                    b.HasIndex("InvitingId");

                    b.ToTable("Invite", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.PaymentMethods.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeactivationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.SubCategories.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeactivationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DefaultPaymentMethodId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DefaultPaymentMethodId");

                    b.ToTable("SubCategory", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PreferredCurrencyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PreferredLanguageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("User", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.FinancialMovements.CashFlow.CashFlow", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Expenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinalBalancePreviousMonth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ForecastExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ForecastUpcomingRevenues")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.Property<decimal>("MonthRevenues")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId", "Year", "Month")
                        .IsUnique();

                    b.ToTable("CashFlow", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.FinancialMovements.FinancialMovements.FinancialMovement", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

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
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("FinancialMovement", "Engagement");
                });

            modelBuilder.Entity("Andor.Domain.Onboarding.Registrations.Registration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("CheckCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Registration", "Onboarding");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.InboxState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Consumed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ConsumerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<int>("ReceiveCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Received")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("Delivered");

                    b.ToTable("InboxState");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxMessage", b =>
                {
                    b.Property<long>("SequenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SequenceNumber"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("DestinationAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime?>("EnqueueTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FaultAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Headers")
                        .HasColumnType("text");

                    b.Property<Guid?>("InboxConsumerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InboxMessageId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InitiatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("OutboxId")
                        .HasColumnType("uuid");

                    b.Property<string>("Properties")
                        .HasColumnType("text");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("ResponseAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SourceAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("SequenceNumber");

                    b.HasIndex("EnqueueTime");

                    b.HasIndex("ExpirationTime");

                    b.HasIndex("OutboxId", "SequenceNumber")
                        .IsUnique();

                    b.HasIndex("InboxMessageId", "InboxConsumerId", "SequenceNumber")
                        .IsUnique();

                    b.ToTable("OutboxMessage");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxState", b =>
                {
                    b.Property<Guid>("OutboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("OutboxId");

                    b.HasIndex("Created");

                    b.ToTable("OutboxState");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Permission", b =>
                {
                    b.HasOne("Andor.Domain.Communications.Users.Recipient", "Recipient")
                        .WithMany("Permissions")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Template", b =>
                {
                    b.HasOne("Andor.Domain.Communications.Rule", "Rule")
                        .WithMany("Templates")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Currencies.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountCategory", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", "Account")
                        .WithMany("Categories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountPaymentMethod", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", "Account")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.PaymentMethods.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountSubCategory", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", "Account")
                        .WithMany("SubCategories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.SubCategories.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.AccountUser", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Invites.Invite", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", "Account")
                        .WithMany("Invites")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Users.User", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Users.User", "Inviting")
                        .WithMany()
                        .HasForeignKey("InvitingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Guest");

                    b.Navigation("Inviting");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.SubCategories.SubCategory", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Categories.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.PaymentMethods.PaymentMethod", "DefaultPaymentMethod")
                        .WithMany("SubCategories")
                        .HasForeignKey("DefaultPaymentMethodId");

                    b.Navigation("Category");

                    b.Navigation("DefaultPaymentMethod");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.FinancialMovements.CashFlow.CashFlow", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.FinancialMovements.FinancialMovements.FinancialMovement", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.PaymentMethods.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.SubCategories.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("PaymentMethod");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Andor.Domain.Onboarding.Registrations.Registration", b =>
                {
                    b.HasOne("Andor.Domain.Engagement.Budget.Accounts.Currencies.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Andor.Domain.Administrations.Languages.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxMessage", b =>
                {
                    b.HasOne("MassTransit.EntityFrameworkCoreIntegration.OutboxState", null)
                        .WithMany()
                        .HasForeignKey("OutboxId");

                    b.HasOne("MassTransit.EntityFrameworkCoreIntegration.InboxState", null)
                        .WithMany()
                        .HasForeignKey("InboxMessageId", "InboxConsumerId")
                        .HasPrincipalKey("MessageId", "ConsumerId");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Rule", b =>
                {
                    b.Navigation("Templates");
                });

            modelBuilder.Entity("Andor.Domain.Communications.Users.Recipient", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Accounts.Account", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Invites");

                    b.Navigation("PaymentMethods");

                    b.Navigation("SubCategories");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.Categories.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Andor.Domain.Engagement.Budget.Accounts.PaymentMethods.PaymentMethod", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
