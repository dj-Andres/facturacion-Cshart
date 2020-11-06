# MySQL-Front 5.0  (Build 1.0)

/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE */;
/*!40101 SET SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES */;
/*!40103 SET SQL_NOTES='ON' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;


# Host: localhost    Database: facturacion2
# ------------------------------------------------------
# Server version 5.5.27

#
# Table structure for table ciudades
#

DROP TABLE IF EXISTS `ciudades`;
CREATE TABLE `ciudades` (
  `Idciudad` int(11) NOT NULL AUTO_INCREMENT,
  `ciudad` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Idciudad`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
INSERT INTO `ciudades` VALUES (1,'PASAJE');
INSERT INTO `ciudades` VALUES (2,'SNTA ROSA');
INSERT INTO `ciudades` VALUES (3,'BUENAVISTA');
INSERT INTO `ciudades` VALUES (4,'MACHALA');
INSERT INTO `ciudades` VALUES (5,'GUABO');
INSERT INTO `ciudades` VALUES (6,'MANABI');
INSERT INTO `ciudades` VALUES (7,'BOTELLA');
/*!40000 ALTER TABLE `ciudades` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table clientes
#

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE `clientes` (
  `Idcliente` int(11) NOT NULL AUTO_INCREMENT,
  `cedula` varchar(10) DEFAULT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `apellido` varchar(30) DEFAULT NULL,
  `direccion` varchar(40) DEFAULT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `sexo` varchar(10) DEFAULT NULL,
  `fecha_ingreso` date DEFAULT NULL,
  `estado` varchar(1) DEFAULT NULL,
  `foto` blob,
  `Idciudad` int(11) DEFAULT NULL,
  PRIMARY KEY (`Idcliente`),
  KEY `fk_ciudad` (`Idciudad`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;
INSERT INTO `clientes` VALUES (1,'0707012601','DIEGO','JIMENEZ','CALICHANA','0992294342','MASCULINO','2019-11-04','1','',1);
INSERT INTO `clientes` VALUES (2,'2356635','HJFDF','YEYTDT','HJFHJ','5365','F','2019-11-01','1',NULL,NULL);
INSERT INTO `clientes` VALUES (3,'028476','MANUEL','DÍAZ','KWLHG','1432','MASCULINO','2019-11-02','0','',1);
INSERT INTO `clientes` VALUES (6,'269037','LAUTARO','MARTINEZ','AV 6 DE MAYO','1234224','MASCULINO','2019-11-03','1',x'433A557365727368704465736B746F7063616C656E646172696F6F6F6F2E6A666966',1);
INSERT INTO `clientes` VALUES (8,'3243654','GWE','SCSAFDSG','DWQEW','14253','M','2019-11-02','0',NULL,1);
INSERT INTO `clientes` VALUES (9,'11111','LL','MM','SS','14253','M','2019-11-02','0',NULL,1);
INSERT INTO `clientes` VALUES (13,'12','WW','WW','WW','12','M','2019-11-01','0',NULL,1);
INSERT INTO `clientes` VALUES (14,'13','WW','WW','WW','12','M','2019-11-01','0',NULL,1);
INSERT INTO `clientes` VALUES (15,'141','DD','SS','FAD','12','M','2019-11-02','0',NULL,1);
INSERT INTO `clientes` VALUES (35,'0703989780','ANGEL MAURCIO','RAMÓN','AV ROCAFUERTE','213321','MASCULINO','2019-11-03','1','',5);
INSERT INTO `clientes` VALUES (36,'0707012605','MANUEL ','RIVAS','AV 6 DE MAYO','1234','MASCULINO','2020-02-14','1',x'433A557365727368704465736B746F70494D472D32303139303831342D5741303030332E6A7067',1);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table presentacion_producto
#

DROP TABLE IF EXISTS `presentacion_producto`;
CREATE TABLE `presentacion_producto` (
  `Idpresentacion` int(11) NOT NULL AUTO_INCREMENT,
  `producto` varchar(20) DEFAULT NULL,
  `Id_tpresentacion` int(11) DEFAULT NULL,
  `Idunidad` int(11) DEFAULT NULL,
  `valor_unidad` int(11) DEFAULT NULL,
  `costo_unitario` double(4,2) DEFAULT NULL,
  `precio_unitario` double(4,2) DEFAULT NULL,
  PRIMARY KEY (`Idpresentacion`),
  KEY `fk_producto` (`producto`),
  KEY `fk_tpresentacion` (`Id_tpresentacion`),
  KEY `fk_unidad` (`Idunidad`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
INSERT INTO `presentacion_producto` VALUES (1,'COCA COLA',1,1,11,12.3,12.4);
INSERT INTO `presentacion_producto` VALUES (2,'VOLCÁN',2,1,15,12.7,12.9);
/*!40000 ALTER TABLE `presentacion_producto` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table productos
#

DROP TABLE IF EXISTS `productos`;
CREATE TABLE `productos` (
  `Idproducto` int(11) NOT NULL AUTO_INCREMENT,
  `productos` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Idproducto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table tipo_presentacion
#

DROP TABLE IF EXISTS `tipo_presentacion`;
CREATE TABLE `tipo_presentacion` (
  `Id_tpresentacion` int(11) NOT NULL AUTO_INCREMENT,
  `presentacion` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Id_tpresentacion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
INSERT INTO `tipo_presentacion` VALUES (1,'BOTELLA');
INSERT INTO `tipo_presentacion` VALUES (2,'CARTON');
/*!40000 ALTER TABLE `tipo_presentacion` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table unidad_medida
#

DROP TABLE IF EXISTS `unidad_medida`;
CREATE TABLE `unidad_medida` (
  `Idunidad` int(11) NOT NULL AUTO_INCREMENT,
  `medida` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Idunidad`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
INSERT INTO `unidad_medida` VALUES (1,'LITROS');
INSERT INTO `unidad_medida` VALUES (2,'KILOGRAMOS');
/*!40000 ALTER TABLE `unidad_medida` ENABLE KEYS */;
UNLOCK TABLES;

#
#  Foreign keys for table clientes
#

ALTER TABLE `clientes`
ADD CONSTRAINT `fk_ciudad` FOREIGN KEY (`Idciudad`) REFERENCES `ciudades` (`Idciudad`);

#
#  Foreign keys for table presentacion_producto
#

ALTER TABLE `presentacion_producto`
ADD CONSTRAINT `fk_tpresentacion` FOREIGN KEY (`Id_tpresentacion`) REFERENCES `tipo_presentacion` (`Id_tpresentacion`),
  ADD CONSTRAINT `fk_unidad` FOREIGN KEY (`Idunidad`) REFERENCES `unidad_medida` (`Idunidad`);


/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
