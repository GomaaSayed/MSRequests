using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSRequests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createServiceRequestAttachment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_RequestID",
                table: "ServiceRequestAttahcments");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestAttahcments_RequestID",
                table: "ServiceRequestAttahcments");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "ServiceRequestAttahcments");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestAttahcments_ServiceRequestID",
                table: "ServiceRequestAttahcments",
                column: "ServiceRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_ServiceRequestID",
                table: "ServiceRequestAttahcments",
                column: "ServiceRequestID",
                principalTable: "ServiceRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_ServiceRequestID",
                table: "ServiceRequestAttahcments");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestAttahcments_ServiceRequestID",
                table: "ServiceRequestAttahcments");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestID",
                table: "ServiceRequestAttahcments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestAttahcments_RequestID",
                table: "ServiceRequestAttahcments",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_RequestID",
                table: "ServiceRequestAttahcments",
                column: "RequestID",
                principalTable: "ServiceRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
