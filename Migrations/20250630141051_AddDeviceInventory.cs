using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device_Inventory",
                columns: table => new
                {
                    device_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    device_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_Inventory", x => x.device_id);
                });

            migrationBuilder.CreateTable(
                name: "Device_Assignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    device_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_Assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Device_Assignments_Device_Inventory_device_id",
                        column: x => x.device_id,
                        principalTable: "Device_Inventory",
                        principalColumn: "device_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Device_Assignments_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_Assignments_device_id",
                table: "Device_Assignments",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "IX_Device_Assignments_user_id",
                table: "Device_Assignments",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device_Assignments");

            migrationBuilder.DropTable(
                name: "Device_Inventory");
        }
    }
}
