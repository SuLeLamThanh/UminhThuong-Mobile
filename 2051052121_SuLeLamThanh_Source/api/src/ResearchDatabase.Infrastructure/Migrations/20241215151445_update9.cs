﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResearchDate",
                value: new DateTime(2020, 12, 15, 22, 14, 44, 637, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "ResearchDate",
                value: new DateTime(2022, 12, 15, 22, 14, 44, 638, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "ResearchRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ResearchDate",
                value: new DateTime(2023, 12, 15, 22, 14, 44, 638, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 15, 22, 14, 44, 637, DateTimeKind.Local).AddTicks(4462), new DateTime(2019, 12, 15, 22, 14, 44, 636, DateTimeKind.Local).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 12, 15, 22, 14, 44, 637, DateTimeKind.Local).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "ResearchSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2022, 12, 15, 22, 14, 44, 637, DateTimeKind.Local).AddTicks(5532));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
