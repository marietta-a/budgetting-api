using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budgetting.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_size_to_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "TEXT",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromotionCode",
                table: "Products",
                type: "TEXT",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "TEXT",
                maxLength: 5,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PromotionCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");
        }
    }
}
