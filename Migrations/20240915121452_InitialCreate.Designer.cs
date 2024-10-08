﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nheejods.Contexts;

#nullable disable

namespace nheejods.Migrations
{
    [DbContext(typeof(MySQLDbContext))]
    [Migration("20240915121452_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("nheejods.Models.FinanceBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<byte>("Month")
                        .HasColumnType("tinyint unsigned")
                        .HasColumnName("month");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<ushort>("Year")
                        .HasColumnType("smallint unsigned")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("finance_boxs");
                });

            modelBuilder.Entity("nheejods.Models.FinanceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoxId")
                        .HasColumnType("int")
                        .HasColumnName("box_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("amount");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("finance_items");
                });

            modelBuilder.Entity("nheejods.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("nheejods.Models.FinanceBox", b =>
                {
                    b.HasOne("nheejods.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
