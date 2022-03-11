	CREATE TABLE `Equipamento`(
	`id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	`descricao` VARCHAR(100) NOT NULL,
	`situacao` VARCHAR(10) NOT NULL,
	`dataDeCadastro` VARCHAR(11) NOT NULL,
	`dataDeAlteracao` VARCHAR(11) NOT NULL,
	`numeroDoPatrimonio` INT(06) NOT NULL)