using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "TbSliderCategories",
                columns: table => new
                {
                    CatSliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorySliderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSliderCategories", x => x.CatSliderId);
                });

           

            migrationBuilder.CreateTable(
                name: "TbSlider",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatSliderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSlider", x => x.SliderId);
                    table.ForeignKey(
                        name: "FK_TbSlider_TbSliderCategory",
                        column: x => x.CatSliderId,
                        principalTable: "TbSliderCategories",
                        principalColumn: "CatSliderId",
                        onDelete: ReferentialAction.Restrict);
                });

           

            migrationBuilder.CreateTable(
                name: "TbSliderImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SliderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSliderImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_TbSliderImage_TbSlider",
                        column: x => x.SliderId,
                        principalTable: "TbSlider",
                        principalColumn: "SliderId",
                        onDelete: ReferentialAction.Restrict);
                });

            

           

            migrationBuilder.CreateIndex(
                name: "IX_TbSlider_CatSliderId",
                table: "TbSlider",
                column: "CatSliderId");

            migrationBuilder.CreateIndex(
                name: "IX_TbSliderImages_SliderId",
                table: "TbSliderImages",
                column: "SliderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TbBusinessInfo");

            migrationBuilder.DropTable(
                name: "TbCashTransacion");

            migrationBuilder.DropTable(
                name: "TbCustomerItems");

            migrationBuilder.DropTable(
                name: "TbItemDiscount");

            migrationBuilder.DropTable(
                name: "TbItemImages");

            migrationBuilder.DropTable(
                name: "TbPurchaseInvoiceItems");

            migrationBuilder.DropTable(
                name: "TbSalesInvoiceItems");

            migrationBuilder.DropTable(
                name: "TbSliderImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TbPurchaseInvoices");

            migrationBuilder.DropTable(
                name: "TbItems");

            migrationBuilder.DropTable(
                name: "TbSalesInvoices");

            migrationBuilder.DropTable(
                name: "TbSlider");

            migrationBuilder.DropTable(
                name: "TbSuppliers");

            migrationBuilder.DropTable(
                name: "TbCategories");

            migrationBuilder.DropTable(
                name: "TbCustomers");

            migrationBuilder.DropTable(
                name: "TbSliderCategories");
        }
    }
}
