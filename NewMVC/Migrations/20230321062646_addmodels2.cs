using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewMVC.Migrations
{
    public partial class addmodels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTITY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENTITY_VALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SECTION_GROUP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOC_ID = table.Column<int>(type: "int", nullable: false),
                    GROUP_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item");
        }
    }
}
