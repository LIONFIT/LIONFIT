using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIONFIT.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionNoleta9aMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "producto",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "producto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "producto",
                newName: "Estado");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "producto",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
