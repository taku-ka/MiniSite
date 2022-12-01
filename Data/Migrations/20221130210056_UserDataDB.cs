using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserDataDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDataModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDataModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDataModel");
        }
    }
}
