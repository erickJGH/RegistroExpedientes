using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroExpedientes.Migrations
{
    public partial class Departamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDepartamento = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departam__787A433DC27A6E07", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    IdExpediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionExpediente = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NombreBeneficiario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoBeneficiario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CedulaoRNC = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoExpediente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Monto = table.Column<decimal>(type: "money", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaDeEntrada = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Expedien__101235DAC9602DE5", x => x.IdExpediente);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDepartamento = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Privilegio = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    PersonCreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersonLastLogin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A6BFF15BDC", x => x.idUsuario);
                    table.ForeignKey(
                        name: "fk_DepartamentUsuario",
                        column: x => x.idDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento");
                });

            migrationBuilder.CreateIndex(
                name: "UN_Deparmento",
                table: "Departamento",
                column: "NombreDepartamento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Expedien__FEB26E7AD24F62D6",
                table: "Expediente",
                column: "CedulaoRNC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idDepartamento",
                table: "Usuario",
                column: "idDepartamento");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__B4ADFE38CF75A4E3",
                table: "Usuario",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__E3237CF77578A68F",
                table: "Usuario",
                column: "Usuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expediente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
