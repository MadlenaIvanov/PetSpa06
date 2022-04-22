using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetSpa.Infrastructure.Data.Migrations
{
    public partial class PetType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetTypeId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PetTypeId",
                table: "Reviews",
                column: "PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_PetTypes_PetTypeId",
                table: "Reviews",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_PetTypes_PetTypeId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "PetTypes");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PetTypeId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PetTypeId",
                table: "Reviews");
        }
    }
}
