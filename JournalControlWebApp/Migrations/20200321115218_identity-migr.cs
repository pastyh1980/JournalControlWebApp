using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalControlWebApp.Migrations
{
    public partial class identitymigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subunits",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subunits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sectors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subunit_id = table.Column<int>(nullable: false),
                    sector = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    is_main = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sectors", x => x.id);
                    table.ForeignKey(
                        name: "FK_sector_subunit",
                        column: x => x.subunit_id,
                        principalTable: "Subunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    sector_id = table.Column<int>(nullable: false),
                    family = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    otch = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    post = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    is_first_login = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.id);
                    table.ForeignKey(
                        name: "FK_worker_sector",
                        column: x => x.sector_id,
                        principalTable: "sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_workers_UserId",
                        column: x => x.UserId,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_workers_UserId",
                        column: x => x.UserId,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_workers_UserId",
                        column: x => x.UserId,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_workers_UserId",
                        column: x => x.UserId,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "check",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    reg_worker = table.Column<int>(nullable: false),
                    delete_worker = table.Column<int>(nullable: true),
                    sector_id = table.Column<int>(nullable: false),
                    reg_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    check_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    check_worker = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    td_kd = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    control_indicator = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    count_operations = table.Column<int>(nullable: false),
                    fail_count = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    fail_description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    isCorrect = table.Column<bool>(nullable: false),
                    delete_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    isFail = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_check", x => x.id);
                    table.ForeignKey(
                        name: "FK_delete_worker",
                        column: x => x.delete_worker,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reg_worker",
                        column: x => x.reg_worker,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_check_sector",
                        column: x => x.sector_id,
                        principalTable: "sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    check_id = table.Column<int>(nullable: false),
                    developer = table.Column<int>(nullable: false),
                    report_worker = table.Column<int>(nullable: true),
                    delete_worker = table.Column<int>(nullable: true),
                    fail_reason = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    respons_worker = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    due_date = table.Column<DateTime>(type: "date", nullable: false),
                    develop_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    report = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    proof_inf = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    report_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    isCorrect = table.Column<bool>(nullable: false),
                    delete_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                    table.ForeignKey(
                        name: "FK_events_check",
                        column: x => x.check_id,
                        principalTable: "check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_events_delete_worker",
                        column: x => x.delete_worker,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_events_developer",
                        column: x => x.developer,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_events_report_worker",
                        column: x => x.report_worker,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shows",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    check_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    worker_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shows", x => x.id);
                    table.ForeignKey(
                        name: "FK_shows_check",
                        column: x => x.check_id,
                        principalTable: "check",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shows_workers",
                        column: x => x.worker_id,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_check_delete_worker",
                table: "check",
                column: "delete_worker");

            migrationBuilder.CreateIndex(
                name: "IX_check_reg_worker",
                table: "check",
                column: "reg_worker");

            migrationBuilder.CreateIndex(
                name: "IX_check_sector_id",
                table: "check",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_check_id",
                table: "events",
                column: "check_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_delete_worker",
                table: "events",
                column: "delete_worker");

            migrationBuilder.CreateIndex(
                name: "IX_events_developer",
                table: "events",
                column: "developer");

            migrationBuilder.CreateIndex(
                name: "IX_events_report_worker",
                table: "events",
                column: "report_worker");

            migrationBuilder.CreateIndex(
                name: "IX_sectors_subunit_id",
                table: "sectors",
                column: "subunit_id");

            migrationBuilder.CreateIndex(
                name: "IX_shows_check_id",
                table: "shows",
                column: "check_id");

            migrationBuilder.CreateIndex(
                name: "IX_shows_worker_id",
                table: "shows",
                column: "worker_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "workers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "workers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_workers_sector_id",
                table: "workers",
                column: "sector_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "shows");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "check");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropTable(
                name: "sectors");

            migrationBuilder.DropTable(
                name: "Subunits");
        }
    }
}
