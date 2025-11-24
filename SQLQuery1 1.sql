use RecentMemory;

Select * from Usuario;

INSERT INTO Usuario(nome, email, senha) VALUES
('Ana Souza', 'ana.souza@example.com', 'senha123'),
('Carlos Lima', 'carlos.lima@example.com', '123senha'),
('Mariana Alves', 'mariana.alves@example.com', 'mariana2025'),
('Jo�o Pereira', 'joao.pereira@example.com', 'joao@secure'),
('Marcos Augusto', 'marcos.augusto@example.com', 'marcos#2025'),
('Felipe Rocha', 'felipe.rocha@email.com', 'senha123'),
('Gabriela Torres', 'gabriela.torres@email.com', 'senha123'),
('Henrique Melo', 'henrique.melo@email.com', 'senha123'),
('Isabela Martins', 'isabela.martins@email.com', 'senha123'),
('Jo�o Pereira', 'joao.pereira@email.com', 'senha123');

Select * from Lugares;

INSERT INTO Lugares(nome) VALUES 
('Pra�a da Liberdade'), 
('Parque Ibirapuera'),
('Cristo Redentor'),
('Mercado Municipal'),
('Museu do Amanh�'),
( 'Trabalho'),
( 'Parque'),
( 'Restaurante'),
( 'Cinema'),
( 'Hospital');

Select * from Contatos;

INSERT INTO Contatos (nome, telefone, Usuario_id) VALUES
('Pedro Santos', ' 11 91234-5677', 1),
('Fernanda Costa', ' 21 99876-5432',2),
('Lucas Oliveira', ' 31 98765-4321',3),
('Juliana Martins', ' 41 97654-3210', 4),
('Ricardo Gomes', ' 61 96543-2109',5),
('Ricardo Silva', ' 11 94321-0987',6 ),
('Fernanda Dias', ' 11 93210-9876', 7),
('Thiago Barbosa', ' 11 92109-8765', 8),
('Patr�cia Nunes', ' 11 91098-7654',9),
('Andr� Ferreira', ' 11 90987-6543', 10);

SELECT  DISTINCT * from Usuario, Contatos, Lugares;

 /* Comentário 1*/

 
