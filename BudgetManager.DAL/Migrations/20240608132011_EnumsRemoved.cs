using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EnumsRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AccountTypes",
                table: "AccountType");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "AccountType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 1,
                column: "AccountName",
                value: "Checking");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 2,
                column: "AccountName",
                value: "Savings");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 3,
                column: "AccountName",
                value: "CreditCard");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 4,
                column: "AccountName",
                value: "Cash");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 5,
                column: "AccountName",
                value: "Investment");

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 6,
                column: "AccountName",
                value: "Loan");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryName",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryName",
                value: "Rent");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CategoryName",
                value: "Utilities");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CategoryName",
                value: "Transportation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CategoryName",
                value: "Entertainment");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CategoryName",
                value: "Clothing");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CategoryName",
                value: "Health");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CategoryName",
                value: "Insurance");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CategoryName",
                value: "PersonalCare");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "CategoryName",
                value: "Miscellaneous");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "AccountType");

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypes",
                table: "AccountType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 1,
                column: "AccountTypes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 2,
                column: "AccountTypes",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 3,
                column: "AccountTypes",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 4,
                column: "AccountTypes",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 5,
                column: "AccountTypes",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AccountType",
                keyColumn: "AccountTypeId",
                keyValue: 6,
                column: "AccountTypes",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Categories",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Categories",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Categories",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Categories",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Categories",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "Categories",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "Categories",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "Categories",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "Categories",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "Categories",
                value: 9);
        }
    }
}
