using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InforceTestTask.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNameOfShortUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortUrlViews",
                table: "ShortUrlViews");

            migrationBuilder.RenameTable(
                name: "ShortUrlViews",
                newName: "ShortUrl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortUrl",
                table: "ShortUrl",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortUrl",
                table: "ShortUrl");

            migrationBuilder.RenameTable(
                name: "ShortUrl",
                newName: "ShortUrlViews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortUrlViews",
                table: "ShortUrlViews",
                column: "Id");
        }
    }
}
