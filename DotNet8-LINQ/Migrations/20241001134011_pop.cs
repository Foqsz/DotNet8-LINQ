using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8_LINQ.Migrations
{
    /// <inheritdoc />
    public partial class pop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir Setores
            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "SetorId", "SetorNome" },
                values: new object[,]
                {
                    { 1, "Recursos Humanos" },
                    { 2, "Contabilidade" },
                    { 3, "Marketing" },
                    { 4, "Tecnologia" },
                    { 5, "Logística" }
                });

            // Inserir Funcionários
            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "FuncionarioNome", "FuncionarioCargo", "SetorId" },
                values: new object[,]
                {
                    { 1, "Marisa Monte", "Gerente", 1 },
                    { 2, "Janice Ribeiro", "Administrativo", 1 },
                    { 3, "Fernando Alves", "Recrutador", 1 },
                    { 4, "Sara Souza", "Assistente de RH", 1 },
                    { 5, "Pedro Toledo", "Gerente", 2 },
                    { 6, "Andre Sanches", "Contador", 2 },
                    { 7, "Hilda Hinst", "Diretora", 2 },
                    { 8, "Bruna Xavier", "Analista Financeiro", 2 },
                    { 9, "Ana Maria Lima", "Gerente", 3 },
                    { 10, "Carlos Ribeiro", "Designer", 3 },
                    { 11, "Jaime Lacuste", "CEO", 3 },
                    { 12, "Beatriz Garcia", "Analista de Marketing", 3 },
                    { 13, "Lucas Silva", "Estagiário de Marketing", 3 },
                    { 14, "Ricardo Borges", "Desenvolvedor Full Stack", 4 },
                    { 15, "Gabriela Costa", "Desenvolvedora Mobile", 4 },
                    { 16, "Maurício Lima", "Gerente de TI", 4 },
                    { 17, "Marina Oliveira", "Suporte Técnico", 4 },
                    { 18, "Julio Fernandes", "Supervisor de Logística", 5 },
                    { 19, "Isabela Santos", "Motorista", 5 },
                    { 20, "Thiago Pereira", "Auxiliar de Expedição", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover Funcionários
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 2);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 3);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 4);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 5);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 6);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 7);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 8);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 9);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 10);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 11);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 12);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 13);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 14);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 15);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 16);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 17);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 18);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 19);
            migrationBuilder.DeleteData(table: "Funcionarios", keyColumn: "FuncionarioId", keyValue: 20);

            // Remover Setores
            migrationBuilder.DeleteData(table: "Setores", keyColumn: "SetorId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Setores", keyColumn: "SetorId", keyValue: 2);
            migrationBuilder.DeleteData(table: "Setores", keyColumn: "SetorId", keyValue: 3);
            migrationBuilder.DeleteData(table: "Setores", keyColumn: "SetorId", keyValue: 4);
            migrationBuilder.DeleteData(table: "Setores", keyColumn: "SetorId", keyValue: 5);
        }
    }
}
