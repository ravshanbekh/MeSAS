using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CheckAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyses_Users_UserId1",
                table: "Analyses");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DoctorId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Analyses_UserId1",
                table: "Analyses");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Analyses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DoctorId1",
                table: "Bookings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Bookings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Analyses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DoctorId1",
                table: "Bookings",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_UserId1",
                table: "Analyses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Analyses_Users_UserId1",
                table: "Analyses",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorId1",
                table: "Bookings",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId1",
                table: "Bookings",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
