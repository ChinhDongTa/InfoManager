using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSocialAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialAccount_UserProfiles_UserId",
                table: "SocialAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialAccount",
                table: "SocialAccount");

            migrationBuilder.DropIndex(
                name: "IX_SocialAccount_UserId",
                table: "SocialAccount");

            migrationBuilder.RenameTable(
                name: "SocialAccount",
                newName: "SocialAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderAccountId",
                table: "SocialAccounts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Provider",
                table: "SocialAccounts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "HomepageUrl",
                table: "SocialAccounts",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "SocialAccounts",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "SocialAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialAccounts",
                table: "SocialAccounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SocialAccounts_Provider_ProviderAccountId",
                table: "SocialAccounts",
                columns: new[] { "Provider", "ProviderAccountId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialAccounts_UserId_Provider",
                table: "SocialAccounts",
                columns: new[] { "UserId", "Provider" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialAccounts_AspNetUsers_UserId",
                table: "SocialAccounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialAccounts_AspNetUsers_UserId",
                table: "SocialAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialAccounts",
                table: "SocialAccounts");

            migrationBuilder.DropIndex(
                name: "IX_SocialAccounts_Provider_ProviderAccountId",
                table: "SocialAccounts");

            migrationBuilder.DropIndex(
                name: "IX_SocialAccounts_UserId_Provider",
                table: "SocialAccounts");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "SocialAccounts");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "SocialAccounts");

            migrationBuilder.RenameTable(
                name: "SocialAccounts",
                newName: "SocialAccount");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderAccountId",
                table: "SocialAccount",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Provider",
                table: "SocialAccount",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "HomepageUrl",
                table: "SocialAccount",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialAccount",
                table: "SocialAccount",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SocialAccount_UserId",
                table: "SocialAccount",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialAccount_UserProfiles_UserId",
                table: "SocialAccount",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}