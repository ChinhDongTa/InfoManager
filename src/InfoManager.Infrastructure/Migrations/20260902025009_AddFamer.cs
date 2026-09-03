using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFamer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HREmployees_Farms_FarmId1",
                table: "HREmployees");

            migrationBuilder.DropIndex(
                name: "IX_HREmployees_FamilyMemberId",
                table: "HREmployees");

            migrationBuilder.DropIndex(
                name: "IX_HREmployees_Status",
                table: "HREmployees");

            migrationBuilder.DropColumn(
                name: "FarmOwnerUserId",
                table: "Farms");

            migrationBuilder.RenameColumn(
                name: "FarmId1",
                table: "HREmployees",
                newName: "DepartmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_HREmployees_FarmId1",
                table: "HREmployees",
                newName: "IX_HREmployees_DepartmentId1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HREmployees",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "HREmployees",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "FarmId",
                table: "HREmployees",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FamilyMemberId",
                table: "HREmployees",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "HREmployees",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalArea",
                table: "Farms",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Farms",
                type: "numeric(18,8)",
                precision: 18,
                scale: 8,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Farms",
                type: "numeric(18,8)",
                precision: 18,
                scale: 8,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CultivableArea",
                table: "Farms",
                type: "numeric(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "FarmerId",
                table: "Farms",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    FamilyMemberId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    FarmerCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IdentityNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_FamilyMembers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_FamilyMemberId",
                table: "HREmployees",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_FarmId_EmployeeNumber",
                table: "HREmployees",
                columns: new[] { "FarmId", "EmployeeNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_LicenseNumber",
                table: "Farms",
                column: "LicenseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_Name",
                table: "Farms",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_Status",
                table: "Farms",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_FamilyMemberId",
                table: "Farmers",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_FarmerCode",
                table: "Farmers",
                column: "FarmerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_IdentityNumber",
                table: "Farmers",
                column: "IdentityNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_Phone",
                table: "Farmers",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_UserId",
                table: "Farmers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HREmployees_Departments_DepartmentId1",
                table: "HREmployees",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_HREmployees_Departments_DepartmentId1",
                table: "HREmployees");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_HREmployees_FamilyMemberId",
                table: "HREmployees");

            migrationBuilder.DropIndex(
                name: "IX_HREmployees_FarmId_EmployeeNumber",
                table: "HREmployees");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_LicenseNumber",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_Name",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_Status",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Farms");

            migrationBuilder.RenameColumn(
                name: "DepartmentId1",
                table: "HREmployees",
                newName: "FarmId1");

            migrationBuilder.RenameIndex(
                name: "IX_HREmployees_DepartmentId1",
                table: "HREmployees",
                newName: "IX_HREmployees_FarmId1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HREmployees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "HREmployees",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "FarmId",
                table: "HREmployees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "FamilyMemberId",
                table: "HREmployees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "HREmployees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalArea",
                table: "Farms",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Farms",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,8)",
                oldPrecision: 18,
                oldScale: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Farms",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,8)",
                oldPrecision: 18,
                oldScale: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CultivableArea",
                table: "Farms",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AddColumn<string>(
                name: "FarmOwnerUserId",
                table: "Farms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_FamilyMemberId",
                table: "HREmployees",
                column: "FamilyMemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_Status",
                table: "HREmployees",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_HREmployees_Farms_FarmId1",
                table: "HREmployees",
                column: "FarmId1",
                principalTable: "Farms",
                principalColumn: "Id");
        }
    }
}
