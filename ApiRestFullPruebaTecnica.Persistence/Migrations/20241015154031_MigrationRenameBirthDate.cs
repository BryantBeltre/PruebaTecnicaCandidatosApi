using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestFullPruebaTecnica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationRenameBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BithDate",
                table: "Candidatos",
                newName: "BirthDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Candidatos",
                newName: "BithDate");
        }
    }
}
