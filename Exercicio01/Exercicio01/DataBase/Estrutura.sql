DROP TABLE notas;

CREATE TABLE notas(
id INT IDENTITY(1,1) PRIMARY KEY,
nome VARCHAR(100)NOT NULL,
matricula VARCHAR(100) NOT NULL,
nota01 REAL NOT NULL,
nota02 REAL NOT NULL,
nota03 REAL NOT NULL,
frequencia Tinyint NOT NULL,
faltas Tinyint NOT NULL

);

INSERT INTO notas  VALUES
('Adrian','123123123',10,10,10,98,5);



SELECT id, nome, matricula, nota01, nota02, nota03, frequencia, faltas FROM notas