using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMatrixCase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DataMatrixInfoShrink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "encoding_format",
                table: "datamatrix_info");

            migrationBuilder.DropColumn(
                name: "metadata",
                table: "datamatrix_info");

            migrationBuilder.DropColumn(
                name: "scan_timestamp",
                table: "datamatrix_info");

            migrationBuilder.DropColumn(
                name: "source_device_id",
                table: "datamatrix_info");

            migrationBuilder.DropColumn(
                name: "source_type",
                table: "datamatrix_info");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "datamatrix_info");

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "datamatrix_info",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_path",
                table: "datamatrix_info");

            migrationBuilder.AddColumn<string>(
                name: "encoding_format",
                table: "datamatrix_info",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "metadata",
                table: "datamatrix_info",
                type: "nvarchar",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "scan_timestamp",
                table: "datamatrix_info",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "source_device_id",
                table: "datamatrix_info",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "source_type",
                table: "datamatrix_info",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "datamatrix_info",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
