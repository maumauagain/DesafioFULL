﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

namespace backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210312121858_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("backend.Models.Entities.Divida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPFDevedor")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Juros")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Multa")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeDevedor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Removed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dividas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPFDevedor = "123456",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Juros = 1m,
                            Multa = 2m,
                            NomeDevedor = "José",
                            Numero = 1010,
                            Removed = false
                        },
                        new
                        {
                            Id = 2,
                            CPFDevedor = "123777",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Juros = 2m,
                            Multa = 4m,
                            NomeDevedor = "João",
                            Numero = 1011,
                            Removed = false
                        });
                });

            modelBuilder.Entity("backend.Models.Entities.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("DividaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Removed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DividaId");

                    b.ToTable("Parcelas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVencimento = new DateTime(2020, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DividaId = 1,
                            Numero = 1,
                            Removed = false,
                            Valor = 100m
                        },
                        new
                        {
                            Id = 2,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVencimento = new DateTime(2020, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DividaId = 1,
                            Numero = 2,
                            Removed = false,
                            Valor = 100m
                        },
                        new
                        {
                            Id = 3,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVencimento = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DividaId = 2,
                            Numero = 3,
                            Removed = false,
                            Valor = 200m
                        },
                        new
                        {
                            Id = 4,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataVencimento = new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DividaId = 2,
                            Numero = 4,
                            Removed = false,
                            Valor = 200m
                        });
                });

            modelBuilder.Entity("backend.Models.Entities.Parcela", b =>
                {
                    b.HasOne("backend.Models.Entities.Divida", "Divida")
                        .WithMany("Parcelas")
                        .HasForeignKey("DividaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}