using Microsoft.EntityFrameworkCore.Migrations;

namespace APP.DB.Migrations
{
    public partial class AddVideoProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    PlaylistId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoProduct",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    VideoId = table.Column<long>(nullable: false),
                    ProductId1 = table.Column<long>(nullable: true),
                    VideoId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoProduct", x => new { x.ProductId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_VideoProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoProduct_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoProduct_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoProduct_Video_VideoId1",
                        column: x => x.VideoId1,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoProduct_ProductId1",
                table: "VideoProduct",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_VideoProduct_VideoId",
                table: "VideoProduct",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoProduct_VideoId1",
                table: "VideoProduct",
                column: "VideoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoProduct");

            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
