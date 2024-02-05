using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cards.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Color", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("0faed4dd-dc36-4d16-aa2c-c4bce45f27e6"), "#7aff33", "3637dd46-f4f2-46cd-bbe4-3a3860d4a215", new DateTime(2024, 2, 5, 16, 18, 28, 770, DateTimeKind.Local).AddTicks(5357), null, null, null, "Throw garbage", 0, new Guid("3637dd46-f4f2-46cd-bbe4-3a3860d4a215") },
                    { new Guid("1e0d9474-499e-4be5-a295-e6c130f9aa6e"), "#7aff33", "7d558b50-4718-453f-bede-4465e9a2dd37", new DateTime(2024, 2, 5, 16, 18, 28, 770, DateTimeKind.Local).AddTicks(5333), null, null, null, "Buy food for the cat", 0, new Guid("7d558b50-4718-453f-bede-4465e9a2dd37") },
                    { new Guid("5441c11c-22b5-4b74-9ccb-3834e68a30ec"), "#ff5733", "7d558b50-4718-453f-bede-4465e9a2dd37", new DateTime(2024, 2, 5, 16, 18, 28, 770, DateTimeKind.Local).AddTicks(5172), null, null, null, "Clean the house", 0, new Guid("7d558b50-4718-453f-bede-4465e9a2dd37") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: new Guid("0faed4dd-dc36-4d16-aa2c-c4bce45f27e6"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: new Guid("1e0d9474-499e-4be5-a295-e6c130f9aa6e"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: new Guid("5441c11c-22b5-4b74-9ccb-3834e68a30ec"));
        }
    }
}
