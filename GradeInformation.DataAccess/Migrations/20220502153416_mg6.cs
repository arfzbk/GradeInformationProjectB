using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeInformation.DataAccess.Migrations
{
    public partial class mg6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCompanies_Fields_FieldId",
                table: "StudentCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "StudentCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCompanies_Fields_FieldId",
                table: "StudentCompanies",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCompanies_Fields_FieldId",
                table: "StudentCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "StudentCompanies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCompanies_Fields_FieldId",
                table: "StudentCompanies",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
