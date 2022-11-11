using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contractor_FindingDEMO.Models;

public partial class ContractorProjectContext : DbContext
{
    public ContractorProjectContext()
    {
    }

    public ContractorProjectContext(DbContextOptions<ContractorProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CityName> CityNames { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Map> Maps { get; set; }

    public virtual DbSet<StateName> StateNames { get; set; }

    public virtual DbSet<TypeUser> TypeUsers { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Contractor_project;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityName>(entity =>
        {
            entity.HasKey(e => e.CityName1).HasName("PK__city_nam__AEE8ADD09A75E927");

            entity.ToTable("city_name");

            entity.HasIndex(e => e.CityId, "UQ__city_nam__B4BEB95F3C1A0803").IsUnique();

            entity.Property(e => e.CityName1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cityName");
            entity.Property(e => e.CityId).HasColumnName("cityId");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderName).HasName("PK__Gender__14B63E728848E22B");

            entity.ToTable("Gender");

            entity.HasIndex(e => e.GenderId, "UQ__Gender__306E2221CDFCD616").IsUnique();

            entity.Property(e => e.GenderName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("genderName");
            entity.Property(e => e.GenderId).HasColumnName("genderID");
        });

        modelBuilder.Entity<Map>(entity =>
        {
            entity.HasKey(e => e.PlaceId).HasName("PK__Map__D5222B4E37AA165D");

            entity.ToTable("Map");

            entity.HasIndex(e => e.Latitude, "UQ__Map__678401E2C3260E7F").IsUnique();

            entity.HasIndex(e => e.Longitude, "UQ__Map__ED4CDA8C76FEA7A9").IsUnique();

            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
        });

        modelBuilder.Entity<StateName>(entity =>
        {
            entity.HasKey(e => e.StateName1).HasName("PK__state_na__8B97A9618DC35E2D");

            entity.ToTable("state_name");

            entity.HasIndex(e => e.StateId, "UQ__state_na__A667B9E0974410FB").IsUnique();

            entity.Property(e => e.StateName1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("stateName");
            entity.Property(e => e.StateId).HasColumnName("stateId");
        });

        modelBuilder.Entity<TypeUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Type_Use__3213E83F89A2C3D9");

            entity.ToTable("Type_User");

            entity.HasIndex(e => e.UserType, "UQ__Type_Use__1FDA748B44C834A3").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Duration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("duration");
            entity.Property(e => e.UserType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User_Det__CB9A1CFFC8B527E5");

            entity.ToTable("User_Details");

            entity.HasIndex(e => e.PhoneNumber, "UQ__User_Det__4849DA01B121D5AE").IsUnique();

            entity.HasIndex(e => e.MailId, "UQ__User_Det__F5CD78A99D239220").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.MailId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mailId");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.StateName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("stateName");
            entity.Property(e => e.TypeUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("typeUser");

            entity.HasOne(d => d.CityNameNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.CityName)
                .HasConstraintName("FK__User_Deta__CityN__2645B050");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.Gender)
                .HasConstraintName("FK__User_Deta__gende__245D67DE");

            entity.HasOne(d => d.StateNameNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.StateName)
                .HasConstraintName("FK__User_Deta__state__25518C17");

            entity.HasOne(d => d.TypeUserNavigation).WithMany(p => p.UserDetails)
                .HasPrincipalKey(p => p.UserType)
                .HasForeignKey(d => d.TypeUser)
                .HasConstraintName("FK__User_Deta__typeU__236943A5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
