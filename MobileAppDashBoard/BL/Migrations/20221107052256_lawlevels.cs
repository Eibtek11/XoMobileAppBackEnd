using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class lawlevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.CreateTable(
                name: "TbLawLevelOne",
                columns: table => new
                {
                    LawLevelOneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LawId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LawLevelOneName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LawLevelOneDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LawLevelOnePdf = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLawLevelOne", x => x.LawLevelOneId);
                    table.ForeignKey(
                        name: "FK_TbLawLevelOne_TbLaw",
                        column: x => x.LawId,
                        principalTable: "TbLaw",
                        principalColumn: "LawId",
                        onDelete: ReferentialAction.Cascade);
                });

          

           

            migrationBuilder.CreateTable(
                name: "TbLawLevelTwo",
                columns: table => new
                {
                    LawLevelTwoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LawLevelOneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LawLevelTwoName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LawLevelTwoDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LawLevelTwoPdf = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLawLevelTwo", x => x.LawLevelTwoId);
                    table.ForeignKey(
                        name: "FK_TbLawLevelTwo_TbLawLevelOne",
                        column: x => x.LawLevelOneId,
                        principalTable: "TbLawLevelOne",
                        principalColumn: "LawLevelOneId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_TbLawLevelOne_LawId",
                table: "TbLawLevelOne",
                column: "LawId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLawLevelTwo_LawLevelOneId",
                table: "TbLawLevelTwo",
                column: "LawLevelOneId");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "TbLawLevelTwo");

          

            migrationBuilder.DropTable(
                name: "TbLawLevelOne");
        }
    }
}
