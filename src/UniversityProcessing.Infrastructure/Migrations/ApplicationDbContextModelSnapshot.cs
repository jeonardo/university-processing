﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityProcessing.Infrastructure;

#nullable disable

namespace UniversityProcessing.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("DiplomaProcessUser", b =>
                {
                    b.Property<Guid>("DiplomaProcessesId")
                        .HasColumnType("TEXT")
                        .HasColumnName("diploma_processes_id");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("TEXT")
                        .HasColumnName("users_id");

                    b.HasKey("DiplomaProcessesId", "UsersId")
                        .HasName("pk_diploma_process_user");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_diploma_process_user_users_id");

                    b.ToTable("diploma_process_user", (string)null);
                });

            modelBuilder.Entity("DiplomaUser", b =>
                {
                    b.Property<Guid>("DiplomasId")
                        .HasColumnType("TEXT")
                        .HasColumnName("diplomas_id");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("TEXT")
                        .HasColumnName("users_id");

                    b.HasKey("DiplomasId", "UsersId")
                        .HasName("pk_diploma_user");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_diploma_user_users_id");

                    b.ToTable("diploma_user", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_role_claims_role_id");

                    b.ToTable("role_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_claims_user_id");

                    b.ToTable("user_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_logins_user_id");

                    b.ToTable("user_logins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_user_roles_role_id");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_tokens");

                    b.ToTable("user_tokens", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("TEXT")
                        .HasColumnName("faculty_id");

                    b.Property<Guid?>("HeadUserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("head_user_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("short_name");

                    b.HasKey("Id")
                        .HasName("pk_departments");

                    b.HasIndex("FacultyId")
                        .HasDatabaseName("ix_departments_faculty_id");

                    b.ToTable("departments", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Diploma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("DiplomaProcessId")
                        .HasColumnType("TEXT")
                        .HasColumnName("diploma_process_id");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER")
                        .HasColumnName("grade");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("student_id");

                    b.Property<Guid?>("SupervisorId")
                        .HasColumnType("TEXT")
                        .HasColumnName("supervisor_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_diplomas");

                    b.HasIndex("DiplomaProcessId")
                        .HasDatabaseName("ix_diplomas_diploma_process_id");

                    b.ToTable("diplomas", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.DiplomaProcess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("department_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<Guid?>("PeriodId")
                        .HasColumnType("TEXT")
                        .HasColumnName("period_id");

                    b.Property<DateTime?>("PossibleFrom")
                        .HasColumnType("TEXT")
                        .HasColumnName("possible_from");

                    b.Property<DateTime?>("PossibleTo")
                        .HasColumnType("TEXT")
                        .HasColumnName("possible_to");

                    b.Property<string>("RequiredTitles")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("required_titles");

                    b.Property<Guid?>("СommitteeId")
                        .HasColumnType("TEXT")
                        .HasColumnName("сommittee_id");

                    b.HasKey("Id")
                        .HasName("pk_diploma_periods");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_diploma_periods_department_id");

                    b.HasIndex("PeriodId")
                        .HasDatabaseName("ix_diploma_periods_period_id");

                    b.HasIndex("СommitteeId")
                        .HasDatabaseName("ix_diploma_periods_сommittee_id");

                    b.ToTable("diploma_periods", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("HeadUserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("head_user_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("short_name");

                    b.HasKey("Id")
                        .HasName("pk_faculties");

                    b.ToTable("faculties", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("department_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("end_date");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("number");

                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("TEXT")
                        .HasColumnName("specialty_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("pk_groups");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_groups_department_id");

                    b.HasIndex("Number")
                        .IsUnique()
                        .HasDatabaseName("ix_groups_number");

                    b.HasIndex("SpecialtyId")
                        .HasDatabaseName("ix_groups_specialty_id");

                    b.ToTable("groups", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsRead")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_read");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("message");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_notifications");

                    b.ToTable("notifications", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Comments")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("comments");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("From")
                        .HasColumnType("TEXT")
                        .HasColumnName("from");

                    b.Property<DateTime>("To")
                        .HasColumnType("TEXT")
                        .HasColumnName("to");

                    b.HasKey("Id")
                        .HasName("pk_period");

                    b.ToTable("period", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("department_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("short_name");

                    b.HasKey("Id")
                        .HasName("pk_specialties");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasDatabaseName("ix_specialties_code");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_specialties_department_id");

                    b.ToTable("specialties", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.UniversityPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_university_positions");

                    b.ToTable("university_positions", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER")
                        .HasColumnName("access_failed_count");

                    b.Property<bool>("Approved")
                        .HasColumnType("INTEGER")
                        .HasColumnName("approved");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("TEXT")
                        .HasColumnName("birthday");

                    b.Property<bool>("Blocked")
                        .HasColumnType("INTEGER")
                        .HasColumnName("blocked");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("department_id");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("email_confirmed");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("TEXT")
                        .HasColumnName("faculty_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("TEXT")
                        .HasColumnName("group_id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT")
                        .HasColumnName("lockout_end");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("middle_name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER")
                        .HasColumnName("two_factor_enabled");

                    b.Property<Guid?>("UniversityPositionId")
                        .HasColumnType("TEXT")
                        .HasColumnName("university_position_id");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("user_name");

                    b.Property<Guid?>("СommitteeId")
                        .HasColumnType("TEXT")
                        .HasColumnName("сommittee_id");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_users_department_id");

                    b.HasIndex("FacultyId")
                        .HasDatabaseName("ix_users_faculty_id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_users_group_id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("UniversityPositionId")
                        .HasDatabaseName("ix_users_university_position_id");

                    b.HasIndex("СommitteeId")
                        .HasDatabaseName("ix_users_сommittee_id");

                    b.ToTable("users", (string)null);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UniversityProcessing.Domain.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("DefaultPermissions")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("default_permissions");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Сommittee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.HasKey("Id")
                        .HasName("pk_сommittee");

                    b.ToTable("сommittee", (string)null);
                });

            modelBuilder.Entity("DiplomaProcessUser", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.DiplomaProcess", null)
                        .WithMany()
                        .HasForeignKey("DiplomaProcessesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_diploma_process_user_diploma_periods_diploma_processes_id");

                    b.HasOne("UniversityProcessing.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_diploma_process_user_users_users_id");
                });

            modelBuilder.Entity("DiplomaUser", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.Diploma", null)
                        .WithMany()
                        .HasForeignKey("DiplomasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_diploma_user_diplomas_diplomas_id");

                    b.HasOne("UniversityProcessing.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_diploma_user_users_users_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_claims_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_claims_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_logins_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_roles_role_id");

                    b.HasOne("UniversityProcessing.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_tokens_users_user_id");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Department", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_departments_faculties_faculty_id");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Diploma", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.DiplomaProcess", "DiplomaProcess")
                        .WithMany("Diplomas")
                        .HasForeignKey("DiplomaProcessId")
                        .HasConstraintName("fk_diplomas_diploma_periods_diploma_process_id");

                    b.Navigation("DiplomaProcess");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.DiplomaProcess", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.Department", null)
                        .WithMany("DiplomaProcesses")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("fk_diploma_periods_departments_department_id");

                    b.HasOne("UniversityProcessing.Domain.Period", "Period")
                        .WithMany("DiplomaProcesses")
                        .HasForeignKey("PeriodId")
                        .HasConstraintName("fk_diploma_periods_period_period_id");

                    b.HasOne("UniversityProcessing.Domain.Сommittee", "Committee")
                        .WithMany()
                        .HasForeignKey("СommitteeId")
                        .HasConstraintName("fk_diploma_periods_сommittee_сommittee_id");

                    b.Navigation("Committee");

                    b.Navigation("Period");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Group", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_groups_departments_department_id");

                    b.HasOne("UniversityProcessing.Domain.Specialty", "Specialty")
                        .WithMany("Groups")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_groups_specialties_specialty_id");

                    b.Navigation("Department");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Specialty", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.Department", "Department")
                        .WithMany("Specialties")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_specialties_departments_department_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.User", b =>
                {
                    b.HasOne("UniversityProcessing.Domain.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_departments_department_id");

                    b.HasOne("UniversityProcessing.Domain.Faculty", "Faculty")
                        .WithMany("Users")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_faculties_faculty_id");

                    b.HasOne("UniversityProcessing.Domain.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_groups_group_id");

                    b.HasOne("UniversityProcessing.Domain.UniversityPosition", "UniversityPosition")
                        .WithMany()
                        .HasForeignKey("UniversityPositionId")
                        .HasConstraintName("fk_users_university_positions_university_position_id");

                    b.HasOne("UniversityProcessing.Domain.Сommittee", null)
                        .WithMany("Users")
                        .HasForeignKey("СommitteeId")
                        .HasConstraintName("fk_users_сommittee_сommittee_id");

                    b.Navigation("Department");

                    b.Navigation("Faculty");

                    b.Navigation("Group");

                    b.Navigation("UniversityPosition");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Department", b =>
                {
                    b.Navigation("DiplomaProcesses");

                    b.Navigation("Specialties");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.DiplomaProcess", b =>
                {
                    b.Navigation("Diplomas");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Faculty", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Group", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Period", b =>
                {
                    b.Navigation("DiplomaProcesses");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Specialty", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("UniversityProcessing.Domain.Сommittee", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
