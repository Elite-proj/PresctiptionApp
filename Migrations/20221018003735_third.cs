using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_prescription.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_DosageForm",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_MedicationRecord",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medication_DosageForm",
                table: "Prescription_Medication");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medication_PatientDoctorVisit",
                table: "Prescription_Medication");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_Medication_DosageID",
                table: "Prescription_Medication");

            migrationBuilder.DropColumn(
                name: "DosageID",
                table: "Prescription_Medication");

            migrationBuilder.DropColumn(
                name: "PrescriptionDate",
                table: "Prescription_Medication");

            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Prescription");

            migrationBuilder.RenameColumn(
                name: "PatientDoctorVisitID",
                table: "Prescription_Medication",
                newName: "AllergyID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_Medication_PatientDoctorVisitID",
                table: "Prescription_Medication",
                newName: "IX_Prescription_Medication_AllergyID");

            migrationBuilder.RenameColumn(
                name: "MedicationID",
                table: "Prescription",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "DosageID",
                table: "Prescription",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_MedicationID",
                table: "Prescription",
                newName: "IX_Prescription_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_DosageID",
                table: "Prescription",
                newName: "IX_Prescription_DoctorID");

            migrationBuilder.AlterColumn<string>(
                name: "WarningIgnoreReason",
                table: "Prescription_Medication",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instruction",
                table: "Prescription_Medication",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AllergyIgnoreReason",
                table: "Prescription_Medication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContraIgnoreReason",
                table: "Prescription_Medication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DispensedStatus",
                table: "Prescription_Medication",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Prescription",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "PatientAllergy",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ChronicMedication",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ChronicHistory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctor",
                table: "Prescription",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient",
                table: "Prescription",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medication_PatientAllergy",
                table: "Prescription_Medication",
                column: "AllergyID",
                principalTable: "PatientAllergy",
                principalColumn: "AllergyID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctor",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medication_PatientAllergy",
                table: "Prescription_Medication");

            migrationBuilder.DropColumn(
                name: "AllergyIgnoreReason",
                table: "Prescription_Medication");

            migrationBuilder.DropColumn(
                name: "ContraIgnoreReason",
                table: "Prescription_Medication");

            migrationBuilder.DropColumn(
                name: "DispensedStatus",
                table: "Prescription_Medication");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Prescription");

            migrationBuilder.RenameColumn(
                name: "AllergyID",
                table: "Prescription_Medication",
                newName: "PatientDoctorVisitID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_Medication_AllergyID",
                table: "Prescription_Medication",
                newName: "IX_Prescription_Medication_PatientDoctorVisitID");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Prescription",
                newName: "MedicationID");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Prescription",
                newName: "DosageID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_PatientID",
                table: "Prescription",
                newName: "IX_Prescription_MedicationID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_DoctorID",
                table: "Prescription",
                newName: "IX_Prescription_DosageID");

            migrationBuilder.AlterColumn<string>(
                name: "WarningIgnoreReason",
                table: "Prescription_Medication",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instruction",
                table: "Prescription_Medication",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DosageID",
                table: "Prescription_Medication",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrescriptionDate",
                table: "Prescription_Medication",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Prescription",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "PatientAllergy",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ChronicMedication",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ChronicHistory",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medication_DosageID",
                table: "Prescription_Medication",
                column: "DosageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_DosageForm",
                table: "Prescription",
                column: "DosageID",
                principalTable: "DosageForm",
                principalColumn: "DosageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_MedicationRecord",
                table: "Prescription",
                column: "MedicationID",
                principalTable: "MedicationRecord",
                principalColumn: "MedicationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medication_DosageForm",
                table: "Prescription_Medication",
                column: "DosageID",
                principalTable: "DosageForm",
                principalColumn: "DosageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medication_PatientDoctorVisit",
                table: "Prescription_Medication",
                column: "PatientDoctorVisitID",
                principalTable: "PatientDoctorVisit",
                principalColumn: "PatientDoctorVisitID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
