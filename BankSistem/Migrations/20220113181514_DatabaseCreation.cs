using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSistem.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardOwners",
                columns: table => new
                {
                    IdCardOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardOwners", x => x.IdCardOwner);
                });

            migrationBuilder.CreateTable(
                name: "SocialStatuses",
                columns: table => new
                {
                    IdSocialStatus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialStatuses", x => x.IdSocialStatus);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<decimal>(type: "Money", nullable: false),
                    IdCardOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_CardOwners_IdCardOwner",
                        column: x => x.IdCardOwner,
                        principalTable: "CardOwners",
                        principalColumn: "IdCardOwner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerStatuses",
                columns: table => new
                {
                    IdOwnerStatus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSocialStatus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCardOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerStatuses", x => x.IdOwnerStatus);
                    table.ForeignKey(
                        name: "FK_OwnerStatuses_CardOwners_IdCardOwner",
                        column: x => x.IdCardOwner,
                        principalTable: "CardOwners",
                        principalColumn: "IdCardOwner",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerStatuses_SocialStatuses_IdSocialStatus",
                        column: x => x.IdSocialStatus,
                        principalTable: "SocialStatuses",
                        principalColumn: "IdSocialStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    IdCard = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<decimal>(type: "Money", nullable: false),
                    IdAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Cards_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CardOwners",
                columns: new[] { "IdCardOwner", "Name" },
                values: new object[,]
                {
                    { new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"), "Дима" },
                    { new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"), "Влад" },
                    { new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"), "Гриша" },
                    { new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"), "Саша" },
                    { new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"), "Кирилл" }
                });

            migrationBuilder.InsertData(
                table: "SocialStatuses",
                columns: new[] { "IdSocialStatus", "Name" },
                values: new object[,]
                {
                    { new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431"), "Пенсионер" },
                    { new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4"), "Инвалид" },
                    { new Guid("04fadf24-1488-4197-9ae6-a8737ffe8337"), "Ветеран" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "IdAccount", "Balance", "IdCardOwner" },
                values: new object[,]
                {
                    { new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438"), 10m, new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99") },
                    { new Guid("ec38f0a8-be2b-4f91-9af0-47ab5d1769c3"), 60m, new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99") },
                    { new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca"), 20m, new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a") },
                    { new Guid("8c961fbe-9316-41b0-913c-6fed6977d479"), 70m, new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a") },
                    { new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6"), 30m, new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81") },
                    { new Guid("93ad8e5c-cd32-4cd9-8944-224e76d6d24d"), 40m, new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7") },
                    { new Guid("e4150c2e-c74a-400b-9fee-48b09ef3e805"), 50m, new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605") }
                });

            migrationBuilder.InsertData(
                table: "OwnerStatuses",
                columns: new[] { "IdOwnerStatus", "IdCardOwner", "IdSocialStatus" },
                values: new object[,]
                {
                    { new Guid("353ad58d-6c1f-468d-9c30-65cf14329afd"), new Guid("0ef8ac41-db5c-47b6-a536-0706d7204f99"), new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431") },
                    { new Guid("23879e10-0a0b-44a1-803d-8b60f9d1b301"), new Guid("81dffe2c-4577-4432-9743-e4cc8920bdf7"), new Guid("c163c49a-c3df-40e0-8bbc-e635aee61431") },
                    { new Guid("628f2928-2104-4fd5-a073-9f2316a6ae43"), new Guid("58476e7a-1213-4c17-afb5-049cf6265d6a"), new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4") },
                    { new Guid("05da5e43-2252-420a-977f-1ea9cdbf4232"), new Guid("a1e9235c-61a4-4a60-a6d0-117f924a2605"), new Guid("66acb6d3-256a-4cf7-9e76-04d84ceea1f4") },
                    { new Guid("3675bbfd-1d00-497e-88d5-190a3b104343"), new Guid("69799b8b-3a07-4ad0-bd56-3131ccde4d81"), new Guid("04fadf24-1488-4197-9ae6-a8737ffe8337") }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "IdCard", "Balance", "IdAccount" },
                values: new object[,]
                {
                    { new Guid("e4e3cd8b-2a59-4dbc-af8e-82196dac63f9"), 100m, new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438") },
                    { new Guid("cd6f000d-5285-4401-b010-283fe976d589"), 30m, new Guid("ed45ad28-c73e-4b0f-9db7-7f2d0040f438") },
                    { new Guid("fe4eca51-fad4-4ead-9bda-2a9fbd81a87a"), 50m, new Guid("ec38f0a8-be2b-4f91-9af0-47ab5d1769c3") },
                    { new Guid("d3787455-4540-4c89-8cee-29aa0e14f73b"), 90m, new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca") },
                    { new Guid("50fa7c36-1025-407c-af2e-7c060fd69ffd"), 20m, new Guid("f30b0daa-810f-4d14-9072-158973ccf3ca") },
                    { new Guid("18dc9f21-2bd6-4a6c-bb6a-67f9b200f8d6"), 40m, new Guid("8c961fbe-9316-41b0-913c-6fed6977d479") },
                    { new Guid("ce95c5b3-a854-449b-b6bc-3d3f6d74d4e7"), 80m, new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6") },
                    { new Guid("ba52bcfa-e7ba-4dff-9ef1-04118350d1fc"), 10m, new Guid("b7736cae-2a7a-42e7-900c-163d0a6b1db6") },
                    { new Guid("90ff565b-0ec2-434b-8779-d4f3d54f7478"), 70m, new Guid("93ad8e5c-cd32-4cd9-8944-224e76d6d24d") },
                    { new Guid("66c03d49-f33b-4aa8-bcf5-81b1144828de"), 60m, new Guid("e4150c2e-c74a-400b-9fee-48b09ef3e805") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdCardOwner",
                table: "Accounts",
                column: "IdCardOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_IdAccount",
                table: "Cards",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerStatuses_IdCardOwner",
                table: "OwnerStatuses",
                column: "IdCardOwner");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerStatuses_IdSocialStatus",
                table: "OwnerStatuses",
                column: "IdSocialStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "OwnerStatuses");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SocialStatuses");

            migrationBuilder.DropTable(
                name: "CardOwners");
        }
    }
}
