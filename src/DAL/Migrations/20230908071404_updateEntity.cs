using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "BodyMassege",
                table: "Messages",
                newName: "MessageBody");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_UserID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hospitals",
                newName: "HospitalName");

            migrationBuilder.RenameColumn(
                name: "MeetingDate",
                table: "Bookings",
                newName: "Meetingtime");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AttachmentId",
                table: "Users",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AttachmentId",
                table: "Hospitals",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AttachmentId",
                table: "Doctors",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_AttachmentId",
                table: "Analyses",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analyses_Attachments_AttachmentId",
                table: "Analyses",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Attachments_AttachmentId",
                table: "Doctors",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Attachments_AttachmentId",
                table: "Hospitals",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Attachments_AttachmentId",
                table: "Users",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyses_Attachments_AttachmentId",
                table: "Analyses");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Attachments_AttachmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Attachments_AttachmentId",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Attachments_AttachmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AttachmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_AttachmentId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AttachmentId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Analyses_AttachmentId",
                table: "Analyses");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MessageBody",
                table: "Messages",
                newName: "BodyMassege");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserID",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.RenameColumn(
                name: "HospitalName",
                table: "Hospitals",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Meetingtime",
                table: "Bookings",
                newName: "MeetingDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
