﻿// <auto-generated />
using System;
using CrowdSup.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CrowdSup.Infra.Data.Migrations
{
    [DbContext(typeof(CrowdsupContext))]
    [Migration("20221127195314_FotoPerfilIsRequiredFalse")]
    partial class FotoPerfilIsRequiredFalse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("SEQ_EVENTO");

            modelBuilder.HasSequence("SEQ_USUARIO")
                .IncrementsBy(10);

            modelBuilder.HasSequence("SEQ_VOLUNTARIO")
                .IncrementsBy(10);

            modelBuilder.Entity("CrowdSup.Domain.Entities.Eventos.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "SEQ_EVENTO");

                    b.Property<bool>("Cancelado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("CANCELADO");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DATA_EVENTO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("DESCRICAO");

                    b.Property<int>("OrganizadorId")
                        .HasColumnType("integer")
                        .HasColumnName("ORGANIZADOR_ID");

                    b.Property<int>("QuantidadeVoluntariosNecessarios")
                        .HasColumnType("integer")
                        .HasColumnName("QTD_VOLUNT_NEC");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("TITULO");

                    b.HasKey("Id");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("EVENTOS", (string)null);
                });

            modelBuilder.Entity("CrowdSup.Domain.Entities.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "SEQ_USUARIO");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("CIDADE");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("ESTADO");

                    b.Property<string>("FotoPerfil")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("FOTO_PERFIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("SENHA");

                    b.Property<int>("Sexo")
                        .HasColumnType("integer")
                        .HasColumnName("SEXO");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id");

                    b.ToTable("USUARIOS", (string)null);
                });

            modelBuilder.Entity("CrowdSup.Domain.Entities.Voluntarios.Voluntario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "SEQ_VOLUNTARIO");

                    b.Property<int>("EventoId")
                        .HasColumnType("integer")
                        .HasColumnName("EVENTO_ID");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("USUARIO_ID");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("VOLUNTARIOS", (string)null);
                });

            modelBuilder.Entity("CrowdSup.Domain.Entities.Eventos.Evento", b =>
                {
                    b.HasOne("CrowdSup.Domain.Entities.Usuarios.Usuario", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_EVENTO_ORGANIZADOR");

                    b.OwnsOne("CrowdSup.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("EventoId")
                                .HasColumnType("integer");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("BAIRRO");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("CIDADE");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("NUMERO");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("RUA");

                            b1.HasKey("EventoId");

                            b1.ToTable("EVENTOS");

                            b1.WithOwner()
                                .HasForeignKey("EventoId");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("CrowdSup.Domain.Entities.Voluntarios.Voluntario", b =>
                {
                    b.HasOne("CrowdSup.Domain.Entities.Eventos.Evento", "Evento")
                        .WithMany("Voluntarios")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VOLUNTARIO_EVENTO");

                    b.HasOne("CrowdSup.Domain.Entities.Usuarios.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VOLUNTARIO_USUARIO");

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CrowdSup.Domain.Entities.Eventos.Evento", b =>
                {
                    b.Navigation("Voluntarios");
                });
#pragma warning restore 612, 618
        }
    }
}
