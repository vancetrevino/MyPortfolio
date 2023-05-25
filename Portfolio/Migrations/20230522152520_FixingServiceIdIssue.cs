using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class FixingServiceIdIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Employee_EmployeeId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Service_ServiceId1",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_EmployeeId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServiceId1",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeServiceAssignment",
                table: "EmployeeServiceAssignment");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeServiceAssignment_EmployeeId",
                table: "EmployeeServiceAssignment");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "EmployeeId_Assignment",
                table: "EmployeeServiceAssignment");

            migrationBuilder.DropColumn(
                name: "ServiceId_Assignment",
                table: "EmployeeServiceAssignment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeServiceAssignment",
                table: "EmployeeServiceAssignment",
                columns: new[] { "EmployeeId", "ServiceId" });

            migrationBuilder.CreateTable(
                name: "EmployeeService",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ServicesServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeService", x => new { x.EmployeesEmployeeId, x.ServicesServiceId });
                    table.ForeignKey(
                        name: "FK_EmployeeService_Employee_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeService_Service_ServicesServiceId",
                        column: x => x.ServicesServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeService_ServicesServiceId",
                table: "EmployeeService",
                column: "ServicesServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeServiceAssignment",
                table: "EmployeeServiceAssignment");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId1",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId_Assignment",
                table: "EmployeeServiceAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId_Assignment",
                table: "EmployeeServiceAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeServiceAssignment",
                table: "EmployeeServiceAssignment",
                columns: new[] { "EmployeeId_Assignment", "ServiceId_Assignment" });

            migrationBuilder.CreateIndex(
                name: "IX_Service_EmployeeId",
                table: "Service",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceId1",
                table: "Service",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServiceAssignment_EmployeeId",
                table: "EmployeeServiceAssignment",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Employee_EmployeeId",
                table: "Service",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Service_ServiceId1",
                table: "Service",
                column: "ServiceId1",
                principalTable: "Service",
                principalColumn: "ServiceId");
        }
    }
}
