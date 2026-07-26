using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "HistoricalEvents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
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
                name: "LastModified",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "FamilyRelations");

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

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "FamilyMembers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeyName",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "FamilyMembers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "KeyName",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "014af7c9-397d-48f4-96f3-b12d80d1a5e4",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3f22bd16-2e0a-4d2e-92d7-4442c27dfaa8",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4814d70b-6202-470b-99ac-778748c743a2",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "64154fed-88e8-4ecf-9404-abd1a1692228",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "69beb3c5-44e5-411c-95e2-acdae6ed6804",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6c6bb70b-c45c-4a88-967a-b2e7584a2999",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6e6f59f5-7f5a-496d-9dd9-e8582c86f30b",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6ed08184-788e-4530-848f-ec53882140f5",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "92ea6071-2279-42a1-899e-ea287086be66",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a8fe7c3e-4fa7-4396-a74c-a179dfac9444",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f68a4c51-fb49-493b-96c4-7c9f1c298235",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "10d0bb42-d9c6-4c28-be58-e64e50a2a911",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "23297e2b-78f1-42ad-97d3-ef1a1ff6b943",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "40172842-82bb-4e4e-8403-b7bb5c91ecd4",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "506424e6-db25-48d9-9841-d4454dbb97ef",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "52edc712-0f51-48bd-ab9d-17dd2bafa639",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "7cd4de3d-6294-4e13-b9c5-fbad7a9ea174",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "87655c00-f770-4af5-88ee-cdac045b97bd",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "8f817c44-2b9f-4e75-8999-957b3c3e5d8f",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "a14ec1c2-6563-4ec8-a022-7318ebd236f0",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "ba609a13-4f83-4075-a78d-55c18e730190",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "dad4eb62-9681-4011-9d36-4ac199f0c239",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "e2b21928-c91c-4534-917b-41971c52bb51",
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null });
        }
    }
}
