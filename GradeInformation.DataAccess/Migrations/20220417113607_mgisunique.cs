using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeInformation.DataAccess.Migrations
{
    public partial class mgisunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Tc",
                table: "Students",
                column: "Tc",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Tc",
                table: "Students");
        }
    }
}
