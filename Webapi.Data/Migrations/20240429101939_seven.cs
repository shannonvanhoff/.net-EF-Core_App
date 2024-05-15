using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class seven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HelperId",
                table: "HTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "helpers",
                columns: table => new
                {
                    HelperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_helpers", x => x.HelperId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HTasks_HelperId",
                table: "HTasks",
                column: "HelperId");

            migrationBuilder.AddForeignKey(
                name: "FK_HTasks_helpers_HelperId",
                table: "HTasks",
                column: "HelperId",
                principalTable: "helpers",
                principalColumn: "HelperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HTasks_helpers_HelperId",
                table: "HTasks");

            migrationBuilder.DropTable(
                name: "helpers");

            migrationBuilder.DropIndex(
                name: "IX_HTasks_HelperId",
                table: "HTasks");

            migrationBuilder.DropColumn(
                name: "HelperId",
                table: "HTasks");
        }
    }
}
