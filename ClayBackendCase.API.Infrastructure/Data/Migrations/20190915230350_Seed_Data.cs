using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClayBackendCase.API.Infrastructure.Data.Migrations
{
    public partial class Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 1, new DateTime(2019, 9, 15, 23, 3, 50, 529, DateTimeKind.Utc).AddTicks(7349), "Clay Solutions" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 1, new DateTime(2019, 9, 15, 23, 3, 50, 529, DateTimeKind.Utc).AddTicks(9372), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { 2, new DateTime(2019, 9, 15, 23, 3, 50, 529, DateTimeKind.Utc).AddTicks(9598), "User" });

            migrationBuilder.InsertData(
                table: "Locks",
                columns: new[] { "Id", "CompanyId", "Created", "IsLocked", "Name" },
                values: new object[] { 1, 1, new DateTime(2019, 9, 15, 23, 3, 50, 530, DateTimeKind.Utc).AddTicks(177), true, "Clay Tunnel Lock" });

            migrationBuilder.InsertData(
                table: "Locks",
                columns: new[] { "Id", "CompanyId", "Created", "IsLocked", "Name" },
                values: new object[] { 2, 1, new DateTime(2019, 9, 15, 23, 3, 50, 530, DateTimeKind.Utc).AddTicks(774), true, "Clay Office Lock" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
