CREATE DATABASE NaturVidaDb;

CREATE TABLE Clientes (
	cliId			INT PRIMARY KEY,	
	cliDocumento	INT,
	cliNombre		VARCHAR(35),
	cliDireccion	VARCHAR(35),
	cliTelefono		INT,
	cliCorreo		VARCHAR(50),
)

CREATE TABLE Vendedores (
	venId			INT PRIMARY KEY,
	venUsuario		VARCHAR(35),
	venContrasena	VARCHAR(35),
)

CREATE TABLE Productos (
	proCodigo			INT PRIMARY KEY,
	proDescripcion		VARCHAR(35),
	proValor			INT,
	proCantidad			INT,
)

CREATE TABLE Facturas (
	facNumero		INT PRIMARY KEY,
	facFecha		DATETIME,
	facValorTotal	VARCHAR(35),
	facTelefono		INT,
	facCliente		INT FOREIGN KEY REFERENCES Clientes(cliId),
	facVendedor		INT FOREIGN KEY REFERENCES Vendedores(venId)
)

CREATE TABLE FacturaDetalle (
	facdCantidad	INT,
	facdNucFactura	INT FOREIGN KEY REFERENCES Facturas(facNumero),
	facdProducto	INT FOREIGN KEY REFERENCES Productos(proCodigo)
)
