using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Entity.Imp.Migrations
{
    public partial class updatedb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company_ognId",
                table: "Department");

            migrationBuilder.AddColumn<string>(
                name: "unitId",
                table: "Department",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_unitId",
                table: "Department",
                column: "unitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Company_unitId",
                table: "Department",
                column: "unitId",
                principalTable: "Company",
                principalColumn: "ognId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Company_unitId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_unitId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "unitId",
                table: "Department");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Company_ognId",
                table: "Department",
                column: "ognId",
                principalTable: "Company",
                principalColumn: "ognId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
