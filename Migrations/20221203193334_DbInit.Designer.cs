﻿// <auto-generated />
using System;
using BigCorp.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigCorp.Migrations
{
    [DbContext(typeof(BigCorpContext))]
    [Migration("20221203193334_DbInit")]
    partial class DbInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigCorp.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("owner")
                        .HasColumnType("int");

                    b.Property<int>("productLine")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<int>("warrantyTime")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("BigCorp.Models.ProductLine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("version")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ProductLine");
                });

            modelBuilder.Entity("BigCorp.Models.Stock", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("factory")
                        .HasColumnType("int");

                    b.Property<DateTime>("mfg")
                        .HasColumnType("datetime2");

                    b.Property<int>("productLine")
                        .HasColumnType("int");

                    b.Property<int>("warrantyTime")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}
