using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProcessing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "сommittee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_сommittee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    short_name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    head_user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    message = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    is_read = table.Column<bool>(type: "INTEGER", nullable: false),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "period",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    from = table.Column<DateTime>(type: "TEXT", nullable: false),
                    to = table.Column<DateTime>(type: "TEXT", nullable: false),
                    comments = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_period", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    default_permissions = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "university_positions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_university_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    short_name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    faculty_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    head_user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                    table.ForeignKey(
                        name: "fk_departments_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    claim_type = table.Column<string>(type: "TEXT", nullable: true),
                    claim_value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diploma_periods",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    required_titles = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    possible_from = table.Column<DateTime>(type: "TEXT", nullable: true),
                    possible_to = table.Column<DateTime>(type: "TEXT", nullable: true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    сommittee_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    period_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    department_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diploma_periods", x => x.id);
                    table.ForeignKey(
                        name: "fk_diploma_periods_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_diploma_periods_period_period_id",
                        column: x => x.period_id,
                        principalTable: "period",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_diploma_periods_сommittee_сommittee_id",
                        column: x => x.сommittee_id,
                        principalTable: "сommittee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "specialties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    short_name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    department_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_specialties", x => x.id);
                    table.ForeignKey(
                        name: "fk_specialties_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diplomas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    grade = table.Column<int>(type: "INTEGER", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    diploma_process_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    student_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    supervisor_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diplomas", x => x.id);
                    table.ForeignKey(
                        name: "fk_diplomas_diploma_periods_diploma_process_id",
                        column: x => x.diploma_process_id,
                        principalTable: "diploma_periods",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    number = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    start_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    department_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    specialty_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_groups_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groups_specialties_specialty_id",
                        column: x => x.specialty_id,
                        principalTable: "specialties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    blocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    approved = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    middle_name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    birthday = table.Column<DateTime>(type: "TEXT", nullable: true),
                    group_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    university_position_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    faculty_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    department_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    сommittee_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    user_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    password_hash = table.Column<string>(type: "TEXT", nullable: true),
                    security_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    access_failed_count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_university_positions_university_position_id",
                        column: x => x.university_position_id,
                        principalTable: "university_positions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_сommittee_сommittee_id",
                        column: x => x.сommittee_id,
                        principalTable: "сommittee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "diploma_process_user",
                columns: table => new
                {
                    diploma_processes_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    users_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diploma_process_user", x => new { x.diploma_processes_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_diploma_process_user_diploma_periods_diploma_processes_id",
                        column: x => x.diploma_processes_id,
                        principalTable: "diploma_periods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_diploma_process_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diploma_user",
                columns: table => new
                {
                    diplomas_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    users_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diploma_user", x => new { x.diplomas_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_diploma_user_diplomas_diplomas_id",
                        column: x => x.diplomas_id,
                        principalTable: "diplomas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_diploma_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    claim_type = table.Column<string>(type: "TEXT", nullable: true),
                    claim_value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "TEXT", nullable: false),
                    provider_key = table.Column<string>(type: "TEXT", nullable: false),
                    provider_display_name = table.Column<string>(type: "TEXT", nullable: true),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_logins_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    role_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    login_provider = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_departments_faculty_id",
                table: "departments",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_diploma_periods_сommittee_id",
                table: "diploma_periods",
                column: "сommittee_id");

            migrationBuilder.CreateIndex(
                name: "ix_diploma_periods_department_id",
                table: "diploma_periods",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_diploma_periods_period_id",
                table: "diploma_periods",
                column: "period_id");

            migrationBuilder.CreateIndex(
                name: "ix_diploma_process_user_users_id",
                table: "diploma_process_user",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_diploma_user_users_id",
                table: "diploma_user",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_diplomas_diploma_process_id",
                table: "diplomas",
                column: "diploma_process_id");

            migrationBuilder.CreateIndex(
                name: "ix_groups_department_id",
                table: "groups",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_groups_number",
                table: "groups",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_groups_specialty_id",
                table: "groups",
                column: "specialty_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_specialties_code",
                table: "specialties",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_specialties_department_id",
                table: "specialties",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_logins_user_id",
                table: "user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_users_сommittee_id",
                table: "users",
                column: "сommittee_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_department_id",
                table: "users",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_faculty_id",
                table: "users",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_group_id",
                table: "users",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_university_position_id",
                table: "users",
                column: "university_position_id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalized_user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diploma_process_user");

            migrationBuilder.DropTable(
                name: "diploma_user");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "diplomas");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "diploma_periods");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "university_positions");

            migrationBuilder.DropTable(
                name: "period");

            migrationBuilder.DropTable(
                name: "сommittee");

            migrationBuilder.DropTable(
                name: "specialties");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "faculties");
        }
    }
}
