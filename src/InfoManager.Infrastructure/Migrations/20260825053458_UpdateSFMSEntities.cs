using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSFMSEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sensors_LastReadingTime",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_SensorType",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_Status",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Infestations_DetectionDate",
                table: "Infestations");

            migrationBuilder.DropIndex(
                name: "IX_Infestations_Status",
                table: "Infestations");

            migrationBuilder.DropIndex(
                name: "IX_Harvests_HarvestDate",
                table: "Harvests");

            migrationBuilder.DropIndex(
                name: "IX_Fields_Status",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FamilyId",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmOwnerUserId",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_Status",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_FarmFinancialSummaries_FarmId_Year_Month",
                table: "FarmFinancialSummaries");

            migrationBuilder.DropIndex(
                name: "IX_FarmExpenses_ExpenseDate",
                table: "FarmExpenses");

            migrationBuilder.DropIndex(
                name: "IX_FarmExpenses_ExpenseType",
                table: "FarmExpenses");

            migrationBuilder.DropIndex(
                name: "IX_EnvironmentalReadings_Quality",
                table: "EnvironmentalReadings");

            migrationBuilder.DropIndex(
                name: "IX_EnvironmentalReadings_ReadingTime",
                table: "EnvironmentalReadings");

            migrationBuilder.DropIndex(
                name: "IX_EnvironmentalReadings_SensorId_ReadingTime",
                table: "EnvironmentalReadings");

            migrationBuilder.DropIndex(
                name: "IX_Devices_LastDataSyncTime",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_Status",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Crops_CommonName",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_IsActive",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_ScientificName",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_CropPlantings_PlantingDate",
                table: "CropPlantings");

            migrationBuilder.DropIndex(
                name: "IX_CropPlantings_Status",
                table: "CropPlantings");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ParentId = table.Column<string>(type: "text", nullable: true),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IPAddress = table.Column<string>(type: "text", nullable: true),
                    DeviceInfo = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HREmployees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FamilyMemberId = table.Column<string>(type: "text", nullable: true),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<string>(type: "text", nullable: true),
                    EmployeeNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    HireDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    TerminationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    TerminationReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    SalaryType = table.Column<int>(type: "integer", nullable: false),
                    BankAccount = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmergencyContactName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HREmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HREmployees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HREmployees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HREmployees_FamilyMembers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HREmployees_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    MinSalary = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxSalary = table.Column<decimal>(type: "numeric", nullable: true),
                    DepartmentId = table.Column<string>(type: "text", nullable: true),
                    RequiredQualifications = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    NumberOfPositions = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPositions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContracts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HREmployeeId = table.Column<string>(type: "text", nullable: false),
                    ContractNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ContractType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    SalaryType = table.Column<int>(type: "integer", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContracts_HREmployees_HREmployeeId",
                        column: x => x.HREmployeeId,
                        principalTable: "HREmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HREmployeeId = table.Column<string>(type: "text", nullable: false),
                    LeaveType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true),
                    ApprovedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_HREmployees_HREmployeeId",
                        column: x => x.HREmployeeId,
                        principalTable: "HREmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HREmployeeId = table.Column<string>(type: "text", nullable: false),
                    PeriodStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PeriodEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    DaysWorked = table.Column<decimal>(type: "numeric", nullable: false),
                    OvertimeHours = table.Column<decimal>(type: "numeric", nullable: true),
                    OvertimeAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    BonusAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Deductions = table.Column<decimal>(type: "numeric", nullable: true),
                    DeductionDetails = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    NetAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaymentMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payrolls_HREmployees_HREmployeeId",
                        column: x => x.HREmployeeId,
                        principalTable: "HREmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    FarmId = table.Column<string>(type: "text", nullable: false),
                    HREmployeeId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkShifts_HREmployees_HREmployeeId",
                        column: x => x.HREmployeeId,
                        principalTable: "HREmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobAssignments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HREmployeeId = table.Column<string>(type: "text", nullable: false),
                    JobPositionId = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AssignedSalary = table.Column<decimal>(type: "numeric", nullable: true),
                    AssignedFieldId = table.Column<string>(type: "text", nullable: true),
                    SupervisorId = table.Column<string>(type: "text", nullable: true),
                    PerformanceNotes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AssignmentReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HREmployeeId1 = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAssignments_Fields_AssignedFieldId",
                        column: x => x.AssignedFieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_JobAssignments_HREmployees_HREmployeeId",
                        column: x => x.HREmployeeId,
                        principalTable: "HREmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobAssignments_HREmployees_HREmployeeId1",
                        column: x => x.HREmployeeId1,
                        principalTable: "HREmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobAssignments_HREmployees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "HREmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_JobAssignments_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HREmployeeId = table.Column<string>(type: "text", nullable: false),
                    AttendanceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckInTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    CheckOutTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    WorkShiftId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HoursWorked = table.Column<decimal>(type: "numeric", nullable: true),
                    OvertimeHours = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendances_HREmployees_HREmployeeId",
                        column: x => x.HREmployeeId,
                        principalTable: "HREmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendances_WorkShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmFinancialSummaries_FarmId",
                table: "FarmFinancialSummaries",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalReadings_SensorId",
                table: "EnvironmentalReadings",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FarmId",
                table: "Departments",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentId",
                table: "Departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_AttendanceDate",
                table: "EmployeeAttendances",
                column: "AttendanceDate");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_HREmployeeId",
                table: "EmployeeAttendances",
                column: "HREmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_HREmployeeId_AttendanceDate",
                table: "EmployeeAttendances",
                columns: new[] { "HREmployeeId", "AttendanceDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_Status",
                table: "EmployeeAttendances",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_WorkShiftId",
                table: "EmployeeAttendances",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_ContractNumber",
                table: "EmployeeContracts",
                column: "ContractNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_HREmployeeId",
                table: "EmployeeContracts",
                column: "HREmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_IsActive",
                table: "EmployeeContracts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContracts_StartDate",
                table: "EmployeeContracts",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_DepartmentId",
                table: "HREmployees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_EmployeeNumber",
                table: "HREmployees",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_FamilyMemberId",
                table: "HREmployees",
                column: "FamilyMemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_FarmId",
                table: "HREmployees",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_Status",
                table: "HREmployees",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_HREmployees_UserId",
                table: "HREmployees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_AssignedFieldId",
                table: "JobAssignments",
                column: "AssignedFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_HREmployeeId",
                table: "JobAssignments",
                column: "HREmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_HREmployeeId1",
                table: "JobAssignments",
                column: "HREmployeeId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_JobPositionId",
                table: "JobAssignments",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_StartDate",
                table: "JobAssignments",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_Status",
                table: "JobAssignments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_SupervisorId",
                table: "JobAssignments",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_DepartmentId",
                table: "JobPositions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_IsActive",
                table: "JobPositions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_Title",
                table: "JobPositions",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_FromDate",
                table: "LeaveRequests",
                column: "FromDate");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_HREmployeeId",
                table: "LeaveRequests",
                column: "HREmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_Status",
                table: "LeaveRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_ToDate",
                table: "LeaveRequests",
                column: "ToDate");

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_UserId",
                table: "LoginHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_HREmployeeId",
                table: "Payrolls",
                column: "HREmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_HREmployeeId_PeriodStartDate_PeriodEndDate",
                table: "Payrolls",
                columns: new[] { "HREmployeeId", "PeriodStartDate", "PeriodEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_PaymentStatus",
                table: "Payrolls",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_PeriodEndDate",
                table: "Payrolls",
                column: "PeriodEndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_PeriodStartDate",
                table: "Payrolls",
                column: "PeriodStartDate");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_FarmId",
                table: "WorkShifts",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_HREmployeeId",
                table: "WorkShifts",
                column: "HREmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_Name",
                table: "WorkShifts",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendances");

            migrationBuilder.DropTable(
                name: "EmployeeContracts");

            migrationBuilder.DropTable(
                name: "JobAssignments");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "LoginHistories");

            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "JobPositions");

            migrationBuilder.DropTable(
                name: "HREmployees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_FarmFinancialSummaries_FarmId",
                table: "FarmFinancialSummaries");

            migrationBuilder.DropIndex(
                name: "IX_EnvironmentalReadings_SensorId",
                table: "EnvironmentalReadings");

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
                name: "IX_Infestations_DetectionDate",
                table: "Infestations",
                column: "DetectionDate");

            migrationBuilder.CreateIndex(
                name: "IX_Infestations_Status",
                table: "Infestations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_HarvestDate",
                table: "Harvests",
                column: "HarvestDate");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Status",
                table: "Fields",
                column: "Status");

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
                name: "IX_FarmFinancialSummaries_FarmId_Year_Month",
                table: "FarmFinancialSummaries",
                columns: new[] { "FarmId", "Year", "Month" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FarmExpenses_ExpenseDate",
                table: "FarmExpenses",
                column: "ExpenseDate");

            migrationBuilder.CreateIndex(
                name: "IX_FarmExpenses_ExpenseType",
                table: "FarmExpenses",
                column: "ExpenseType");

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
                name: "IX_Devices_LastDataSyncTime",
                table: "Devices",
                column: "LastDataSyncTime");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Status",
                table: "Devices",
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
                name: "IX_CropPlantings_PlantingDate",
                table: "CropPlantings",
                column: "PlantingDate");

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantings_Status",
                table: "CropPlantings",
                column: "Status");
        }
    }
}
