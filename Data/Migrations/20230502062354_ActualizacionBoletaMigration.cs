using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIONFIT.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionBoletaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "precio_total",
                table: "boleta");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "boleta",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "boleta",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "boleta",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "boleta",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_boleta_ProductoId",
                table: "boleta",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_boleta_producto_ProductoId",
                table: "boleta",
                column: "ProductoId",
                principalTable: "producto",
                principalColumn: "id_producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boleta_producto_ProductoId",
                table: "boleta");

            migrationBuilder.DropIndex(
                name: "IX_boleta_ProductoId",
                table: "boleta");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "boleta");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "boleta");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "boleta");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "boleta",
                newName: "fecha");

            migrationBuilder.AddColumn<double>(
                name: "precio_total",
                table: "boleta",
                type: "double precision",
                nullable: true);
        }
    }
}
