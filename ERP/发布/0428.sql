ALTER TABLE `erp`.`storestock` 
ADD COLUMN `remarks` VARCHAR(500) NULL ;

ALTER TABLE `erp`.`storestockdetail` 
ADD COLUMN `complete_time` DATETIME NULL ,ADD COLUMN `remarks` VARCHAR(45) NULL ;


ALTER TABLE `erp`.`stockdetail` 
ADD COLUMN `status` INT NULL DEFAULT 0;
