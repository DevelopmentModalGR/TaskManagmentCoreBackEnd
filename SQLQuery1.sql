select * from dbo.CheckOutProcess


select * from dbo.Departments

select * from dbo.DepartmentUser

select * from dbo.Jobs

select * from dbo.JobsUser

select * from dbo.Users

select * from dbo.Companies


DELETE FROM dbo.Users WHERE Email = 'renato@123.com'

Delete from dbo.companies where id = 3


INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Toninho Do fusca Adega', '12345678910');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Bar da F�tima', '12346781111');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Dona Tonha Mercearia', '14775719111');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'ModalGR', '45771748811');

INSERT INTO dbo.Departments(name)
VALUES ('Administra��o');
INSERT INTO dbo.Departments(name)
VALUES ('RH');
INSERT INTO dbo.Departments(name)
VALUES ('TI');
INSERT INTO dbo.Departments(name)
VALUES ('Gerencia');


INSERT INTO dbo.CheckOutProcess(name, DepartmentId, Description, StartDate, Enddate)
VALUES ( 'Pegar manga no p�', 1, 'Pegar as mangas no quintal dos outros n� brother', '0001-01-01T00:00:00', '0001-01-01T00:00:00');
INSERT INTO dbo.CheckOutProcess(name, DepartmentId, Description, StartDate, Enddate)
VALUES ( 'Correr Atr�s das Pipas', 4, 'Chegou a epoca de ferias mulec�o b� pegar pipa e se ralar feito trouxa :D', '0001-01-01T00:00:00', '0001-01-01T00:00:00');
INSERT INTO dbo.CheckOutProcess(name, DepartmentId, Description, StartDate, Enddate)
VALUES ( 'Tentar N�o ser assassinado pelo agiota', 4, 'peguei 100 conto com o agiota a 3 anos e o maluco ta putasso', '0001-01-01T00:00:00', '0001-01-01T00:00:00');

INSERT INTO dbo.Jobs(name, PredecessorTaskStatus, StartDate, EndDate, status, CheckoutProcessId)
VALUES ( 'Pegar o Pipa e se ralar', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 2)
INSERT INTO dbo.Jobs(name, PredecessorTaskStatus, StartDate, EndDate, status, CheckoutProcessId)
VALUES ( 'Quebrei a telha da dona zilda', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 2)
INSERT INTO dbo.Jobs(name, PredecessorTaskStatus, StartDate, EndDate, status, CheckoutProcessId)
VALUES ( 'Fudeu, o agiota ta me procurando', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3)

INSERT INTO dbo.Users(name, Email, SignUpDate, IsActive, IsAdmin, Password,Role)
VALUES ('Renato Santos', 'renato@123.com','0001-01-01T00:00:00', 1,1, '123456', 'manager')
INSERT INTO dbo.Users(name, Email, SignUpDate, IsActive, IsAdmin, Password,Role)
VALUES ('Andre Ribeiro', 'AndrezinhoReiDelas_2002@123.com','0001-01-01T00:00:00', 1,0, '123456', 'manager')
INSERT INTO dbo.Users(name, Email, SignUpDate, IsActive, IsAdmin, Password,Role)
VALUES ('Angelo Brabo', 'Agenlao@123.com','0001-01-01T00:00:00', 1,0, '123456', 'manager')