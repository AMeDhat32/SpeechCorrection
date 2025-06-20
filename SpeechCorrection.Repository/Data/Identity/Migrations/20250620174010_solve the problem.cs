using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeechCorrection.Repository.Data.Identity.Migrations
{
    /// <inheritdoc />
    public partial class solvetheproblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "TrainingRecord");

            migrationBuilder.DropTable(
                name: "TrainingLevel");

            migrationBuilder.DropTable(
                name: "Letter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableFrom = table.Column<TimeOnly>(type: "time", nullable: true),
                    AvailableTo = table.Column<TimeOnly>(type: "time", nullable: true),
                    WorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Letter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FamilyMembersCount = table.Column<int>(type: "int", nullable: true),
                    LatestIqTestResult = table.Column<double>(type: "float", nullable: true),
                    LatestLeftEarTestResult = table.Column<double>(type: "float", nullable: true),
                    LatestRightEarTestResult = table.Column<double>(type: "float", nullable: true),
                    SiblingRank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingLevel_Letter_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingLevelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordingUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingRecord_TrainingLevel_TrainingLevelId",
                        column: x => x.TrainingLevelId,
                        principalTable: "TrainingLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingLevel_LetterId",
                table: "TrainingLevel",
                column: "LetterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRecord_TrainingLevelId",
                table: "TrainingRecord",
                column: "TrainingLevelId");
        }
    }
}
