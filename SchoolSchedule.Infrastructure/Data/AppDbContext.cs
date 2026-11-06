using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Core.Entities;
namespace SchoolSchedule.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Class> Classes => Set<Class>();
        public DbSet<CurriculumItem> CurriculumItems => Set<CurriculumItem>();
        public DbSet<LessonSlot> LessonSlots => Set<LessonSlot>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<TeacherSubject> TeacherSubjects => Set<TeacherSubject>();

    }
}
