﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(InfoDiagContext))]
    [Migration("20190606231644_ErrorCodeToCompilation")]
    partial class ErrorCodeToCompilation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Entity.Compilation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CompilationTime");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Compilation");
                });

            modelBuilder.Entity("Entity.CompilationError", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompilationId");

                    b.Property<string>("ErrorCodeId");

                    b.Property<string>("Message");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompilationId");

                    b.HasIndex("ErrorCodeId");

                    b.ToTable("CompilationError");
                });

            modelBuilder.Entity("Entity.CompilationErrorLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CompilationErrorId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("CompilationErrorId");

                    b.ToTable("CompilationErrorLine");
                });

            modelBuilder.Entity("Entity.ErrorCode", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ErrorCode");
                });

            modelBuilder.Entity("Entity.Compilation", b =>
                {
                    b.HasOne("Entity.Client", null)
                        .WithMany("Compilations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.CompilationError", b =>
                {
                    b.HasOne("Entity.Compilation", null)
                        .WithMany("CompilationErrors")
                        .HasForeignKey("CompilationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.ErrorCode", "ErrorCode")
                        .WithMany()
                        .HasForeignKey("ErrorCodeId");
                });

            modelBuilder.Entity("Entity.CompilationErrorLine", b =>
                {
                    b.HasOne("Entity.CompilationError", null)
                        .WithMany("Lines")
                        .HasForeignKey("CompilationErrorId");
                });
#pragma warning restore 612, 618
        }
    }
}
