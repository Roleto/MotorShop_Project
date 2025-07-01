using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorShop_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class Order_Add_HasExtrasCouloum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasExtras",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasExtras",
                table: "Orders");
        }
    }
}
