using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CursoEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("42fb1aad-174e-47b5-81b7-038b6a23da01"), null, "Actividades Pendientes", 20 },
                    { new Guid("42fb1aad-174e-47b5-81b7-038b6a23da02"), null, "Actividades Personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("42fb1aad-174e-47b5-81b7-038b6a23da03"), new Guid("42fb1aad-174e-47b5-81b7-038b6a23da01"), null, new DateTime(2023, 1, 31, 12, 25, 20, 969, DateTimeKind.Local).AddTicks(1396), 1, "Pago de servicios publicos" },
                    { new Guid("42fb1aad-174e-47b5-81b7-038b6a23da04"), new Guid("42fb1aad-174e-47b5-81b7-038b6a23da02"), null, new DateTime(2023, 1, 31, 12, 25, 20, 969, DateTimeKind.Local).AddTicks(1409), 0, "Terminar de ver pelicula" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("42fb1aad-174e-47b5-81b7-038b6a23da03"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("42fb1aad-174e-47b5-81b7-038b6a23da04"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("42fb1aad-174e-47b5-81b7-038b6a23da01"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("42fb1aad-174e-47b5-81b7-038b6a23da02"));
        }
    }
}
