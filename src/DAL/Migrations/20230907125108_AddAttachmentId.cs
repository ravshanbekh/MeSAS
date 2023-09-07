using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAttachmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AttachmentId",
                table: "Hospitals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AttachmentId",
                table: "Doctors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AttachmentId",
                table: "Analyses",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Analyses");
        }
    }
}
