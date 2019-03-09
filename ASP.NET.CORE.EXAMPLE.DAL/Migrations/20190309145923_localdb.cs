using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET.CORE.EXAMPLE.DAL.Migrations
{
    public partial class localdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TABLE.STUDENTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameSurname = table.Column<string>(nullable: true),
                    Sex = table.Column<byte>(nullable: false),
                    ProfileAvatar = table.Column<string>(nullable: true),
                    AddedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE.STUDENTS", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TABLE.STUDENTS");
        }
    }
}
