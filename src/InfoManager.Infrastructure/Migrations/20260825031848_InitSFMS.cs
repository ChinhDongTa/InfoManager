using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitSFMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Transactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TokenBlacklists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PriceTrackings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Intentions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "HistoricalEvents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HistoricalEvents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HistoricalEvents",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "HistoricalEvents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "HistoricalEvents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "FamilyRelations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FamilyRelations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FamilyRelations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "FamilyRelations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "FamilyRelations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FamilyMembers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FamilyEvents",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FamilyEventReminders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FamilyEventOccurrences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Families",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Experiences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CommonName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ScientificName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Family = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DaysToMaturity = table.Column<int>(type: "integer", nullable: true),
                    MinTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MinHumidity = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxHumidity = table.Column<decimal>(type: "numeric", nullable: true),
                    MinSoilPh = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxSoilPh = table.Column<decimal>(type: "numeric", nullable: true),
                    WaterRequirement = table.Column<decimal>(type: "numeric", nullable: true),
                    SunLightHours = table.Column<decimal>(type: "numeric", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CommonName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ScientificName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DiseaseType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CausativeOrganism = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    AffectedCrops = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Symptoms = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    FavorableConditions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TransmissionMethod = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PreventionMethods = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    RecommendedTreatments = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SeverityLevel = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: false),
                    CultivableArea = table.Column<decimal>(type: "numeric", nullable: false),
                    Location = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: true),
                    FarmOwnerUserId = table.Column<string>(type: "text", nullable: false),
                    FamilyId = table.Column<string>(type: "text", nullable: false),
                    LicenseNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EstablishedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CommonName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ScientificName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PestType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AffectedCrops = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DamageSymptoms = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    LifeCycle = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PreventionMethods = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    RecommendedPesticides = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    BiologicalControl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SeverityLevel = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourcePurchases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SupplierName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SupplierContact = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PurchaseOrderNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    InvoiceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    OutstandingBalance = table.Column<decimal>(type: "numeric", nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePurchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropVarieties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    VarietyName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CropId = table.Column<string>(type: "text", nullable: false),
                    BreederName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DaysToMaturity = table.Column<int>(type: "integer", nullable: true),
                    ExpectedYield = table.Column<decimal>(type: "numeric", nullable: true),
                    YieldUnit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SeedRate = table.Column<decimal>(type: "numeric", nullable: true),
                    DiseaseResistance = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PestResistance = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ClimateSuitability = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    YearOfRelease = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropVarieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropVarieties_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MacAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CommunicationProtocol = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LastDataSyncTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FirmwareVersion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BatteryLevel = table.Column<decimal>(type: "numeric", nullable: true),
                    StorageCapacity = table.Column<decimal>(type: "numeric", nullable: true),
                    StorageUsed = table.Column<decimal>(type: "numeric", nullable: true),
                    InstallationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastMaintenanceDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EquipmentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PowerRating = table.Column<decimal>(type: "numeric", nullable: true),
                    Specifications = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PurchaseCost = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrentValue = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OperatingHours = table.Column<decimal>(type: "numeric", nullable: true),
                    LastMaintenanceDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NextMaintenanceDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmFinancialSummaries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: true),
                    TotalExpenses = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalRevenue = table.Column<decimal>(type: "numeric", nullable: false),
                    Profit = table.Column<decimal>(type: "numeric", nullable: false),
                    CropCycleCount = table.Column<int>(type: "integer", nullable: true),
                    TotalAreaCultivated = table.Column<decimal>(type: "numeric", nullable: true),
                    AverageYieldPerHectare = table.Column<decimal>(type: "numeric", nullable: true),
                    AverageCostPerHectare = table.Column<decimal>(type: "numeric", nullable: true),
                    AverageRevenuePerHectare = table.Column<decimal>(type: "numeric", nullable: true),
                    HealthScore = table.Column<decimal>(type: "numeric", nullable: true),
                    KPIs = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmFinancialSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmFinancialSummaries_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmInventories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    ResourceName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ResourceType = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CurrentQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MinimumQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    MaximumQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    CostPerUnit = table.Column<decimal>(type: "numeric", nullable: true),
                    StorageLocation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ExpiryDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BatchNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Supplier = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Certification = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Specification = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmInventories_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Area = table.Column<decimal>(type: "numeric", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    SoilType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SoilCondition = table.Column<int>(type: "integer", nullable: true),
                    Elevation = table.Column<decimal>(type: "numeric", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastPreparationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DrainageCondition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HasIrrigation = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherAlerts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    AlertType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    ExpectedStartTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ExpectedEndTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AlertIssuedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    FarmingImpact = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RecommendedActions = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Source = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherAlerts_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    RecordingTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MinTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    Humidity = table.Column<decimal>(type: "numeric", nullable: true),
                    DewPoint = table.Column<decimal>(type: "numeric", nullable: true),
                    Rainfall = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeed = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirection = table.Column<decimal>(type: "numeric", nullable: true),
                    WindGustSpeed = table.Column<decimal>(type: "numeric", nullable: true),
                    Pressure = table.Column<decimal>(type: "numeric", nullable: true),
                    SolarRadiation = table.Column<decimal>(type: "numeric", nullable: true),
                    UVIndex = table.Column<decimal>(type: "numeric", nullable: true),
                    CloudCover = table.Column<decimal>(type: "numeric", nullable: true),
                    Visibility = table.Column<decimal>(type: "numeric", nullable: true),
                    WeatherCondition = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DataSource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Quality = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherData_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    ForecastTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MinTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    Humidity = table.Column<decimal>(type: "numeric", nullable: true),
                    PrecipitationProbability = table.Column<decimal>(type: "numeric", nullable: true),
                    ExpectedRainfall = table.Column<decimal>(type: "numeric", nullable: true),
                    WindSpeed = table.Column<decimal>(type: "numeric", nullable: true),
                    WindDirection = table.Column<decimal>(type: "numeric", nullable: true),
                    CloudCover = table.Column<decimal>(type: "numeric", nullable: true),
                    Pressure = table.Column<decimal>(type: "numeric", nullable: true),
                    SolarRadiation = table.Column<decimal>(type: "numeric", nullable: true),
                    UVIndex = table.Column<decimal>(type: "numeric", nullable: true),
                    ForecastedCondition = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Confidence = table.Column<decimal>(type: "numeric", nullable: true),
                    ForecastSource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ForecastIssuedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Alerts = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AccuracyRating = table.Column<decimal>(type: "numeric", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PestDiseaseLinks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PestId = table.Column<string>(type: "text", nullable: false),
                    DiseaseId = table.Column<string>(type: "text", nullable: false),
                    RelationshipDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PestDiseaseLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PestDiseaseLinks_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PestDiseaseLinks_Pests_PestId",
                        column: x => x.PestId,
                        principalTable: "Pests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ScheduleName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CropId = table.Column<string>(type: "text", nullable: false),
                    CropVarietyId = table.Column<string>(type: "text", nullable: true),
                    PlantingSeason = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PlantingDateRange = table.Column<string>(type: "text", nullable: true),
                    HarvestDateRange = table.Column<string>(type: "text", nullable: true),
                    DaysToHarvest = table.Column<int>(type: "integer", nullable: false),
                    PlantSpacing = table.Column<decimal>(type: "numeric", nullable: true),
                    RowSpacing = table.Column<decimal>(type: "numeric", nullable: true),
                    IrrigationSchedule = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FertilizationSchedule = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PesticideSchedule = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ExpectedYield = table.Column<decimal>(type: "numeric", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "numeric", nullable: true),
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
                    table.PrimaryKey("PK_CropSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropSchedules_CropVarieties_CropVarietyId",
                        column: x => x.CropVarietyId,
                        principalTable: "CropVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CropSchedules_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceAlerts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: false),
                    AlertType = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    AlertTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ResolvedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false),
                    ResolutionNotes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceAlerts_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EquipmentId = table.Column<string>(type: "text", nullable: false),
                    MaintenanceDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MaintenanceType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PartReplaced = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    ServiceProvider = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    OperatingHours = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DocumentUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourcePurchaseItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PurchaseId = table.Column<string>(type: "text", nullable: false),
                    InventoryId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    LineTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SensorType = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FieldId = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Depth = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LastReadingTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BatteryLevel = table.Column<decimal>(type: "numeric", nullable: true),
                    SignalStrength = table.Column<decimal>(type: "numeric", nullable: true),
                    InstallationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    NextCalibrationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sensors_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoilAnalyses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FieldId = table.Column<string>(type: "text", nullable: false),
                    AnalysisDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LabName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SamplingDepth = table.Column<decimal>(type: "numeric", nullable: true),
                    PH = table.Column<decimal>(type: "numeric", nullable: true),
                    ElectricalConductivity = table.Column<decimal>(type: "numeric", nullable: true),
                    Nitrogen = table.Column<decimal>(type: "numeric", nullable: true),
                    Phosphorus = table.Column<decimal>(type: "numeric", nullable: true),
                    Potassium = table.Column<decimal>(type: "numeric", nullable: true),
                    Calcium = table.Column<decimal>(type: "numeric", nullable: true),
                    Magnesium = table.Column<decimal>(type: "numeric", nullable: true),
                    Sulfur = table.Column<decimal>(type: "numeric", nullable: true),
                    OrganicMatter = table.Column<decimal>(type: "numeric", nullable: true),
                    Iron = table.Column<decimal>(type: "numeric", nullable: true),
                    Manganese = table.Column<decimal>(type: "numeric", nullable: true),
                    Zinc = table.Column<decimal>(type: "numeric", nullable: true),
                    Copper = table.Column<decimal>(type: "numeric", nullable: true),
                    Boron = table.Column<decimal>(type: "numeric", nullable: true),
                    CationExchangeCapacity = table.Column<decimal>(type: "numeric", nullable: true),
                    SandPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    SiltPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    ClayPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    ReportUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LabRemarks = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Recommendations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoilAnalyses_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropCycles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    CycleName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CropId = table.Column<string>(type: "text", nullable: false),
                    CropVarietyId = table.Column<string>(type: "text", nullable: true),
                    CropScheduleId = table.Column<string>(type: "text", nullable: true),
                    StartYear = table.Column<int>(type: "integer", nullable: false),
                    Season = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PlannedPlantingDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PlannedHarvestDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PlannedArea = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EstimatedCost = table.Column<decimal>(type: "numeric", nullable: true),
                    EstimatedRevenue = table.Column<decimal>(type: "numeric", nullable: true),
                    EstimatedProfit = table.Column<decimal>(type: "numeric", nullable: true),
                    ExpectedYield = table.Column<decimal>(type: "numeric", nullable: true),
                    TargetMarket = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    TargetSellingPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropCycles_CropSchedules_CropScheduleId",
                        column: x => x.CropScheduleId,
                        principalTable: "CropSchedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CropCycles_CropVarieties_CropVarietyId",
                        column: x => x.CropVarietyId,
                        principalTable: "CropVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CropCycles_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropCycles_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrowthStages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    StageName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CropId = table.Column<string>(type: "text", nullable: false),
                    CropScheduleId = table.Column<string>(type: "text", nullable: true),
                    StageSequence = table.Column<int>(type: "integer", nullable: false),
                    DaysAfterPlanting = table.Column<int>(type: "integer", nullable: false),
                    StageDuration = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MinTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxTemperature = table.Column<decimal>(type: "numeric", nullable: true),
                    MinHumidity = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxHumidity = table.Column<decimal>(type: "numeric", nullable: true),
                    WaterRequirement = table.Column<decimal>(type: "numeric", nullable: true),
                    NitrogenRequirement = table.Column<decimal>(type: "numeric", nullable: true),
                    PhosphorusRequirement = table.Column<decimal>(type: "numeric", nullable: true),
                    PotassiumRequirement = table.Column<decimal>(type: "numeric", nullable: true),
                    CommonPests = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CommonDiseases = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ManagementActivities = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowthStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrowthStages_CropSchedules_CropScheduleId",
                        column: x => x.CropScheduleId,
                        principalTable: "CropSchedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrowthStages_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalReadings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SensorId = table.Column<string>(type: "text", nullable: false),
                    ReadingTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SensorType = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Quality = table.Column<int>(type: "integer", nullable: false),
                    RawValue = table.Column<decimal>(type: "numeric", nullable: true),
                    IsWithinRange = table.Column<bool>(type: "boolean", nullable: false),
                    MinExpectedValue = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxExpectedValue = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalReadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentalReadings_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropPlantings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FieldId = table.Column<string>(type: "text", nullable: false),
                    CropId = table.Column<string>(type: "text", nullable: false),
                    CropVarietyId = table.Column<string>(type: "text", nullable: true),
                    CropScheduleId = table.Column<string>(type: "text", nullable: true),
                    PlantingDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpectedHarvestDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ActualHarvestDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PlantedArea = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityPlanted = table.Column<decimal>(type: "numeric", nullable: true),
                    PlantedUnit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CropCycleId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropPlantings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropPlantings_CropCycles_CropCycleId",
                        column: x => x.CropCycleId,
                        principalTable: "CropCycles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CropPlantings_CropSchedules_CropScheduleId",
                        column: x => x.CropScheduleId,
                        principalTable: "CropSchedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CropPlantings_CropVarieties_CropVarietyId",
                        column: x => x.CropVarietyId,
                        principalTable: "CropVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CropPlantings_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropPlantings_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HarvestPlans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropCycleId = table.Column<string>(type: "text", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ExpectedStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpectedEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    HarvestMethod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExpectedYield = table.Column<decimal>(type: "numeric", nullable: true),
                    YieldUnit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LaborRequirement = table.Column<decimal>(type: "numeric", nullable: true),
                    EquipmentRequired = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostHarvestProcessing = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    StorageRequirement = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    StorageDuration = table.Column<int>(type: "integer", nullable: true),
                    TransportationPlan = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ExpectedSaleDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    TargetBuyer = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    ExpectedSellingPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RiskAssessment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HarvestPlans_CropCycles_CropCycleId",
                        column: x => x.CropCycleId,
                        principalTable: "CropCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantingPlans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropCycleId = table.Column<string>(type: "text", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FieldAllocation = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PlantingMethod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SeedQuantityRequired = table.Column<decimal>(type: "numeric", nullable: true),
                    SeedSource = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SeedbedPreparation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ExpectedGerminationRate = table.Column<decimal>(type: "numeric", nullable: true),
                    IrrigationPlan = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FertilizationPlan = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LaborRequirement = table.Column<decimal>(type: "numeric", nullable: true),
                    EquipmentRequired = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingPlans_CropCycles_CropCycleId",
                        column: x => x.CropCycleId,
                        principalTable: "CropCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrowthStageAlerts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: false),
                    GrowthStageId = table.Column<string>(type: "text", nullable: false),
                    AlertType = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    AlertTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpectedAchievementDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ActualAchievementDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false),
                    ActionTaken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowthStageAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrowthStageAlerts_GrowthStages_GrowthStageId",
                        column: x => x.GrowthStageId,
                        principalTable: "GrowthStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostAnalyses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    AnalysisDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FromDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ToDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false),
                    CostBreakdown = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    CostPerHectare = table.Column<decimal>(type: "numeric", nullable: true),
                    CostPerUnit = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalRevenue = table.Column<decimal>(type: "numeric", nullable: false),
                    GrossProfit = table.Column<decimal>(type: "numeric", nullable: false),
                    NetProfit = table.Column<decimal>(type: "numeric", nullable: false),
                    ProfitMargin = table.Column<decimal>(type: "numeric", nullable: false),
                    ROI = table.Column<decimal>(type: "numeric", nullable: false),
                    BreakEvenAnalysis = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    EfficiencyRating = table.Column<decimal>(type: "numeric", nullable: true),
                    Recommendations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PreparedBy = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostAnalyses_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CostAnalyses_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropHealthRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: false),
                    AssessmentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HealthStatus = table.Column<int>(type: "integer", nullable: false),
                    LeafCondition = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    StemCondition = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RootCondition = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PlantHeight = table.Column<decimal>(type: "numeric", nullable: true),
                    VegetationDensity = table.Column<decimal>(type: "numeric", nullable: true),
                    PestDamagePercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    DiseaseSymptoms = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BiomassEstimate = table.Column<decimal>(type: "numeric", nullable: true),
                    LeafAreaIndex = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    RecommendedActions = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PhotoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropHealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropHealthRecords_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmExpenses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    ExpenseType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExpenseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Vendor = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    InvoiceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PaymentMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "integer", nullable: false),
                    ApprovedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AttachmentUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmExpenses_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FarmExpenses_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: false),
                    HarvestDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HarvestMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HarvestedArea = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityUnit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    YieldPerHectare = table.Column<decimal>(type: "numeric", nullable: true),
                    QualityGrade = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    HarvesterName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    WeatherCondition = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LossPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PhotoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvests_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infestations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: false),
                    PestId = table.Column<string>(type: "text", nullable: true),
                    DiseaseId = table.Column<string>(type: "text", nullable: true),
                    InfestationType = table.Column<int>(type: "integer", nullable: false),
                    DetectionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AffectedArea = table.Column<decimal>(type: "numeric", nullable: false),
                    AffectedPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    SeverityLevel = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TreatmentApplied = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TreatmentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ProductUsed = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TreatmentCost = table.Column<decimal>(type: "numeric", nullable: true),
                    EffectivenessRating = table.Column<decimal>(type: "numeric", nullable: true),
                    ControlledDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    YieldLossPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    EconomicLoss = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PhotoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infestations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infestations_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Infestations_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Infestations_Pests_PestId",
                        column: x => x.PestId,
                        principalTable: "Pests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TaskName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    FieldId = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    TaskType = table.Column<int>(type: "integer", nullable: false),
                    EquipmentId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ScheduledStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ScheduledEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ActualStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ActualEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DurationHours = table.Column<decimal>(type: "numeric", nullable: true),
                    WorkArea = table.Column<decimal>(type: "numeric", nullable: true),
                    AssignedTo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    CompletionPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HarvestId = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ProcessingType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StorageLocation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ExpiryDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CostPerUnit = table.Column<decimal>(type: "numeric", nullable: true),
                    SellingPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalValue = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Certification = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Harvests_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yields",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: false),
                    HarvestId = table.Column<string>(type: "text", nullable: true),
                    ActualYield = table.Column<decimal>(type: "numeric", nullable: false),
                    ExpectedYield = table.Column<decimal>(type: "numeric", nullable: true),
                    Unit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    YieldPerHectare = table.Column<decimal>(type: "numeric", nullable: false),
                    QualityRating = table.Column<decimal>(type: "numeric", nullable: true),
                    WastePercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    YieldVariance = table.Column<decimal>(type: "numeric", nullable: true),
                    GrowthDays = table.Column<int>(type: "integer", nullable: true),
                    ProductionCost = table.Column<decimal>(type: "numeric", nullable: true),
                    Revenue = table.Column<decimal>(type: "numeric", nullable: true),
                    Profit = table.Column<decimal>(type: "numeric", nullable: true),
                    ROI = table.Column<decimal>(type: "numeric", nullable: true),
                    AffectingFactors = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Analysis = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Recommendations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yields_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yields_Harvests_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResourceUsages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    InventoryId = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<string>(type: "text", nullable: true),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    FieldId = table.Column<string>(type: "text", nullable: true),
                    UsageDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    QuantityUsed = table.Column<decimal>(type: "numeric", nullable: false),
                    Purpose = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    UsageCost = table.Column<decimal>(type: "numeric", nullable: true),
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
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    SaleDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    BuyerName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    QuantitySold = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    NetAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    SaleChannel = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmRevenues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    CropPlantingId = table.Column<string>(type: "text", nullable: true),
                    HarvestId = table.Column<string>(type: "text", nullable: true),
                    SaleId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    RevenueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    BuyerName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    PaymentReceivedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmRevenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmRevenues_CropPlantings_CropPlantingId",
                        column: x => x.CropPlantingId,
                        principalTable: "CropPlantings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FarmRevenues_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmRevenues_Harvests_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FarmRevenues_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "014af7c9-397d-48f4-96f3-b12d80d1a5e4",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3f22bd16-2e0a-4d2e-92d7-4442c27dfaa8",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4814d70b-6202-470b-99ac-778748c743a2",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "64154fed-88e8-4ecf-9404-abd1a1692228",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "69beb3c5-44e5-411c-95e2-acdae6ed6804",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6c6bb70b-c45c-4a88-967a-b2e7584a2999",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6e6f59f5-7f5a-496d-9dd9-e8582c86f30b",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6ed08184-788e-4530-848f-ec53882140f5",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "92ea6071-2279-42a1-899e-ea287086be66",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a8fe7c3e-4fa7-4396-a74c-a179dfac9444",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f68a4c51-fb49-493b-96c4-7c9f1c298235",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "10d0bb42-d9c6-4c28-be58-e64e50a2a911",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "23297e2b-78f1-42ad-97d3-ef1a1ff6b943",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "40172842-82bb-4e4e-8403-b7bb5c91ecd4",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "506424e6-db25-48d9-9841-d4454dbb97ef",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "52edc712-0f51-48bd-ab9d-17dd2bafa639",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "7cd4de3d-6294-4e13-b9c5-fbad7a9ea174",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "87655c00-f770-4af5-88ee-cdac045b97bd",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "8f817c44-2b9f-4e75-8999-957b3c3e5d8f",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "a14ec1c2-6563-4ec8-a022-7318ebd236f0",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "ba609a13-4f83-4075-a78d-55c18e730190",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "dad4eb62-9681-4011-9d36-4ac199f0c239",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "e2b21928-c91c-4534-917b-41971c52bb51",
                columns: new[] { "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.CreateIndex(
                name: "IX_CostAnalyses_CropPlantingId",
                table: "CostAnalyses",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_CostAnalyses_FarmId",
                table: "CostAnalyses",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_CropCycles_CropId",
                table: "CropCycles",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropCycles_CropScheduleId",
                table: "CropCycles",
                column: "CropScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CropCycles_CropVarietyId",
                table: "CropCycles",
                column: "CropVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_CropCycles_FarmId",
                table: "CropCycles",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_CropHealthRecords_CropPlantingId",
                table: "CropHealthRecords",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_CropCycleId",
                table: "CropPlantings",
                column: "CropCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_CropId",
                table: "CropPlantings",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_CropScheduleId",
                table: "CropPlantings",
                column: "CropScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_CropVarietyId",
                table: "CropPlantings",
                column: "CropVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_FieldId",
                table: "CropPlantings",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_PlantingDate",
                table: "CropPlantings",
                column: "PlantingDate");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_Status",
                table: "CropPlantings",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_CommonName",
                table: "Crops",
                column: "CommonName");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_IsActive",
                table: "Crops",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_ScientificName",
                table: "Crops",
                column: "ScientificName");

            migrationBuilder.CreateIndex(
                name: "IX_CropSchedules_CropId",
                table: "CropSchedules",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropSchedules_CropVarietyId",
                table: "CropSchedules",
                column: "CropVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_CropVarieties_CropId",
                table: "CropVarieties",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceAlerts_DeviceId",
                table: "DeviceAlerts",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FarmId",
                table: "Devices",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_LastDataSyncTime",
                table: "Devices",
                column: "LastDataSyncTime");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Status",
                table: "Devices",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalReadings_Quality",
                table: "EnvironmentalReadings",
                column: "Quality");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalReadings_ReadingTime",
                table: "EnvironmentalReadings",
                column: "ReadingTime",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalReadings_SensorId_ReadingTime",
                table: "EnvironmentalReadings",
                columns: new[] { "SensorId", "ReadingTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_FarmId",
                table: "Equipment",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmExpenses_CropPlantingId",
                table: "FarmExpenses",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmExpenses_ExpenseDate",
                table: "FarmExpenses",
                column: "ExpenseDate");

            migrationBuilder.CreateIndex(
                name: "IX_FarmExpenses_ExpenseType",
                table: "FarmExpenses",
                column: "ExpenseType");

            migrationBuilder.CreateIndex(
                name: "IX_FarmExpenses_FarmId",
                table: "FarmExpenses",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmFinancialSummaries_FarmId_Year_Month",
                table: "FarmFinancialSummaries",
                columns: new[] { "FarmId", "Year", "Month" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FarmInventories_FarmId",
                table: "FarmInventories",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmRevenues_CropPlantingId",
                table: "FarmRevenues",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmRevenues_FarmId",
                table: "FarmRevenues",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmRevenues_HarvestId",
                table: "FarmRevenues",
                column: "HarvestId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmRevenues_SaleId",
                table: "FarmRevenues",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FamilyId",
                table: "Farms",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmOwnerUserId",
                table: "Farms",
                column: "FarmOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_Status",
                table: "Farms",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FarmId",
                table: "Fields",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Status",
                table: "Fields",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_GrowthStageAlerts_GrowthStageId",
                table: "GrowthStageAlerts",
                column: "GrowthStageId");

            migrationBuilder.CreateIndex(
                name: "IX_GrowthStages_CropId",
                table: "GrowthStages",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_GrowthStages_CropScheduleId",
                table: "GrowthStages",
                column: "CropScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPlans_CropCycleId",
                table: "HarvestPlans",
                column: "CropCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_CropPlantingId",
                table: "Harvests",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_HarvestDate",
                table: "Harvests",
                column: "HarvestDate");

            migrationBuilder.CreateIndex(
                name: "IX_Infestations_CropPlantingId",
                table: "Infestations",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_Infestations_DetectionDate",
                table: "Infestations",
                column: "DetectionDate");

            migrationBuilder.CreateIndex(
                name: "IX_Infestations_DiseaseId",
                table: "Infestations",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Infestations_PestId",
                table: "Infestations",
                column: "PestId");

            migrationBuilder.CreateIndex(
                name: "IX_Infestations_Status",
                table: "Infestations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_EquipmentId",
                table: "MaintenanceRecords",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PestDiseaseLinks_DiseaseId",
                table: "PestDiseaseLinks",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PestDiseaseLinks_PestId",
                table: "PestDiseaseLinks",
                column: "PestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPlans_CropCycleId",
                table: "PlantingPlans",
                column: "CropCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_HarvestId",
                table: "Products",
                column: "HarvestId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_DeviceId",
                table: "Sensors",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_FieldId",
                table: "Sensors",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_LastReadingTime",
                table: "Sensors",
                column: "LastReadingTime");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SensorType",
                table: "Sensors",
                column: "SensorType");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Status",
                table: "Sensors",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SoilAnalyses_FieldId",
                table: "SoilAnalyses",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CropPlantingId",
                table: "Tasks",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EquipmentId",
                table: "Tasks",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_FieldId",
                table: "Tasks",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherAlerts_FarmId",
                table: "WeatherAlerts",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_FarmId",
                table: "WeatherData",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_FarmId",
                table: "WeatherForecasts",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Yields_CropPlantingId",
                table: "Yields",
                column: "CropPlantingId");

            migrationBuilder.CreateIndex(
                name: "IX_Yields_HarvestId",
                table: "Yields",
                column: "HarvestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostAnalyses");

            migrationBuilder.DropTable(
                name: "CropHealthRecords");

            migrationBuilder.DropTable(
                name: "DeviceAlerts");

            migrationBuilder.DropTable(
                name: "EnvironmentalReadings");

            migrationBuilder.DropTable(
                name: "FarmExpenses");

            migrationBuilder.DropTable(
                name: "FarmFinancialSummaries");

            migrationBuilder.DropTable(
                name: "FarmRevenues");

            migrationBuilder.DropTable(
                name: "GrowthStageAlerts");

            migrationBuilder.DropTable(
                name: "HarvestPlans");

            migrationBuilder.DropTable(
                name: "Infestations");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "PestDiseaseLinks");

            migrationBuilder.DropTable(
                name: "PlantingPlans");

            migrationBuilder.DropTable(
                name: "ResourcePurchaseItems");

            migrationBuilder.DropTable(
                name: "ResourceUsages");

            migrationBuilder.DropTable(
                name: "SoilAnalyses");

            migrationBuilder.DropTable(
                name: "WeatherAlerts");

            migrationBuilder.DropTable(
                name: "WeatherData");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Yields");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "GrowthStages");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Pests");

            migrationBuilder.DropTable(
                name: "ResourcePurchases");

            migrationBuilder.DropTable(
                name: "FarmInventories");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "CropPlantings");

            migrationBuilder.DropTable(
                name: "CropCycles");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "CropSchedules");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "CropVarieties");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TokenBlacklists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PriceTrackings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Intentions");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "HistoricalEvents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HistoricalEvents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HistoricalEvents");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "HistoricalEvents");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "HistoricalEvents");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FamilyEvents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FamilyEventReminders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FamilyEventOccurrences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Categories");
        }
    }
}
