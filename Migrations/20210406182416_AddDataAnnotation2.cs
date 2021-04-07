using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzz.Migrations
{
    public partial class AddDataAnnotation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Number_Results",
                table: "Number_Results");

            migrationBuilder.RenameTable(
                name: "Number_Results",
                newName: "Number_Result");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Number_Result",
                table: "Number_Result",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Number_Result",
                table: "Number_Result");

            migrationBuilder.RenameTable(
                name: "Number_Result",
                newName: "Number_Results");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Number_Results",
                table: "Number_Results",
                column: "Id");
        }
    }
}
