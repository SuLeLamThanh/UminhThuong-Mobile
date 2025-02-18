using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResearchRecordSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchRecordId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchRecordSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchRecordSpecies_ResearchRecords_ResearchRecordId",
                        column: x => x.ResearchRecordId,
                        principalTable: "ResearchRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchRecordSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 10, 0, 0, 8, 486, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 10, 0, 0, 8, 486, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 10, 0, 0, 8, 486, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 0, 0, 8, 486, DateTimeKind.Local).AddTicks(2701), new DateTime(2019, 12, 10, 0, 0, 8, 485, DateTimeKind.Local).AddTicks(3097) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 10, 0, 0, 8, 486, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 10, 0, 0, 8, 486, DateTimeKind.Local).AddTicks(3814));

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRecordSpecies_ResearchRecordId",
                table: "ResearchRecordSpecies",
                column: "ResearchRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRecordSpecies_SpeciesId",
                table: "ResearchRecordSpecies",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchRecordSpecies");

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 9, 14, 54, 36, 528, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 9, 14, 54, 36, 529, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 9, 14, 54, 36, 529, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 9, 14, 54, 36, 527, DateTimeKind.Local).AddTicks(9877), new DateTime(2019, 12, 9, 14, 54, 36, 526, DateTimeKind.Local).AddTicks(2453) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 9, 14, 54, 36, 528, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 9, 14, 54, 36, 528, DateTimeKind.Local).AddTicks(2240));
        }
    }
}
