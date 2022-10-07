using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace E_prescription.Models
{
    public partial class GRP42EPrescriptionContext : DbContext
    {
        public GRP42EPrescriptionContext()
        {
        }

        public GRP42EPrescriptionContext(DbContextOptions<GRP42EPrescriptionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveIngredient> ActiveIngredients { get; set; }
        public virtual DbSet<ActiveIngredientStrength> ActiveIngredientStrengths { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ChronicHistory> ChronicHistories { get; set; }
        public virtual DbSet<ChronicMedication> ChronicMedications { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ConditionDiagnosis> ConditionDiagnoses { get; set; }
        public virtual DbSet<ContraIndication> ContraIndications { get; set; }
        public virtual DbSet<DispensedMedication> DispensedMedications { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DosageForm> DosageForms { get; set; }
        public virtual DbSet<HighestQualification> HighestQualifications { get; set; }
        public virtual DbSet<InteractionLevel> InteractionLevels { get; set; }
        public virtual DbSet<MedInteractionActiveIngredient> MedInteractionActiveIngredients { get; set; }
        public virtual DbSet<MedicalPractice> MedicalPractices { get; set; }
        public virtual DbSet<MedicationActiveIngredient> MedicationActiveIngredients { get; set; }
        public virtual DbSet<MedicationInteraction> MedicationInteractions { get; set; }
        public virtual DbSet<MedicationRecord> MedicationRecords { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientAllergy> PatientAllergies { get; set; }
        public virtual DbSet<PatientDoctorVisit> PatientDoctorVisits { get; set; }
        public virtual DbSet<Pharmacist> Pharmacists { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Repeat> Repeats { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Suburb> Suburbs { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SICT-SQL.mandela.ac.za;Database=GRP-4-2-EPrescription;User ID=GRP-4-02;Password=grp-4-02-soit2022");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ActiveIngredient>(entity =>
            {
                entity.HasKey(e => e.IngredientId);

                entity.ToTable("ActiveIngredient");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.IngredientDescription).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.StrengthId).HasColumnName("StrengthID");

                entity.HasOne(d => d.Strength)
                    .WithMany(p => p.ActiveIngredients)
                    .HasForeignKey(d => d.StrengthId)
                    .HasConstraintName("FK_ActiveIngredient_ActiveIngredientStrength");
            });

            modelBuilder.Entity<ActiveIngredientStrength>(entity =>
            {
                entity.HasKey(e => e.StrengthId);

                entity.ToTable("ActiveIngredientStrength");

                entity.Property(e => e.StrengthId).HasColumnName("StrengthID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.StrengthDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("AdminID");

                entity.HasOne(d => d.AdminNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_tblUser");
            });

            modelBuilder.Entity<ChronicHistory>(entity =>
            {
                entity.HasKey(e => e.ChronicId);

                entity.ToTable("ChronicHistory");

                entity.Property(e => e.ChronicId).HasColumnName("ChronicID");

                entity.Property(e => e.ConditionId).HasColumnName("ConditionID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.ChronicHistories)
                    .HasForeignKey(d => d.ConditionId)
                    .HasConstraintName("FK_ChronicHistory_ConditionDiagnosis");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ChronicHistories)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_ChronicHistory_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ChronicHistories)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_ChronicHistory_Patient");
            });

            modelBuilder.Entity<ChronicMedication>(entity =>
            {
                entity.ToTable("ChronicMedication");

                entity.Property(e => e.ChronicMedicationId).HasColumnName("ChronicMedicationID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ChronicMedications)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_ChronicMedication_Doctor");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.ChronicMedications)
                    .HasForeignKey(d => d.MedicationId)
                    .HasConstraintName("FK_ChronicMedication_MedicationRecord");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ChronicMedications)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_ChronicMedication_Patient");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(4)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_City_Province");
            });

            modelBuilder.Entity<ConditionDiagnosis>(entity =>
            {
                entity.HasKey(e => e.ConditionId);

                entity.ToTable("ConditionDiagnosis");

                entity.Property(e => e.ConditionId).HasColumnName("ConditionID");

                entity.Property(e => e.ConditionDecription).HasMaxLength(50);
            });

            modelBuilder.Entity<ContraIndication>(entity =>
            {
                entity.ToTable("ContraIndication");

                entity.Property(e => e.ContraIndicationId).HasColumnName("ContraIndicationID");

                entity.Property(e => e.ConditionId).HasColumnName("ConditionID");

                entity.Property(e => e.ContraIndicationName).HasMaxLength(50);

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.ContraIndications)
                    .HasForeignKey(d => d.ConditionId)
                    .HasConstraintName("FK_ContraIndication_ConditionDiagnosis");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.ContraIndications)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_ContraIndication_ActiveIngredient");
            });

            modelBuilder.Entity<DispensedMedication>(entity =>
            {
                entity.ToTable("DispensedMedication");

                entity.Property(e => e.DispensedMedicationId).HasColumnName("DispensedMedicationID");

                entity.Property(e => e.ContraIndicationId).HasColumnName("ContraIndicationID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DosageId).HasColumnName("DosageID");

                entity.Property(e => e.MedInteractionId).HasColumnName("MedInteractionID");

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.PharmacistId).HasColumnName("PharmacistID");

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.WarningIgnoreReason).HasMaxLength(50);

                entity.HasOne(d => d.ContraIndication)
                    .WithMany(p => p.DispensedMedications)
                    .HasForeignKey(d => d.ContraIndicationId)
                    .HasConstraintName("FK_DispensedMedication_ContraIndication");

                entity.HasOne(d => d.Dosage)
                    .WithMany(p => p.DispensedMedications)
                    .HasForeignKey(d => d.DosageId)
                    .HasConstraintName("FK_DispensedMedication_DosageForm");

                entity.HasOne(d => d.MedInteraction)
                    .WithMany(p => p.DispensedMedications)
                    .HasForeignKey(d => d.MedInteractionId)
                    .HasConstraintName("FK_DispensedMedication_MedicationInteraction");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.DispensedMedications)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DispensedMedication_MedicationRecord");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DispensedMedications)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_DispensedMedication_Patient");

                entity.HasOne(d => d.Pharmacist)
                    .WithMany(p => p.DispensedMedications)
                    .HasForeignKey(d => d.PharmacistId)
                    .HasConstraintName("FK_DispensedMedication_Pharmacist");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorId)
                    .ValueGeneratedNever()
                    .HasColumnName("DoctorID");

                entity.Property(e => e.Hcrn)
                    .HasMaxLength(50)
                    .HasColumnName("HCRN");

                entity.Property(e => e.MedicalPracticeId).HasColumnName("MedicalPracticeID");

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.HasOne(d => d.DoctorNavigation)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_tblUser");

                entity.HasOne(d => d.MedicalPractice)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.MedicalPracticeId)
                    .HasConstraintName("FK_Doctor_MedicalPractice");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.QualificationId)
                    .HasConstraintName("FK_Doctor_HighestQualification");
            });

            modelBuilder.Entity<DosageForm>(entity =>
            {
                entity.HasKey(e => e.DosageId);

                entity.ToTable("DosageForm");

                entity.Property(e => e.DosageId).HasColumnName("DosageID");

                entity.Property(e => e.DosageDescription).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<HighestQualification>(entity =>
            {
                entity.HasKey(e => e.QualificationId);

                entity.ToTable("HighestQualification");

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.Property(e => e.QualificationName).HasMaxLength(50);
            });

            modelBuilder.Entity<InteractionLevel>(entity =>
            {
                entity.ToTable("InteractionLevel");

                entity.Property(e => e.InteractionLevelId).HasColumnName("InteractionLevelID");

                entity.Property(e => e.InteractionLevelDecsription).HasMaxLength(50);
            });

            modelBuilder.Entity<MedInteractionActiveIngredient>(entity =>
            {
                entity.ToTable("MedInteraction_ActiveIngredient");

                entity.Property(e => e.MedInteractionActiveIngredientId).HasColumnName("MedInteraction_ActiveIngredientID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.InteractionLevelId).HasColumnName("InteractionLevelID");

                entity.Property(e => e.MedInteractionId).HasColumnName("MedInteractionID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.MedInteractionActiveIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_MedInteraction_ActiveIngredient_ActiveIngredient1");

                entity.HasOne(d => d.InteractionLevel)
                    .WithMany(p => p.MedInteractionActiveIngredients)
                    .HasForeignKey(d => d.InteractionLevelId)
                    .HasConstraintName("FK_MedInteraction_ActiveIngredient_InteractionLevel1");

                entity.HasOne(d => d.MedInteraction)
                    .WithMany(p => p.MedInteractionActiveIngredients)
                    .HasForeignKey(d => d.MedInteractionId)
                    .HasConstraintName("FK_MedInteraction_ActiveIngredient_MedicationInteraction");
            });

            modelBuilder.Entity<MedicalPractice>(entity =>
            {
                entity.ToTable("MedicalPractice");

                entity.Property(e => e.MedicalPracticeId).HasColumnName("MedicalPracticeID");

                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.PracticeContactNo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PracticeEmail).HasMaxLength(50);

                entity.Property(e => e.PracticeName).HasMaxLength(50);

                entity.Property(e => e.PracticeNo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.SuburbId).HasColumnName("SuburbID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.MedicalPractices)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_MedicalPractice_City");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.MedicalPractices)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_MedicalPractice_Province");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.MedicalPractices)
                    .HasForeignKey(d => d.SuburbId)
                    .HasConstraintName("FK_MedicalPractice_Suburb");
            });

            modelBuilder.Entity<MedicationActiveIngredient>(entity =>
            {
                entity.HasKey(e => e.MedicationIngredientId);

                entity.ToTable("Medication_ActiveIngredient");

                entity.Property(e => e.MedicationIngredientId).HasColumnName("MedicationIngredientID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.MedicationActiveIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_Medication_ActiveIngredient_ActiveIngredient");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.MedicationActiveIngredients)
                    .HasForeignKey(d => d.MedicationId)
                    .HasConstraintName("FK_Medication_ActiveIngredient_MedicationRecord");
            });

            modelBuilder.Entity<MedicationInteraction>(entity =>
            {
                entity.HasKey(e => e.MedInteractionId);

                entity.ToTable("MedicationInteraction");

                entity.Property(e => e.MedInteractionId).HasColumnName("MedInteractionID");

                entity.Property(e => e.ActiveIngredient1).HasMaxLength(50);

                entity.Property(e => e.ActiveIngredient2).HasMaxLength(50);

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.MedicationInteractions)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_MedicationInteraction_ActiveIngredient");
            });

            modelBuilder.Entity<MedicationRecord>(entity =>
            {
                entity.HasKey(e => e.MedicationId);

                entity.ToTable("MedicationRecord");

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.Property(e => e.DosageId).HasColumnName("DosageID");

                entity.Property(e => e.MedicationName).HasMaxLength(50);

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.HasOne(d => d.Dosage)
                    .WithMany(p => p.MedicationRecords)
                    .HasForeignKey(d => d.DosageId)
                    .HasConstraintName("FK_MedicationRecord_DosageForm");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.MedicationRecords)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK_MedicationRecord_Schedule");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("PatientID");

                entity.Property(e => e.Dob)
                    .HasMaxLength(20)
                    .HasColumnName("DOB");

                entity.Property(e => e.Idnumber)
                    .HasMaxLength(13)
                    .HasColumnName("IDNumber")
                    .IsFixedLength(true);

                entity.HasOne(d => d.PatientNavigation)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<Patient>(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_tblUser");
            });

            modelBuilder.Entity<PatientAllergy>(entity =>
            {
                entity.HasKey(e => e.AllergyId);

                entity.ToTable("PatientAllergy");

                entity.Property(e => e.AllergyId).HasColumnName("AllergyID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PatientAllergies)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_PatientAllergy_Doctor");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PatientAllergies)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_PatientAllergy_ActiveIngredient");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAllergies)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientAllergy_Patient");
            });

            modelBuilder.Entity<PatientDoctorVisit>(entity =>
            {
                entity.ToTable("PatientDoctorVisit");

                entity.Property(e => e.PatientDoctorVisitId).HasColumnName("PatientDoctorVisitID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.VisitDate).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PatientDoctorVisits)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_PatientDoctorVisit_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientDoctorVisits)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientDoctorVisit_Patient");
            });

            modelBuilder.Entity<Pharmacist>(entity =>
            {
                entity.ToTable("Pharmacist");

                entity.Property(e => e.PharmacistId)
                    .ValueGeneratedNever()
                    .HasColumnName("PharmacistID");

                entity.Property(e => e.PharmacyId).HasColumnName("PharmacyID");

                entity.Property(e => e.RegNumber)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.PharmacistNavigation)
                    .WithOne(p => p.Pharmacist)
                    .HasForeignKey<Pharmacist>(d => d.PharmacistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pharmacist_tblUser");

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.Pharmacists)
                    .HasForeignKey(d => d.PharmacyId)
                    .HasConstraintName("FK_Pharmacist_Pharmacy");
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.ToTable("Pharmacy");

                entity.Property(e => e.PharmacyId).HasColumnName("PharmacyID");

                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.LicenseNo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PharmacyContactNo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PharmacyEmail).HasMaxLength(50);

                entity.Property(e => e.PharmacyName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.SuburbId).HasColumnName("SuburbID");
            });

            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.ToTable("PostalCode");

                entity.Property(e => e.PostalCodeId)
                    .ValueGeneratedNever()
                    .HasColumnName("PostalCodeID");

                entity.Property(e => e.CityId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CityID");

                entity.Property(e => e.PostalCodeName).HasMaxLength(20);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.PostalCodes)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostalCode_PostalCode");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

                entity.Property(e => e.ConditionId).HasColumnName("ConditionID");

                entity.Property(e => e.DosageId).HasColumnName("DosageID");

                entity.Property(e => e.Instruction).HasMaxLength(50);

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.ConditionId)
                    .HasConstraintName("FK_Prescription_ConditionDiagnosis");

                entity.HasOne(d => d.Dosage)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DosageId)
                    .HasConstraintName("FK_Prescription_DosageForm");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.MedicationId)
                    .HasConstraintName("FK_Prescription_MedicationRecord");
            });

            modelBuilder.Entity<PrescriptionMedication>(entity =>
            {
                entity.ToTable("Prescription_Medication");

                entity.Property(e => e.PrescriptionMedicationId).HasColumnName("PrescriptionMedicationID");

                entity.Property(e => e.ContraIndicationId).HasColumnName("ContraIndicationID");

                entity.Property(e => e.DosageId).HasColumnName("DosageID");

                entity.Property(e => e.Instruction).HasMaxLength(50);

                entity.Property(e => e.MedInteractionId).HasColumnName("MedInteractionID");

                entity.Property(e => e.MedicationId).HasColumnName("MedicationID");

                entity.Property(e => e.PatientDoctorVisitId).HasColumnName("PatientDoctorVisitID");

                entity.Property(e => e.PrescriptionDate).HasColumnType("datetime");

                entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.RepeatId).HasColumnName("RepeatID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.WarningIgnoreReason).HasMaxLength(50);

                entity.HasOne(d => d.ContraIndication)
                    .WithMany(p => p.PrescriptionMedications)
                    .HasForeignKey(d => d.ContraIndicationId)
                    .HasConstraintName("FK_Prescription_Medication_ContraIndication");

                entity.HasOne(d => d.Dosage)
                    .WithMany(p => p.PrescriptionMedications)
                    .HasForeignKey(d => d.DosageId)
                    .HasConstraintName("FK_Prescription_Medication_DosageForm");

                entity.HasOne(d => d.MedInteraction)
                    .WithMany(p => p.PrescriptionMedications)
                    .HasForeignKey(d => d.MedInteractionId)
                    .HasConstraintName("FK_Prescription_Medication_MedicationInteraction");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.PrescriptionMedications)
                    .HasForeignKey(d => d.MedicationId)
                    .HasConstraintName("FK_Prescription_Medication_MedicationRecord");

                entity.HasOne(d => d.PatientDoctorVisit)
                    .WithMany(p => p.PrescriptionMedications)
                    .HasForeignKey(d => d.PatientDoctorVisitId)
                    .HasConstraintName("FK_Prescription_Medication_PatientDoctorVisit");

                entity.HasOne(d => d.Repeat)
                    .WithMany(p => p.PrescriptionMedications)
                    .HasForeignKey(d => d.RepeatId)
                    .HasConstraintName("FK_Prescription_Medication_Repeat");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.ProvinceName).HasMaxLength(50);
            });

            modelBuilder.Entity<Repeat>(entity =>
            {
                entity.ToTable("Repeat");

                entity.Property(e => e.RepeatId).HasColumnName("RepeatID");

                entity.Property(e => e.RepeatDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.ScheduleDescription).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Suburb>(entity =>
            {
                entity.ToTable("Suburb");

                entity.Property(e => e.SuburbId).HasColumnName("SuburbID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.SuburbName).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Suburbs)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Suburb_City");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.SuburbId).HasColumnName("SuburbID");

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserStatus).HasMaxLength(50);

                entity.Property(e => e.UserType).HasMaxLength(50);

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.SuburbId)
                    .HasConstraintName("FK_User_Suburb");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
