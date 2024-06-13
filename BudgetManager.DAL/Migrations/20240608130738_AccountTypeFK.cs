using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AccountTypeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountType_TypeAccountTypeId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_TypeAccountTypeId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TypeAccountTypeId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountType_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId",
                principalTable: "AccountType",
                principalColumn: "AccountTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountType_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "TypeAccountTypeId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TypeAccountTypeId",
                table: "Accounts",
                column: "TypeAccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountType_TypeAccountTypeId",
                table: "Accounts",
                column: "TypeAccountTypeId",
                principalTable: "AccountType",
                principalColumn: "AccountTypeId");
        }
    }
}
