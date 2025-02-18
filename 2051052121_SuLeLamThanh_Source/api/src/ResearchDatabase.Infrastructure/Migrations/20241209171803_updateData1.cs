using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeciesId1",
                table: "ResearchRecordSpecies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 10, 0, 18, 2, 593, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 10, 0, 18, 2, 593, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 10, 0, 18, 2, 593, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 0, 18, 2, 592, DateTimeKind.Local).AddTicks(8582), new DateTime(2019, 12, 10, 0, 18, 2, 591, DateTimeKind.Local).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 10, 0, 18, 2, 592, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 10, 0, 18, 2, 592, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRecordSpecies_SpeciesId1",
                table: "ResearchRecordSpecies",
                column: "SpeciesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchRecordSpecies_Species_SpeciesId1",
                table: "ResearchRecordSpecies",
                column: "SpeciesId1",
                principalTable: "Species",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchRecordSpecies_Species_SpeciesId1",
                table: "ResearchRecordSpecies");

            migrationBuilder.DropIndex(
                name: "IX_ResearchRecordSpecies_SpeciesId1",
                table: "ResearchRecordSpecies");

            migrationBuilder.DropColumn(
                name: "SpeciesId1",
                table: "ResearchRecordSpecies");

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
        }
    }
}
