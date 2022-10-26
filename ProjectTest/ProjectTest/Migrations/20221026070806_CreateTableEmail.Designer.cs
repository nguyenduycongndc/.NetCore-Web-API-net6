﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTest.Data;

#nullable disable

namespace ProjectTest.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20221026070806_CreateTableEmail")]
    partial class CreateTableEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectTest.Data.DataEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)")
                        .HasColumnName("body");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<string>("Subject")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("subject");

                    b.HasKey("Id");

                    b.ToTable("data_email");
                });

            modelBuilder.Entity("ProjectTest.Data.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("ProjectTest.Data.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DateOfJoining")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_joining");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<DateTime?>("ExpirationDateOtp")
                        .HasColumnType("datetime2")
                        .HasColumnName("expiration_date_otp");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("full_name");

                    b.Property<int>("IsActive")
                        .HasColumnType("int")
                        .HasColumnName("is_active");

                    b.Property<int?>("IsDeleted")
                        .HasColumnType("int")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("modified_by");

                    b.Property<int?>("OTP")
                        .HasColumnType("int")
                        .HasColumnName("otp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("SaltKey")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("salt");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ProjectTest.Data.UsersRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("roles_id")
                        .HasColumnType("int");

                    b.Property<int?>("users_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("roles_id");

                    b.HasIndex("users_id");

                    b.ToTable("users_roles");
                });

            modelBuilder.Entity("ProjectTest.Data.UsersRoles", b =>
                {
                    b.HasOne("ProjectTest.Data.Roles", "Roles")
                        .WithMany("UsersRoles")
                        .HasForeignKey("roles_id");

                    b.HasOne("ProjectTest.Data.Users", "Users")
                        .WithMany("UsersRoles")
                        .HasForeignKey("users_id");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProjectTest.Data.Roles", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("ProjectTest.Data.Users", b =>
                {
                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
