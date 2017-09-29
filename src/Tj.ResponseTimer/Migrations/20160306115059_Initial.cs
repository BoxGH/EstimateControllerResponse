using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Tj.ResponseTimer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PagePath = table.Column<string>(nullable: true),
                    PagePath2 = table.Column<string>(nullable: true),
                    PagePath3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForTable", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "RequestResponseTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndRequest = table.Column<long>(nullable: false),
                    MeasureTime = table.Column<long>(nullable: false),
                    PagePath = table.Column<string>(nullable: true),
                    ServerIn = table.Column<long>(nullable: false),
                    ServerOut = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestResponseTime", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "SomeDataClassForView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldNamber = table.Column<int>(nullable: false),
                    FieldString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeDataClassForView", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ForTable");
            migrationBuilder.DropTable("RequestResponseTime");
            migrationBuilder.DropTable("SomeDataClassForView");
        }
    }
}
