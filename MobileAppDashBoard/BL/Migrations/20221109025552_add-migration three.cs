using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BL.Migrations
{
    public partial class addmigrationthree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "TbClaimLeveOness",
              columns: table => new
              {
                  ClaimLeveOneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  ClaimId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 200, nullable: true),
                  ClaimLeveOneSyntax = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                  ClaimLevelOneDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                  CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                  CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                  UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                  CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                  UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                  ClainLeveOneImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                  ClaimLeveOnePdf = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                  Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_TbClaimLeveOness", x => x.ClaimLeveOneId);
                  table.ForeignKey(
                      name: "FK_TbClaimLeveOness_TbClaims",
                      column: x => x.ClaimId,
                      principalTable: "TbClaims",
                      principalColumn: "ClaimId",
                      onDelete: ReferentialAction.Cascade);
              });

            migrationBuilder.CreateTable(
                name: "TbClaimLevelTwoss",
                columns: table => new
                {
                    ClaimLevelTwoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimLeveOneId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 200, nullable: true),
                    ClaimLevelTwoSyntax = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaimLevelTwoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClainLevelTwoImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClaimLevelTwoPdf = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbClaimLevelTwoss", x => x.ClaimLevelTwoId);
                    table.ForeignKey(
                        name: "FK_TbClaimLevelTwoss_TbClaimLeveOness",
                        column: x => x.ClaimLeveOneId,
                        principalTable: "TbClaimLeveOness",
                        principalColumn: "ClaimLeveOneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbClaimLevelTwoss_ClaimLeveOneId",
                table: "TbClaimLevelTwoss",
                column: "ClaimLeveOneId");

            migrationBuilder.CreateIndex(
                name: "IX_TbClaimLeveOness_ClaimId",
                table: "TbClaimLeveOness",
                column: "ClaimId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "TbClaimLevelTwoss");

            migrationBuilder.DropTable(
                name: "TbClaimLeveOness");

        }
    }
}
