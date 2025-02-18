-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS RestaurantesDB;
USE RestaurantesDB;

-- Crear la tabla de restaurantes
CREATE TABLE IF NOT EXISTS Restaurantes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Dueño VARCHAR(100) NOT NULL,
    Provincia VARCHAR(50) NOT NULL,
    Canton VARCHAR(50) NOT NULL,
    Distrito VARCHAR(50) NOT NULL,
    DireccionExacta VARCHAR(255) NOT NULL
);

-- Insertar datos de prueba
INSERT INTO Restaurantes (Nombre, Dueño, Provincia, Canton, Distrito, DireccionExacta) VALUES
('La Pizzería', 'Carlos Murillo', 'Heredia', 'Heredia', 'Barreal', '75mts al oeste del condominio la ladera'),
('La casa del cerdo', 'Juancho', 'Heredia', 'San Pablo', 'San Pablo', 'Frente al arco del triunfo');

-- Verificar los datos insertados
SELECT * FROM Restaurantes;
