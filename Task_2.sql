-- Создаем отношение продукты и категории
CREATE TABLE Product (
	id INT PRIMARY KEY IDENTITY, 
  	name VARCHAR2 (100) NOT NULL
)

CREATE TABLE Category (
	id INT PRIMARY KEY IDENTITY,
  	name VARCHAR2 (100) NOT NULL
)

-- Создаем отношение продукты_категории
CREATE TABLE ProdCategory (
	id INT PRIMARY KEY IDENTITY,
  	prod_id INT NOT NULL,
  	cat_id INT NOT NUL,
  	FOREIGN KEY (prod_id) REFERENCES Prod (prod_id) ON DELETE CASCADE,
    FOREIGN KEY (cat_id) REFERENCES Category (cat_id) ON DELETE CASCADE
)

-- Доваляем в котрежи в отношение продуктами
INSERT INTO Prod (prod_name)
VALUES
	('Вилка'),
    ('Ложка'),
    ('Нож'),
	('Крущка-ложка')
	
-- Доваляем в котрежи в отношение категории
INSERT INTO Category (cat_name)
VALUES
	('Столовый'),
    ('Декоративый'),
    ('Кухоный')
	

-- Доваляем в котрежи в продукты_категории
INSERT INTO ProdCategory (prod_id, cat_id)
VALUES
    (1, 1),
    (2, 1),
    (2, 2),
    (3, 1),
    (3, 2),
    (3, 3),
    (4, NULL)

-- Удаляем категорию "Декоративый"
DELETE FROM Category
WHERE cat_name = 'Декоративый'

-- Запрос
SELECT 
    p.prod_name,
    c.cat_name
FROM ProdCategory pc 
LEFT JOIN Prod p ON pc.prod_id = p.prod_id
LEFT JOIN Category c ON pc.cat_id = c.cat_id
