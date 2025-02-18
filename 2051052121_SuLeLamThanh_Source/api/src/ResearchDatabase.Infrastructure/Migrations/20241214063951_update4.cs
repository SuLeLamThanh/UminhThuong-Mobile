using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 14, 13, 39, 50, 799, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 14, 13, 39, 50, 799, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 14, 13, 39, 50, 799, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 14, 13, 39, 50, 798, DateTimeKind.Local).AddTicks(6209), new DateTime(2019, 12, 14, 13, 39, 50, 796, DateTimeKind.Local).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 14, 13, 39, 50, 798, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 13, 39, 50, 798, DateTimeKind.Local).AddTicks(7824));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 14, 13, 39, 28, 15, DateTimeKind.Local).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 14, 13, 39, 28, 15, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 14, 13, 39, 28, 15, DateTimeKind.Local).AddTicks(6874));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 14, 13, 39, 28, 15, DateTimeKind.Local).AddTicks(897), new DateTime(2019, 12, 14, 13, 39, 28, 13, DateTimeKind.Local).AddTicks(9423) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 14, 13, 39, 28, 15, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 13, 39, 28, 15, DateTimeKind.Local).AddTicks(2006));
        }
    }
}
