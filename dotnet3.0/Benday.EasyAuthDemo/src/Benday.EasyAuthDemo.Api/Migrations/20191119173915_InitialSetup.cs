using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Benday.EasyAuthDemo.Api.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
DisplayOrder = table.Column<int>(nullable: false),
LookupType = table.Column<string>(maxLength: 50, nullable: false),
LookupKey = table.Column<string>(maxLength: 50, nullable: false),
LookupValue = table.Column<string>(maxLength: 50, nullable: false),
Status = table.Column<string>(nullable: false),
CreatedBy = table.Column<string>(nullable: false),
CreatedDate = table.Column<DateTime>(nullable: false),
LastModifiedBy = table.Column<string>(nullable: false),
LastModifiedDate = table.Column<DateTime>(nullable: false),
Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
FirstName = table.Column<string>(maxLength: 50, nullable: false),
LastName = table.Column<string>(maxLength: 50, nullable: false),
PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
Status = table.Column<string>(nullable: false),
CreatedBy = table.Column<string>(nullable: false),
CreatedDate = table.Column<DateTime>(nullable: false),
LastModifiedBy = table.Column<string>(nullable: false),
LastModifiedDate = table.Column<DateTime>(nullable: false),
Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
},
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
