create database AC_Score
go
use AC_Score
go

CREATE TABLE [Sede] (
  [IdSede] varchar(36)  default newid(),
  [Sede] varchar(30),
  PRIMARY KEY ([IdSede])
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
  [Tipo] varchar(1),
  [Usuario] varchar(30),
  [Contraseña] varchar(64),
  [IdRol] varchar(36),
  PRIMARY KEY ([IdUsuario]),
  CONSTRAINT [FK_Usuario.IdRol]
    FOREIGN KEY ([IdRol])
      REFERENCES [Entidad]([IdRol])
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
  [IdSede] varchar(36),
  PRIMARY KEY ([IdCarrera]),
  CONSTRAINT [FK_Carrera.IdSede]
    FOREIGN KEY ([IdSede])
      REFERENCES [Sede]([IdSede])
);

CREATE TABLE [Curso] (
  [IdCurso] varchar(36)  default newid() ,
  [Curso] varchar(30),
  [IdCarrera] varchar(36),
  [IdUsuario] varchar(36),
  [idPeriodicidad] varchar(36),
  PRIMARY KEY ([IdCurso]),
  CONSTRAINT [FK_Curso.IdUsuario]
    FOREIGN KEY ([IdUsuario])
      REFERENCES [Usuario]([IdUsuario]),
  CONSTRAINT [FK_Curso.idPeriodicidad]
    FOREIGN KEY ([idPeriodicidad])
      REFERENCES [Periodicidad]([IdPeriodicidad]),
  CONSTRAINT [FK_Curso.IdCarrera]
    FOREIGN KEY ([IdCarrera])
      REFERENCES [Carrera]([IdCarrera])
);

CREATE TABLE [DetalleCurso] (
  [IdDetalleCurso] varchar(36)  default newid(),
  [IdCurso] varchar(36),
  [IdUsuario] varchar(36),
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
  PRIMARY KEY ([IdDetalleCurso], [IdCurso], [IdUsuario]),
  CONSTRAINT [FK_DetalleCurso.IdUsuario]
    FOREIGN KEY ([IdUsuario])
      REFERENCES [Usuario]([IdUsuario]),
  CONSTRAINT [FK_DetalleCurso.IdCurso]
    FOREIGN KEY ([IdCurso])
      REFERENCES [Curso]([IdCurso])
);



-- inserts

INSERT INTO usuario ( [Contraseña], [IdRol], [IdUsuario], [NoIdentificacion], [PrimerApellido], [PrimerNombre], [Profesion], [SegundoApellido], [SegundoNombre], [TercerNombre], [Tipo], [Usuario]) VALUES ('A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3' ,'F7375042-3E59-4BFA-A1F6-451769896647' ,'B0A9A513-9D6E-4FE7-9173-862AD58B4727' ,'41234' ,'Cordero' ,'Albin' ,'Ingeniero' ,'Garcia' ,'Leonel' ,'' ,'A' ,'albin' )