﻿// <auto-generated />
using System;
using API_RFID;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIRFID.Migrations
{
    [DbContext(typeof(EntradasContext))]
    partial class EntradasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_RFID.Models.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AreaID");

                    b.ToTable("Area", (string)null);

                    b.HasData(
                        new
                        {
                            AreaID = 1,
                            Nombre = "Administración y Finanzas"
                        },
                        new
                        {
                            AreaID = 2,
                            Nombre = "Calidad administrativa"
                        },
                        new
                        {
                            AreaID = 3,
                            Nombre = "Calidad de proyectos"
                        },
                        new
                        {
                            AreaID = 4,
                            Nombre = "Compras"
                        },
                        new
                        {
                            AreaID = 5,
                            Nombre = "Almacén"
                        },
                        new
                        {
                            AreaID = 6,
                            Nombre = "Recursos Humanos"
                        },
                        new
                        {
                            AreaID = 7,
                            Nombre = "Construcción"
                        },
                        new
                        {
                            AreaID = 8,
                            Nombre = "Ingeniería"
                        },
                        new
                        {
                            AreaID = 9,
                            Nombre = "Aplicaciones"
                        },
                        new
                        {
                            AreaID = 10,
                            Nombre = "Higiene"
                        },
                        new
                        {
                            AreaID = 11,
                            Nombre = "Soporte Técnico"
                        },
                        new
                        {
                            AreaID = 12,
                            Nombre = "Area de ventas"
                        },
                        new
                        {
                            AreaID = 13,
                            Nombre = "Desarrollo"
                        });
                });

            modelBuilder.Entity("API_RFID.Models.TipoTurno", b =>
                {
                    b.Property<int>("TipoTurnoID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Entrada")
                        .HasColumnType("time");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<TimeSpan>("Salida")
                        .HasColumnType("time");

                    b.HasKey("TipoTurnoID");

                    b.ToTable("TipoTurno", (string)null);

                    b.HasData(
                        new
                        {
                            TipoTurnoID = 1,
                            Entrada = new TimeSpan(0, 8, 0, 0, 0),
                            Nombre = "Normal",
                            Salida = new TimeSpan(0, 19, 0, 0, 0)
                        },
                        new
                        {
                            TipoTurnoID = 2,
                            Entrada = new TimeSpan(0, 7, 0, 0, 0),
                            Nombre = "Normal",
                            Salida = new TimeSpan(0, 18, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("API_RFID.Models.Trabajador", b =>
                {
                    b.Property<int>("TrabajadorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrabajadorID"));

                    b.Property<string>("A_Materno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("A_Paterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("AreaID")
                        .HasColumnType("int");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rfc")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("RfidCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TipoTurnoID")
                        .HasColumnType("int");

                    b.HasKey("TrabajadorID");

                    b.HasIndex("AreaID");

                    b.HasIndex("Curp")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Rfc")
                        .IsUnique();

                    b.HasIndex("RfidCode")
                        .IsUnique();

                    b.HasIndex("TipoTurnoID");

                    b.ToTable("Trabajador", (string)null);

                    b.HasData(
                        new
                        {
                            TrabajadorID = 1,
                            AMaterno = "Velazquez",
                            APaterno = "Carrillo",
                            AreaID = 13,
                            Curp = "CAVD990306HVZRLV01",
                            Email = "davidacarrillovz@outlook.com",
                            Nombres = "David",
                            Rfc = "CAVD990306LS4",
                            RfidCode = "0000145236",
                            TipoTurnoID = 1
                        },
                        new
                        {
                            TrabajadorID = 2,
                            AMaterno = "Beltrán",
                            APaterno = "Torres",
                            AreaID = 3,
                            Curp = "TOBJ980528JUT9P4",
                            Email = "juanmanueltb06@outlook.com",
                            Nombres = "Juan Manuel",
                            Rfc = "TOBJ980528ZK8",
                            RfidCode = "0000145233",
                            TipoTurnoID = 1
                        },
                        new
                        {
                            TrabajadorID = 3,
                            AMaterno = "Shimabuko",
                            APaterno = "Jimenez",
                            AreaID = 10,
                            Curp = "JISO980619HVJRMK07",
                            Email = "oscjimenez55@outlook.com",
                            Nombres = "Oscar",
                            Rfc = "JISO980619MI6",
                            RfidCode = "0000145234",
                            TipoTurnoID = 2
                        },
                        new
                        {
                            TrabajadorID = 4,
                            AMaterno = "Belmán",
                            APaterno = "Gonzalez",
                            AreaID = 11,
                            Curp = "GOBM990427HVZRBB41",
                            Email = "marcosgblm99@outlook.com",
                            Nombres = "Márcos Antonio",
                            Rfc = "GOBM990427YU9",
                            RfidCode = "0000145235",
                            TipoTurnoID = 1
                        });
                });

            modelBuilder.Entity("EntradaSalida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("A_MaternoT")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("A_PaternoT")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Entrada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreArea")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreTurno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombresT")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RfcT")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("RfidCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TrabajadorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrabajadorID");

                    b.ToTable("EntradaSalida", (string)null);
                });

            modelBuilder.Entity("API_RFID.Models.Trabajador", b =>
                {
                    b.HasOne("API_RFID.Models.Area", "Area")
                        .WithMany("Trabajadores")
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("API_RFID.Models.TipoTurno", "TipoTurno")
                        .WithMany("Trabajadores")
                        .HasForeignKey("TipoTurnoID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Area");

                    b.Navigation("TipoTurno");
                });

            modelBuilder.Entity("EntradaSalida", b =>
                {
                    b.HasOne("API_RFID.Models.Trabajador", "Trabajador")
                        .WithMany("Entradas")
                        .HasForeignKey("TrabajadorID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("API_RFID.Models.Area", b =>
                {
                    b.Navigation("Trabajadores");
                });

            modelBuilder.Entity("API_RFID.Models.TipoTurno", b =>
                {
                    b.Navigation("Trabajadores");
                });

            modelBuilder.Entity("API_RFID.Models.Trabajador", b =>
                {
                    b.Navigation("Entradas");
                });
#pragma warning restore 612, 618
        }
    }
}
