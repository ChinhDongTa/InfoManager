# Smart Farm Management System (SFMS) - Implementation Guide

## Overview

The Smart Farm Management System (SFMS) is a comprehensive entity model for managing multi-farm agricultural operations within the InfoManager platform. It extends the existing family-based architecture to support:

- **Multi-farm operations** - Farms belong to families, supporting collaborative farming management
- **Advanced crop tracking** - From planning through harvest with comprehensive lifecycle management
- **IoT sensor integration** - Real-time environmental monitoring and data collection
- **Resource management** - Inventory tracking for seeds, fertilizers, pesticides, and equipment
- **Financial analytics** - Complete cost and revenue tracking with profitability analysis
- **Pest & disease management** - Comprehensive tracking of agricultural issues and interventions
- **Weather integration** - Historical data, forecasts, and severe weather alerts
- **Operational planning** - Planting and harvest plans with resource scheduling

---

## Architecture

### Entity Organization

The SFMS entities are organized into 10 logical domains:

#### 1. **Infrastructure (Base A)**
Foundational physical and digital resources

```
Farm
├── name, location, coordinates
├── totalArea, cultivableArea
├── status (Active, Inactive, Maintenance, Closed)
└── ownedBy user → FamilyId relationship

Field
├── name, area, soilType
├── coordinates, elevation
├── status (Vacant, Preparation, Cultivated, Fallow, Maintenance)
├── drainageCondition, hasIrrigation
└── belongs to Farm

Sensor
├── sensorType (Temperature, Humidity, SoilMoisture, pH, NPK, etc.)
├── model, serialNumber
├── installationDate, calibrationDate
├── batteryLevel, signalStrength
│└── deployed in Field
└── connected to Device

Device
├── deviceType (Gateway, DataLogger, WeatherStation, etc.)
├── model, macAddress, ipAddress
├── communicationProtocol (WiFi, LoRaWAN, Cellular, etc.)
├── status, battery level
├── lastDataSyncTime
└── manages multiple Sensors

DeviceAlert
├── alertType (LowBattery, NoData, HardwareFailure, etc.)
├── severity, message
├── resolutionStatus
└── tracks Device health
```

#### 2. **Agricultural (Planning & Cultivation)**
Crop definitions, varieties, and cultivation planning

```
Crop
├── commonName, scientificName
├── family, growthCharacteristics
├── min/maxTemperature, humidity, pH
├── waterRequirement, sunlightHours
├── daysToMaturity
└── isActive flag

CropVariety
├── varietyName, breederName
├── specifics: daysToMaturity, expectedYield
├── diseaseResistance, pestResistance
├── climateSuitability, yearOfRelease
└── belongs to Crop

CropSchedule
├── scheduleName, plantingSeason
├── plantingDateRange, harvestDateRange
├── daysToHarvest, plantSpacing, rowSpacing
├── irrigationSchedule, fertilizationSchedule
├── pesticide/herbicideSchedule
├── expectedYield, estimatedCost
└── for Crop & CropVariety

GrowthStage
├── stageName (Vegetative, Flowering, Fruiting, Maturity)
├── stageSequence, daysAfterPlanting, stageDuration
├── optimal: temperature, humidity, water
├── nutrient requirements (N, P, K)
├── commonPests, commonDiseases
├── managementActivities
└── part of Crop → CropSchedule
```

#### 3. **Operations (Execution)**
Planting instances, crop health, and daily management

```
CropPlanting
├── fieldId, cropId, varietyId, scheduleId
├── plantingDate, expectedHarvestDate, actualHarvestDate
├── plantedArea, quantityPlanted
├── status (Planned, Planted, Growing, Mature, Harvesting, Harvested, Abandoned)
├── notes
└── in Field

Equipment
├── name, type (Tractor, Pump, Sprayer, Harrow, etc.)
├── manufacturer, model, serialNumber
├── powerRating, specifications
├── purchaseDate, purchaseCost, currentValue
├── operatingHours
├── status (Active, Idle, UnderMaintenance, Retired)
├── lastMaintenanceDate, nextMaintenanceDate
└── in Farm

Maintenance
├── equipmentId
├── maintenanceDate, maintenanceType
├── description, partsReplaced
├── cost, operatingHoursAtTime
├── status (Planned, InProgress, Completed, Postponed, Cancelled)
├── serviceProvider, documentUrl
└── tracks Equipment maintenance

Task
├── taskName, fieldId, [cropPlantingId], [equipmentId]
├── taskType (Planting, Watering, Weeding, Spraying, Harvesting, etc.)
├── status (Pending, InProgress, Completed, Delayed, Cancelled, OnHold)
├── priority (Low, Normal, High, Critical)
├── scheduledStartDate, scheduledEndDate
├── actualStartDate, actualEndDate
├── completionPercentage
├── assignedTo
└── workArea
```

