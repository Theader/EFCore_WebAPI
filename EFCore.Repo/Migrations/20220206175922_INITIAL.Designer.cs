// <auto-generated />
using System;
using EFCore.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Repo.Migrations
{
    [DbContext(typeof(RHContext))]
    [Migration("20220206175922_INITIAL")]
    partial class INITIAL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Dominio.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<int>("SetorId");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("EFCore.Dominio.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<int?>("CargoId");

                    b.Property<DateTime>("DataAdmissao");

                    b.Property<DateTime>("DataDesligamento");

                    b.Property<int>("IdCargo");

                    b.Property<int>("IdSetor");

                    b.Property<string>("Nome");

                    b.Property<string>("RG");

                    b.Property<float>("Salario");

                    b.Property<int?>("SetorId");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("SetorId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("EFCore.Dominio.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int>("IdGestor");

                    b.Property<string>("Nome");

                    b.Property<int>("QtdeFuncionarios");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("EFCore.Dominio.Cargo", b =>
                {
                    b.HasOne("EFCore.Dominio.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCore.Dominio.Funcionario", b =>
                {
                    b.HasOne("EFCore.Dominio.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.HasOne("EFCore.Dominio.Setor", "Setor")
                        .WithMany("FuncionarioSetor")
                        .HasForeignKey("SetorId");
                });
#pragma warning restore 612, 618
        }
    }
}
