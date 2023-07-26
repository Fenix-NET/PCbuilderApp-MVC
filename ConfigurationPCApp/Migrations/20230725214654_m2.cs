using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigurationPCApp.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Memory",
                table: "RAMs");

            migrationBuilder.AddColumn<string>(
                name: "DDR",
                table: "MotherBoards",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
