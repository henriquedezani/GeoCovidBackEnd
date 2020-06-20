﻿// <auto-generated />
using GeoCovid.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeoCovid.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("GeoCovid.Model.Coordenada", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Coordenadas");
                });

            modelBuilder.Entity("GeoCovid.Model.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lote")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tema")
                        .HasColumnType("TEXT");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("GeoCovid.Model.Usuario", b =>
                {
                    b.Property<string>("EmailTelefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("EmailTelefone");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}