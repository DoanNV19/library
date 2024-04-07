using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("2f3980e5-9b19-4317-bc05-2654c6f2ac15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9d7469e-68f1-435c-a157-de082c9e94da"));

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Accounts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "EmailId", "FirstName", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "LastName" },
                values: new object[] { new Guid("e9d7469e-68f1-435c-a157-de082c9e94da"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Password", "Status", "UserId", "UserName" },
                values: new object[] { new Guid("2f3980e5-9b19-4317-bc05-2654c6f2ac15"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, null, null, "55de1e4b50da90d84249ab53f61a99a6959d4c6fd8a6c402670b4115c137beae", 1, new Guid("e9d7469e-68f1-435c-a157-de082c9e94da"), "admin" });
        }
    }
}
