using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace END.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeTypes_DocumentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_AttributeTypes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "AttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentDocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChildDocumentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentLinks_Documents_ChildDocumentId",
                        column: x => x.ChildDocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentLinks_Documents_ParentDocumentId",
                        column: x => x.ParentDocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da"), "Указ" },
                    { new Guid("d0fb024e-7f8a-4fd9-9cf7-cf8f4259488f"), "Инструкия" }
                });

            migrationBuilder.InsertData(
                table: "AttributeTypes",
                columns: new[] { "Id", "DataType", "Name", "TypeId" },
                values: new object[,]
                {
                    { new Guid("04215f96-7f97-4626-b6b1-0c60a466dd79"), "string", "Статус", new Guid("d0fb024e-7f8a-4fd9-9cf7-cf8f4259488f") },
                    { new Guid("7ef34cb3-5f61-4256-b8ae-b8df3abc9435"), "int", "Номер", new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da") },
                    { new Guid("b95e63a2-4119-45ca-bb4e-3ff6d2f1b031"), "string", "Описание", new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da") },
                    { new Guid("cd8c3655-d190-481f-94af-4abba625dd15"), "string", "Автор", new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da") }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[,]
                {
                    { new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"), "Указ купить 2л пива шефу", new Guid("34daec0b-af9d-46ae-b19c-ac6cdfc962da") },
                    { new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"), "Инструкция закрывания двери", new Guid("d0fb024e-7f8a-4fd9-9cf7-cf8f4259488f") }
                });

            migrationBuilder.InsertData(
                table: "AttributeValues",
                columns: new[] { "Id", "AttributeId", "DocumentId", "Value" },
                values: new object[,]
                {
                    { new Guid("2f8ac9d2-f458-4065-9e96-b492e0a53ffb"), new Guid("04215f96-7f97-4626-b6b1-0c60a466dd79"), new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"), "Действующий" },
                    { new Guid("438b96d0-f447-45e8-bb46-995a18f883cd"), new Guid("b95e63a2-4119-45ca-bb4e-3ff6d2f1b031"), new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"), "Ручку дергать туда сюда" },
                    { new Guid("790bb43a-ce2b-4563-980b-0892323e611c"), new Guid("7ef34cb3-5f61-4256-b8ae-b8df3abc9435"), new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"), "1488" },
                    { new Guid("d088a886-2aa8-45b6-995a-2f72b6448a81"), new Guid("cd8c3655-d190-481f-94af-4abba625dd15"), new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"), "Начальник всего" },
                    { new Guid("e9c19528-2ef1-4a5d-abcf-663a70916be0"), new Guid("b95e63a2-4119-45ca-bb4e-3ff6d2f1b031"), new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"), "Старый мельник" },
                    { new Guid("f4269fb2-a316-475b-8a02-71dd22eb8d91"), new Guid("cd8c3655-d190-481f-94af-4abba625dd15"), new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3"), "Начальник двери" }
                });

            migrationBuilder.InsertData(
                table: "DocumentLinks",
                columns: new[] { "Id", "ChildDocumentId", "ParentDocumentId" },
                values: new object[] { new Guid("0fc55202-6098-419c-9fd3-1bae8d734089"), new Guid("76ddc547-f53f-42c4-8f65-a3beb462b571"), new Guid("dc1f21fa-d389-4f70-b9a8-e24e253a40f3") });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_TypeId",
                table: "AttributeTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_DocumentId",
                table: "AttributeValues",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLinks_ChildDocumentId",
                table: "DocumentLinks",
                column: "ChildDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLinks_ParentDocumentId",
                table: "DocumentLinks",
                column: "ParentDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "DocumentLinks");

            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentTypes");
        }
    }
}
