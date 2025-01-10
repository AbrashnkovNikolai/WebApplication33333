using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication33333.Models;

public partial class Dz2Context : DbContext
{
    public Dz2Context()
    {
    }

    public Dz2Context(DbContextOptions<Dz2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Faculty> Facultys { get; set; }

    public virtual DbSet<GiftedGrant> GiftedGrants { get; set; }



    public virtual DbSet<GrantsInfo> GrantsInfos { get; set; }



    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dz2;Username=postgres;Password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("facultys_pkey");

            entity.ToTable("facultys");

            entity.Property(e => e.GroupId)
                .ValueGeneratedNever()
                .HasColumnName("group_id");
            entity.Property(e => e.Faculty1).HasColumnName("faculty");
            entity.Property(e => e.GroupName).HasColumnName("group_name");
            entity.Property(e => e.YearOfAdmission).HasColumnName("year_of_admission");
        });

        modelBuilder.Entity<GiftedGrant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Idpkey");
            entity.ToTable("GiftedGrants");
            entity.Property(e => e.Id)
    .HasDefaultValueSql("nextval('student_info_id_seq'::regclass)")
    .HasColumnName("Id");



            entity.Property(e => e.GrantName)
                .HasMaxLength(255)
                .HasColumnName("grant_name");
            entity.Property(e => e.GrantValue).HasColumnName("grant_value");

            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.GrantNameNavigation).WithMany()
                .HasForeignKey(d => d.GrantName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GiftedGrants_fk2");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GiftedGrants_fk1");
        });

       

        modelBuilder.Entity<GrantsInfo>(entity =>
        {
            entity.HasKey(e => e.GrantName).HasName("grants_info_pkey");


            entity.ToTable("grants_info");

            entity.Property(e => e.GrantName)
                .HasMaxLength(255)
                .HasColumnName("grant_name");
            entity.Property(e => e.AspirantGrantValue).HasColumnName("aspirant_grant_value");
            entity.Property(e => e.BanclorGrantValue).HasColumnName("banclor_grant_value");
            entity.Property(e => e.GrantNameId).HasColumnName("grant_name_id");
            entity.Property(e => e.MasterGrantValue).HasColumnName("master_grant_value");
        });

       

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_info_pkey");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('student_info_id_seq'::regclass)")
                .HasColumnName("Id");
            entity.Property(e => e.Degree)
                .HasMaxLength(255)
                .HasColumnName("degree");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.StudentFatherName)
                .HasMaxLength(255)
                .HasColumnName("student_father_name");
            entity.Property(e => e.StudentName)
                .HasMaxLength(255)
                .HasColumnName("student_name");
            entity.Property(e => e.StudentSurname)
                .HasMaxLength(255)
                .HasColumnName("student_surname");

            entity.HasOne(d => d.GroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Group)
                .HasConstraintName("student_info_group_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
