using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewMVC.Migrations
{
    public partial class add314 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    CastId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.CastId);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    ShowId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.ShowId);
                });

            migrationBuilder.CreateTable(
                name: "CastShow",
                columns: table => new
                {
                    CastsCastId = table.Column<long>(type: "bigint", nullable: false),
                    ShowId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastShow", x => new { x.CastsCastId, x.ShowId });
                    table.ForeignKey(
                        name: "FK_CastShow_Cast_CastsCastId",
                        column: x => x.CastsCastId,
                        principalTable: "Cast",
                        principalColumn: "CastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastShow_Show_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Show",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastShow_ShowId",
                table: "CastShow",
                column: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastShow");

            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Show");
        }
    }
}
