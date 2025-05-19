CREATE DATABASE IF NOT EXISTS gestorfinanzas;
USE gestorfinanzas;

-- Tabla: ahorro (exactamente como la tenías)
CREATE TABLE IF NOT EXISTS ahorro (
  id_ahorro INT(20) NOT NULL AUTO_INCREMENT,
  total_ahorrado DECIMAL(65,0) DEFAULT NULL,
  fecha_ahorrado DATE NOT NULL,
  fecha_final_ahorrado DATE NOT NULL,
  PRIMARY KEY (id_ahorro)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Tabla: moneda (idéntica a tu versión)
CREATE TABLE IF NOT EXISTS moneda (
  id_moneda INT(11) NOT NULL AUTO_INCREMENT,
  nombre_moneda VARCHAR(50) NOT NULL,
  pais_origen VARCHAR(50) NOT NULL,
  PRIMARY KEY (id_moneda)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Tabla: presupuesto (sin cambios)
CREATE TABLE IF NOT EXISTS presupuesto (
  id INT(11) NOT NULL AUTO_INCREMENT,
  monto_ingresar DECIMAL(10,0) NOT NULL,
  fecha_ingresar DATE NOT NULL,
  permitir_gasto_total TINYINT(1) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- -----------------------------------------
-- -----------------------------------------
-- -----------------------------------------
-- -----------------------------------------
-- Tabla: activos (versión-finalista kevin )
CREATE TABLE IF NOT EXISTS activos (
  id_activo INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Tabla: inversiones (versión finalista - kevin)
CREATE TABLE IF NOT EXISTS inversiones (
  id_inversion INT AUTO_INCREMENT PRIMARY KEY,
  id_activo INT NOT NULL,
  cantidad DECIMAL(15,8) NOT NULL,
  precio DECIMAL(15,2) NOT NULL, 
  tiempo DATETIME NOT NULL,
  FOREIGN KEY (id_activo) REFERENCES activos(id_activo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;



INSERT IGNORE INTO activos (nombre) VALUES 
('Acciones'),
('Forex'),
('Cripto');


-- -----------------------------------------
-- -----------------------------------------
-- -----------------------------------------------
-- ----------------------------------------------


















