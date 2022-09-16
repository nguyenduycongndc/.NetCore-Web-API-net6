﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Migrations
{
    public partial class FirstMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_joining = table.Column<DateTime>(type: "datetime2", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    users_id = table.Column<int>(type: "int", nullable: true),
                    roles_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_roles_roles_roles_id",
                        column: x => x.roles_id,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_roles_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_roles_roles_id",
                table: "users_roles",
                column: "roles_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_roles_users_id",
                table: "users_roles",
                column: "users_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users_roles");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
