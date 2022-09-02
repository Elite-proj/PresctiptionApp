using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_prescription.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveIngredientStrength",
                columns: table => new
                {
                    StrengthID = table.Column<int>(type: "int", nullable: false),
                    StrengthDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveIngredientStrength", x => x.StrengthID);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "ConditionDiagnosis",
                columns: table => new
                {
                    ConditionID = table.Column<int>(type: "int", nullable: false),
                    ConditionDecription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionDiagnosis", x => x.ConditionID);
                });

            migrationBuilder.CreateTable(
                name: "DosageForm",
                columns: table => new
                {
                    DosageID = table.Column<int>(type: "int", nullable: false),
                    DosageDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosageForm", x => x.DosageID);
                });

            migrationBuilder.CreateTable(
                name: "HighestQualification",
                columns: table => new
                {
                    QualificationID = table.Column<int>(type: "int", nullable: false),
                    QualificationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighestQualification", x => x.QualificationID);
                });

            migrationBuilder.CreateTable(
                name: "InteractionLevel",
                columns: table => new
                {
                    InteractionLevelID = table.Column<int>(type: "int", nullable: false),
                    InteractionLevelDecsription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionLevel", x => x.InteractionLevelID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    IDNumber = table.Column<string>(type: "nchar(13)", fixedLength: true, maxLength: 13, nullable: true),
                    DOB = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Repeat",
                columns: table => new
                {
                    RepeatID = table.Column<int>(type: "int", nullable: false),
                    RepeatDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repeat", x => x.RepeatID);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false),
                    ScheduleDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "ActiveIngredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    IngredientDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StrengthID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveIngredient", x => x.IngredientID);
                    table.ForeignKey(
                        name: "FK_ActiveIngredient_ActiveIngredientStrength",
                        column: x => x.StrengthID,
                        principalTable: "ActiveIngredientStrength",
                        principalColumn: "StrengthID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalPractice",
                columns: table => new
                {
                    MedicalPracticeID = table.Column<int>(type: "int", nullable: false),
                    PracticeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    PracticeEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PracticeContactNo = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    PracticeNo = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPractice", x => x.MedicalPracticeID);
                    table.ForeignKey(
                        name: "FK_MedicalPractice_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    PharmacyID = table.Column<int>(type: "int", nullable: false),
                    PharmacyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PharmacyContactNo = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    PharmacyEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LicenseNo = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.PharmacyID);
                    table.ForeignKey(
                        name: "FK_Pharmacy_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suburb",
                columns: table => new
                {
                    SuburbID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    SuburbName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb", x => x.SuburbID);
                    table.ForeignKey(
                        name: "FK_Suburb_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContraIndication",
                columns: table => new
                {
                    ContraIndicationID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: true),
                    ConditionID = table.Column<int>(type: "int", nullable: true),
                    ContraIndicationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraIndication", x => x.ContraIndicationID);
                    table.ForeignKey(
                        name: "FK_ContraIndication_ActiveIngredient",
                        column: x => x.IngredientID,
                        principalTable: "ActiveIngredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContraIndication_ConditionDiagnosis",
                        column: x => x.ConditionID,
                        principalTable: "ConditionDiagnosis",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicationInteraction",
                columns: table => new
                {
                    MedInteractionID = table.Column<int>(type: "int", nullable: false),
                    ActiveIngredient1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActiveIngredient2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IngredientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationInteraction", x => x.MedInteractionID);
                    table.ForeignKey(
                        name: "FK_MedicationInteraction_ActiveIngredient",
                        column: x => x.IngredientID,
                        principalTable: "ActiveIngredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicationRecord",
                columns: table => new
                {
                    MedicationID = table.Column<int>(type: "int", nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IngredientID = table.Column<int>(type: "int", nullable: true),
                    ScheduleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationRecord", x => x.MedicationID);
                    table.ForeignKey(
                        name: "FK_MedicationRecord_ActiveIngredient",
                        column: x => x.IngredientID,
                        principalTable: "ActiveIngredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicationRecord_Schedule",
                        column: x => x.ScheduleID,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    HCRN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QualificationID = table.Column<int>(type: "int", nullable: true),
                    MedicalPracticeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_HighestQualification",
                        column: x => x.QualificationID,
                        principalTable: "HighestQualification",
                        principalColumn: "QualificationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_MedicalPractice",
                        column: x => x.MedicalPracticeID,
                        principalTable: "MedicalPractice",
                        principalColumn: "MedicalPracticeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacist",
                columns: table => new
                {
                    PharmacistID = table.Column<int>(type: "int", nullable: false),
                    RegNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    PharmacyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacist", x => x.PharmacistID);
                    table.ForeignKey(
                        name: "FK_Pharmacist_Pharmacy",
                        column: x => x.PharmacyID,
                        principalTable: "Pharmacy",
                        principalColumn: "PharmacyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedInteraction_ActiveIngredient",
                columns: table => new
                {
                    MedInteraction_ActiveIngredientID = table.Column<int>(type: "int", nullable: false),
                    MedInteractionID = table.Column<int>(type: "int", nullable: true),
                    IngredientID = table.Column<int>(type: "int", nullable: true),
                    InteractionLevelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedInteraction_ActiveIngredient", x => x.MedInteraction_ActiveIngredientID);
                    table.ForeignKey(
                        name: "FK_MedInteraction_ActiveIngredient_ActiveIngredient1",
                        column: x => x.IngredientID,
                        principalTable: "ActiveIngredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedInteraction_ActiveIngredient_InteractionLevel1",
                        column: x => x.InteractionLevelID,
                        principalTable: "InteractionLevel",
                        principalColumn: "InteractionLevelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedInteraction_ActiveIngredient_MedicationInteraction",
                        column: x => x.MedInteractionID,
                        principalTable: "MedicationInteraction",
                        principalColumn: "MedInteractionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    ConditionID = table.Column<int>(type: "int", nullable: true),
                    MedicationID = table.Column<int>(type: "int", nullable: true),
                    DosageID = table.Column<int>(type: "int", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_ConditionDiagnosis",
                        column: x => x.ConditionID,
                        principalTable: "ConditionDiagnosis",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_DosageForm",
                        column: x => x.DosageID,
                        principalTable: "DosageForm",
                        principalColumn: "DosageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_MedicationRecord",
                        column: x => x.MedicationID,
                        principalTable: "MedicationRecord",
                        principalColumn: "MedicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChronicHistory",
                columns: table => new
                {
                    ChronicID = table.Column<int>(type: "int", nullable: false),
                    ConditionID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicHistory", x => x.ChronicID);
                    table.ForeignKey(
                        name: "FK_ChronicHistory_ConditionDiagnosis",
                        column: x => x.ConditionID,
                        principalTable: "ConditionDiagnosis",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChronicHistory_Doctor",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChronicHistory_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChronicMedication",
                columns: table => new
                {
                    ChronicMedicationID = table.Column<int>(type: "int", nullable: false),
                    MedicationID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicMedication", x => x.ChronicMedicationID);
                    table.ForeignKey(
                        name: "FK_ChronicMedication_Doctor",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChronicMedication_MedicationRecord",
                        column: x => x.MedicationID,
                        principalTable: "MedicationRecord",
                        principalColumn: "MedicationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChronicMedication_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergy",
                columns: table => new
                {
                    AllergyID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergy", x => x.AllergyID);
                    table.ForeignKey(
                        name: "FK_PatientAllergy_ActiveIngredient",
                        column: x => x.IngredientID,
                        principalTable: "ActiveIngredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientAllergy_Doctor",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientAllergy_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientDoctorVisit",
                columns: table => new
                {
                    PatientDoctorVisitID = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDoctorVisit", x => x.PatientDoctorVisitID);
                    table.ForeignKey(
                        name: "FK_PatientDoctorVisit_Doctor",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientDoctorVisit_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DispensedMedication",
                columns: table => new
                {
                    DispensedMedicationID = table.Column<int>(type: "int", nullable: false),
                    MedicationID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DosageID = table.Column<int>(type: "int", nullable: true),
                    ContraIndicationID = table.Column<int>(type: "int", nullable: true),
                    MedInteractionID = table.Column<int>(type: "int", nullable: true),
                    WarningIgnoreReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PharmacistID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispensedMedication", x => x.DispensedMedicationID);
                    table.ForeignKey(
                        name: "FK_DispensedMedication_ContraIndication",
                        column: x => x.ContraIndicationID,
                        principalTable: "ContraIndication",
                        principalColumn: "ContraIndicationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispensedMedication_DosageForm",
                        column: x => x.DosageID,
                        principalTable: "DosageForm",
                        principalColumn: "DosageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispensedMedication_MedicationInteraction",
                        column: x => x.MedInteractionID,
                        principalTable: "MedicationInteraction",
                        principalColumn: "MedInteractionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispensedMedication_MedicationRecord",
                        column: x => x.MedicationID,
                        principalTable: "MedicationRecord",
                        principalColumn: "MedicationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispensedMedication_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispensedMedication_Pharmacist",
                        column: x => x.PharmacistID,
                        principalTable: "Pharmacist",
                        principalColumn: "PharmacistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNo = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Admin",
                        column: x => x.UserID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Doctor",
                        column: x => x.UserID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Pharmacist",
                        column: x => x.UserID,
                        principalTable: "Pharmacist",
                        principalColumn: "PharmacistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Pharmacy",
                        column: x => x.UserID,
                        principalTable: "Pharmacy",
                        principalColumn: "PharmacyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medication",
                columns: table => new
                {
                    PrescriptionMedicationID = table.Column<int>(type: "int", nullable: false),
                    MedicationID = table.Column<int>(type: "int", nullable: true),
                    DosageID = table.Column<int>(type: "int", nullable: true),
                    PatientDoctorVisitID = table.Column<int>(type: "int", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RepeatID = table.Column<int>(type: "int", nullable: true),
                    ContraIndicationID = table.Column<int>(type: "int", nullable: true),
                    MedInteractionID = table.Column<int>(type: "int", nullable: true),
                    WarningIgnoreReason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrescriptionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrescriptionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medication", x => x.PrescriptionMedicationID);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_ContraIndication",
                        column: x => x.ContraIndicationID,
                        principalTable: "ContraIndication",
                        principalColumn: "ContraIndicationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_DosageForm",
                        column: x => x.DosageID,
                        principalTable: "DosageForm",
                        principalColumn: "DosageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_MedicationInteraction",
                        column: x => x.MedInteractionID,
                        principalTable: "MedicationInteraction",
                        principalColumn: "MedInteractionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_MedicationRecord",
                        column: x => x.MedicationID,
                        principalTable: "MedicationRecord",
                        principalColumn: "MedicationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_PatientDoctorVisit",
                        column: x => x.PatientDoctorVisitID,
                        principalTable: "PatientDoctorVisit",
                        principalColumn: "PatientDoctorVisitID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication_Repeat",
                        column: x => x.RepeatID,
                        principalTable: "Repeat",
                        principalColumn: "RepeatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveIngredient_StrengthID",
                table: "ActiveIngredient",
                column: "StrengthID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicHistory_ConditionID",
                table: "ChronicHistory",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicHistory_DoctorID",
                table: "ChronicHistory",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicHistory_PatientID",
                table: "ChronicHistory",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicMedication_DoctorID",
                table: "ChronicMedication",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicMedication_MedicationID",
                table: "ChronicMedication",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicMedication_PatientID",
                table: "ChronicMedication",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ContraIndication_ConditionID",
                table: "ContraIndication",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_ContraIndication_IngredientID",
                table: "ContraIndication",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_DispensedMedication_ContraIndicationID",
                table: "DispensedMedication",
                column: "ContraIndicationID");

            migrationBuilder.CreateIndex(
                name: "IX_DispensedMedication_DosageID",
                table: "DispensedMedication",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_DispensedMedication_MedicationID",
                table: "DispensedMedication",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_DispensedMedication_MedInteractionID",
                table: "DispensedMedication",
                column: "MedInteractionID");

            migrationBuilder.CreateIndex(
                name: "IX_DispensedMedication_PatientID",
                table: "DispensedMedication",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DispensedMedication_PharmacistID",
                table: "DispensedMedication",
                column: "PharmacistID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_MedicalPracticeID",
                table: "Doctor",
                column: "MedicalPracticeID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_QualificationID",
                table: "Doctor",
                column: "QualificationID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPractice_CityID",
                table: "MedicalPractice",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationInteraction_IngredientID",
                table: "MedicationInteraction",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRecord_IngredientID",
                table: "MedicationRecord",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRecord_ScheduleID",
                table: "MedicationRecord",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_MedInteraction_ActiveIngredient_IngredientID",
                table: "MedInteraction_ActiveIngredient",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedInteraction_ActiveIngredient_InteractionLevelID",
                table: "MedInteraction_ActiveIngredient",
                column: "InteractionLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_MedInteraction_ActiveIngredient_MedInteractionID",
                table: "MedInteraction_ActiveIngredient",
                column: "MedInteractionID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergy_DoctorID",
                table: "PatientAllergy",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergy_IngredientID",
                table: "PatientAllergy",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergy_PatientID",
                table: "PatientAllergy",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctorVisit_DoctorID",
                table: "PatientDoctorVisit",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctorVisit_PatientID",
                table: "PatientDoctorVisit",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacist_PharmacyID",
                table: "Pharmacist",
                column: "PharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_CityID",
                table: "Pharmacy",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ConditionID",
                table: "Prescription",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DosageID",
                table: "Prescription",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicationID",
                table: "Prescription",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_ContraIndicationID",
                table: "Prescription_Medication",
                column: "ContraIndicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_DosageID",
                table: "Prescription_Medication",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_MedicationID",
                table: "Prescription_Medication",
                column: "MedicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_MedInteractionID",
                table: "Prescription_Medication",
                column: "MedInteractionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_PatientDoctorVisitID",
                table: "Prescription_Medication",
                column: "PatientDoctorVisitID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_RepeatID",
                table: "Prescription_Medication",
                column: "RepeatID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_CityID",
                table: "Suburb",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityID",
                table: "User",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChronicHistory");

            migrationBuilder.DropTable(
                name: "ChronicMedication");

            migrationBuilder.DropTable(
                name: "DispensedMedication");

            migrationBuilder.DropTable(
                name: "MedInteraction_ActiveIngredient");

            migrationBuilder.DropTable(
                name: "PatientAllergy");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Prescription_Medication");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "InteractionLevel");

            migrationBuilder.DropTable(
                name: "ContraIndication");

            migrationBuilder.DropTable(
                name: "DosageForm");

            migrationBuilder.DropTable(
                name: "MedicationInteraction");

            migrationBuilder.DropTable(
                name: "MedicationRecord");

            migrationBuilder.DropTable(
                name: "PatientDoctorVisit");

            migrationBuilder.DropTable(
                name: "Repeat");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Pharmacist");

            migrationBuilder.DropTable(
                name: "ConditionDiagnosis");

            migrationBuilder.DropTable(
                name: "ActiveIngredient");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "ActiveIngredientStrength");

            migrationBuilder.DropTable(
                name: "HighestQualification");

            migrationBuilder.DropTable(
                name: "MedicalPractice");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
