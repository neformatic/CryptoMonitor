﻿// <auto-generated />
using System;
using CryptoMonitor.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CryptoMonitor.DAL.Migrations
{
    [DbContext(typeof(CryptoMonitorDbContext))]
    [Migration("20220406113614_AddNotNullForBet")]
    partial class AddNotNullForBet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BetDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("BetPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId")
                        .IsUnique()
                        .HasFilter("[CurrencyId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.CryptoCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CurrencyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CryptoCurrency");
                });

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("CryptoCurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("CryptoCurrencyId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.Bet", b =>
                {
                    b.HasOne("CryptoMonitor.DAL.Entities.CryptoCurrency", "Currency")
                        .WithOne("Bet")
                        .HasForeignKey("CryptoMonitor.DAL.Entities.Bet", "CurrencyId");

                    b.HasOne("CryptoMonitor.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.User", b =>
                {
                    b.HasOne("CryptoMonitor.DAL.Entities.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("CryptoMonitor.DAL.Entities.User", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptoMonitor.DAL.Entities.CryptoCurrency", "Currency")
                        .WithMany()
                        .HasForeignKey("CryptoCurrencyId");

                    b.Navigation("Account");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.Account", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("CryptoMonitor.DAL.Entities.CryptoCurrency", b =>
                {
                    b.Navigation("Bet");
                });
#pragma warning restore 612, 618
        }
    }
}
