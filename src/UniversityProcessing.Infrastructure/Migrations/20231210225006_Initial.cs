using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniversityProcessing.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "diploma_processings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    secretary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    required_titles = table.Column<string[]>(type: "text[]", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diploma_processings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "universities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    short_name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_universities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_profiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    last_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    father_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    short_name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_faculties", x => x.id);
                    table.ForeignKey(
                        name: "fk_faculties_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    short_name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: false),
                    faculty_id = table.Column<Guid>(type: "uuid", nullable: false),
                    supervisor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    table.ForeignKey(
                        name: "fk_departments_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specialties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    short_name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: false),
                    faculty_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    table.ForeignKey(
                        name: "fk_specialties_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_specialties_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graduate_works",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    grade = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    supervisor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    diploma_processing_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graduate_works", x => x.id);
                    table.ForeignKey(
                        name: "fk_graduate_works_diploma_processings_diploma_processing_entit",
                        column: x => x.diploma_processing_entity_id,
                        principalTable: "diploma_processings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_graduate_works_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_number = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: false),
                    faculty_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    specialty_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    student_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_study_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_study_groups_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_study_groups_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_study_groups_specialties_specialty_entity_id",
                        column: x => x.specialty_entity_id,
                        principalTable: "specialties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_study_groups_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    study_group_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    department_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    diploma_processing_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    faculty_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    university_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    specialty_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_employee_entity_departments_department_entity_id",
                        column: x => x.department_entity_id,
                        principalTable: "departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employee_entity_diploma_processings_diploma_processing_entit",
                        column: x => x.diploma_processing_entity_id,
                        principalTable: "diploma_processings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_student_entity_departments_department_entity_id",
                        column: x => x.department_entity_id,
                        principalTable: "departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_student_entity_diploma_processings_diploma_processing_entity",
                        column: x => x.diploma_processing_entity_id,
                        principalTable: "diploma_processings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_faculties_faculty_entity_id",
                        column: x => x.faculty_entity_id,
                        principalTable: "faculties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_specialties_specialty_entity_id",
                        column: x => x.specialty_entity_id,
                        principalTable: "specialties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_study_groups_study_group_entity_id",
                        column: x => x.study_group_entity_id,
                        principalTable: "study_groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_universities_university_entity_id",
                        column: x => x.university_entity_id,
                        principalTable: "universities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_user_profiles_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "user_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                schema: "public",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_logins_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_tokens_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_departments_faculty_id",
                table: "departments",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_departments_supervisor_id",
                table: "departments",
                column: "supervisor_id");

            migrationBuilder.CreateIndex(
                name: "ix_departments_university_id",
                table: "departments",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_faculties_university_id",
                table: "faculties",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_graduate_works_diploma_processing_entity_id",
                table: "graduate_works",
                column: "diploma_processing_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_graduate_works_status_id",
                table: "graduate_works",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_graduate_works_student_id",
                table: "graduate_works",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_graduate_works_supervisor_id",
                table: "graduate_works",
                column: "supervisor_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                schema: "public",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "public",
                table: "roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_specialties_department_id",
                table: "specialties",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_specialties_faculty_id",
                table: "specialties",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_specialties_university_id",
                table: "specialties",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_study_groups_department_id",
                table: "study_groups",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_study_groups_faculty_id",
                table: "study_groups",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_study_groups_specialty_entity_id",
                table: "study_groups",
                column: "specialty_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_study_groups_student_entity_id",
                table: "study_groups",
                column: "student_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_study_groups_university_id",
                table: "study_groups",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                schema: "public",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_logins_user_id",
                schema: "public",
                table: "user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                schema: "public",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "users",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_department_entity_id",
                schema: "public",
                table: "users",
                column: "department_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_diploma_processing_entity_id",
                schema: "public",
                table: "users",
                column: "diploma_processing_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_faculty_entity_id",
                schema: "public",
                table: "users",
                column: "faculty_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_specialty_entity_id",
                schema: "public",
                table: "users",
                column: "specialty_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_study_group_entity_id",
                schema: "public",
                table: "users",
                column: "study_group_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_university_entity_id",
                schema: "public",
                table: "users",
                column: "university_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_user_profile_id",
                schema: "public",
                table: "users",
                column: "user_profile_id");

            migrationBuilder.AddForeignKey(
                name: "fk_departments_users_supervisor_id",
                table: "departments",
                column: "supervisor_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_graduate_works_users_student_id",
                table: "graduate_works",
                column: "student_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_graduate_works_users_supervisor_id",
                table: "graduate_works",
                column: "supervisor_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_study_groups_users_student_entity_id",
                table: "study_groups",
                column: "student_entity_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_departments_faculties_faculty_id",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "fk_specialties_faculties_faculty_id",
                table: "specialties");

            migrationBuilder.DropForeignKey(
                name: "fk_study_groups_faculties_faculty_id",
                table: "study_groups");

            migrationBuilder.DropForeignKey(
                name: "fk_users_faculties_faculty_entity_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_departments_universities_university_id",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "fk_specialties_universities_university_id",
                table: "specialties");

            migrationBuilder.DropForeignKey(
                name: "fk_study_groups_universities_university_id",
                table: "study_groups");

            migrationBuilder.DropForeignKey(
                name: "fk_users_universities_university_entity_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_departments_users_supervisor_id",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "fk_study_groups_users_student_entity_id",
                table: "study_groups");

            migrationBuilder.DropTable(
                name: "graduate_works");

            migrationBuilder.DropTable(
                name: "role_claims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_claims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_logins",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_tokens",
                schema: "public");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "faculties");

            migrationBuilder.DropTable(
                name: "universities");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "diploma_processings");

            migrationBuilder.DropTable(
                name: "study_groups");

            migrationBuilder.DropTable(
                name: "user_profiles");

            migrationBuilder.DropTable(
                name: "specialties");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
