using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitInventoty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "MinimumQuantity",
                table: "FarmInventories",
                newName: "MinQuantity");

            migrationBuilder.RenameColumn(
                name: "MaximumQuantity",
                table: "FarmInventories",
                newName: "MaxQuantity");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpiryDate",
                table: "FarmInventories",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FertilizerId",
                table: "FarmInventories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PesticideId",
                table: "FarmInventories",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PlantingCode",
                table: "CropPlantings",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Fertilizers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FertilizerType = table.Column<int>(type: "integer", nullable: false),
                    NitrogenPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    PhosphorusPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    PotassiumPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAlertSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    ExpiringSoonDays = table.Column<int>(type: "integer", nullable: false),
                    EnableLowStockAlert = table.Column<bool>(type: "boolean", nullable: false),
                    EnableOutOfStockAlert = table.Column<bool>(type: "boolean", nullable: false),
                    EnableExpiryAlert = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAlertSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryAlertSettings_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesticides",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ActiveIngredient = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PesticideType = table.Column<int>(type: "integer", nullable: false),
                    ToxicityLevel = table.Column<int>(type: "integer", nullable: false),
                    PreHarvestIntervalDays = table.Column<int>(type: "integer", nullable: true),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    RegistrationNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesticides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizationPlans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    GrowthStageId = table.Column<string>(type: "text", nullable: true),
                    FertilizerId = table.Column<string>(type: "text", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PlannedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DaysAfterPlanting = table.Column<int>(type: "integer", nullable: true),
                    PlannedQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ApplicationMethod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizationPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizationPlans_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FertilizationPlans_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizationPlans_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizationPlans_GrowthStages_GrowthStageId",
                        column: x => x.GrowthStageId,
                        principalTable: "GrowthStages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryAlerts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    ItemType = table.Column<int>(type: "integer", nullable: false),
                    FertilizerId = table.Column<string>(type: "text", nullable: true),
                    PesticideId = table.Column<string>(type: "text", nullable: true),
                    FarmInventoryId = table.Column<string>(type: "text", nullable: true),
                    ItemName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AlertType = table.Column<int>(type: "integer", nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    CurrentQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    MinQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AlertTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false),
                    ResolvedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryAlerts_FarmInventories_FarmInventoryId",
                        column: x => x.FarmInventoryId,
                        principalTable: "FarmInventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryAlerts_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryAlerts_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryAlerts_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PesticidePlans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    GrowthStageId = table.Column<string>(type: "text", nullable: true),
                    PesticideId = table.Column<string>(type: "text", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Target = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PlannedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PlannedQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ApplicationMethod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticidePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PesticidePlans_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PesticidePlans_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PesticidePlans_GrowthStages_GrowthStageId",
                        column: x => x.GrowthStageId,
                        principalTable: "GrowthStages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PesticidePlans_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    FieldId = table.Column<string>(type: "text", nullable: true),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    FertilizationPlanId = table.Column<string>(type: "text", nullable: true),
                    FertilizerId = table.Column<string>(type: "text", nullable: false),
                    AppliedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AppliedQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ApplicationMethod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AppliedBy = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizerApplications_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FertilizerApplications_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizerApplications_FertilizationPlans_FertilizationPlan~",
                        column: x => x.FertilizationPlanId,
                        principalTable: "FertilizationPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FertilizerApplications_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizerApplications_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PesticideApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    FieldId = table.Column<string>(type: "text", nullable: true),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    PesticidePlanId = table.Column<string>(type: "text", nullable: true),
                    PesticideId = table.Column<string>(type: "text", nullable: false),
                    AppliedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AppliedQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ApplicationMethod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AppliedBy = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    SafeHarvestDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticideApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PesticideApplications_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PesticideApplications_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PesticideApplications_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PesticideApplications_PesticidePlans_PesticidePlanId",
                        column: x => x.PesticidePlanId,
                        principalTable: "PesticidePlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PesticideApplications_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmInventories_FertilizerId",
                table: "FarmInventories",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmInventories_PesticideId",
                table: "FarmInventories",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationPlans_CropPlantingId",
                table: "FertilizationPlans",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationPlans_FarmId",
                table: "FertilizationPlans",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationPlans_FertilizerId",
                table: "FertilizationPlans",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationPlans_GrowthStageId",
                table: "FertilizationPlans",
                column: "GrowthStageId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerApplications_CropPlantingId",
                table: "FertilizerApplications",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerApplications_FarmId",
                table: "FertilizerApplications",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerApplications_FertilizationPlanId",
                table: "FertilizerApplications",
                column: "FertilizationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerApplications_FertilizerId",
                table: "FertilizerApplications",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerApplications_FieldId",
                table: "FertilizerApplications",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAlerts_FarmId",
                table: "InventoryAlerts",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAlerts_FarmInventoryId",
                table: "InventoryAlerts",
                column: "FarmInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAlerts_FertilizerId",
                table: "InventoryAlerts",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAlerts_PesticideId",
                table: "InventoryAlerts",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAlertSettings_FarmId",
                table: "InventoryAlertSettings",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideApplications_CropPlantingId",
                table: "PesticideApplications",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideApplications_FarmId",
                table: "PesticideApplications",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideApplications_FieldId",
                table: "PesticideApplications",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideApplications_PesticideId",
                table: "PesticideApplications",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideApplications_PesticidePlanId",
                table: "PesticideApplications",
                column: "PesticidePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticidePlans_CropPlantingId",
                table: "PesticidePlans",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticidePlans_FarmId",
                table: "PesticidePlans",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticidePlans_GrowthStageId",
                table: "PesticidePlans",
                column: "GrowthStageId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticidePlans_PesticideId",
                table: "PesticidePlans",
                column: "PesticideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmInventories_Fertilizers_FertilizerId",
                table: "FarmInventories",
                column: "FertilizerId",
                principalTable: "Fertilizers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmInventories_Pesticides_PesticideId",
                table: "FarmInventories",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_FarmInventories_Fertilizers_FertilizerId",
                table: "FarmInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_FarmInventories_Pesticides_PesticideId",
                table: "FarmInventories");

            migrationBuilder.DropTable(
                name: "FertilizerApplications");

            migrationBuilder.DropTable(
                name: "InventoryAlerts");

            migrationBuilder.DropTable(
                name: "InventoryAlertSettings");

            migrationBuilder.DropTable(
                name: "PesticideApplications");

            migrationBuilder.DropTable(
                name: "FertilizationPlans");

            migrationBuilder.DropTable(
                name: "PesticidePlans");

            migrationBuilder.DropTable(
                name: "Fertilizers");

            migrationBuilder.DropTable(
                name: "Pesticides");

            migrationBuilder.DropIndex(
                name: "IX_FarmInventories_FertilizerId",
                table: "FarmInventories");

            migrationBuilder.DropIndex(
                name: "IX_FarmInventories_PesticideId",
                table: "FarmInventories");

            migrationBuilder.DropColumn(
                name: "FertilizerId",
                table: "FarmInventories");

            migrationBuilder.DropColumn(
                name: "PesticideId",
                table: "FarmInventories");

            migrationBuilder.RenameColumn(
                name: "MinQuantity",
                table: "FarmInventories",
                newName: "MinimumQuantity");

            migrationBuilder.RenameColumn(
                name: "MaxQuantity",
                table: "FarmInventories",
                newName: "MaximumQuantity");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiryDate",
                table: "FarmInventories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlantingCode",
                table: "CropPlantings",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
