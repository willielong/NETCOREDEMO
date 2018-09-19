using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Entity.Imp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    ognId = table.Column<string>(maxLength: 32, nullable: false),
                    ognName = table.Column<string>(maxLength: 32, nullable: true),
                    parentId = table.Column<string>(maxLength: 32, nullable: true),
                    head = table.Column<string>(maxLength: 32, nullable: true),
                    c_head = table.Column<string>(maxLength: 32, nullable: true),
                    sort = table.Column<int>(nullable: false),
                    virOgn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ognId);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    style_name = table.Column<string>(nullable: true),
                    operation_id = table.Column<string>(nullable: false),
                    level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.operation_id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    permission_id = table.Column<string>(nullable: false),
                    level = table.Column<int>(nullable: false),
                    sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.permission_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    code = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    sys_type = table.Column<int>(nullable: false),
                    default_user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    account = table.Column<string>(maxLength: 32, nullable: true),
                    name = table.Column<string>(maxLength: 32, nullable: true),
                    photo = table.Column<string>(nullable: true),
                    email = table.Column<string>(maxLength: 32, nullable: true),
                    password = table.Column<string>(maxLength: 32, nullable: true),
                    phone = table.Column<string>(maxLength: 32, nullable: true),
                    age = table.Column<int>(nullable: false),
                    sex = table.Column<string>(maxLength: 2, nullable: true),
                    address = table.Column<string>(maxLength: 256, nullable: true),
                    school = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: false),
                    sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Workbench",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    parent_id = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    sort = table.Column<int>(nullable: false),
                    workbench_style = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    workbench_code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workbench", x => x.workbench_code);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    ognId = table.Column<string>(maxLength: 32, nullable: false),
                    ognName = table.Column<string>(maxLength: 32, nullable: true),
                    parentId = table.Column<string>(maxLength: 32, nullable: true),
                    head = table.Column<string>(maxLength: 32, nullable: true),
                    c_head = table.Column<string>(maxLength: 32, nullable: true),
                    sort = table.Column<int>(nullable: false),
                    virOgn = table.Column<int>(nullable: false),
                    branched = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ognId);
                    table.ForeignKey(
                        name: "FK_Department_Company_ognId",
                        column: x => x.ognId,
                        principalTable: "Company",
                        principalColumn: "ognId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_code",
                        column: x => x.code,
                        principalTable: "Role",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpreationMiddle",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    workbench_code = table.Column<string>(nullable: true),
                    permission_id = table.Column<string>(nullable: true),
                    operation_id = table.Column<string>(nullable: true),
                    person = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpreationMiddle", x => x.id);
                    table.ForeignKey(
                        name: "FK_OpreationMiddle_Operation_operation_id",
                        column: x => x.operation_id,
                        principalTable: "Operation",
                        principalColumn: "operation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpreationMiddle_Permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "Permission",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpreationMiddle_Role_person",
                        column: x => x.person,
                        principalTable: "Role",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpreationMiddle_User_person",
                        column: x => x.person,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpreationMiddle_Workbench_workbench_code",
                        column: x => x.workbench_code,
                        principalTable: "Workbench",
                        principalColumn: "workbench_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserKey",
                columns: table => new
                {
                    enable = table.Column<int>(nullable: false),
                    caretor = table.Column<string>(maxLength: 32, nullable: true),
                    crateDate = table.Column<DateTime>(nullable: true),
                    modifier = table.Column<string>(maxLength: 32, nullable: true),
                    modifierDate = table.Column<DateTime>(nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ognId = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKey", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserKey_Department_ognId",
                        column: x => x.ognId,
                        principalTable: "Department",
                        principalColumn: "ognId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserKey_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpreationMiddle_operation_id",
                table: "OpreationMiddle",
                column: "operation_id");

            migrationBuilder.CreateIndex(
                name: "IX_OpreationMiddle_permission_id",
                table: "OpreationMiddle",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_OpreationMiddle_person",
                table: "OpreationMiddle",
                column: "person");

            migrationBuilder.CreateIndex(
                name: "IX_OpreationMiddle_workbench_code",
                table: "OpreationMiddle",
                column: "workbench_code");

            migrationBuilder.CreateIndex(
                name: "IX_UserKey_ognId",
                table: "UserKey",
                column: "ognId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKey_userId",
                table: "UserKey",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_code",
                table: "UserRole",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_user_id",
                table: "UserRole",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpreationMiddle");

            migrationBuilder.DropTable(
                name: "UserKey");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Workbench");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
