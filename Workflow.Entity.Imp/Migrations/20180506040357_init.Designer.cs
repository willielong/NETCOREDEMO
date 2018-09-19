﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Entity.Imp.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    [Migration("20180506040357_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Workflow.Entity.Imp.Company", b =>
                {
                    b.Property<string>("ognId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32);

                    b.Property<string>("c_head")
                        .HasMaxLength(32);

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<string>("head")
                        .HasMaxLength(32);

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("ognName")
                        .HasMaxLength(32);

                    b.Property<string>("parentId")
                        .HasMaxLength(32);

                    b.Property<int>("sort");

                    b.Property<int>("virOgn");

                    b.HasKey("ognId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.Department", b =>
                {
                    b.Property<string>("ognId")
                        .HasMaxLength(32);

                    b.Property<string>("branched")
                        .HasMaxLength(32);

                    b.Property<string>("c_head")
                        .HasMaxLength(32);

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<string>("head")
                        .HasMaxLength(32);

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("ognName")
                        .HasMaxLength(32);

                    b.Property<string>("parentId")
                        .HasMaxLength(32);

                    b.Property<int>("sort");

                    b.Property<int>("virOgn");

                    b.HasKey("ognId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.Operation", b =>
                {
                    b.Property<string>("operation_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<int>("level");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("name");

                    b.Property<string>("style_name");

                    b.HasKey("operation_id");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.OpreationMiddle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("operation_id");

                    b.Property<string>("permission_id");

                    b.Property<string>("person");

                    b.Property<string>("type");

                    b.Property<string>("workbench_code");

                    b.HasKey("id");

                    b.HasIndex("operation_id");

                    b.HasIndex("permission_id");

                    b.HasIndex("person");

                    b.HasIndex("workbench_code");

                    b.ToTable("OpreationMiddle");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.Permission", b =>
                {
                    b.Property<string>("permission_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<int>("level");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("name");

                    b.Property<int>("sort");

                    b.HasKey("permission_id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.Role", b =>
                {
                    b.Property<string>("code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<string>("default_user_id");

                    b.Property<int>("enable");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("name");

                    b.Property<int>("sys_type");

                    b.HasKey("code");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.User", b =>
                {
                    b.Property<string>("userId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("account")
                        .HasMaxLength(32);

                    b.Property<string>("address")
                        .HasMaxLength(256);

                    b.Property<int>("age");

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<string>("email")
                        .HasMaxLength(32);

                    b.Property<int>("enable");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("name")
                        .HasMaxLength(32);

                    b.Property<string>("password")
                        .HasMaxLength(32);

                    b.Property<string>("phone")
                        .HasMaxLength(32);

                    b.Property<string>("photo");

                    b.Property<string>("school");

                    b.Property<string>("sex")
                        .HasMaxLength(2);

                    b.Property<int>("sort");

                    b.HasKey("userId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.UserKey", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("ognId");

                    b.Property<string>("userId");

                    b.HasKey("id");

                    b.HasIndex("ognId");

                    b.HasIndex("userId");

                    b.ToTable("UserKey");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.UserRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<string>("code");

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("user_id");

                    b.HasKey("id");

                    b.HasIndex("code");

                    b.HasIndex("user_id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.Workbench", b =>
                {
                    b.Property<string>("workbench_code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("caretor")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("crateDate");

                    b.Property<int>("enable");

                    b.Property<int>("level");

                    b.Property<string>("modifier")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("modifierDate");

                    b.Property<string>("name");

                    b.Property<string>("parent_id");

                    b.Property<int>("sort");

                    b.Property<string>("workbench_style");

                    b.HasKey("workbench_code");

                    b.ToTable("Workbench");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.Department", b =>
                {
                    b.HasOne("Workflow.Entity.Imp.Company", "company")
                        .WithMany("Departments")
                        .HasForeignKey("ognId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Workflow.Entity.Imp.OpreationMiddle", b =>
                {
                    b.HasOne("Workflow.Entity.Imp.Operation", "operation")
                        .WithMany("opmodel")
                        .HasForeignKey("operation_id");

                    b.HasOne("Workflow.Entity.Imp.Permission", "permission")
                        .WithMany("opmodel")
                        .HasForeignKey("permission_id");

                    b.HasOne("Workflow.Entity.Imp.Role", "role")
                        .WithMany("opmodel")
                        .HasForeignKey("person");

                    b.HasOne("Workflow.Entity.Imp.User", "user")
                        .WithMany("opmodel")
                        .HasForeignKey("person");

                    b.HasOne("Workflow.Entity.Imp.Workbench", "workbench")
                        .WithMany("opmodel")
                        .HasForeignKey("workbench_code");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.UserKey", b =>
                {
                    b.HasOne("Workflow.Entity.Imp.Department", "department")
                        .WithMany("users")
                        .HasForeignKey("ognId");

                    b.HasOne("Workflow.Entity.Imp.User", "user")
                        .WithMany("Departments")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Workflow.Entity.Imp.UserRole", b =>
                {
                    b.HasOne("Workflow.Entity.Imp.Role", "role")
                        .WithMany("users")
                        .HasForeignKey("code");

                    b.HasOne("Workflow.Entity.Imp.User", "user")
                        .WithMany("roles")
                        .HasForeignKey("user_id");
                });
#pragma warning restore 612, 618
        }
    }
}
