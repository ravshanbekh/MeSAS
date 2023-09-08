using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserID",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
