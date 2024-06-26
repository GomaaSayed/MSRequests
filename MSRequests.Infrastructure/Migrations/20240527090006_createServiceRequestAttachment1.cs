﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSRequests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createServiceRequestAttachment1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_RequestID",
                table: "ServiceRequestAttahcments");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestID",
                table: "ServiceRequestAttahcments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_RequestID",
                table: "ServiceRequestAttahcments",
                column: "RequestID",
                principalTable: "ServiceRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_RequestID",
                table: "ServiceRequestAttahcments");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestID",
                table: "ServiceRequestAttahcments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestAttahcments_ServiceRequest_RequestID",
                table: "ServiceRequestAttahcments",
                column: "RequestID",
                principalTable: "ServiceRequest",
                principalColumn: "ID");
        }
    }
}
