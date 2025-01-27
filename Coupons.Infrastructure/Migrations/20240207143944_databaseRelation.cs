using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coupons.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class databaseRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CouponAuthorizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    UserCreated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponAuthorizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    UserCreated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<bool>(type: "bit", nullable: false),
                    Cash = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplyOverDiscount = table.Column<bool>(type: "bit", nullable: false),
                    ApplyOverBundle = table.Column<bool>(type: "bit", nullable: false),
                    IsGeneric = table.Column<bool>(type: "bit", nullable: false),
                    UserCreated = table.Column<int>(type: "int", nullable: false),
                    CouponTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponConfigurations_CouponTypes_CouponTypeId",
                        column: x => x.CouponTypeId,
                        principalTable: "CouponTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreated = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponConfigurationId = table.Column<int>(type: "int", nullable: false),
                    CouponAuthorizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_CouponAuthorizers_CouponAuthorizerId",
                        column: x => x.CouponAuthorizerId,
                        principalTable: "CouponAuthorizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coupons_CouponConfigurations_CouponConfigurationId",
                        column: x => x.CouponConfigurationId,
                        principalTable: "CouponConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    ReferenceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreated = table.Column<int>(type: "int", nullable: false),
                    CounponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponDetails_Coupons_CounponId",
                        column: x => x.CounponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponConfigurations_CouponTypeId",
                table: "CouponConfigurations",
                column: "CouponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponDetails_CounponId",
                table: "CouponDetails",
                column: "CounponId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_CouponAuthorizerId",
                table: "Coupons",
                column: "CouponAuthorizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_CouponConfigurationId",
                table: "Coupons",
                column: "CouponConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponDetails");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "CouponAuthorizers");

            migrationBuilder.DropTable(
                name: "CouponConfigurations");

            migrationBuilder.DropTable(
                name: "CouponTypes");
        }
    }
}
