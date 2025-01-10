using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication33333.Migrations
{
    /// <inheritdoc />
    public partial class seq1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GiftedGrants",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('Id_seq'::regclass)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('Id_seq'::regclass)");

            migrationBuilder.AlterColumn<long>(
                name: "group_id",
                table: "facultys",
                type: "serial",
                nullable: false,
                defaultValueSql: "nextval('group_id_seq'::regclass)",
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GiftedGrants",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('Id_seq'::regclass)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('Id_seq'::regclass)");

            migrationBuilder.AlterColumn<long>(
                name: "group_id",
                table: "facultys",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "nextval('group_id_seq'::regclass)");
        }
    }
}
