using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResearchRecordSpecies",
                columns: new[] { "Id", "ResearchRecordId", "SpeciesId", "SpeciesId1" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 2, 2, 2, null },
                    { 3, 3, 3, null }
                });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 10, 9, 51, 47, 512, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 10, 9, 51, 47, 512, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 10, 9, 51, 47, 512, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 9, 51, 47, 511, DateTimeKind.Local).AddTicks(5137), new DateTime(2019, 12, 10, 9, 51, 47, 510, DateTimeKind.Local).AddTicks(5059) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 10, 9, 51, 47, 511, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 10, 9, 51, 47, 511, DateTimeKind.Local).AddTicks(6251));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResearchRecordSpecies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResearchRecordSpecies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ResearchRecordSpecies",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
