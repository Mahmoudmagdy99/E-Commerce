using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class paymentSummaryCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentSummary_Year",
                table: "Orders",
                newName: "PaymentSummary_ExpYear");

            migrationBuilder.RenameColumn(
                name: "PaymentSummary_Band",
                table: "Orders",
                newName: "PaymentSummary_Brand");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentSummary_ExpYear",
                table: "Orders",
                newName: "PaymentSummary_Year");

            migrationBuilder.RenameColumn(
                name: "PaymentSummary_Brand",
                table: "Orders",
                newName: "PaymentSummary_Band");
        }
    }
}
