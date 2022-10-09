using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addQuestionMCQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuestionMCQQuestionId",
                table: "TbUserQestionAnswers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbLaw",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.CreateTable(
                name: "TbQuestionsMCQS",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QestionSyntax = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbQuestionsMCQS", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_TbQuestionsMCQS_TbLevels",
                        column: x => x.LevelId,
                        principalTable: "TbLevels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbUserQestionAnswers_QuestionMCQQuestionId",
                table: "TbUserQestionAnswers",
                column: "QuestionMCQQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TbQuestionsMCQS_LevelId",
                table: "TbQuestionsMCQS",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserQestionAnswers_TbQuestionsMCQS_QuestionMCQQuestionId",
                table: "TbUserQestionAnswers",
                column: "QuestionMCQQuestionId",
                principalTable: "TbQuestionsMCQS",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbUserQestionAnswers_TbQuestionsMCQS_QuestionMCQQuestionId",
                table: "TbUserQestionAnswers");

            migrationBuilder.DropTable(
                name: "TbQuestionsMCQS");

            migrationBuilder.DropIndex(
                name: "IX_TbUserQestionAnswers_QuestionMCQQuestionId",
                table: "TbUserQestionAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionMCQQuestionId",
                table: "TbUserQestionAnswers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbLaw",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
