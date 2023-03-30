using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mgr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Goods",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Descryption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Goods__3214EC2747D3C508", x => x.ID)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Authed = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC27EF4AD3F1", x => x.ID)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__D7CB621F4C519DAB", x => new { x.UserId, x.GoodId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK__Comments__GoodId__46E78A0C",
                        column: x => x.GoodId,
                        principalSchema: "dbo",
                        principalTable: "Goods",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Comments__UserId__45F365D3",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GoodsList",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GoodsLis__D7CB621F7A6EF2A9", x => new { x.UserId, x.GoodId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK__GoodsList__GoodI__3F466844",
                        column: x => x.GoodId,
                        principalSchema: "dbo",
                        principalTable: "Goods",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__GoodsList__UserI__3E52440B",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LikedList",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LikedLis__D7CB621F263FEB94", x => new { x.UserId, x.GoodId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK__LikedList__GoodI__4316F928",
                        column: x => x.GoodId,
                        principalSchema: "dbo",
                        principalTable: "Goods",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__LikedList__UserI__4222D4EF",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SavedAdresses",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Building = table.Column<int>(type: "int", nullable: true),
                    Front = table.Column<int>(type: "int", nullable: true),
                    Apartament = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SavedAdr__D543AA01C2B1B66D", x => new { x.UserId, x.Title })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK__SavedAdre__UserI__398D8EEE",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ships__DF685A06ADC55F86", x => new { x.ID, x.UserId, x.GoodId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK__Ships__GoodId__4AB81AF0",
                        column: x => x.GoodId,
                        principalSchema: "dbo",
                        principalTable: "Goods",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Ships__UserId__49C3F6B7",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GoodId",
                schema: "dbo",
                table: "Comments",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsList_GoodId",
                schema: "dbo",
                table: "GoodsList",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedList_GoodId",
                schema: "dbo",
                table: "LikedList",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_GoodId",
                schema: "dbo",
                table: "Ships",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_UserId",
                schema: "dbo",
                table: "Ships",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GoodsList",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LikedList",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SavedAdresses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ships",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Goods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
