use TaskManagmentCore

--SELECT

select * from "CheckOutProcesses"


select * from "Departments"

select * from "DepartmentUser"

select * from "Jobs"

select * from "JobsUser"

select * from "Users"

select * from "Companies""

select * from "Users"

--DELETTERS


DELETE FROM "Users" WHERE Email = 'renato@123.com'

DELETE FROM "Users" WHERE Name = 'teste'

DELETE FROM "Users" WHERE Email = 'testando@123.com'

Delete from "Users" where id = 1015

Delete from "companies"" where id = 3

delete from "companies""  where Name = 'Teste'

delete from "jobs"

delete from "JobsUser" where UsersId = 1



UPDATE "Users" SET CompanyId = 106 WHERE Name = 'Renato Santos';

UPDATE "Jobs" SET StartDate = DATEADD(SECOND, ABS(CHECKSUM(NEWID()) % 359011111), '2010-01-01') 



INSERT INTO "Companies"("Name", "CNPJ")
VALUES ( 'Toninho Do fusca - Adega e Mercearia', '12345678910');
INSERT INTO "Companies"("Name", "CNPJ")
VALUES ( 'Bar da Fatima', '12346781111');
INSERT INTO "Companies"("Name", "CNPJ")
VALUES ( 'Dona Tonha Mercearia', '14775719111');
INSERT INTO "Companies"("Name", "CNPJ")
VALUES ( 'Modal Gestao e Resultados', '45771748811');
INSERT INTO "Companies"("Name", "CNPJ")
VALUES ( 'Teste', '41476359000117');
INSERT INTO "Companies"("Name", "CNPJ")
VALUES ( 'Bar da Vera', '35033683000168');
INSERT INTO "Companies"("Name", "CNPJ")
VALUES ( 'RocketSeat', '15262144000193');


INSERT INTO "Departments"("Name")
VALUES ('Administraao');
INSERT INTO "Departments"("Name")
VALUES ('RH');
INSERT INTO "Departments"("Name")
VALUES ('TI');
INSERT INTO "Departments"("Name")
VALUES ('Gerencia');
INSERT INTO "Departments"("Name")
VALUES ('Gerencia'),('Operaao'),('Seguranaa do Trabalho'),('Infraestrutura'),('TechLead');



INSERT INTO "CheckOutProcesses"("Name", "DepartmentId", "Description", "StartDate", "EndDate")
VALUES ( 'Pegar manga no pa', 1, 'Pegar as mangas no quintal dos outros na brother', '0001-01-01T00:00:00', '0001-01-01T00:00:00');
INSERT INTO "CheckOutProcesses"("Name", "DepartmentId", "Description", "StartDate", "EndDate")
VALUES ( 'Correr Atras das Pipas', 4, 'Chegou a epoca de ferias mulecao ba pegar pipa e se ralar feito trouxa :D', '0001-01-01T00:00:00', '0001-01-01T00:00:00');
INSERT INTO "CheckOutProcesses"("Name", "DepartmentId", "Description", "StartDate", "EndDate")
VALUES ( 'Tentar Nao ser assassinado pelo agiota', 4, 'peguei 100 conto com o agiota a 3 anos e o maluco ta putasso', '0001-01-01T00:00:00', '0001-01-01T00:00:00');
INSERT INTO "CheckOutProcesses"("Name", "DepartmentId", "Description", "StartDate", "EndDate")
VALUES ( 'Tentando sobreviver', 4, 'a vida a foda meu parceiro', '0001-01-01T00:00:00', '0001-01-01T00:00:00');


INSERT INTO "Jobs"("Name", "PredecessorTaskStatus", "StartDate", "EndDate", "Status", "CheckoutProcessId")
VALUES ( 'Pegar o Pipa e se ralar', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 2),
( 'Quebrei a telha da dona zilda', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 2),
( 'Fudeu, o agiota ta me procurando', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Perdi o Busao :(', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Fui feito de trouxa e gostei', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'A mimir', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Acordei com as costas travada :(', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Achei vinte conto', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Apanhei da minha mulher', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Achei cinquenta conto', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Achei um relogio', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Fui comprar pao e me confundiram com o ibrahimovic', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Escovar os dentes a gay?', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Sera que estou ficando calvo?', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Sei la brother coloca qualquer merda ai 1', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Sei la brother coloca qualquer merda ai 2', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Sei la brother coloca qualquer merda ai 3', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Ja to sem ideia', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'pastel de frango', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'coxinha de ovo', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'nao sei ', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'sera que posso ir embora mais cedo?', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
( 'Fala ai meu mano', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Moqueca', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Carne de sol', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Tapioca', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Aaaa ', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Churrasco', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Pao de queijo', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha.', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 2', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 3', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 4', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 5', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 6', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 7', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 8', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 9', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 10', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 12', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 32', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Coxinha 24', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Bartira Cascais', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Dino Villas Baas', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Eva Fiestas', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Geraldo Rico', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Josua Aveiro', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Macia Brito', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Natalia Granja', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Noamia Perdigao', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Renan Baptista', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Sebastiana Quintela', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Noel Alcaide', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Vator ou Victor Benavides', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Jacinto Vergueiro Liliana Brites', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Noel Alcaide', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Teodoro Canto', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 3),
('Fudeu, o agiota ta me procurando 1234', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 1),
('Caralho aquele marcelo a foda', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 4),
('Oque eu tava pensando quando virei programador?', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 4),
('Cachaaa caraio', 1, '0001-01-01T00:00:00','0001-01-01T00:00:00', 1, 4)




INSERT INTO "Users"("Name", "Email", "SignUpDate", "IsActive", "IsAdmin", "Password","Role", "CompanyId")
VALUES ('Renato Santos', 'renato@123.com','2021-02-28T01:21:11', 1,1, '123456', 'manager',4)
INSERT INTO "Users"("Name", "Email", "SignUpDate", "IsActive", "IsAdmin", "Password","Role", "CompanyId")
VALUES ('Andre Ribeiro', 'AndrezinhoReiDelas_2002@123.com','2021-02-21T01:21:12', 1,0, '123456', 'manager',2)
INSERT INTO "Users"("Name", "Email", "SignUpDate", "IsActive", "IsAdmin", "Password","Role", "CompanyId")
VALUES ('Angelo Brabo', 'Angelao@123.com','2020-01-28T01:21:11', 1,0, '123456', 'manager',3)
INSERT INTO "Users"("Name", "Email", "SignUpDate", "IsActive", "IsAdmin", "Password","Role", "CompanyId")
VALUES ('manager', 'oBrabo@123.com','2021-01-12T12:12:11', 1,1, '123456', 'admin',1)

INSERT INTO "DepartmentUser"("DepartmentsId", "UsersId")
Values(1,1)

INSERT INTO "DepartmentUser"("DepartmentsId", "UsersId")
Values(4,1),(2,1),(3,1),(6,1);

INSERT INTO "JobsUser"("JobsId", "UsersId")
Values(1,1),(32,1),(31,1),(24,1),(33,1),(12,1),(15,1),(22,1);