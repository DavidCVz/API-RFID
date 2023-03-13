using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIRFID.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "TipoTurno",
                columns: table => new
                {
                    TipoTurnoID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Entrada = table.Column<TimeSpan>(type: "time", nullable: false),
                    Salida = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTurno", x => x.TipoTurnoID);
                });

            migrationBuilder.CreateTable(
                name: "Trabajador",
                columns: table => new
                {
                    TrabajadorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(type: "int", nullable: true),
                    TipoTurnoID = table.Column<int>(type: "int", nullable: true),
                    RfidCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    APaterno = table.Column<string>(name: "A_Paterno", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AMaterno = table.Column<string>(name: "A_Materno", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Curp = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador", x => x.TrabajadorID);
                    table.ForeignKey(
                        name: "FK_Trabajador_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Trabajador_TipoTurno_TipoTurnoID",
                        column: x => x.TipoTurnoID,
                        principalTable: "TipoTurno",
                        principalColumn: "TipoTurnoID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EntradaSalida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorID = table.Column<int>(type: "int", nullable: true),
                    RfidCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombresT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    APaternoT = table.Column<string>(name: "A_PaternoT", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AMaternoT = table.Column<string>(name: "A_MaternoT", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RfcT = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreTurno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreArea = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Entrada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaSalida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradaSalida_Trabajador_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajador",
                        principalColumn: "TrabajadorID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "AreaID", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administración y Finanzas" },
                    { 2, "Calidad administrativa" },
                    { 3, "Calidad de proyectos" },
                    { 4, "Compras" },
                    { 5, "Almacén" },
                    { 6, "Recursos Humanos" },
                    { 7, "Construcción" },
                    { 8, "Ingeniería" },
                    { 9, "Aplicaciones" },
                    { 10, "Higiene" },
                    { 11, "Soporte Técnico" },
                    { 12, "Area de ventas" },
                    { 13, "Desarrollo" }
                });

            migrationBuilder.InsertData(
                table: "TipoTurno",
                columns: new[] { "TipoTurnoID", "Entrada", "Nombre", "Salida" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 0, 0, 0), "Normal", new TimeSpan(0, 19, 0, 0, 0) },
                    { 2, new TimeSpan(0, 7, 0, 0, 0), "Normal", new TimeSpan(0, 18, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Trabajador",
                columns: new[] { "TrabajadorID", "A_Materno", "A_Paterno", "AreaID", "Curp", "Email", "Nombres", "Rfc", "RfidCode", "TipoTurnoID" },
                values: new object[,]
                {
                    { 1, "Velazquez", "Carrillo", 13, "CAVD990306HVZRLV01", "davidacarrillovz@outlook.com", "David", "CAVD990306LS4", "0000145236", 1 },
                    { 2, "Beltrán", "Torres", 3, "TOBJ980528JUT9P4", "juanmanueltb06@outlook.com", "Juan Manuel", "TOBJ980528ZK8", "0000145233", 1 },
                    { 3, "Shimabuko", "Jimenez", 10, "JISO980619HVJRMK07", "oscjimenez55@outlook.com", "Oscar", "JISO980619MI6", "0000145234", 2 },
                    { 4, "Belmán", "Gonzalez", 11, "GOBM990427HVZRBB41", "marcosgblm99@outlook.com", "Márcos Antonio", "GOBM990427YU9", "0000145235", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaSalida_TrabajadorID",
                table: "EntradaSalida",
                column: "TrabajadorID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_AreaID",
                table: "Trabajador",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_Curp",
                table: "Trabajador",
                column: "Curp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_Email",
                table: "Trabajador",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_Rfc",
                table: "Trabajador",
                column: "Rfc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_RfidCode",
                table: "Trabajador",
                column: "RfidCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_TipoTurnoID",
                table: "Trabajador",
                column: "TipoTurnoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaSalida");

            migrationBuilder.DropTable(
                name: "Trabajador");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "TipoTurno");
        }
    }
}
