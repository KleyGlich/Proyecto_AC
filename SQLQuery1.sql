Drop database  AC_Score
go

create database  AC_Score

go
use AC_Score
CREATE TABLE [Sede] (
  [IdSede] varchar(36)  default newid(),
  [Sede] varchar(30),
  PRIMARY KEY ([IdSede])
);

CREATE TABLE [Periodicidad] (
  [IdPeriodicidad] varchar(36) default newid(),
  [Nombre] varchar(30),
  [Descripcion] varchar(75),
  PRIMARY KEY ([IdPeriodicidad])
);

CREATE TABLE [Carrera] (
  [IdCarrera] varchar(36)  default newid(),
  [Carrera] varchar(30),
  [Estudiante] varchar(36),
  [IdSede] varchar(36),
  PRIMARY KEY ([IdCarrera]),
  CONSTRAINT [FK_Carrera.IdSede]
    FOREIGN KEY ([IdSede])
      REFERENCES [Sede]([IdSede])
);

CREATE TABLE [Entidad] (
  [IdRol] varchar(36)  default newid(),
  [Nombre] varchar(30),
  [Descripcion] varchar(50),
  PRIMARY KEY ([IdRol])
);

CREATE TABLE [Usuario] (
  [IdUsuario] varchar(36)  default newid(),
  [PrimerNombre] varchar(30),
  [SegundoNombre] varchar(30),
  [TercerNombre] varchar(30),
  [PrimerApellido] varchar(30),
  [SegundoApellido] varchar(30),
  [NoIdentificacion] bigint,
  [Profesion] varchar(30),
  [Tipo] varchar(30),
  [Usuario] varchar(30),
  [Contraseña] varchar(64),
  [IdRol] varchar(36),
  PRIMARY KEY ([IdUsuario]),
  CONSTRAINT [FK_Usuario.IdRol]
    FOREIGN KEY ([IdRol])
      REFERENCES [Entidad]([IdRol])
);

CREATE TABLE [Curso] (
  [IdCurso] varchar(36)  default newid(),
  [Curso] varchar(30),
  [IdCarrera] varchar(36),
  [IdUsuario] varchar(36),
  [idPeriodicidad] varchar(36),
  PRIMARY KEY ([IdCurso]),
  CONSTRAINT [FK_Curso.idPeriodicidad]
    FOREIGN KEY ([idPeriodicidad])
      REFERENCES [Periodicidad]([IdPeriodicidad]),
  CONSTRAINT [FK_Curso.IdCarrera]
    FOREIGN KEY ([IdCarrera])
      REFERENCES [Carrera]([IdCarrera]),
  CONSTRAINT [FK_Curso.IdUsuario]
    FOREIGN KEY ([IdUsuario])
      REFERENCES [Usuario]([IdUsuario])
);

CREATE TABLE [Estudiante] (
  [IdUsuario] varchar(36)  default newid(),
  [PrimerNombre] varchar(30),
  [SegundoNombre] varchar(30),
  [TercerNombre] varchar(30),
  [PrimerApellido] varchar(30),
  [SegundoApellido] varchar(30),
  [NoIdentificacion] bigint,
  [Usuario] varchar(30),
  [Contraseña] varchar(64),
  [Inscripcion] Date,
  [IdRol] varchar(36) default 'Student' ,
  PRIMARY KEY ([IdUsuario])
);

CREATE TABLE [DetalleCurso] (
  [IdDetalleCurso] varchar(36)  default newid(),
  [IdCurso] varchar(36),
  [Estudiante] varchar(36),
  [PrimerParcial] int,
  [SegundoParcial] int,
  [Actividades] int,
  [ProyectoFinal] int,
  [Extraordinario] int,
  [Estado] bit,
  [FechaIngresoNota] date ,
  [FechaFinalizacion] date,
  [NumeroActa] int,
  [Año] varchar(4),
  PRIMARY KEY ([IdDetalleCurso], [IdCurso], [Estudiante]),
  CONSTRAINT [FK_DetalleCurso.IdCurso]
    FOREIGN KEY ([IdCurso])
      REFERENCES [Curso]([IdCurso]),
  CONSTRAINT [FK_DetalleCurso.Estudiante]
    FOREIGN KEY ([Estudiante])
      REFERENCES [Estudiante]([IdUsuario])
);

CREATE TABLE [Estudiante_Carrera] (
  [ID_Estu] varchar(36)  default newid(),
  [IdCarrera] varchar(36),
  [Estudiante] varchar(36),
  PRIMARY KEY ([ID_Estu]),
  CONSTRAINT [FK_Estudiante_Carrera.Estudiante]
    FOREIGN KEY ([Estudiante])
      REFERENCES [Estudiante]([IdUsuario]),
  CONSTRAINT [FK_Estudiante_Carrera.IdCarrera]
    FOREIGN KEY ([IdCarrera])
      REFERENCES [Carrera]([IdCarrera])
);

