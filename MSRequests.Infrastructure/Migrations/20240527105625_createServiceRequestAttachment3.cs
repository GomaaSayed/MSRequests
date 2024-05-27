using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSRequests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createServiceRequestAttachment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestHistory_ServiceRequest_RequestID",
                table: "RequestHistory");

            migrationBuilder.DropIndex(
                name: "IX_RequestHistory_RequestID",
                table: "RequestHistory");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "RequestHistory");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHistory_ServiceRequestID",
                table: "RequestHistory",
                column: "ServiceRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHistory_ServiceRequest_ServiceRequestID",
                table: "RequestHistory",
                column: "ServiceRequestID",
                principalTable: "ServiceRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestHistory_ServiceRequest_ServiceRequestID",
                table: "RequestHistory");

            migrationBuilder.DropIndex(
                name: "IX_RequestHistory_ServiceRequestID",
                table: "RequestHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestID",
                table: "RequestHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RequestHistory_RequestID",
                table: "RequestHistory",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHistory_ServiceRequest_RequestID",
                table: "RequestHistory",
                column: "RequestID",
                principalTable: "ServiceRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
