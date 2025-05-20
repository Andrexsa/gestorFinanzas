-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 20-05-2025 a las 08:31:35
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `gestorfinanzas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `activos`
--

CREATE TABLE `activos` (
  `id_activo` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `activos`
--

INSERT INTO `activos` (`id_activo`, `nombre`) VALUES
(1, 'Acciones'),
(2, 'Forex'),
(3, 'Cripto');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ahorro`
--

CREATE TABLE `ahorro` (
  `id_ahorro` int(20) NOT NULL,
  `total_ahorrado` decimal(65,0) DEFAULT NULL,
  `fecha_ahorrado` date NOT NULL,
  `fecha_final_ahorrado` date NOT NULL,
  `tipo_ahorro` varchar(50) NOT NULL,
  `fecha_inicio` datetime(6) NOT NULL,
  `frecuencia` varchar(50) NOT NULL,
  `nombre_ahorro` varchar(100) NOT NULL,
  `monto_objetivo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `ahorro`
--

INSERT INTO `ahorro` (`id_ahorro`, `total_ahorrado`, `fecha_ahorrado`, `fecha_final_ahorrado`, `tipo_ahorro`, `fecha_inicio`, `frecuencia`, `nombre_ahorro`, `monto_objetivo`) VALUES
(6784, 2900000, '2025-05-20', '2025-05-19', 'Emergencias', '2025-05-19 23:29:56.067450', 'Semanalmente', 'nuevo', 0),
(3173, 900900, '2025-05-19', '2025-05-19', 'Tecnología', '2025-05-19 23:32:31.345160', 'Mensualmente', 'carro', 0),
(6068, 888000, '2025-05-19', '2025-05-19', 'Vehículo', '2025-05-19 23:34:02.137589', 'Quincenalmente', 'nosee', 0),
(1673, 44400044, '2025-05-19', '2025-05-19', 'Tecnología', '2025-05-19 23:36:05.287892', 'Mensualmente', 'ahora si', 0),
(4557, 500000, '2025-05-20', '2025-05-20', 'Inmobiliario', '2025-05-20 00:30:48.055710', 'Diariamente', 'ojala', 1000000),
(1094, 1500000, '2025-05-20', '2025-05-20', 'Tecnología', '2025-05-20 00:32:03.847769', 'Quincenalmente', 'andrex', 2000000),
(5862, 2500000, '2025-05-20', '2025-05-20', 'Tecnología', '2025-05-20 00:38:18.699229', 'Mensualmente', 'paula', 5000000),
(1268, 3000000, '2025-05-20', '2025-05-20', 'Tecnología', '2025-05-20 01:16:40.400850', 'Semanalmente', 'cely', 9000000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inversiones`
--

CREATE TABLE `inversiones` (
  `id_inversion` int(11) NOT NULL,
  `id_activo` int(11) NOT NULL,
  `cantidad` decimal(15,8) NOT NULL,
  `precio` decimal(15,2) NOT NULL,
  `tiempo` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `moneda`
--

CREATE TABLE `moneda` (
  `id_moneda` int(11) NOT NULL,
  `nombre_moneda` varchar(50) NOT NULL,
  `pais_origen` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `presupuesto`
--

CREATE TABLE `presupuesto` (
  `id` int(11) NOT NULL,
  `monto_ingresar` decimal(10,0) NOT NULL,
  `fecha_ingresar` date NOT NULL,
  `permitir_gasto_total` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `activos`
--
ALTER TABLE `activos`
  ADD PRIMARY KEY (`id_activo`);

--
-- Indices de la tabla `inversiones`
--
ALTER TABLE `inversiones`
  ADD PRIMARY KEY (`id_inversion`),
  ADD KEY `id_activo` (`id_activo`);

--
-- Indices de la tabla `moneda`
--
ALTER TABLE `moneda`
  ADD PRIMARY KEY (`id_moneda`);

--
-- Indices de la tabla `presupuesto`
--
ALTER TABLE `presupuesto`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `activos`
--
ALTER TABLE `activos`
  MODIFY `id_activo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `inversiones`
--
ALTER TABLE `inversiones`
  MODIFY `id_inversion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `moneda`
--
ALTER TABLE `moneda`
  MODIFY `id_moneda` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `presupuesto`
--
ALTER TABLE `presupuesto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `inversiones`
--
ALTER TABLE `inversiones`
  ADD CONSTRAINT `inversiones_ibfk_1` FOREIGN KEY (`id_activo`) REFERENCES `activos` (`id_activo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
