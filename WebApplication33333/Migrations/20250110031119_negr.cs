using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication33333.Migrations
{
    /// <inheritdoc />
    public partial class negr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "facultys",
                columns: table => new
                {
                    group_id = table.Column<long>(type: "bigint", nullable: false),
                    faculty = table.Column<string>(type: "text", nullable: false),
                    group_name = table.Column<string>(type: "text", nullable: false),
                    year_of_admission = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("facultys_pkey", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "grants_info",
                columns: table => new
                {
                    grant_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    banclor_grant_value = table.Column<long>(type: "bigint", nullable: false),
                    master_grant_value = table.Column<long>(type: "bigint", nullable: false),
                    aspirant_grant_value = table.Column<long>(type: "bigint", nullable: false),
                    grant_name_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("grants_info_pkey", x => x.grant_name);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('student_info_id_seq'::regclass)"),
                    student_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    student_surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    student_father_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    semester = table.Column<long>(type: "bigint", nullable: false),
                    degree = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    group = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("student_info_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "student_info_group_fkey",
                        column: x => x.group,
                        principalTable: "facultys",
                        principalColumn: "group_id");
                });

            migrationBuilder.CreateTable(
                name: "GiftedGrants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('student_info_id_seq'::regclass)"),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    grant_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    grant_value = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Idpkey", x => x.Id);
                    table.ForeignKey(
                        name: "GiftedGrants_fk1",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "GiftedGrants_fk2",
                        column: x => x.grant_name,
                        principalTable: "grants_info",
                        principalColumn: "grant_name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiftedGrants_grant_name",
                table: "GiftedGrants",
                column: "grant_name");

            migrationBuilder.CreateIndex(
                name: "IX_GiftedGrants_student_id",
                table: "GiftedGrants",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_group",
                table: "Students",
                column: "group");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiftedGrants");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "grants_info");

            migrationBuilder.DropTable(
                name: "facultys");
        }
    }
}
