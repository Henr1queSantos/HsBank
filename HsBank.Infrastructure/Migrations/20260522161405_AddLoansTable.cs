using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HsBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLoansTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Loans",
                newName: "TermInMonths");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TermInMonths",
                table: "Loans",
                newName: "Status");
        }
    }
}
