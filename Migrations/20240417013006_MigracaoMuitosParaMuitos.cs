using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 23, 223, 73, 65, 52, 29, 115, 5, 67, 200, 239, 122, 65, 177, 222, 22, 141, 17, 89, 39, 120, 101, 165, 123, 64, 212, 141, 130, 232, 103, 21, 136, 195, 98, 213, 193, 181, 38, 55, 119, 100, 111, 152, 176, 28, 189, 196, 215, 141, 94, 161, 67, 245, 189, 50, 48, 68, 145, 124, 160, 23, 21, 153, 135 }, new byte[] { 182, 63, 16, 226, 228, 198, 240, 26, 11, 57, 191, 70, 218, 206, 52, 94, 29, 163, 226, 152, 54, 26, 65, 220, 46, 188, 190, 128, 116, 69, 205, 41, 24, 63, 106, 87, 122, 246, 90, 99, 68, 50, 31, 66, 93, 95, 66, 126, 128, 111, 45, 89, 226, 144, 233, 21, 11, 47, 60, 198, 228, 117, 68, 10, 133, 14, 222, 203, 98, 240, 49, 213, 33, 143, 52, 246, 242, 107, 14, 210, 77, 248, 154, 181, 231, 223, 142, 176, 169, 71, 32, 128, 24, 82, 208, 132, 219, 43, 203, 101, 33, 0, 140, 141, 186, 215, 244, 19, 207, 34, 41, 18, 207, 135, 14, 32, 190, 171, 84, 166, 124, 217, 179, 84, 119, 182, 52, 233 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 201, 239, 49, 151, 82, 49, 9, 9, 33, 196, 107, 63, 205, 250, 204, 85, 91, 186, 246, 136, 119, 112, 89, 174, 116, 246, 165, 251, 139, 128, 230, 44, 64, 134, 36, 246, 195, 190, 26, 71, 141, 137, 29, 186, 207, 24, 101, 247, 240, 238, 96, 100, 188, 175, 181, 107, 18, 113, 169, 72, 205, 110, 143, 152 }, new byte[] { 52, 192, 211, 235, 15, 241, 101, 170, 73, 244, 38, 92, 39, 87, 95, 167, 187, 74, 205, 225, 20, 10, 143, 107, 111, 106, 14, 209, 0, 237, 59, 182, 246, 90, 233, 134, 85, 124, 93, 237, 34, 103, 226, 188, 231, 109, 248, 133, 117, 15, 146, 212, 128, 2, 254, 129, 72, 137, 83, 125, 146, 163, 104, 33, 30, 69, 76, 66, 241, 135, 196, 90, 76, 167, 55, 210, 67, 70, 5, 242, 244, 153, 254, 148, 175, 21, 238, 75, 86, 108, 135, 101, 231, 224, 124, 15, 23, 243, 137, 99, 182, 227, 133, 184, 116, 33, 85, 62, 6, 248, 233, 18, 176, 132, 239, 128, 171, 33, 95, 236, 62, 19, 181, 208, 63, 92, 171, 63 } });
        }
    }
}
