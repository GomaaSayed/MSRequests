using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSRequests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateReuestHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangedByID",
                table: "RequestHistory");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "RequestHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChangedByID",
                table: "RequestHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "RequestHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
