﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exchangy.DataAccess.Migrations
{
    [DbContext(typeof(ExchangyContext))]
    partial class ExchangyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Exchangy.FixerIoFramework.DataAccess.CurrencyRequest", b =>
                {
                    b.Property<int>("CurrencyRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BaseCurrency")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("TEXT");

                    b.HasKey("CurrencyRequestId");

                    b.ToTable("CurrencyRequests");
                });

            modelBuilder.Entity("Exchangy.FixerIoFramework.DataAccess.RateResult", b =>
                {
                    b.Property<int>("RateResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrencyRequestId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Rate")
                        .HasColumnType("REAL");

                    b.HasKey("RateResultId");

                    b.HasIndex("CurrencyRequestId");

                    b.ToTable("RateResults");
                });

            modelBuilder.Entity("Exchangy.FixerIoFramework.DataAccess.RateResult", b =>
                {
                    b.HasOne("Exchangy.FixerIoFramework.DataAccess.CurrencyRequest", "CurrencyRequest")
                        .WithMany("Rates")
                        .HasForeignKey("CurrencyRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyRequest");
                });

            modelBuilder.Entity("Exchangy.FixerIoFramework.DataAccess.CurrencyRequest", b =>
                {
                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
