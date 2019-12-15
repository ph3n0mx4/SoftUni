namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments{ get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                entity.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                entity.Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode(true);

                entity.Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

                entity.Property(p => p.HasInsurance)
                .IsRequired(true);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity.Property(v => v.Date)
                .HasColumnType("DATETIME");

                entity.Property(v => v.Comments)
                .IsUnicode(true)
                .HasMaxLength(250);

                entity.HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(v => v.PatientId);

                entity.HasOne(v => v.Doctor)
                .WithMany(d => d.Visitations)
                .HasForeignKey(v => v.DoctorId);
            });

            modelBuilder.Entity<Diagnose>(e =>
            {
                e.HasKey(d => d.DiagnoseId);

                e.Property(d => d.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

                e.Property(d => d.Comments)
                .IsUnicode(true)
                .HasMaxLength(250);

                e.HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasKey(m => m.MedicamentId);

                e.Property(m => m.Name)
                .IsUnicode(true)
                .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientMedicament>(e =>
            {
                e.HasKey(pm => new { pm.MedicamentId, pm.PatientId });

                e.HasOne(pm => pm.Medicament)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);

                e.HasOne(pm => pm.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);
            });

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(d => d.DoctorId);

                e.Property(d => d.Name)
                .IsUnicode(true)
                .HasMaxLength(100);

                e.Property(d => d.Specialty)
                .IsUnicode(true)
                .HasMaxLength(100);

            });
        }


    }
}
