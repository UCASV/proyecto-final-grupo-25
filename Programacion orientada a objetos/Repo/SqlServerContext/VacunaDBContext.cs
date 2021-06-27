using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class VacunaDBContext : DbContext
    {
        public VacunaDBContext()
        {
        }

        public VacunaDBContext(DbContextOptions<VacunaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabina> Cabinas { get; set; }
        public virtual DbSet<Ciudadano> Ciudadanos { get; set; }
        public virtual DbSet<EfectoSec> EfectoSecs { get; set; }
        public virtual DbSet<Enfermedad> Enfermedads { get; set; }
        public virtual DbSet<Gestor> Gestors { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<RegistroEfecto> RegistroEfectos { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; }
        public virtual DbSet<TipoVacuna> TipoVacunas { get; set; }
        public virtual DbSet<Vacuna> Vacunas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=VacunaDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cabina>(entity =>
            {
                entity.ToTable("cabina");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefono")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Ciudadano>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__ciudadan__D876F1BE771DAB10");

                entity.ToTable("ciudadano");

                entity.Property(e => e.Dui)
                    .ValueGeneratedNever()
                    .HasColumnName("dui");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdentificadorInst).HasColumnName("identificador_inst");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<EfectoSec>(entity =>
            {
                entity.ToTable("efecto_sec");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EfectoSec1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("efecto_sec");
            });

            modelBuilder.Entity<Enfermedad>(entity =>
            {
                entity.ToTable("enfermedad");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EnfermedadCronica)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("enfermedad_cronica");

                entity.Property(e => e.IdCiudadano).HasColumnName("id_ciudadano");

                entity.HasOne(d => d.IdCiudadanoNavigation)
                    .WithMany(p => p.Enfermedads)
                    .HasForeignKey(d => d.IdCiudadano)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enfermeda__id_ci__3D5E1FD2");
            });

            modelBuilder.Entity<Gestor>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__gestor__C83612B12648040F");

                entity.ToTable("gestor");

                entity.Property(e => e.Identificador)
                    .ValueGeneratedNever()
                    .HasColumnName("identificador");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdCabinaAdmin).HasColumnName("id_cabina_admin");

                entity.Property(e => e.IdTipoEmpleado).HasColumnName("id_tipo_empleado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdCabinaAdminNavigation)
                    .WithMany(p => p.Gestors)
                    .HasForeignKey(d => d.IdCabinaAdmin)
                    .HasConstraintName("FK__gestor__id_cabin__38996AB5");

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.Gestors)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__gestor__id_tipo___37A5467C");
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.ToTable("registro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.IdCabina).HasColumnName("id_cabina");

                entity.Property(e => e.IdGestor).HasColumnName("id_gestor");

                entity.HasOne(d => d.IdCabinaNavigation)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.IdCabina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__registro__id_cab__35BCFE0A");

                entity.HasOne(d => d.IdGestorNavigation)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.IdGestor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__registro__id_ges__36B12243");
            });

            modelBuilder.Entity<RegistroEfecto>(entity =>
            {
                entity.ToTable("registro_efecto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.IdEfectoSec).HasColumnName("id_efecto_sec");

                entity.Property(e => e.IdVacuna).HasColumnName("id_vacuna");

                entity.HasOne(d => d.IdEfectoSecNavigation)
                    .WithMany(p => p.RegistroEfectos)
                    .HasForeignKey(d => d.IdEfectoSec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__registro___id_ef__3F466844");

                entity.HasOne(d => d.IdVacunaNavigation)
                    .WithMany(p => p.RegistroEfectos)
                    .HasForeignKey(d => d.IdVacuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__registro___id_va__3E52440B");
            });

            modelBuilder.Entity<TipoEmpleado>(entity =>
            {
                entity.ToTable("tipo_empleado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoEmpleado1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_empleado");
            });

            modelBuilder.Entity<TipoVacuna>(entity =>
            {
                entity.ToTable("tipo_vacuna");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoVacuna1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_vacuna");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.ToTable("vacuna");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CitaFechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("cita_fecha_hora");

                entity.Property(e => e.ColaFechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("cola_fecha_hora");

                entity.Property(e => e.IdCabina).HasColumnName("id_cabina");

                entity.Property(e => e.IdCiudadano).HasColumnName("id_ciudadano");

                entity.Property(e => e.IdGestor).HasColumnName("id_gestor");

                entity.Property(e => e.IdTipoVacuna).HasColumnName("id_tipo_vacuna");

                entity.Property(e => e.VacunaFechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("vacuna_fecha_hora");

                entity.HasOne(d => d.IdCabinaNavigation)
                    .WithMany(p => p.Vacunas)
                    .HasForeignKey(d => d.IdCabina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vacuna__id_cabin__3A81B327");

                entity.HasOne(d => d.IdCiudadanoNavigation)
                    .WithMany(p => p.Vacunas)
                    .HasForeignKey(d => d.IdCiudadano)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vacuna__id_ciuda__3C69FB99");

                entity.HasOne(d => d.IdGestorNavigation)
                    .WithMany(p => p.Vacunas)
                    .HasForeignKey(d => d.IdGestor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vacuna__id_gesto__3B75D760");

                entity.HasOne(d => d.IdTipoVacunaNavigation)
                    .WithMany(p => p.Vacunas)
                    .HasForeignKey(d => d.IdTipoVacuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vacuna__id_tipo___398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
