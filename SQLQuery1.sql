CREATE DATABASE XzBooksDb;
GO

USE XzBooksDb;
GO

CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    Genre NVARCHAR(100) NOT NULL,
    Publisher NVARCHAR(255) NOT NULL,
    Year INT NOT NULL
);
GO

INSERT INTO Books (Title, Author, Genre, Publisher, Year) VALUES
('The Silent Patient', 'Alex Michaelides', 'Thriller', 'Celadon Books', 2019),
('Atomic Habits', 'James Clear', 'Self-help', 'Penguin', 2018),
('1984', 'George Orwell', 'Dystopian', 'Secker & Warburg', 1949),
('The Hobbit', 'J.R.R. Tolkien', 'Fantasy', 'George Allen & Unwin', 1937),
('Clean Code', 'Robert C. Martin', 'Programming', 'Prentice Hall', 2008);
GO
