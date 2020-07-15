using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.EntityFramework.Migrations
{
    public partial class ChgEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Domain");

            migrationBuilder.CreateTable(
                name: "Nodes",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    NodeId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maps_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalSchema: "Domain",
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maps_Maps_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Domain",
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payloads",
                schema: "Domain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    MapId = table.Column<int>(nullable: false),
                    NodeId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payloads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payloads_Maps_MapId",
                        column: x => x.MapId,
                        principalSchema: "Domain",
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payloads_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalSchema: "Domain",
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_NodeId",
                schema: "Domain",
                table: "Maps",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_ParentId",
                schema: "Domain",
                table: "Maps",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payloads_MapId",
                schema: "Domain",
                table: "Payloads",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Payloads_NodeId",
                schema: "Domain",
                table: "Payloads",
                column: "NodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payloads",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Maps",
                schema: "Domain");

            migrationBuilder.DropTable(
                name: "Nodes",
                schema: "Domain");
        }
    }
}