#### 4. **Monitoring (Real-time Data)**
Environmental data collection and crop health assessment

```
EnvironmentalReading
├── sensorId
├── readingTime, sensorType
├── value, unit
├── quality (Good, Warning, Error, Missing)
├── min/maxExpectedValue
├── isWithinRange
└── time-series data from Sensor

SoilAnalysis
├── fieldId, analysisDate
├── lab name, samplingDepth
├── nutrients: N, P, K, Ca, Mg, S
├── pH, electricalConductivity
├── organicMatter, micronutrients (Fe, Mn, Zn, Cu, B)
├── soilTexture (Sand%, Silt%, Clay%)
├── CEC (Cation Exchange Capacity)
├── recommendations
└── field-level soil data

CropHealth
├── cropPlantingId, assessmentDate
├── healthStatus (Excellent, Good, Fair, Poor, Critical, Dead)
├── leafCondition, stemCondition, rootCondition
├── plantHeight, vegetationDensity
├── pestDamagePercentage, diseaseSymptoms
├── biomassEstimate, leafAreaIndex
├── recommendedActions, photoUrl
└── assessment of CropPlanting
```

#### 5. **Production (Harvest & Processing)**
Harvest records, product processing, and sales

```
Harvest
├── cropPlantingId, harvestDate
├── harvestMethod (Manual, Mechanical, Partial)
├── harvestedArea, totalQuantity, quantityUnit
├── yieldPerHectare, qualityGrade
├── harvesterName, weatherCondition
├── lossPercentage
└── harvest record for CropPlanting

Product
├── harvestId, productName, processingType
├── quantity, unit, storageLocation
├── expiryDate, cost/unit, sellingPrice
├── totalValue, status (Available, Sold, Damaged, Discarded)
├── certification (Organic, ISO, etc.)
└── processed product from Harvest

Sale
├── productId, saleDate
├── buyerName, quantitySold, unitPrice
├── discountPercentage, totalAmount, netAmount
├── saleChannel (Direct, Wholesale, Market, Online)
├── paymentStatus, paymentDate
├── invoiceNumber
└── sales record

Yield
├── cropPlantingId, [harvestId]
├── actualYield, expectedYield, unit
├── yieldPerHectare, qualityRating
├── wastePercentage, yieldVariance
├── growthDays
├── productionCost, revenue, profit, ROI
├── affectingFactors, analysis, recommendations
└── yield analytics
```

#### 6. **Issues (Pest & Disease Management)**
Pest and disease tracking  

```
Pest
├── commonName, scientificName, pestType
├── description, affectedCrops
├── damageSymptoms, lifecycle
├── preventionMethods
├── recommendedPesticides, biologicalControl
├── severityLevel
└── pest reference database

Disease
├── commonName, scientificName, diseaseType
├── causativeOrganism, affectedCrops
├── symptoms, favorableConditions
├── transmissionMethod
├── preventionMethods, recommendedTreatments
├── severityLevel
└── disease reference database

PestDiseaseLink
├── pestId, diseaseId
├── relationshipDescription (e.g., "transmits")
└── pest-disease interactions

Infestation
├── cropPlantingId, [pestId], [diseaseId]
├── infestationType (Pest, Disease, Weed, Environmental)
├── detectionDate, affectedArea, affectedPercentage
├── severityLevel, status
├── treatmentApplied, treatmentDate, productUsed
├── treatmentCost, effectivenessRating
├── controlledDate, yieldLossPercentage
├── economicLoss, photoUrl
└── infestation instance
```

#### 7. **Resources (Inventory & Procurement)**
Resource inventory and cost tracking

```
FarmInventory
├── farmId, resourceName, resourceType
├── brand, currentQuantity, unit
├── min/maximumQuantity
├── costPerUnit, storageLocation
├── expiryDate, batchNumber
├── purchaseDate, supplier
├── certification (Organic, ISO, etc.)
├── isActive
└── farm resource stock

ResourceUsage
├── inventoryId, [taskId], [cropPlantingId], [fieldId]
├── usageDate, quantityUsed
├── purpose (description)
├── usageCost, applicationMethod
└── resource consumption record

ResourcePurchase
├── farmId, purchaseDate
├── supplierName, supplierContact
├── purchaseOrderNo, invoiceNo
├── totalAmount, paidAmount
├── outstandingBalance
├── paymentStatus, paymentDate
├── deliveryDate
└── purchase order

ResourcePurchaseItem
├── purchaseId, inventoryId
├── quantity, unitPrice, lineTotal
└── purchase line item
```

