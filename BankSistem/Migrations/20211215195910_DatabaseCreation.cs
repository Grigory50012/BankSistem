using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSistem.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    IdBank = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.IdBank);
                });

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
                name: "Towns",
                columns: table => new
                {
                    IdTown = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.IdTown);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<decimal>(type: "Money", nullable: false),
                    IdBank = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCardOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_Banks_IdBank",
                        column: x => x.IdBank,
                        principalTable: "Banks",
                        principalColumn: "IdBank",
                        onDelete: ReferentialAction.Cascade);
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
                name: "BankBranches",
                columns: table => new
                {
                    IdBankBranch = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTown = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBank = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.IdBankBranch);
                    table.ForeignKey(
                        name: "FK_BankBranches_Banks_IdBank",
                        column: x => x.IdBank,
                        principalTable: "Banks",
                        principalColumn: "IdBank",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankBranches_Towns_IdTown",
                        column: x => x.IdTown,
                        principalTable: "Towns",
                        principalColumn: "IdTown",
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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdBank",
                table: "Accounts",
                column: "IdBank");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdCardOwner",
                table: "Accounts",
                column: "IdCardOwner");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_IdBank",
                table: "BankBranches",
                column: "IdBank");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_IdTown",
                table: "BankBranches",
                column: "IdTown");

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
                name: "BankBranches");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "OwnerStatuses");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SocialStatuses");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CardOwners");
        }
    }
}
