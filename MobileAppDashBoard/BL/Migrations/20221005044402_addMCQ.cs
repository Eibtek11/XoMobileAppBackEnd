using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addMCQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbQuestionsMcqAnswerss",
                columns: table => new
                {
                    QuestionsMcqAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionsMcqAnswerSytntax = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbQuestionsMcqAnswerss", x => x.QuestionsMcqAnswerId);
                    table.ForeignKey(
                        name: "FK_TbQuestionsMcqAnswers_TbQuestionsMCQ",
                        column: x => x.QuestionId,
                        principalTable: "TbQuestionsMCQS",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbQuestionsMcqAnswerss_QuestionId",
                table: "TbQuestionsMcqAnswerss",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbQuestionsMcqAnswerss");
        }
    }
}
