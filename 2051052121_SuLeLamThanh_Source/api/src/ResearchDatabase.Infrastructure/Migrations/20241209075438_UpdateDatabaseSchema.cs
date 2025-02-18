using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEndemic",
                table: "Species",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "ResearchRecords",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Notes", "ResearchDate", "SpeciesId" },
                values: new object[] { "GTM-001", new DateTime(2020, 12, 9, 14, 54, 36, 528, DateTimeKind.Local).AddTicks(9318), null });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Notes", "ResearchDate", "SpeciesId" },
                values: new object[] { "GTM-002", new DateTime(2022, 12, 9, 14, 54, 36, 529, DateTimeKind.Local).AddTicks(1400), null });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Notes", "ResearchDate", "SpeciesId" },
                values: new object[] { "GTM-002", new DateTime(2023, 12, 9, 14, 54, 36, 529, DateTimeKind.Local).AddTicks(1410), null });

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

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsEndemic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsEndemic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsEndemic",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRecords_SpeciesId",
                table: "ResearchRecords",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchRecords_Species_SpeciesId",
                table: "ResearchRecords",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchRecords_Species_SpeciesId",
                table: "ResearchRecords");

            migrationBuilder.DropIndex(
                name: "IX_ResearchRecords_SpeciesId",
                table: "ResearchRecords");

            migrationBuilder.DropColumn(
                name: "IsEndemic",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "ResearchRecords");

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Notes", "ResearchDate" },
                values: new object[] { "This study tracked lions over a period of 6 months in the savannah.", new DateTime(2020, 12, 7, 15, 1, 59, 449, DateTimeKind.Local).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Notes", "ResearchDate" },
                values: new object[] { "Data was collected in multiple regions with different climate conditions.", new DateTime(2022, 12, 7, 15, 1, 59, 449, DateTimeKind.Local).AddTicks(3356) });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Notes", "ResearchDate" },
                values: new object[] { "Initial observations indicate a diverse range of fungi species.", new DateTime(2023, 12, 7, 15, 1, 59, 449, DateTimeKind.Local).AddTicks(3362) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 7, 15, 1, 59, 448, DateTimeKind.Local).AddTicks(7845), new DateTime(2019, 12, 7, 15, 1, 59, 447, DateTimeKind.Local).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 7, 15, 1, 59, 448, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 7, 15, 1, 59, 448, DateTimeKind.Local).AddTicks(8882));
        }
    }
}
