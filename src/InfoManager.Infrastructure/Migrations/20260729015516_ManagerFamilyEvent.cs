using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManagerFamilyEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "EventDate",
                table: "HistoricalEvents",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "FamilyEvents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FamilyEvents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "FamilyEvents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "FamilyEvents",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FamilyEventOccurrences",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FamilyEventId = table.Column<string>(type: "text", nullable: false),
                    OccurrenceDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyEventOccurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyEventOccurrences_FamilyEvents_FamilyEventId",
                        column: x => x.FamilyEventId,
                        principalTable: "FamilyEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyEventReminders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FamilyEventId = table.Column<string>(type: "text", nullable: false),
                    DaysBefore = table.Column<int>(type: "integer", nullable: false),
                    RemindTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Channel = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyEventReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyEventReminders_FamilyEvents_FamilyEventId",
                        column: x => x.FamilyEventId,
                        principalTable: "FamilyEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyEventOccurrences_FamilyEventId",
                table: "FamilyEventOccurrences",
                column: "FamilyEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyEventReminders_FamilyEventId",
                table: "FamilyEventReminders",
                column: "FamilyEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyEventOccurrences");

            migrationBuilder.DropTable(
                name: "FamilyEventReminders");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "FamilyEvents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FamilyEvents");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "FamilyEvents");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "FamilyEvents");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EventDate",
                table: "HistoricalEvents",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
