Create Table tbl_Login (
	idLogin int primary key identity(1,1),
	usuario varchar(150),
	hash varbinary(max),
	salt varbinary(max),
	dthCriacao datetime
)
Create Table tbl_Cidade(
	idCidade int primary key identity(1,1),
	Nome_Cidade varchar(150),
	Nome_Estado varchar(150),
	Sigla_Estado varchar(10)
)
Create Table tbl_Usuario(
	idUsuario int primary key identity(1,1),
	Nome_Usuario varchar(150),
	CPF_CNPJ varchar(20),
	dthNascimento date,
	tUsuario bit,
	CEP varchar(9),
	Rua varchar(150),
	idCidade int,
	idLogin int,
	dthRegistro dateTime,
	constraint fk_idCidade_tbl_Cidade foreign key (idCidade) references tbl_Cidade(idCidade),
	constraint fk_idLogin_tbl_Login foreign key (idLogin) references tbl_Login(idLogin)
)