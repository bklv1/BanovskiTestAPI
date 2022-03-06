using Microsoft.EntityFrameworkCore.Migrations;

namespace BanovskiTestAPI.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerClub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teamInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teamInfo_playerInfo_PlayerInfoId",
                        column: x => x.PlayerInfoId,
                        principalTable: "playerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teamInfo_PlayerInfoId",
                table: "teamInfo",
                column: "PlayerInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teamInfo");

            migrationBuilder.DropTable(
                name: "playerInfo");
        }
    }
}
