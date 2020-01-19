using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutTracker.Data.Migrations
{
    public partial class DeleteCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassTypes_Categories_CategoryID",
                table: "ClassTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Categories_CategoryID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Categories_CategoryID",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CategoryID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CategoryID",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_ClassTypes_CategoryID",
                table: "ClassTypes");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "ClassTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "ClassTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CategoryID",
                table: "Locations",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CategoryID",
                table: "Instructors",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTypes_CategoryID",
                table: "ClassTypes",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTypes_Categories_CategoryID",
                table: "ClassTypes",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Categories_CategoryID",
                table: "Instructors",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Categories_CategoryID",
                table: "Locations",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
