using Microsoft.EntityFrameworkCore.Migrations;

namespace ListIT.Data.Migrations
{
    public partial class AddedPerksAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Perks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacePerks",
                columns: table => new
                {
                    PlaceId = table.Column<string>(nullable: false),
                    PerkId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacePerks", x => new { x.PlaceId, x.PerkId });
                    table.ForeignKey(
                        name: "FK_PlacePerks_Perks_PerkId",
                        column: x => x.PerkId,
                        principalTable: "Perks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacePerks_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacePerks_PerkId",
                table: "PlacePerks",
                column: "PerkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacePerks");

            migrationBuilder.DropTable(
                name: "Perks");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Places");
        }
    }
}
