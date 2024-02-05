using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cards.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("3637dd46-f4f2-46cd-bbe4-3a3860d4a215"), "pohiosm@gmail.com", "rita@5", "Member" },
                    { new Guid("7d558b50-4718-453f-bede-4465e9a2dd37"), "koutlasilias@gmail.com", "rita@4", "Administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3637dd46-f4f2-46cd-bbe4-3a3860d4a215"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7d558b50-4718-453f-bede-4465e9a2dd37"));
        }
    }
}
