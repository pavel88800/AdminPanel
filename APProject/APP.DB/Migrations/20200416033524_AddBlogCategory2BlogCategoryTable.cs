using Microsoft.EntityFrameworkCore.Migrations;

namespace APP.DB.Migrations
{
    public partial class AddBlogCategory2BlogCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategory_BlogCategory_BlogCategoriesId",
                table: "BlogCategory");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategory_BlogCategoriesId",
                table: "BlogCategory");

            migrationBuilder.DropColumn(
                name: "BlogCategoriesId",
                table: "BlogCategory");

            migrationBuilder.CreateTable(
                name: "BlogCategory2BlogCategories",
                columns: table => new
                {
                    BlogCategory1Id = table.Column<long>(nullable: false),
                    BlogCategory2Id = table.Column<long>(nullable: false),
                    BlogCategoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory2BlogCategories", x => new { x.BlogCategory1Id, x.BlogCategory2Id });
                    table.ForeignKey(
                        name: "FK_BlogCategory2BlogCategories_BlogCategory_BlogCategory1Id",
                        column: x => x.BlogCategory1Id,
                        principalTable: "BlogCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogCategory2BlogCategories_BlogCategory_BlogCategory2Id",
                        column: x => x.BlogCategory2Id,
                        principalTable: "BlogCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogCategory2BlogCategories_BlogCategory_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategory2BlogCategories_BlogCategory2Id",
                table: "BlogCategory2BlogCategories",
                column: "BlogCategory2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategory2BlogCategories_BlogCategoryId",
                table: "BlogCategory2BlogCategories",
                column: "BlogCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCategory2BlogCategories");

            migrationBuilder.AddColumn<long>(
                name: "BlogCategoriesId",
                table: "BlogCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategory_BlogCategoriesId",
                table: "BlogCategory",
                column: "BlogCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategory_BlogCategory_BlogCategoriesId",
                table: "BlogCategory",
                column: "BlogCategoriesId",
                principalTable: "BlogCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
