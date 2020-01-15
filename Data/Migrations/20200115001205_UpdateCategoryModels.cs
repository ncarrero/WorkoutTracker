using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutTracker.Data.Migrations
{
    public partial class UpdateCategoryModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Instructors",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "ClassTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Locations_CategoryID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CategoryID",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_ClassTypes_CategoryID",
                table: "ClassTypes");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Instructors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "ClassTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
