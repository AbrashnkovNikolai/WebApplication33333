using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication33333.Migrations
{
    /// <inheritdoc />
    public partial class unitaz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('Id_seq'::regclass)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('Id_seq'::regclass)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('Id_seq'::regclass)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('Id_seq'::regclass)");
        }
    }
}
