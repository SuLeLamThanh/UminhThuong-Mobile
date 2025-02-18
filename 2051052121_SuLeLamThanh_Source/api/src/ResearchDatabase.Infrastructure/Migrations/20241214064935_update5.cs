using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 14, 13, 49, 34, 213, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 14, 13, 49, 34, 213, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 14, 13, 49, 34, 213, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 14, 13, 49, 34, 213, DateTimeKind.Local).AddTicks(782), new DateTime(2019, 12, 14, 13, 49, 34, 212, DateTimeKind.Local).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 14, 13, 49, 34, 213, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 14, 13, 49, 34, 213, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkaoeue9Hceyj3bot9dpM0-gDHWoUib0tj8A&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRow_p2_0QR5ExOF6fj3s7VPt_JWm0gB3IODw&s");
        }
    }
}
