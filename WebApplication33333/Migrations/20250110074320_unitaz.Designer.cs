﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication33333.Models;

#nullable disable

namespace WebApplication33333.Migrations
{
    [DbContext(typeof(Dz2Context))]
    [Migration("20250110074320_unitaz")]
    partial class unitaz
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication33333.Faculty", b =>
                {
                    b.Property<long>("GroupId")
                        .HasColumnType("bigint")
                        .HasColumnName("group_id")
                        .HasDefaultValueSql("nextval('group_id_seq'::regclass)");

                    b.Property<string>("Faculty1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("faculty");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("group_name");

                    b.Property<int>("YearOfAdmission")
                        .HasColumnType("integer")
                        .HasColumnName("year_of_admission");

                    b.HasKey("GroupId")
                        .HasName("facultys_pkey");

                    b.ToTable("facultys", (string)null);
                });

            modelBuilder.Entity("WebApplication33333.GiftedGrant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("nextval('Id_seq'::regclass)");

                    b.Property<string>("GrantName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("grant_name");

                    b.Property<long?>("GrantValue")
                        .HasColumnType("bigint")
                        .HasColumnName("grant_value");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer")
                        .HasColumnName("student_id");

                    b.HasKey("Id")
                        .HasName("Idpkey");

                    b.HasIndex("GrantName");

                    b.HasIndex("StudentId");

                    b.ToTable("GiftedGrants", (string)null);
                });

            modelBuilder.Entity("WebApplication33333.GrantsInfo", b =>
                {
                    b.Property<string>("GrantName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("grant_name");

                    b.Property<long>("AspirantGrantValue")
                        .HasColumnType("bigint")
                        .HasColumnName("aspirant_grant_value");

                    b.Property<long>("BanclorGrantValue")
                        .HasColumnType("bigint")
                        .HasColumnName("banclor_grant_value");

                    b.Property<int?>("GrantNameId")
                        .HasColumnType("integer")
                        .HasColumnName("grant_name_id");

                    b.Property<long>("MasterGrantValue")
                        .HasColumnType("bigint")
                        .HasColumnName("master_grant_value");

                    b.HasKey("GrantName")
                        .HasName("grants_info_pkey");

                    b.ToTable("grants_info", (string)null);
                });

            modelBuilder.Entity("WebApplication33333.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("nextval('Id_seq'::regclass)");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("degree");

                    b.Property<long?>("Group")
                        .HasColumnType("bigint")
                        .HasColumnName("group");

                    b.Property<long>("Semester")
                        .HasColumnType("bigint")
                        .HasColumnName("semester");

                    b.Property<string>("StudentFatherName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("student_father_name");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("student_name");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("student_surname");

                    b.HasKey("Id")
                        .HasName("student_info_pkey");

                    b.HasIndex("Group");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication33333.GiftedGrant", b =>
                {
                    b.HasOne("WebApplication33333.GrantsInfo", "GrantNameNavigation")
                        .WithMany()
                        .HasForeignKey("GrantName")
                        .IsRequired()
                        .HasConstraintName("GiftedGrants_fk2");

                    b.HasOne("WebApplication33333.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("GiftedGrants_fk1");

                    b.Navigation("GrantNameNavigation");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApplication33333.Student", b =>
                {
                    b.HasOne("WebApplication33333.Faculty", "GroupNavigation")
                        .WithMany("Students")
                        .HasForeignKey("Group")
                        .HasConstraintName("student_info_group_fkey");

                    b.Navigation("GroupNavigation");
                });

            modelBuilder.Entity("WebApplication33333.Faculty", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
