using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConservationStatus",
                columns: new[] { "Id", "Description", "Name", "Severity" },
                values: new object[] { 3, "High risk of extinction in the wild", "Endangered", "High" });

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 14, 18, 21, 51, 646, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 14, 18, 21, 51, 646, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 14, 18, 21, 51, 646, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 14, 18, 21, 51, 645, DateTimeKind.Local).AddTicks(9652), new DateTime(2019, 12, 14, 18, 21, 51, 644, DateTimeKind.Local).AddTicks(9806) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 14, 18, 21, 51, 646, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 21, 51, 646, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConservationStatusId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConservationStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 14, 18, 21, 31, 932, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 14, 18, 21, 31, 932, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 14, 18, 21, 31, 932, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 14, 18, 21, 31, 932, DateTimeKind.Local).AddTicks(2358), new DateTime(2019, 12, 14, 18, 21, 31, 931, DateTimeKind.Local).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 14, 18, 21, 31, 932, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 18, 21, 31, 932, DateTimeKind.Local).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConservationStatusId",
                value: 1);
        }
    }
}
