using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RenameEntiyes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profits_Cars_CustomerId",
                table: "Profits");

            migrationBuilder.DropForeignKey(
                name: "FK_Profits_CarTypes_TypeId",
                table: "Profits");

            migrationBuilder.DropForeignKey(
                name: "FK_Profits_Drivers_МasseurId",
                table: "Profits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profits",
                table: "Profits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Profits",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Мasseurs");

            migrationBuilder.RenameTable(
                name: "CarTypes",
                newName: "MassageTypes");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Profits_TypeId",
                table: "Reservations",
                newName: "IX_Reservations_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Profits_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Profits_МasseurId",
                table: "Reservations",
                newName: "IX_Reservations_МasseurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Мasseurs",
                table: "Мasseurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MassageTypes",
                table: "MassageTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Мasseurs_МasseurId",
                table: "Reservations",
                column: "МasseurId",
                principalTable: "Мasseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MassageTypes_TypeId",
                table: "Reservations",
                column: "TypeId",
                principalTable: "MassageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Мasseurs_МasseurId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MassageTypes_TypeId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MassageTypes",
                table: "MassageTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Мasseurs",
                table: "Мasseurs");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Profits");

            migrationBuilder.RenameTable(
                name: "MassageTypes",
                newName: "CarTypes");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Cars");

            migrationBuilder.RenameTable(
                name: "Мasseurs",
                newName: "Drivers");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TypeId",
                table: "Profits",
                newName: "IX_Profits_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Profits",
                newName: "IX_Profits_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_МasseurId",
                table: "Profits",
                newName: "IX_Profits_МasseurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profits",
                table: "Profits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profits_Cars_CustomerId",
                table: "Profits",
                column: "CustomerId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profits_CarTypes_TypeId",
                table: "Profits",
                column: "TypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profits_Drivers_МasseurId",
                table: "Profits",
                column: "МasseurId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
