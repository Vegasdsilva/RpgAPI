using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 201, 239, 49, 151, 82, 49, 9, 9, 33, 196, 107, 63, 205, 250, 204, 85, 91, 186, 246, 136, 119, 112, 89, 174, 116, 246, 165, 251, 139, 128, 230, 44, 64, 134, 36, 246, 195, 190, 26, 71, 141, 137, 29, 186, 207, 24, 101, 247, 240, 238, 96, 100, 188, 175, 181, 107, 18, 113, 169, 72, 205, 110, 143, 152 }, new byte[] { 52, 192, 211, 235, 15, 241, 101, 170, 73, 244, 38, 92, 39, 87, 95, 167, 187, 74, 205, 225, 20, 10, 143, 107, 111, 106, 14, 209, 0, 237, 59, 182, 246, 90, 233, 134, 85, 124, 93, 237, 34, 103, 226, 188, 231, 109, 248, 133, 117, 15, 146, 212, 128, 2, 254, 129, 72, 137, 83, 125, 146, 163, 104, 33, 30, 69, 76, 66, 241, 135, 196, 90, 76, 167, 55, 210, 67, 70, 5, 242, 244, 153, 254, 148, 175, 21, 238, 75, 86, 108, 135, 101, 231, 224, 124, 15, 23, 243, 137, 99, 182, 227, 133, 184, 116, 33, 85, 62, 6, 248, 233, 18, 176, 132, 239, 128, 171, 33, 95, 236, 62, 19, 181, 208, 63, 92, 171, 63 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 206, 252, 35, 99, 56, 135, 98, 40, 165, 58, 58, 77, 149, 91, 88, 157, 128, 161, 196, 90, 158, 170, 88, 197, 172, 115, 119, 28, 55, 96, 210, 120, 113, 242, 190, 161, 44, 118, 25, 84, 214, 131, 165, 39, 162, 193, 34, 79, 199, 72, 117, 71, 154, 211, 27, 11, 187, 152, 82, 112, 229, 195, 10, 18 }, new byte[] { 36, 100, 92, 39, 183, 216, 219, 64, 252, 206, 237, 162, 59, 226, 143, 21, 101, 131, 106, 167, 127, 78, 178, 191, 37, 118, 106, 174, 26, 105, 31, 133, 45, 130, 231, 102, 22, 101, 219, 37, 38, 253, 83, 182, 101, 52, 146, 131, 10, 191, 52, 124, 144, 43, 93, 20, 0, 225, 4, 254, 87, 172, 202, 254, 54, 80, 244, 233, 93, 52, 121, 30, 157, 1, 92, 186, 203, 253, 13, 176, 37, 139, 223, 67, 225, 78, 61, 175, 37, 26, 117, 43, 188, 76, 156, 99, 190, 214, 129, 241, 68, 88, 30, 245, 243, 102, 4, 198, 230, 72, 99, 156, 207, 121, 177, 105, 42, 8, 214, 241, 137, 219, 101, 58, 185, 104, 211, 196 } });
        }
    }
}
