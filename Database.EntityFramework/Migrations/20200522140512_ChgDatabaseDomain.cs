using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.EntityFramework.Migrations
{
    public partial class ChgDatabaseDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payloads_Maps_MapId",
                schema: "Domain",
                table: "Payloads");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                schema: "Domain",
                table: "Payloads",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                schema: "Domain",
                table: "Payloads",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                schema: "Domain",
                table: "Nodes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Domain",
                table: "Maps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                schema: "Domain",
                table: "Maps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                schema: "Domain",
                table: "Maps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Payloads_Maps_MapId",
                schema: "Domain",
                table: "Payloads",
                column: "MapId",
                principalSchema: "Domain",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payloads_Maps_MapId",
                schema: "Domain",
                table: "Payloads");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                schema: "Domain",
                table: "Payloads");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                schema: "Domain",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Domain",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                schema: "Domain",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                schema: "Domain",
                table: "Maps");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                schema: "Domain",
                table: "Payloads",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payloads_Maps_MapId",
                schema: "Domain",
                table: "Payloads",
                column: "MapId",
                principalSchema: "Domain",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
