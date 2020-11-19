using Microsoft.EntityFrameworkCore.Migrations;

namespace TemperatureAPI.Migrations
{
    public partial class AddedRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Location_LocationId",
                table: "Measurements");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Location_LocationId",
                table: "Measurements",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Location_LocationId",
                table: "Measurements");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Measurements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Location_LocationId",
                table: "Measurements",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
