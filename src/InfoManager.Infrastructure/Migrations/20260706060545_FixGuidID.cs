using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixGuidID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "001adee0-fc3f-45e0-a850-f7f29f8da883");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "527cebed-6859-40e9-8145-2bbcc73c4ca2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "58c255a7-f029-4bcb-ad92-158c35024675");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6885d0f8-7c9b-4c7e-a7d8-86506f73b200");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "747e2a30-1dbe-4e70-bd4a-e31291730344");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ae72d6fb-3348-493e-9733-a574414ac372");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "af486dcc-ed6c-41b4-b894-6b6fb66d9fb9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "b21237c5-1b9b-4e40-af78-1ea5fc9c0084");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "bb9fe4c6-d5b0-40a4-a091-f275ad0ed894");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ee7b35f4-206a-4411-a060-0abb3f7df65c");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "fbcb55c0-ef43-498d-9ae4-91b118aeff6c");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "14f51e85-0f67-4735-8144-391fdd6bb057");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "26e2b973-18b9-43be-a654-9dd34a65dab6");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "48942491-512a-4f1d-a46b-d1bedcfc8715");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "57011bd0-b13b-4439-96a6-b05bbf69ecac");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "6a84c2a3-8c25-41e8-88ba-ee71644ce381");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "7929779a-4036-4943-936d-45ef9405b2a1");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "84c3d511-a1d9-40e3-91b4-57ff33da58da");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "9e39d9a1-07ce-4389-9333-eddc56c17b2b");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "9ea116e7-445d-4b81-aef3-e10c6c120dd0");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "9fd253e5-1493-4e2d-ac5a-0f63a5d67610");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "ab3ca290-b462-479c-848d-783e73403714");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "f24bfa76-dbf7-4156-9815-17a5699b47c2");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "CreatedBy", "Group", "KeyName", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { "014af7c9-397d-48f4-96f3-b12d80d1a5e4", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Lương" },
                    { "3f22bd16-2e0a-4d2e-92d7-4442c27dfaa8", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Hiếu hỉ" },
                    { "4814d70b-6202-470b-99ac-778748c743a2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Đầu tư" },
                    { "64154fed-88e8-4ecf-9404-abd1a1692228", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Công nghệ thông tin" },
                    { "69beb3c5-44e5-411c-95e2-acdae6ed6804", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mua sắm" },
                    { "6c6bb70b-c45c-4a88-967a-b2e7584a2999", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Chi tiêu hàng ngày" },
                    { "6e6f59f5-7f5a-496d-9dd9-e8582c86f30b", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bán hàng" },
                    { "6ed08184-788e-4530-848f-ec53882140f5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Giải trí" },
                    { "92ea6071-2279-42a1-899e-ea287086be66", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Nông nghiệp" },
                    { "a8fe7c3e-4fa7-4396-a74c-a179dfac9444", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Sức khỏe" },
                    { "f68a4c51-fb49-493b-96c4-7c9f1c298235", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Học tập" }
                });

            migrationBuilder.InsertData(
                table: "FamilyRelations",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { "10d0bb42-d9c6-4c28-be58-e64e50a2a911", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông cố nội" },
                    { "23297e2b-78f1-42ad-97d3-ef1a1ff6b943", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Cha" },
                    { "40172842-82bb-4e4e-8403-b7bb5c91ecd4", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà ngoại" },
                    { "506424e6-db25-48d9-9841-d4454dbb97ef", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Con gái" },
                    { "52edc712-0f51-48bd-ab9d-17dd2bafa639", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông nội" },
                    { "7cd4de3d-6294-4e13-b9c5-fbad7a9ea174", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông ngoại" },
                    { "87655c00-f770-4af5-88ee-cdac045b97bd", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà nội" },
                    { "8f817c44-2b9f-4e75-8999-957b3c3e5d8f", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà cố nội" },
                    { "a14ec1c2-6563-4ec8-a022-7318ebd236f0", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Con trai" },
                    { "ba609a13-4f83-4075-a78d-55c18e730190", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà cố ngoại" },
                    { "dad4eb62-9681-4011-9d36-4ac199f0c239", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mẹ" },
                    { "e2b21928-c91c-4534-917b-41971c52bb51", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông cố ngoại" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "014af7c9-397d-48f4-96f3-b12d80d1a5e4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3f22bd16-2e0a-4d2e-92d7-4442c27dfaa8");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4814d70b-6202-470b-99ac-778748c743a2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "64154fed-88e8-4ecf-9404-abd1a1692228");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "69beb3c5-44e5-411c-95e2-acdae6ed6804");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6c6bb70b-c45c-4a88-967a-b2e7584a2999");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6e6f59f5-7f5a-496d-9dd9-e8582c86f30b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6ed08184-788e-4530-848f-ec53882140f5");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "92ea6071-2279-42a1-899e-ea287086be66");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a8fe7c3e-4fa7-4396-a74c-a179dfac9444");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f68a4c51-fb49-493b-96c4-7c9f1c298235");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "10d0bb42-d9c6-4c28-be58-e64e50a2a911");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "23297e2b-78f1-42ad-97d3-ef1a1ff6b943");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "40172842-82bb-4e4e-8403-b7bb5c91ecd4");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "506424e6-db25-48d9-9841-d4454dbb97ef");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "52edc712-0f51-48bd-ab9d-17dd2bafa639");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "7cd4de3d-6294-4e13-b9c5-fbad7a9ea174");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "87655c00-f770-4af5-88ee-cdac045b97bd");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "8f817c44-2b9f-4e75-8999-957b3c3e5d8f");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "a14ec1c2-6563-4ec8-a022-7318ebd236f0");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "ba609a13-4f83-4075-a78d-55c18e730190");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "dad4eb62-9681-4011-9d36-4ac199f0c239");

            migrationBuilder.DeleteData(
                table: "FamilyRelations",
                keyColumn: "Id",
                keyValue: "e2b21928-c91c-4534-917b-41971c52bb51");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "CreatedBy", "Group", "KeyName", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { "001adee0-fc3f-45e0-a850-f7f29f8da883", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Giải trí" },
                    { "527cebed-6859-40e9-8145-2bbcc73c4ca2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Công nghệ thông tin" },
                    { "58c255a7-f029-4bcb-ad92-158c35024675", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Chi tiêu hàng ngày" },
                    { "6885d0f8-7c9b-4c7e-a7d8-86506f73b200", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Hiếu hỉ" },
                    { "747e2a30-1dbe-4e70-bd4a-e31291730344", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Học tập" },
                    { "ae72d6fb-3348-493e-9733-a574414ac372", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Lương" },
                    { "af486dcc-ed6c-41b4-b894-6b6fb66d9fb9", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bán hàng" },
                    { "b21237c5-1b9b-4e40-af78-1ea5fc9c0084", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Đầu tư" },
                    { "bb9fe4c6-d5b0-40a4-a091-f275ad0ed894", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Sức khỏe" },
                    { "ee7b35f4-206a-4411-a060-0abb3f7df65c", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mua sắm" },
                    { "fbcb55c0-ef43-498d-9ae4-91b118aeff6c", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Nông nghiệp" }
                });

            migrationBuilder.InsertData(
                table: "FamilyRelations",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { "14f51e85-0f67-4735-8144-391fdd6bb057", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông cố nội" },
                    { "26e2b973-18b9-43be-a654-9dd34a65dab6", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Con trai" },
                    { "48942491-512a-4f1d-a46b-d1bedcfc8715", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Con gái" },
                    { "57011bd0-b13b-4439-96a6-b05bbf69ecac", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Mẹ" },
                    { "6a84c2a3-8c25-41e8-88ba-ee71644ce381", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà cố nội" },
                    { "7929779a-4036-4943-936d-45ef9405b2a1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông cố ngoại" },
                    { "84c3d511-a1d9-40e3-91b4-57ff33da58da", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông nội" },
                    { "9e39d9a1-07ce-4389-9333-eddc56c17b2b", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà ngoại" },
                    { "9ea116e7-445d-4b81-aef3-e10c6c120dd0", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà nội" },
                    { "9fd253e5-1493-4e2d-ac5a-0f63a5d67610", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bà cố ngoại" },
                    { "ab3ca290-b462-479c-848d-783e73403714", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Cha" },
                    { "f24bfa76-dbf7-4156-9815-17a5699b47c2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Ông ngoại" }
                });
        }
    }
}
