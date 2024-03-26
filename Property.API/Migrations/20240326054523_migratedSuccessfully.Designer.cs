﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Property.Data;

#nullable disable

namespace Property.API.Migrations
{
    [DbContext(typeof(PropertyDbContext))]
    [Migration("20240326054523_migratedSuccessfully")]
    partial class migratedSuccessfully
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Property.Model.PropertyStatusType", b =>
                {
                    b.Property<int>("PropertyStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyStatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("PropertyStatusId");

                    b.ToTable("PropertyStatus");
                });

            modelBuilder.Entity("Property.Model.PropertyType", b =>
                {
                    b.Property<int>("PropertyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyTypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("PropertyTypeId");

                    b.ToTable("PropertyType");
                });

            modelBuilder.Entity("Property.Model.Propertys", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<string>("PropertyAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PropertyBedrooms")
                        .HasColumnType("int");

                    b.Property<string>("PropertyDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PropertyPrice")
                        .HasColumnType("int");

                    b.Property<int>("PropertySize")
                        .HasColumnType("int");

                    b.Property<int>("PropertyStatusId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("PropertyStatusId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Propertys");
                });

            modelBuilder.Entity("Property.Model.Propertys", b =>
                {
                    b.HasOne("Property.Model.PropertyStatusType", "PropertyStatusType")
                        .WithMany()
                        .HasForeignKey("PropertyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Property.Model.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropertyStatusType");

                    b.Navigation("PropertyType");
                });
#pragma warning restore 612, 618
        }
    }
}
