using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class initttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marks_mark_id",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "mark_id",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marks_mark_id",
                table: "Products",
                column: "mark_id",
                principalTable: "Marks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marks_mark_id",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "mark_id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marks_mark_id",
                table: "Products",
                column: "mark_id",
                principalTable: "Marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
