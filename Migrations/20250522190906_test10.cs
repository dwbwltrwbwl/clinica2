using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinica2.Migrations
{
    /// <inheritdoc />
    public partial class test10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "diagnosis",
                columns: table => new
                {
                    id_diagnosis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnosis_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosis", x => x.id_diagnosis);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "site",
                columns: table => new
                {
                    id_site = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    site_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_site", x => x.id_site);
                });

            migrationBuilder.CreateTable(
                name: "specializations",
                columns: table => new
                {
                    id_specialization = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specialization_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specializations", x => x.id_specialization);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id_status);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id_patient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    policy_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_site = table.Column<int>(type: "int", nullable: false),
                    id_role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id_patient);
                    table.ForeignKey(
                        name: "FK_patients_roles_id_role",
                        column: x => x.id_role,
                        principalTable: "roles",
                        principalColumn: "id_role",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patients_site_id_site",
                        column: x => x.id_site,
                        principalTable: "site",
                        principalColumn: "id_site",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id_doctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id_specialization = table.Column<int>(type: "int", nullable: false),
                    id_role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id_doctor);
                    table.ForeignKey(
                        name: "FK_doctors_roles_id_role",
                        column: x => x.id_role,
                        principalTable: "roles",
                        principalColumn: "id_role",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctors_specializations_id_specialization",
                        column: x => x.id_specialization,
                        principalTable: "specializations",
                        principalColumn: "id_specialization",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptions",
                columns: table => new
                {
                    id_reception = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_reception = table.Column<DateTime>(type: "datetime2", nullable: true),
                    time_reception = table.Column<TimeSpan>(type: "time", nullable: true),
                    id_patient = table.Column<int>(type: "int", nullable: false),
                    id_doctor = table.Column<int>(type: "int", nullable: false),
                    id_status = table.Column<int>(type: "int", nullable: false),
                    symptoms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_diagnosis = table.Column<int>(type: "int", nullable: false),
                    treatment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receptions", x => x.id_reception);
                    table.ForeignKey(
                        name: "FK_receptions_diagnosis_id_diagnosis",
                        column: x => x.id_diagnosis,
                        principalTable: "diagnosis",
                        principalColumn: "id_diagnosis",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_receptions_doctors_id_doctor",
                        column: x => x.id_doctor,
                        principalTable: "doctors",
                        principalColumn: "id_doctor",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_receptions_patients_id_patient",
                        column: x => x.id_patient,
                        principalTable: "patients",
                        principalColumn: "id_patient",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_receptions_status_id_status",
                        column: x => x.id_status,
                        principalTable: "status",
                        principalColumn: "id_status",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctors_id_role",
                table: "doctors",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_id_specialization",
                table: "doctors",
                column: "id_specialization");

            migrationBuilder.CreateIndex(
                name: "IX_patients_id_role",
                table: "patients",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_patients_id_site",
                table: "patients",
                column: "id_site");

            migrationBuilder.CreateIndex(
                name: "IX_receptions_id_diagnosis",
                table: "receptions",
                column: "id_diagnosis");

            migrationBuilder.CreateIndex(
                name: "IX_receptions_id_doctor",
                table: "receptions",
                column: "id_doctor");

            migrationBuilder.CreateIndex(
                name: "IX_receptions_id_patient",
                table: "receptions",
                column: "id_patient");

            migrationBuilder.CreateIndex(
                name: "IX_receptions_id_status",
                table: "receptions",
                column: "id_status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receptions");

            migrationBuilder.DropTable(
                name: "diagnosis");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "specializations");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "site");
        }
    }
}