#### 8. **Weather (Environmental Context)**
Weather tracking and forecasting  

```
WeatherData
├── farmId, recordingTime
├── temperature, min/maxTemperature
├── humidity, dewPoint
├── rainfall, windSpeed, windDirection
├── windGustSpeed, pressure
├── solarRadiation, uvIndex
├── cloudCover, visibility
├── weatherCondition, dataSource
├── quality rating
└── historical weather record

WeatherForecast
├── farmId, forecastTime
├── forecasted: temperature, humidity
├── precipitationProbability, expectedRainfall
├── windSpeed, windDirection
├── cloudCover, pressure
├── solarRadiation, uvIndex
├── forecastedCondition, confidence
├── forecastSource, forecastIssuedDate
├── alerts, accuracyRating
└── weather forecast

WeatherAlert
├── farmId, alertType
├── description, severity
├── expectedStartTime, expectedEndTime
├── alertIssuedTime, status
├── farmingImpact, recommendedActions
├── source
└── severe weather alert
```

#### 9. **Planning (Operational Execution)**
Detailed plans for planting and harvest operations

```
CropCycle
├── farmId, cycleName
├── cropId, [varietyId], [scheduleId]
├── startYear, season
├── plannedPlantingDate, plannedHarvestDate
├── plannedArea, status
├── estimatedCost, estimatedRevenue
├── estimatedProfit, expectedYield
├── targetMarket, targetSellingPrice
└── complete crop cycle

PlantingPlan
├── cropCycleId, planName
├── fieldAllocation (JSON or separate records)
├── plantingMethod (Direct, Transplanting)
├── seedQuantityRequired, seedSource
├── seedbedPreparation
├── expectedGerminationRate
├── irrigationPlan, fertilizationPlan
├── laborRequirement, equipmentRequired
├── status (Draft, Approved, InExecution, Completed)
└── detailed planting operations plan

HarvestPlan
├── cropCycleId, planName
├── expectedStartDate, expectedEndDate
├── harvestMethod (Manual, Mechanical, Combination)
├── expectedYield, yieldUnit
├── laborRequirement, equipmentRequired
├── postHarvestProcessing
├── storageRequirement, storageDuration
├── transportationPlan
├── expectedSaleDate, targetBuyer
├── expectedSellingPrice
├── riskAssessment, status
└── detailed harvest operations plan
```

#### 10. **Economics (Financial Analysis)**
Cost tracking and profitability analysis

```
FarmExpense
├── farmId, [cropPlantingId]
├── expenseType (Seed, Fertilizer, Pesticide, Water,  Labor, etc.)
├── description, amount, category
├── expenseDate, vendor, invoiceNumber
├── paymentMethod, paymentStatus
├── approvalStatus, approvedBy
├── attachmentUrl
└── expense record

FarmRevenue
├── farmId, [cropPlantingId], [harvestId], [saleId]
├── source, amount, currency
├── revenueDate, buyerName
├── paymentStatus, paymentReceivedDate
└── revenue record

CostAnalysis
├── farmId, [cropPlantingId]
├── analysisDate, fromDate, toDate
├── totalCost, costBreakdown (JSON)
├── costPerHectare, costPerUnit
├── totalRevenue
├── grossProfit, netProfit, profitMargin
├── ROI, breakEvenAnalysis
├── efficiencyRating
├── recommendations, preparedBy
└── detailed cost analysis

FarmFinancialSummary
├── farmId, year, [month]
├── totalExpenses, totalRevenue, profit
├── cropCycleCount, totalAreaCultivated
├── averageYieldPerHectare
├── averageCostPerHectare, averageRevenuePerHectare
├── healthScore (0-100)
├── KPIs (Key Performance Indicators)
└── financial summary report
```

---

## Database Integration

### DbContext Configuration

All SFMS entities are registered in `ApplicationDbContext`:

