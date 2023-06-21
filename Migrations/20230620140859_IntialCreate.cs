using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace core7_postgre_angular14.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descriptions = table.Column<string>(type: "varchar", nullable: true),
                    qty = table.Column<int>(type: "integer", nullable: false),
                    unit = table.Column<string>(type: "varchar", nullable: true),
                    cost_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    sell_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    prod_pic = table.Column<string>(type: "varchar", nullable: true),
                    category = table.Column<string>(type: "varchar", nullable: true),
                    sale_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    alert_level = table.Column<int>(type: "integer", nullable: false),
                    critical_level = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastname = table.Column<string>(type: "varchar", nullable: true),
                    firstname = table.Column<string>(type: "varchar", nullable: true),
                    username = table.Column<string>(type: "varchar", nullable: true),
                    password = table.Column<string>(type: "varchar", nullable: true),
                    email = table.Column<string>(type: "varchar", nullable: true),
                    mobile = table.Column<string>(type: "varchar", nullable: true),
                    roles = table.Column<string>(type: "varchar", nullable: true),
                    isactivated = table.Column<int>(type: "integer", nullable: false),
                    isblocked = table.Column<int>(type: "integer", nullable: false),
                    mailtoken = table.Column<int>(type: "integer", nullable: false),
                    qrcodeurl = table.Column<string>(type: "varchar", nullable: true),
                    profilepic = table.Column<string>(type: "varchar", nullable: true),
                    secretkey = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
