using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customer",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customer",
                newName: "EmailAddress");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Customer",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Customer",
                newName: "Email");
        }
    }
}
