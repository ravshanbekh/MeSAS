using Domain.Entities;
using Domain.Entitiesrg;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
   public  DbSet<User> Users { get; set; }
   public  DbSet<Analyse> Analyses { get; set; }
   public  DbSet<Attachment> Attachments { get; set; }
   public  DbSet<Booking> Bookings { get; set; }
   public  DbSet<Doctor> Doctors { get; set; }
   public  DbSet<Hospital> Hospitals { get; set; }
   public  DbSet<MedicalRecord> MedicalRecords { get; set; }
   public  DbSet<Message> Messages { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Analyse>()
    //        .HasOne(i => i.User)
    //        .WithMany()
    //        .HasForeignKey(i => i.UserId);

    //    modelBuilder.Entity<Analyse>()
    //        .HasOne(i => i.Doctor)
    //        .WithMany()
    //        .HasForeignKey(i => i.DoctorId);

    //    modelBuilder.Entity<Booking>()
    //        .HasOne(i => i.User)
    //        .WithMany()
    //        .HasForeignKey(i => i.UserId);

    //    modelBuilder.Entity<Booking>()
    //        .HasOne(i => i.Doctor)
    //        .WithMany()
    //        .HasForeignKey(i => i.DoctorId);
    //}
}
