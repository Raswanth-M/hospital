using HospitalAppMgnt.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppMgnt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<DoctorProfile> DoctorProfiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
    new User { Id = 1, UserName = "doctor1", Password = "password123", Role = "Doctor" },
    new User { Id = 2, UserName = "patient1", Password = "password123", Role = "Patient" },
    new User { Id = 3, UserName = "doctor2", Password = "password123", Role = "Doctor" },
    new User { Id = 4, UserName = "patient2", Password = "password123", Role = "Patient" }
);

            modelBuilder.Entity<DoctorProfile>().HasData(
    new DoctorProfile { Id = 1, Name = "Dr. John Doe", Specialization = "Cardiology", ContactDetails = "123-456-7890", Availability = "9 AM - 5 PM", UserId = 1 },
    new DoctorProfile { Id = 2, Name = "Dr. Jane Smith", Specialization = "Neurology", ContactDetails = "987-654-3210", Availability = "10 AM - 6 PM", UserId = 3 }
);

            modelBuilder.Entity<PatientProfile>().HasData(
    new PatientProfile { Id = 1, Name = "Alice Johnson", DateOfBirth = new DateTime(1990, 1, 1), MedicalHistory = "Asthma", ContactDetails = "alice@example.com", UserId = 2 },
    new PatientProfile { Id = 2, Name = "Bob Brown", DateOfBirth = new DateTime(1985, 5, 15), MedicalHistory = "Diabetes", ContactDetails = "bob@example.com", UserId = 4 }
);
            modelBuilder.Entity<Notification>().HasData(
    new Notification { Id = 1, UserId = 1, Message = "Your appointment is confirmed.", Timestamp = DateTime.Now, Status = "Unread" },
    new Notification { Id = 2, UserId = 2, Message = "Your test results are available.", Timestamp = DateTime.Now, Status = "Unread" }
);
            modelBuilder.Entity<DoctorSchedule>().HasData(
    new DoctorSchedule { Id = 1,ScheduleId = 1, DoctorId = 1, AvailableTimeSlots = "9 AM - 10 AM, 2 PM - 3 PM", IsSlotFilled = false },
    new DoctorSchedule { Id = 2,ScheduleId = 2, DoctorId = 2, AvailableTimeSlots = "10 AM - 11 AM, 4 PM - 5 PM", IsSlotFilled = false }
);

            modelBuilder.Entity<Appointment>().HasData(
    new Appointment { Id = 1, PatientId = 1, DoctorId = 1, AppointmentDate = new DateTime(2025, 3, 20, 9, 0, 0), Status = "Scheduled" },
    new Appointment { Id = 2, PatientId = 2, DoctorId = 2, AppointmentDate = new DateTime(2025, 3, 21, 10, 0, 0), Status = "Scheduled" }
);
            modelBuilder.Entity<MedicalHistory>().HasData(
    new MedicalHistory { Id = 1, PatientId = 1, Diagnosis = "Asthma", Treatment = "Inhaler", DateOfVisit = new DateTime(2025, 1, 15) },
    new MedicalHistory { Id = 2, PatientId = 2, Diagnosis = "Diabetes", Treatment = "Insulin", DateOfVisit = new DateTime(2025, 2, 10) }
);

            //modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            //modelBuilder.Entity<PatientProfile>()
            //    .HasOne(p => p.User)
            //    .WithOne(u => u.PatientProfile)
            //    .HasForeignKey<PatientProfile>(p => p.UserId)
            //    .OnDelete(DeleteBehavior.NoAction); 

            //modelBuilder.Entity<DoctorProfile>()
            //    .HasOne(d => d.User)
            //    .WithOne(u => u.DoctorProfile)
            //    .HasForeignKey<DoctorProfile>(d => d.UserId)
            //    .OnDelete(DeleteBehavior.NoAction); // Prevents cascading deletes

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Patient)
            //    .WithMany(p => p.Appointments)
            //    .HasForeignKey(a => a.PatientId)
            //    .OnDelete(DeleteBehavior.NoAction); 

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Doctor)
            //    .WithMany(d => d.Appointments)
            //    .HasForeignKey(a => a.DoctorId)
            //    .OnDelete(DeleteBehavior.NoAction); 

            //modelBuilder.Entity<DoctorSchedule>()
            //    .HasOne(ds => ds.Doctor)
            //    .WithMany(d => d.DoctorSchedules)
            //    .HasForeignKey(ds => ds.DoctorId)
            //    .OnDelete(DeleteBehavior.NoAction); 

            //modelBuilder.Entity<MedicalHistory>()
            //    .HasOne(mh => mh.Patient)
            //    .WithMany(p => p.MedicalHistories)
            //    .HasForeignKey(mh => mh.PatientId)
            //    .OnDelete(DeleteBehavior.NoAction); 

            //modelBuilder.Entity<Notification>()
            //    .HasOne(n => n.User)
            //    .WithMany(u => u.Notifications)
            //    .HasForeignKey(n => n.UserId)
            //    .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}