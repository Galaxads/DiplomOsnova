using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе.Context;

public partial class User015Context : DbContext
{
    public User015Context()
    {
    }

    public User015Context(DbContextOptions<User015Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Achivka> Achivkas { get; set; }

    public virtual DbSet<Achivlist> Achivlists { get; set; }

    public virtual DbSet<Bioinf> Bioinfs { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Listbioinf> Listbioinfs { get; set; }

    public virtual DbSet<Listtrenirov> Listtrenirovs { get; set; }

    public virtual DbSet<Perosnalupr> Perosnaluprs { get; set; }

    public virtual DbSet<Problem> Problems { get; set; }

    public virtual DbSet<Problemslist> Problemslists { get; set; }

    public virtual DbSet<Unicalplan> Unicalplans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=user015;Username=user015;password=67102");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achivka>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achivka_pk");

            entity.ToTable("achivka", "FitnesPrl");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Achivlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achivlist_pk");

            entity.ToTable("achivlist", "FitnesPrl");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdAchiv).HasColumnName("id_achiv");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdAchivNavigation).WithMany(p => p.Achivlists)
                .HasForeignKey(d => d.IdAchiv)
                .HasConstraintName("achivlist_achivka_fk");
        });

        modelBuilder.Entity<Bioinf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bioinf_pk");

            entity.ToTable("bioinf", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Kolvovater).HasColumnName("kolvovater");
            entity.Property(e => e.Rost).HasColumnName("rost");
            entity.Property(e => e.Ves).HasColumnName("ves");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exercise_pk");

            entity.ToTable("exercise", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Povtorenia).HasColumnName("povtorenia");
            entity.Property(e => e.Problems).HasColumnName("problems");
            entity.Property(e => e.Slojnost).HasColumnName("slojnost");

            entity.HasOne(d => d.ProblemsNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.Problems)
                .HasConstraintName("exercise_problemslist_fk");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genders_pk");

            entity.ToTable("genders", "FitnesPrl");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Genders).HasColumnName("genders");
        });

        modelBuilder.Entity<Listbioinf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("listbioinf_pk");

            entity.ToTable("listbioinf", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Listbio).HasColumnName("listbio");
            entity.Property(e => e.Listuser).HasColumnName("listuser");

            entity.HasOne(d => d.ListbioNavigation).WithMany(p => p.Listbioinfs)
                .HasForeignKey(d => d.Listbio)
                .HasConstraintName("listbioinf_bioinf_fk");
        });

        modelBuilder.Entity<Listtrenirov>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("listtrenirov_pk");

            entity.ToTable("listtrenirov", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Listupr).HasColumnName("listupr");
            entity.Property(e => e.Listuser).HasColumnName("listuser");

            entity.HasOne(d => d.ListuprNavigation).WithMany(p => p.Listtrenirovs)
                .HasForeignKey(d => d.Listupr)
                .HasConstraintName("listtrenirov_exercise_fk");
        });

        modelBuilder.Entity<Perosnalupr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("perosnalupr_pk");

            entity.ToTable("perosnalupr", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.End).HasColumnName("end");
            entity.Property(e => e.Idday).HasColumnName("idday");
            entity.Property(e => e.Idupr).HasColumnName("idupr");
        });

        modelBuilder.Entity<Problem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("problem_pk");

            entity.ToTable("problem", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Problemslist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("problems_pk");

            entity.ToTable("problemslist", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdProbl).HasColumnName("id_probl");
            entity.Property(e => e.IdUpr).HasColumnName("id_upr");

            entity.HasOne(d => d.IdProblNavigation).WithMany(p => p.Problemslists)
                .HasForeignKey(d => d.IdProbl)
                .HasConstraintName("problemslist_problem_fk");

            entity.HasOne(d => d.IdUprNavigation).WithMany(p => p.Problemslists)
                .HasForeignKey(d => d.IdUpr)
                .HasConstraintName("problemslist_exercise_fk");
        });

        modelBuilder.Entity<Unicalplan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unicalplan_pk");

            entity.ToTable("unicalplan", "FitnesPrl");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Soisokupr).HasColumnName("soisokupr");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("User", "FitnesPrl");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Achivment).HasColumnName("achivment");
            entity.Property(e => e.Biodate).HasColumnName("biodate");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Plansport).HasColumnName("plansport");

            entity.HasOne(d => d.AchivmentNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Achivment)
                .HasConstraintName("user_achivlist_fk");

            entity.HasOne(d => d.BiodateNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Biodate)
                .HasConstraintName("user_listbioinf_fk");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Gender)
                .HasConstraintName("user_genders_fk");

            entity.HasOne(d => d.PlansportNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Plansport)
                .HasConstraintName("user_listtrenirov_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
