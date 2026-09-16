using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSocialAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramId",
                table: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "UserProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SocialAccount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProviderAccountId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    HomepageUrl = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialAccount_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialAccount_UserId",
                table: "SocialAccount",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialAccount");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "UserProfiles");

            migrationBuilder.AddColumn<long>(
                name: "TelegramId",
                table: "UserProfiles",
                type: "bigint",
                nullable: true);
        }
    }
}