```csharp
// Infrastructure
public DbSet<Farm> Farms => Set<Farm>();
public DbSet<Field> Fields => Set<Field>();
public DbSet<Sensor> Sensors => Set<Sensor>();
public DbSet<Device> Devices => Set<Device>();
public DbSet<DeviceAlert> DeviceAlerts => Set<DeviceAlert>();

// Agricultural
public DbSet<Crop> Crops => Set<Crop>();
public DbSet<CropVariety> CropVarieties => Set<CropVariety>();
public DbSet<CropSchedule> CropSchedules => Set<CropSchedule>();
public DbSet<CropPlanting> CropPlantings => Set<CropPlanting>();
public DbSet<GrowthStage> GrowthStages => Set<GrowthStage>();

// ... and so on for all 50+ entities
```

### EF Core Configurations

Entity configurations are defined in:
- `src/InfoManager.Infrastructure/Data/Configurations/SFMS/SfmsEntityConfigurations.cs`

Key features:
- Proper foreign key relationships with cascade delete policies
- Unique indexes for financial summaries
- Composite indexes for time-series queries (Sensor ID + DateTime)
- Navigation properties for eager loading optimization

---

## Key Design Decisions

### 1. **Multi-Tenant Support**
Farms belong to families, implementing implicit multi-tenancy:
- `Farm.FamilyId` - Associates farm to a family
- `Farm.FarmOwnerUserId` - User ownership for access control
- Family-based filtering can be implemented in queries

###  2. **Time-Series Data**
Environmental readings support efficient time-series queries:
- `EnvironmentalReading` - Simple value store (not complex events)
- Index on `(SensorId, ReadingTime)` for range queries
- `Quality` field for data validation without complex event types

### 3. **Flexible Relationships**
Uses optional foreign keys for flexibility:
- `CropPlanting` can exist without `CropVariety` or `CropSchedule`
- `FarmExpense` can be general (farm-level) or specific (crop-level)
- Entities can have `[Task]` or `[Harvest]` associations

### 4. **Audit Trail**
Inherits from `BaseAuditableEntity`:
- `Created`, `CreatedBy`, `LastModified`, `LastModifiedBy`
- Automatic timestamp management
- User tracking for accountability

### 5. **Enum-Based Status**
Status fields use enums for type safety:
- `FarmStatus`, `FieldStatus`, `PlantingStatus`, `TaskStatus`, etc.
- Prevents invalid state transitions
- Database-agnostic

---

## Key Features

### 1. **Comprehensive Lifecycle Management**
```
Crop Planning → Planting → Growth Monitoring → Pest/Disease Tracking
		   ↓        ↓            ↓                     ↓
	Schedules  Tasks    Health Records          Infestations
		↓        ↓            ↓                     ↓
	Cost Plan  Labor  Environmental Readings   Treatment Records
```

### 2. **Real-Time Monitoring**
- IoT sensor data (`EnvironmentalReading`)
- Device health tracking (`DeviceAlert`)
- Crop health assessment (`CropHealth`)
- Weather integration (`WeatherData`, `WeatherForecast`)

### 3. **Resource Optimization**
- Inventory management (`FarmInventory`, `ResourceUsage`)
- Equipment maintenance tracking (`Equipment`, `Maintenance`)
- Procurement management (`ResourcePurchase`)
- Cost per unit calculations

### 4. **Financial Analytics**
- Complete cost tracking by expense type
- Revenue tracking with payment status
- Profitability analysis (ROI, profit margin)
- Financial summaries by month/year
- Cost efficiency metrics

### 5. **Issue Management**
- Pest and disease reference databases
- Infestation tracking with severity levels
- Treatment effectiveness rating
- Economic loss quantification
- Preventive recommendations

---

## Next Steps

### 1. **Database Migrations**
```bash
cd src/InfoManager.Infrastructure
dotnet ef migrations add InitialSFMSEntities
dotnet ef database update
```

### 2. **Application Services**
Create application layer services for:
- Crop management
- Farm operations
- Environmental monitoring
- Financial reporting
- Pest/disease management

### 3. **API Endpoints**
Implement Minimal APIs or Controllers for:
- Farm CRUD operations
- Crop planting management
- Sensor data retrieval
- Financial reports
- Task scheduling

### 4. **Blazor Components**
Build UI components for:
- Farm dashboard
- Field management
- Crop monitoring
- Financial analytics
- Alerts and notifications

---

## Statistics

- **Total Entities**: 50+
- **DbSets Registered**: 48
- **Enums**: 15+
- **Relationships**: 100+
- **Indexes**: 30+
- **Lines of Code**: 5000+ (domain models)

---

## Contact & Support

For questions about SFMS implementation:
- Review entity documentation in respective files
- Check EF Core configurations for relationship details
- Refer to GlobalUsing for auto-imported namespaces
