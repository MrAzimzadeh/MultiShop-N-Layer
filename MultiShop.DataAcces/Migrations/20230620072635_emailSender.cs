using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class emailSender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserToken",
                table: "Users");
        }
    }
}
