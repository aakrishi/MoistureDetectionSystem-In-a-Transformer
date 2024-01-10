using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebApi.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SilicaGelData",
                table: "SilicaGelDetails");

            migrationBuilder.AddColumn<int>(
                name: "BValue",
                table: "SilicaGelDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GValue",
                table: "SilicaGelDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCritical",
                table: "SilicaGelDetails",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RValue",
                table: "SilicaGelDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BValue",
                table: "SilicaGelDetails");

            migrationBuilder.DropColumn(
                name: "GValue",
                table: "SilicaGelDetails");

            migrationBuilder.DropColumn(
                name: "IsCritical",
                table: "SilicaGelDetails");

            migrationBuilder.DropColumn(
                name: "RValue",
                table: "SilicaGelDetails");

            migrationBuilder.AddColumn<double>(
                name: "SilicaGelData",
                table: "SilicaGelDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
