using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSFMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Farms");

            migrationBuilder.AddColumn<string>(
                name: "FarmId1",
                table: "HREmployees",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentType",
                table: "Equipment",
                type: "integer",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_FarmId1",
                table: "HREmployees",
                column: "FarmId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HREmployees_Farms_FarmId1",
                table: "HREmployees",
                column: "FarmId1",
                principalTable: "Farms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HREmployees_Farms_FarmId1",
                table: "HREmployees");

            migrationBuilder.DropIndex(
                name: "IX_HREmployees_FarmId1",
                table: "HREmployees");

            migrationBuilder.DropColumn(
                name: "FarmId1",
                table: "HREmployees");

            migrationBuilder.AddColumn<string>(
                name: "FamilyId",
                table: "Farms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EquipmentType",
                table: "Equipment",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 50);
        }
    }
}