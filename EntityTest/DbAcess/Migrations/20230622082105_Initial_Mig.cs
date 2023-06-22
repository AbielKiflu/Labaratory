using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAcess.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "street",
                table: "Addresses",
                newName: "Street");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "street");
        }
    }
}
