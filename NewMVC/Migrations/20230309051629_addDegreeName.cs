using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewMVC.Migrations
{
    public partial class addDegreeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DegreeName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeName1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeName", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeName");
        }
    }
}
