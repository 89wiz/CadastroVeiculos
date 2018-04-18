using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Infra.Data.Context.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Placa = table.Column<string>(maxLength: 7, nullable: false),
                    ProprietarioID = table.Column<Guid>(nullable: false),
                    Renavam = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Veiculo_Proprietario_ProprietarioID",
                        column: x => x.ProprietarioID,
                        principalTable: "Proprietario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoFoto",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ArquivoID = table.Column<Guid>(nullable: false),
                    VeiculoID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoFoto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VeiculoFoto_Veiculo_VeiculoID",
                        column: x => x.VeiculoID,
                        principalTable: "Veiculo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ProprietarioID",
                table: "Veiculo",
                column: "ProprietarioID");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoFoto_VeiculoID",
                table: "VeiculoFoto",
                column: "VeiculoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeiculoFoto");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
