using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biochallenge.Migrations
{
    /// <inheritdoc />
    public partial class migration009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChallengeId",
                table: "Questions",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    IsStarted = table.Column<bool>(type: "bit", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    ChallengedId = table.Column<string>(type: "char(36)", nullable: false),
                    ChallengerId = table.Column<string>(type: "char(36)", nullable: false),
                    WinnerId = table.Column<string>(type: "char(36)", nullable: true),
                    LaunchedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcceptedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_Participants_ChallengedId",
                        column: x => x.ChallengedId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Challenges_Participants_ChallengerId",
                        column: x => x.ChallengerId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Challenges_Participants_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ChallengeId",
                table: "Questions",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ChallengedId",
                table: "Challenges",
                column: "ChallengedId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ChallengerId",
                table: "Challenges",
                column: "ChallengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_WinnerId",
                table: "Challenges",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Challenges_ChallengeId",
                table: "Questions",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Challenges_ChallengeId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ChallengeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "Questions");
        }
    }
}
