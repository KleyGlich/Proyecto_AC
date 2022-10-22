using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gestor_Notas.Models
{
    public partial class AC_ScoreContext : DbContext
    {
        public AC_ScoreContext()
        {
        }

        public AC_ScoreContext(DbContextOptions<AC_ScoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<DetalleCurso> DetalleCursos { get; set; } = null!;
        public virtual DbSet<Entidad> Entidads { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<EstudianteCarrera> EstudianteCarreras { get; set; } = null!;
        public virtual DbSet<Periodicidad> Periodicidads { get; set; } = null!;
        public virtual DbSet<Sede> Sedes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AC_Score;user=sa;password=LDesarrollo#4;Trusted_Connection=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__Carrera__884A8F1FE8A3C591");

                entity.ToTable("Carrera");

                entity.Property(e => e.IdCarrera)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Carrera1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Carrera");

                entity.Property(e => e.IdSede)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdSede)
                    .HasConstraintName("FK_Carrera.IdSede");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D6694A05B9");

                entity.ToTable("Curso");

                entity.Property(e => e.IdCurso)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Curso1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Curso");

                entity.Property(e => e.IdCarrera)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.IdPeriodicidad)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("idPeriodicidad");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK_Curso.IdCarrera");

                entity.HasOne(d => d.IdPeriodicidadNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdPeriodicidad)
                    .HasConstraintName("FK_Curso.idPeriodicidad");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Curso.IdUsuario");
            });

            modelBuilder.Entity<DetalleCurso>(entity =>
            {
                entity.HasKey(e => new { e.IdDetalleCurso, e.IdCurso, e.Estudiante })
                    .HasName("PK__DetalleC__34DAF0D0F4E6F6D7");

                entity.ToTable("DetalleCurso");

                entity.Property(e => e.IdDetalleCurso)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdCurso)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Estudiante)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Año)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinalizacion).HasColumnType("date");

                entity.Property(e => e.FechaIngresoNota).HasColumnType("date");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.DetalleCursos)
                    .HasForeignKey(d => d.Estudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCurso.Estudiante");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.DetalleCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCurso.IdCurso");
            });

            modelBuilder.Entity<Entidad>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Entidad__2A49584CFEF3D574");

                entity.ToTable("Entidad");

                entity.Property(e => e.IdRol)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Estudian__5B65BF97BC8B0E9D");

                entity.ToTable("Estudiante");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Student')");

                entity.Property(e => e.Inscripcion).HasColumnType("date");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TercerNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstudianteCarrera>(entity =>
            {
                entity.HasKey(e => e.IdEstu)
                    .HasName("PK__Estudian__6053EECE9B1BF6D2");

                entity.ToTable("Estudiante_Carrera");

                entity.Property(e => e.IdEstu)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID_Estu")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Estudiante)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.IdCarrera)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.EstudianteCarreras)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK_Estudiante_Carrera.Estudiante");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.EstudianteCarreras)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK_Estudiante_Carrera.IdCarrera");
            });

            modelBuilder.Entity<Periodicidad>(entity =>
            {
                entity.HasKey(e => e.IdPeriodicidad)
                    .HasName("PK__Periodic__DA476CCDF3FC67ED");

                entity.ToTable("Periodicidad");

                entity.Property(e => e.IdPeriodicidad)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.HasKey(e => e.IdSede)
                    .HasName("PK__Sede__A7780DFF727482AA");

                entity.ToTable("Sede");

                entity.Property(e => e.IdSede)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sede1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Sede");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97B756D6BF");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Profesion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TercerNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuario.IdRol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
