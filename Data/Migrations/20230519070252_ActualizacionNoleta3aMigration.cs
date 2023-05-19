using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIONFIT.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionNoleta3aMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "boleta",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "boleta");
        }
    }
}
