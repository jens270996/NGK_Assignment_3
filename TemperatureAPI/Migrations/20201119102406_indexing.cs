using Microsoft.EntityFrameworkCore.Migrations;

namespace TemperatureAPI.Migrations
{
    public partial class indexing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Location_LocationId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_LocationId",
                table: "Measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Measurements",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_LocationName",
                table: "Measurements",
                column: "LocationName");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_Time",
                table: "Measurements",
                column: "Time");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Locations_LocationName",
                table: "Measurements",
                column: "LocationName",
                principalTable: "Locations",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Locations_LocationName",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_LocationName",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_Time",
                table: "Measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Measurements");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Measurements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_LocationId",
                table: "Measurements",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Location_LocationId",
                table: "Measurements",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
