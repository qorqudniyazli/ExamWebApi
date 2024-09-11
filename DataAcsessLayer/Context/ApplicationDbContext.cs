using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet'ler tanımlanır
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Exam> Exams { get; set; }

    // OnModelCreating metodu ile model konfigürasyonları yapılır
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Lesson entity konfigrasiyaları
        modelBuilder.Entity<Lesson>()
            .HasKey(l => l.LessonCode);

        modelBuilder.Entity<Lesson>()
            .Property(l => l.LessonCode)
            .HasMaxLength(3)
            .IsFixedLength();

        modelBuilder.Entity<Lesson>()
            .Property(l => l.LessonName)
            .HasMaxLength(30);

        modelBuilder.Entity<Lesson>()
            .Property(l => l.Grade)
            .HasColumnType("number(2,0)");

        modelBuilder.Entity<Lesson>()
            .Property(l => l.TeacherFirstName)
            .HasMaxLength(20);

        modelBuilder.Entity<Lesson>()
            .Property(l => l.TeacherLastName)
            .HasMaxLength(20);

        // Student entity konfigrasiyaları
        modelBuilder.Entity<Student>()
            .HasKey(s => s.StudentNumber);

        modelBuilder.Entity<Student>()
            .Property(s => s.StudentNumber)
            .HasColumnType("number(5,0)");

        modelBuilder.Entity<Student>()
            .Property(s => s.FirstName)
            .HasMaxLength(30);

        modelBuilder.Entity<Student>()
            .Property(s => s.LastName)
            .HasMaxLength(30);

        modelBuilder.Entity<Student>()
            .Property(s => s.Grade)
            .HasColumnType("number(2,0)");

        // Exam entity konfigrasiyaları
        modelBuilder.Entity<Exam>()
            .HasKey(e => new { e.LessonCode, e.StudentNumber });

        modelBuilder.Entity<Exam>()
            .Property(e => e.LessonCode)
            .HasMaxLength(3)
            .IsFixedLength();

        modelBuilder.Entity<Exam>()
            .Property(e => e.StudentNumber)
            .HasColumnType("number(5,0)");

        modelBuilder.Entity<Exam>()
            .Property(e => e.ExamDate)
            .HasColumnType("date");

        modelBuilder.Entity<Exam>()
            .Property(e => e.Score)
            .HasColumnType("number(1,0)");
    }
}
