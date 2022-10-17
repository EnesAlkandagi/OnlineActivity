using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActivities",
                table: "UserActivities");

            migrationBuilder.DropColumn(
                name: "ActivityPaidStatus",
                table: "UserActivities");

            migrationBuilder.RenameTable(
                name: "UserActivities",
                newName: "user_activity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_activity",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_activity",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "user_activity",
                newName: "activity_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_activity",
                table: "user_activity",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_activity_id",
                table: "user_activity",
                column: "activity_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_activity_activity_activity_id",
                table: "user_activity",
                column: "activity_id",
                principalTable: "activity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_activity_activity_activity_id",
                table: "user_activity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_activity",
                table: "user_activity");

            migrationBuilder.DropIndex(
                name: "IX_user_activity_activity_id",
                table: "user_activity");

            migrationBuilder.RenameTable(
                name: "user_activity",
                newName: "UserActivities");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserActivities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserActivities",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "activity_id",
                table: "UserActivities",
                newName: "ActivityId");

            migrationBuilder.AddColumn<int>(
                name: "ActivityPaidStatus",
                table: "UserActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActivities",
                table: "UserActivities",
                column: "Id");
        }
    }
}
