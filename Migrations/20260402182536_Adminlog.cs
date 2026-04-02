using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreMachineTest.Migrations
{
    /// <inheritdoc />
    public partial class Adminlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1b2c3d4-e5f6-7890-abcd-ef1234567890", 0, "STATIC_CONCURRENCY_STAMP_V1", "admin@bookstore.com", true, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEP8T9SJuOLMkUf9xE8rY0NCCeBfmA9+WZP5NVt2RKoA/Ttp3sFg1gMcb0mIXOnyLew==", null, false, "STATIC_SECURITY_STAMP_V1", false, "admin@bookstore.com" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 2, 18, 25, 35, 658, DateTimeKind.Utc).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 2, 18, 25, 35, 658, DateTimeKind.Utc).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 2, 18, 25, 35, 658, DateTimeKind.Utc).AddTicks(2613));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 2, 17, 9, 21, 142, DateTimeKind.Utc).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 2, 17, 9, 21, 142, DateTimeKind.Utc).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 2, 17, 9, 21, 142, DateTimeKind.Utc).AddTicks(9035));
        }
    }
}
