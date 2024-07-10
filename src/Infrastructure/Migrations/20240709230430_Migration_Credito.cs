using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_Credito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "creditAnalysis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    documentoCliente = table.Column<string>(type: "text", nullable: false),
                    statusAnalise = table.Column<int>(type: "integer", nullable: false),
                    liminiteMinimo = table.Column<decimal>(type: "numeric", nullable: false),
                    LiminiteMaximo = table.Column<decimal>(type: "numeric", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditAnalysis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    documento = table.Column<string>(type: "text", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    telefone = table.Column<string>(type: "text", nullable: false),
                    renda = table.Column<decimal>(type: "numeric", nullable: false),
                    estadoCivil = table.Column<int>(type: "integer", nullable: false),
                    dependentes = table.Column<int>(type: "integer", nullable: false),
                    genero = table.Column<int>(type: "integer", nullable: false),
                    idade = table.Column<int>(type: "integer", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_creditAnalysis_documentoCliente",
                table: "creditAnalysis",
                column: "documentoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_users_documento_ativo",
                table: "users",
                columns: new[] { "documento", "ativo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "creditAnalysis");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
