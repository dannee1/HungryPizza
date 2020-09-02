using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizza.Domain.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flavor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flavorId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmailLogin = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    DDD = table.Column<string>(type: "varchar(2)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressName = table.Column<string>(type: "varchar(80)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(20)", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(2)", nullable: false),
                    IdUser = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addressId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_address_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: true),
                    Idaddress = table.Column<Guid>(nullable: true),
                    OrderDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaFlavor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPizza = table.Column<Guid>(nullable: false),
                    IdFlavor = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaFlavorId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaFlavor_Pizza_IdPizza",
                        column: x => x.IdPizza,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaFlavor_Flavor_IdFlavor",
                        column: x => x.IdFlavor,
                        principalTable: "Flavor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flavor",
                columns: new[] { "Id", "Description", "Price" },
                values: new object[,]
                {
                    { new Guid("afd43ced-bb64-4b2c-9b6d-358597484320"), "3 Queijos", 50m },
                    { new Guid("65f94207-10d6-4ffb-841d-8e8fda817555"), "Frango com requeijão ", 59.99m },
                    { new Guid("3de1e14e-4938-42ec-96b9-a4359f1ff072"), "Mussarela ", 42.5m },
                    { new Guid("bbb1d0c8-ee7c-4ef5-8d49-9a98293f5c9d"), "Calabresa ", 42.5m },
                    { new Guid("c06bfce9-12a9-45b1-9bf6-06a23a579c9d"), "Pepperoni", 55m },
                    { new Guid("06925036-bbec-4e46-b804-5137f3bc02d9"), "Portuguesa ", 45m },
                    { new Guid("11895cec-1106-400f-a1c6-d1077e21fb1e"), "Veggie ", 59.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_IdUser",
                table: "address",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdUser",
                table: "Order",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderId",
                table: "Pizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaFlavor_IdPizza",
                table: "PizzaFlavor",
                column: "IdPizza");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaFlavor_IdFlavor",
                table: "PizzaFlavor",
                column: "IdFlavor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "PizzaFlavor");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Flavor");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
