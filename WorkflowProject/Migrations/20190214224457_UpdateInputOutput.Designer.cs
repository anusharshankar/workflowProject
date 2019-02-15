﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkflowProject.Models;

namespace WorkflowProject.Migrations
{
    [DbContext(typeof(WorkflowContext))]
    [Migration("20190214224457_UpdateInputOutput")]
    partial class UpdateInputOutput
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkflowProject.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ADesc");

                    b.Property<string>("ATitle");

                    b.Property<string>("Departments");

                    b.Property<int?>("InputsInputId");

                    b.Property<bool>("IsSRSAffected");

                    b.Property<int?>("OutputsOutputId");

                    b.Property<int>("ProcessId");

                    b.HasKey("Id");

                    b.HasIndex("InputsInputId");

                    b.HasIndex("OutputsOutputId");

                    b.HasIndex("ProcessId");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("WorkflowProject.Models.Amendment", b =>
                {
                    b.Property<int>("AmendmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmendAuth");

                    b.Property<DateTime>("AmendDate");

                    b.Property<DateTime>("ApprDate");

                    b.Property<string>("Notes");

                    b.Property<string>("OrigApprAuth");

                    b.Property<int?>("PolicyId");

                    b.HasKey("AmendmentId");

                    b.HasIndex("PolicyId");

                    b.ToTable("Amendment");
                });

            modelBuilder.Entity("WorkflowProject.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualOutcome");

                    b.Property<string>("ChangedExpectation");

                    b.Property<string>("ExpectedOutcome");

                    b.Property<string>("FiledBy");

                    b.Property<DateTime>("FiledOn");

                    b.Property<string>("FilerFeedback");

                    b.Property<string>("FixStatus");

                    b.Property<string>("Issues");

                    b.Property<string>("NecessaryFix");

                    b.Property<string>("RootCause");

                    b.Property<string>("StepsTaken");

                    b.Property<string>("Title");

                    b.HasKey("IncidentId");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("WorkflowProject.Models.Input", b =>
                {
                    b.Property<int>("InputId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InputDesc");

                    b.Property<string>("InputTitle");

                    b.HasKey("InputId");

                    b.ToTable("Input");
                });

            modelBuilder.Entity("WorkflowProject.Models.Output", b =>
                {
                    b.Property<int>("OutputId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OutputDesc");

                    b.Property<string>("OutputTitle");

                    b.HasKey("OutputId");

                    b.ToTable("Output");
                });

            modelBuilder.Entity("WorkflowProject.Models.Policy", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PDescription");

                    b.Property<string>("PScope");

                    b.Property<string>("PTitle");

                    b.Property<int?>("ReviewId");

                    b.HasKey("PolicyId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("WorkflowProject.Models.Procedure", b =>
                {
                    b.Property<int>("ProcedureId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PolicyId");

                    b.Property<string>("PrDesc");

                    b.Property<string>("PrPurpose");

                    b.Property<string>("PrTitle");

                    b.HasKey("ProcedureId");

                    b.HasIndex("PolicyId");

                    b.ToTable("Procedure");
                });

            modelBuilder.Entity("WorkflowProject.Models.Process", b =>
                {
                    b.Property<int>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProcDesc");

                    b.Property<string>("ProcTitle");

                    b.Property<int>("ProcedureId");

                    b.HasKey("ProcessId");

                    b.HasIndex("ProcedureId");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("WorkflowProject.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Administrator");

                    b.Property<string>("AdvisoryCommittee");

                    b.Property<string>("ApprovalAuthority");

                    b.Property<DateTime>("NxtReviewDate");

                    b.HasKey("ReviewId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("WorkflowProject.Models.Action", b =>
                {
                    b.HasOne("WorkflowProject.Models.Input", "Inputs")
                        .WithMany()
                        .HasForeignKey("InputsInputId");

                    b.HasOne("WorkflowProject.Models.Output", "Outputs")
                        .WithMany()
                        .HasForeignKey("OutputsOutputId");

                    b.HasOne("WorkflowProject.Models.Process", "Process")
                        .WithMany("Actions")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkflowProject.Models.Amendment", b =>
                {
                    b.HasOne("WorkflowProject.Models.Policy")
                        .WithMany("Amendments")
                        .HasForeignKey("PolicyId");
                });

            modelBuilder.Entity("WorkflowProject.Models.Policy", b =>
                {
                    b.HasOne("WorkflowProject.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");
                });

            modelBuilder.Entity("WorkflowProject.Models.Procedure", b =>
                {
                    b.HasOne("WorkflowProject.Models.Policy", "Policy")
                        .WithMany("Procedures")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkflowProject.Models.Process", b =>
                {
                    b.HasOne("WorkflowProject.Models.Procedure", "Procedure")
                        .WithMany("Processes")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
