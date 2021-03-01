use TaskManagmentCore

select * from dbo.CheckOutProcesses


select * from dbo.Departments

select * from dbo.DepartmentUser

select * from dbo.Jobs

select * from dbo.JobsUser

select * from dbo.Users

select * from dbo.Companies



select * from dbo.Users


DELETE FROM dbo.Users WHERE Email = 'renato@123.com'

DELETE FROM dbo.Users WHERE Name = 'teste'

DELETE FROM dbo.Users WHERE Email = 'testando@123.com'

Delete from dbo.Users where id = 1015

Delete from dbo.companies where id = 3

delete from dbo.companies  where Name = 'Teste'



UPDATE dbo.Users
SET CompanyId = 106
WHERE name = 'Renato Santos';



INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Toninho Do fusca - Adega e Mercearia', '12345678910');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Bar da Fátima', '12346781111');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Dona Tonha Mercearia', '14775719111');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Modal Gestão e Resultados', '45771748811');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Teste', '41476359000117');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'Bar da Vera', '35033683000168');
INSERT INTO dbo.Companies(name, cnpj)
VALUES ( 'RocketSeat', '15262144000193');


INSERT INTO dbo.Departments(name)
VALUES ('Administração');
INSERT INTO dbo.Departments(name)
VALUES ('RH');
INSERT INTO dbo.Departments(name)
VALUES ('TI');
INSERT INTO dbo.Departments(name)
VALUES ('Gerencia');
INSERT INTO dbo.Departments(name)
VALUES ('Gerencia'),('Operação'),('Segurança do Trabalho'),('Infraestrutura'),('TechLead');



INSERT INTO dbo.CheckOutProcesses(name, DepartmentId, Description, StartDate, Enddate)
VALUES ( 'Pegar manga no pé', 1, 'Pegar as mangas no quintal dos outros né brother', '0001-01-01T00:00:00', '0001-01-01T00:00:00');
INSERT INTO dbo.CheckOutProcesses(name, DepartmentId, Description, StartDate, Enddate)
VALUES ( 'Correr Atrás das Pipas', 4, 'Chegou a epoca de ferias mulecão bó pegar pipa e se ralar feito trouxa :D', '0001-01-01T00:00:00', '0001-01-01T00:00:00');
INSERT INTO dbo.CheckOutProcesses(name, DepartmentId, Description, StartDate, Enddate)
VALUES ( 'Tentar Não ser assassinado pelo agiota', 4, 'peguei 100 conto com o agiota a 3 anos e o maluco ta putasso', '0001-01-01T00:00:00', '0001-01-01T00:00:00');

INSERT INTO dbo.Jobs(name, PredecessorTaskStatus, StartDate, EndDate, status, CheckoutProcessId)
VALUES ( 'Pegar o Pipa e se ralar', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 2)
INSERT INTO dbo.Jobs(name, PredecessorTaskStatus, StartDate, EndDate, status, CheckoutProcessId)
VALUES ( 'Quebrei a telha da dona zilda', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 2)
INSERT INTO dbo.Jobs(name, PredecessorTaskStatus, StartDate, EndDate, status, CheckoutProcessId)
VALUES ( 'Fudeu, o agiota ta me procurando', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3)

INSERT INTO dbo.Users(name, Email, SignUpDate, IsActive, IsAdmin, Password,Role, CompanyId)
VALUES ('Renato Santos', 'renato@123.com','2021-02-28T01:21:11', 1,1, '123456', 'manager',4)
INSERT INTO dbo.Users(name, Email, SignUpDate, IsActive, IsAdmin, Password,Role, CompanyId)
VALUES ('Andre Ribeiro', 'AndrezinhoReiDelas_2002@123.com','2021-02-21T01:21:12', 1,0, '123456', 'manager',2)
INSERT INTO dbo.Users(name, Email, SignUpDate, IsActive, IsAdmin, Password,Role, CompanyId)
VALUES ('Angelo Brabo', 'Angelao@123.com','2020-01-28T01:21:11', 1,0, '123456', 'manager',3)
INSERT INTO dbo.Users(name, Email, SignUpDate, IsActive, IsAdmin, Password,Role, CompanyId)
VALUES ('manager', 'oBrabo@123.com','2021-01-12T12:12:11', 1,1, '123456', 'admin',1)

INSERT INTO DepartmentUser(DepartmentsId, UsersId)
Values(1,1)

INSERT INTO DepartmentUser(DepartmentsId, UsersId)
Values(4,1),(1,1),(2,1),(3,1),(6,1);

INSERT INTO JobsUser(JobsId, UsersId)
Values(1,1),(3,1),(2,1);