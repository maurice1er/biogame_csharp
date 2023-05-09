using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace biochallenge.Migrations
{
    /// <inheritdoc />
    public partial class migration002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "6201fbe6-471f-40b1-b224-67bd4bf5a13d");

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "f04c0f9f-d5b2-4fbf-b728-52e1c096d45b");

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Score" },
                values: new object[,]
                {
                    { "75cc7325-20c1-4c0e-a8ab-15f0f36eb288", 1.0 },
                    { "83a815e1-452f-4fb3-9123-3618d6c965da", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "ChallengeId", "Duration", "Hint", "Quiz" },
                values: new object[] { "8eac2a6d-77a7-410f-8d5a-d650ea85a5db", null, 10, "", "Quiz 1" });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "AcceptedAt", "ChallengedId", "ChallengerId", "EndAt", "IsFinished", "IsStarted", "LaunchedAt", "WinnerId" },
                values: new object[] { "5310272a-3104-4adc-a245-09127a240f62", null, "83a815e1-452f-4fb3-9123-3618d6c965da", "75cc7325-20c1-4c0e-a8ab-15f0f36eb288", null, false, false, null, null });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Answer", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { "2fa0719b-2337-4dce-833d-bc83ee1384d1", "Answer 3", true, "8eac2a6d-77a7-410f-8d5a-d650ea85a5db" },
                    { "930c76c9-c411-49aa-90e0-ba0e81fb978b", "Answer 1", false, "8eac2a6d-77a7-410f-8d5a-d650ea85a5db" },
                    { "c1eeddd5-c8d8-415e-9a5b-f16fdcbe8522", "Answer 2", false, "8eac2a6d-77a7-410f-8d5a-d650ea85a5db" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: "5310272a-3104-4adc-a245-09127a240f62");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "2fa0719b-2337-4dce-833d-bc83ee1384d1");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "930c76c9-c411-49aa-90e0-ba0e81fb978b");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "c1eeddd5-c8d8-415e-9a5b-f16fdcbe8522");

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "75cc7325-20c1-4c0e-a8ab-15f0f36eb288");

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "83a815e1-452f-4fb3-9123-3618d6c965da");

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: "8eac2a6d-77a7-410f-8d5a-d650ea85a5db");

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Score" },
                values: new object[,]
                {
                    { "6201fbe6-471f-40b1-b224-67bd4bf5a13d", 1.0 },
                    { "f04c0f9f-d5b2-4fbf-b728-52e1c096d45b", 2.0 }
                });
        }
    }
}
