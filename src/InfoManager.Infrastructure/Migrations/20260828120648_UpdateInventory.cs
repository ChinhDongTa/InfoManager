using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourcePurchaseItems");

            migrationBuilder.DropTable(
                name: "ResourceUsages");

            migrationBuilder.DropTable(
                name: "ResourcePurchases");

            migrationBuilder.AddColumn<string>(
                name: "CropVarietyId",
                table: "InventoryAlerts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CropVarietyId",
                table: "FarmInventories",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InventoryReceipts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReceiptDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Supplier = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    InvoiceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PostedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryReceipts_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryReceiptItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    InventoryReceiptId = table.Column<string>(type: "text", nullable: false),
                    FarmInventoryId = table.Column<string>(type: "text", nullable: true),
                    ResourceType = table.Column<int>(type: "integer", nullable: false),
                    ResourceName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FertilizerId = table.Column<string>(type: "text", nullable: true),
                    PesticideId = table.Column<string>(type: "text", nullable: true),
                    CropVarietyId = table.Column<string>(type: "text", nullable: true),
                    Brand = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CostPerUnit = table.Column<decimal>(type: "numeric", nullable: true),
                    LineAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    BatchNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StorageLocation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryReceiptItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryReceiptItems_CropVarieties_CropVarietyId",
                        column: x => x.CropVarietyId,
                        principalTable: "CropVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryReceiptItems_FarmInventories_FarmInventoryId",
                        column: x => x.FarmInventoryId,
                        principalTable: "FarmInventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryReceiptItems_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryReceiptItems_InventoryReceipts_InventoryReceiptId",
                        column: x => x.InventoryReceiptId,
                        principalTable: "InventoryReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryReceiptItems_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    FarmInventoryId = table.Column<string>(type: "text", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    UsageType = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    QuantityBefore = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityAfter = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPerUnit = table.Column<decimal>(type: "numeric", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    TransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    InventoryReceiptId = table.Column<string>(type: "text", nullable: true),
                    InventoryReceiptItemId = table.Column<string>(type: "text", nullable: true),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    FieldId = table.Column<string>(type: "text", nullable: true),
                    TaskId = table.Column<string>(type: "text", nullable: true),
                    FertilizerApplicationId = table.Column<string>(type: "text", nullable: true),
                    PesticideApplicationId = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ApplicationMethod = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_FarmInventories_FarmInventoryId",
                        column: x => x.FarmInventoryId,
                        principalTable: "FarmInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_FertilizerApplications_FertilizerAppl~",
                        column: x => x.FertilizerApplicationId,
                        principalTable: "FertilizerApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_InventoryReceiptItems_InventoryReceip~",
                        column: x => x.InventoryReceiptItemId,
                        principalTable: "InventoryReceiptItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_InventoryReceipts_InventoryReceiptId",
                        column: x => x.InventoryReceiptId,
                        principalTable: "InventoryReceipts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_PesticideApplications_PesticideApplic~",
                        column: x => x.PesticideApplicationId,
                        principalTable: "PesticideApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmInventories_CropVarietyId",
                table: "FarmInventories",
                column: "CropVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptItems_CropVarietyId",
                table: "InventoryReceiptItems",
                column: "CropVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptItems_FarmInventoryId",
                table: "InventoryReceiptItems",
                column: "FarmInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptItems_FertilizerId",
                table: "InventoryReceiptItems",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptItems_InventoryReceiptId",
                table: "InventoryReceiptItems",
                column: "InventoryReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceiptItems_PesticideId",
                table: "InventoryReceiptItems",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryReceipts_FarmId",
                table: "InventoryReceipts",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_CropPlantingId",
                table: "InventoryTransactions",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_FarmId",
                table: "InventoryTransactions",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_FarmInventoryId",
                table: "InventoryTransactions",
                column: "FarmInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_FertilizerApplicationId",
                table: "InventoryTransactions",
                column: "FertilizerApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_FieldId",
                table: "InventoryTransactions",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_InventoryReceiptId",
                table: "InventoryTransactions",
                column: "InventoryReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_InventoryReceiptItemId",
                table: "InventoryTransactions",
                column: "InventoryReceiptItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_PesticideApplicationId",
                table: "InventoryTransactions",
                column: "PesticideApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmInventories_CropVarieties_CropVarietyId",
                table: "FarmInventories",
                column: "CropVarietyId",
                principalTable: "CropVarieties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmInventories_CropVarieties_CropVarietyId",
                table: "FarmInventories");

            migrationBuilder.DropTable(
                name: "InventoryTransactions");

            migrationBuilder.DropTable(
                name: "InventoryReceiptItems");

            migrationBuilder.DropTable(
                name: "InventoryReceipts");

            migrationBuilder.DropIndex(
                name: "IX_FarmInventories_CropVarietyId",
                table: "FarmInventories");

            migrationBuilder.DropColumn(
                name: "CropVarietyId",
                table: "InventoryAlerts");

            migrationBuilder.DropColumn(
                name: "CropVarietyId",
                table: "FarmInventories");

            migrationBuilder.CreateTable(
                name: "ResourcePurchases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    InvoiceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    OutstandingBalance = table.Column<decimal>(type: "numeric", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    PaymentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PurchaseOrderNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SupplierContact = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SupplierName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePurchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUsages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    FieldId = table.Column<string>(type: "text", nullable: true),
                    InventoryId = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<string>(type: "text", nullable: true),
                    ApplicationMethod = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Purpose = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    QuantityUsed = table.Column<decimal>(type: "numeric", nullable: false),
                    UsageCost = table.Column<decimal>(type: "numeric", nullable: true),
                    UsageDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceUsages_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResourceUsages_FarmInventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "FarmInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceUsages_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResourceUsages_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResourcePurchaseItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    InventoryId = table.Column<string>(type: "text", nullable: false),
                    PurchaseId = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LineTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourcePurchaseItems_FarmInventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "FarmInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourcePurchaseItems_ResourcePurchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "ResourcePurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePurchaseItems_InventoryId",
                table: "ResourcePurchaseItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePurchaseItems_PurchaseId",
                table: "ResourcePurchaseItems",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsages_CropPlantingId",
                table: "ResourceUsages",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsages_FieldId",
                table: "ResourceUsages",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsages_InventoryId",
                table: "ResourceUsages",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsages_TaskId",
                table: "ResourceUsages",
                column: "TaskId");
        }
    }
}