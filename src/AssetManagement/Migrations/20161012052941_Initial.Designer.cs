using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AssetManagement.Data;

namespace AssetManagement.Migrations
{
    [DbContext(typeof(AssetConetxt))]
    [Migration("20161012052941_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssetManagement.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.Property<decimal>("Value");

                    b.HasKey("AssetId");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("AssetManagement.Models.Assignee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastMidName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Assignee");
                });

            modelBuilder.Entity("AssetManagement.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssetID");

                    b.Property<int>("AssigneeID");

                    b.Property<int?>("ProgramLocation");

                    b.HasKey("AssignmentID");

                    b.HasIndex("AssetID");

                    b.HasIndex("AssigneeID");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("AssetManagement.Models.Assignment", b =>
                {
                    b.HasOne("AssetManagement.Models.Asset", "Asset")
                        .WithMany("Assignments")
                        .HasForeignKey("AssetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AssetManagement.Models.Assignee", "Assignee")
                        .WithMany("Asssignments")
                        .HasForeignKey("AssigneeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
