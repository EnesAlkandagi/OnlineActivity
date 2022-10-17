using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_approved",
                table: "activity");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "participant_count",
                table: "activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ActivityPaidStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_created_by",
                table: "activity",
                column: "created_by");

            migrationBuilder.AddForeignKey(
                name: "FK_activity_user_created_by",
                table: "activity",
                column: "created_by",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activity_user_created_by",
                table: "activity");

            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropIndex(
                name: "IX_activity_created_by",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "participant_count",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "status",
                table: "activity");

            migrationBuilder.AddColumn<bool>(
                name: "is_approved",
                table: "activity",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
