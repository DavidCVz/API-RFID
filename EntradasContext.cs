using Microsoft.EntityFrameworkCore;
using API_RFID.Models;
using API_RFID.Seeds;

namespace API_RFID
{
    public class EntradasContext : DbContext
    {
        // La definicion de estas colecciones generara tablas en la BD
        public DbSet<Area> Areas { get; set; }
        public DbSet<TipoTurno> TipoTurnos { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<EntradaSalida> EntradasSalidas { get; set; }
        public EntradasContext(DbContextOptions<EntradasContext> options) : base(options) { }
        private ContextSeeds seeds = new ContextSeeds();

        //Definiendo las reglas de los atributos de cada entidad (Tabla)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /// SEEDS
            var areaInit = new List<Area>();
            var turnosInit = new List<TipoTurno>();
            var trabajadorInit = new List<Trabajador>();

            areaInit = seeds.GetAreasSeed();
            turnosInit = seeds.GetTurnosSeed();
            trabajadorInit = seeds.GetTrabajadoresSeed();

            /// TABLAS PADRES
            //Area
            modelBuilder.Entity<Area>(area =>
            {
                area.ToTable("Area");
                // Clave primaria
                area.HasKey(p => p.AreaID);
                // Atributos
                area.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                // Para agregar datos iniciales a la tabla area se usa la funcion HasData
                // recibiendo como parametro una lista de datos de areas
                area.HasData(areaInit);
            });

            //TipoTurno
            modelBuilder.Entity<TipoTurno>(turno =>
            {
                turno.ToTable("Area");
                // Clave primaria
                turno.HasKey(p => p.TipoTurnoID);
                // Atributos
                turno.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                turno.Property(p => p.Entrada).IsRequired();
                // Seeds
                turno.HasData(turnosInit);
            });

            ///HIJO (Nivel 1)
            modelBuilder.Entity<Trabajador>(trabajador =>
            {
                trabajador.ToTable("Trabajador");
                //Clave primaria
                trabajador.HasKey(p => p.TrabajadorID);
                // DEFINICION PARA CLAVES FORANEAS
                // p.Area es la propiedad virtual en la clase Trabajador 
                // p.Trabajadores es la propiedad virtual en la clase Area
                // p.AreaID, es el atributo clave que relaciona las tablas en la clase Trabajador
                trabajador.HasOne(p => p.Area).WithMany(p => p.Trabajadores).HasForeignKey(p => p.AreaID).OnDelete(DeleteBehavior.SetNull);
                trabajador.HasOne(p => p.TipoTurno).WithMany(p => p.Trabajadores).HasForeignKey(p => p.TipoTurnoID).OnDelete(DeleteBehavior.SetNull);
                //Atributos
                trabajador.Property(p => p.AreaID).IsRequired(false);
                trabajador.Property(p => p.TipoTurnoID).IsRequired(false);
                trabajador.Property(p => p.RfidCode).IsRequired().HasMaxLength(10);
                trabajador.Property(p => p.Nombres).IsRequired().HasMaxLength(50);
                trabajador.Property(p => p.A_Paterno).IsRequired().HasMaxLength(50);
                trabajador.Property(p => p.A_Materno).IsRequired().HasMaxLength(50);
                trabajador.Property(p => p.Rfc).IsRequired().HasMaxLength(13);
                trabajador.Property(p => p.Curp).IsRequired().HasMaxLength(18);
                trabajador.Property(p => p.Email).IsRequired().HasMaxLength(255);
                // Seeds
                trabajador.HasData(trabajadorInit);
            });
            // Configuracion de Constraints de Trabajador
            modelBuilder.Entity<Trabajador>().HasIndex(u => u.RfidCode).IsUnique();
            modelBuilder.Entity<Trabajador>().HasIndex(u => u.Rfc).IsUnique();
            modelBuilder.Entity<Trabajador>().HasIndex(u => u.Curp).IsUnique();
            modelBuilder.Entity<Trabajador>().HasIndex(u => u.Email).IsUnique();

            ///HIJO (Nivel 2)
            modelBuilder.Entity<EntradaSalida>().Property(p => p.Id).ValueGeneratedOnAdd(); // Estableciendo regla de autoincremento
            modelBuilder.Entity<EntradaSalida>(entradaS =>
            {
                entradaS.ToTable("EntradaSalida");
                //Clave primaria
                entradaS.HasKey(p => p.Id);
                // DEFINICION PARA CLAVES FORANEAS
                entradaS.HasOne(p => p.Trabajador).WithMany(p => p.Entradas).HasForeignKey(p => p.TrabajadorID).OnDelete(DeleteBehavior.SetNull);
                //Atributos
                entradaS.Property(p => p.TrabajadorID).IsRequired(false);
                entradaS.Property(p => p.RfidCode).IsRequired().HasMaxLength(10);
                entradaS.Property(p => p.NombresT).IsRequired().HasMaxLength(50);
                entradaS.Property(p => p.A_PaternoT).IsRequired().HasMaxLength(50);
                entradaS.Property(p => p.A_MaternoT).IsRequired().HasMaxLength(50);
                entradaS.Property(p => p.RfcT).IsRequired().HasMaxLength(13);
                entradaS.Property(p => p.Fecha).IsRequired();
                entradaS.Property(p => p.NombreTurno).IsRequired().HasMaxLength(100);
                entradaS.Property(p => p.NombreArea).IsRequired().HasMaxLength(100);
                entradaS.Property(p => p.Entrada).IsRequired();
            });
        }
    }
}