using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzz.Migrations
{
    public partial class FBowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_Result_AspNetUsers_OwnerId",
                table: "Number_Result");

            migrationBuilder.DropIndex(
                name: "IX_Number_Result_OwnerId",
                table: "Number_Result");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Number_Result");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Number_Result",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Number_Result");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Number_Result",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Number_Result_OwnerId",
                table: "Number_Result",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Number_Result_AspNetUsers_OwnerId",
                table: "Number_Result",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
