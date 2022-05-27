using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeInformation.DataAccess.Migrations
{
    public partial class initialcreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyField");

            migrationBuilder.CreateTable(
                name: "CompanyFields",
                columns: table => new
                {
                    CompanyFieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    FieldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFields", x => x.CompanyFieldId);
                    table.ForeignKey(
                        name: "FK_CompanyFields_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFields_CompanyId",
                table: "CompanyFields",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFields_FieldId",
                table: "CompanyFields",
                column: "FieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyFields");

            migrationBuilder.CreateTable(
                name: "CompanyField",
                columns: table => new
                {
                    CompaniesCompanyId = table.Column<int>(type: "int", nullable: false),
                    FieldsFieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyField", x => new { x.CompaniesCompanyId, x.FieldsFieldId });
                    table.ForeignKey(
                        name: "FK_CompanyField_Companies_CompaniesCompanyId",
                        column: x => x.CompaniesCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyField_Fields_FieldsFieldId",
                        column: x => x.FieldsFieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyField_FieldsFieldId",
                table: "CompanyField",
                column: "FieldsFieldId");
        }
    }
}
