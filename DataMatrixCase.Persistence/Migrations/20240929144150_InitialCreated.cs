using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMatrixCase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "datamatrix_info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    decodeddata = table.Column<string>(name: "decoded_data", type: "nvarchar(max)", nullable: false),
                    encodingformat = table.Column<string>(name: "encoding_format", type: "nvarchar(50)", nullable: false),
                    sourcetype = table.Column<string>(name: "source_type", type: "nvarchar(100)", nullable: false),
                    sourcedeviceid = table.Column<string>(name: "source_device_id", type: "nvarchar(255)", nullable: false),
                    scantimestamp = table.Column<DateTime>(name: "scan_timestamp", type: "datetime2", nullable: false),
                    metadata = table.Column<string>(type: "nvarchar", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datamatrix_info", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datamatrix_info");
        }
    }
}
