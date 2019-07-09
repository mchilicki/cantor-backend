using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chilicki.Cantor.Infrastructure.Migrations
{
    public partial class AddUsersCantorsWalletsAndCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CantorWallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CantorWallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    SellPrice = table.Column<decimal>(nullable: false),
                    AveragePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Money = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CantorCurrency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CantorId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CantorCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CantorCurrency_CantorWallet_CantorId",
                        column: x => x.CantorId,
                        principalTable: "CantorWallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CantorCurrency_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletCurrency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletCurrency_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletCurrency_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CantorCurrency_CantorId",
                table: "CantorCurrency",
                column: "CantorId");

            migrationBuilder.CreateIndex(
                name: "IX_CantorCurrency_CurrencyId",
                table: "CantorCurrency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletCurrency_CurrencyId",
                table: "WalletCurrency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletCurrency_OwnerId",
                table: "WalletCurrency",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CantorCurrency");

            migrationBuilder.DropTable(
                name: "WalletCurrency");

            migrationBuilder.DropTable(
                name: "CantorWallet");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
