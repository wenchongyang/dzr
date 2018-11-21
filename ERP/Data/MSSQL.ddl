
CREATE DATABASE erp DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;


DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Store;
DROP TABLE IF EXISTS StockDetail;
DROP TABLE IF EXISTS Stock;
DROP TABLE IF EXISTS SalesDetail;
DROP TABLE IF EXISTS Sales;
DROP TABLE IF EXISTS Roles;
DROP TABLE IF EXISTS Product;

/**********************************/
/* Table Name: Product */
/**********************************/
CREATE TABLE Product(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		name                          		VARCHAR(100)		 NULL  COMMENT 'name',
		guide_price                   		DECIMAL(18,2)		 NULL  COMMENT 'guide_price',
		remarks                       		VARCHAR(200)		 NULL  COMMENT 'remarks',
		dimensions                    		VARCHAR(250)		 NULL  COMMENT 'dimensions',
		color                         		VARCHAR(50)		 NULL  COMMENT 'color',
		price                         		DECIMAL(18,2)		 NULL  COMMENT 'price',
		market_price                  		DECIMAL(18,2)		 NULL  COMMENT 'market_price',
		cost_price                    		DECIMAL(18,2)		 NULL  COMMENT 'cost_price'
) COMMENT='Product';

/**********************************/
/* Table Name: Roles */
/**********************************/
CREATE TABLE Roles(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		name                          		VARCHAR(100)		 NULL  COMMENT 'name'
) COMMENT='Roles';

/**********************************/
/* Table Name: Sales */
/**********************************/
CREATE TABLE Sales(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		bill_id                       		INTEGER(10)		 NULL  COMMENT 'bill_id',
		store_id                      		MEDIUMINT(10)		 NULL  COMMENT 'store_id',
		user_id                       		MEDIUMINT(10)		 NULL  COMMENT 'user_id',
		customer_name                 		VARCHAR(100)		 NULL  COMMENT 'customer_name',
		phone                         		VARCHAR(100)		 NULL  COMMENT 'phone',
		address                       		VARCHAR(100)		 NULL  COMMENT 'address',
		remarks                       		VARCHAR(200)		 NULL  COMMENT 'remarks',
		sapshot                       		BLOB		 NULL  COMMENT 'sapshot',
		product_count                 		MEDIUMINT(10)		 NULL  COMMENT 'product_count',
		need_pay                      		DECIMAL(18,2)		 NULL  COMMENT 'need_pay',
		actually_pay                  		DECIMAL(18,2)		 NULL  COMMENT 'actually_pay',
		paymet_method1                		VARCHAR(100)		 NULL  COMMENT 'paymet_method1',
		paymet_method2                		VARCHAR(100)		 NULL  COMMENT 'paymet_method2',
		status                        		TINYINT(10)		 NULL  COMMENT 'status',
		create_time                   		DATETIME		 NULL  COMMENT 'create_time',
		create_user                   		INT(100)		 NULL  COMMENT 'create_user',
		modfied_user                  		INT(100)		 NULL  COMMENT 'modfied_user',
		modfied_time                  		DATETIME		 NULL  COMMENT 'modfied_time',
		delivery_number               		VARCHAR(50)		 NULL  COMMENT 'delivery_number',
		delivery_pay                  		DECIMAL(18,2)		 NULL  COMMENT 'delivery_pay',
		delivery_date                 		DATETIME		 NULL  COMMENT 'delivery_date'
) COMMENT='Sales';

/**********************************/
/* Table Name: SalesDetail */
/**********************************/
CREATE TABLE SalesDetail(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		sales_id                      		MEDIUMINT(10)		 NULL  COMMENT 'sales_id',
		product_id                    		MEDIUMINT(10)		 NULL  COMMENT 'product_id',
		product_name                  		VARCHAR(100)		 NULL  COMMENT 'product_name',
		dimensions                    		VARCHAR(50)		 NULL  COMMENT 'dimensions',
		color                         		VARCHAR(50)		 NULL  COMMENT 'color',
		count                         		INT(10)		 NULL  COMMENT 'count',
		guide_price                   		DECIMAL(18,2)		 NULL  COMMENT 'guide_price',
		discount                      		DECIMAL(18,2)		 NULL  COMMENT 'discount',
		need_pay                      		DECIMAL(18,2)		 NULL  COMMENT 'need_pay',
		actually_pay                  		DECIMAL(18,2)		 NULL  COMMENT 'actually_pay',
		paymet_method                 		VARCHAR(10)		 NULL  COMMENT 'paymet_method',
		margins                       		DECIMAL(18,2)		 NULL  COMMENT 'margins',
		cost_price                    		DECIMAL(18,2)		 NULL  COMMENT 'cost_price',
		commission                    		DECIMAL(18,2)		 NULL  COMMENT 'commission',
		cal_way                       		VARCHAR(200)		 NULL  COMMENT 'cal_way'
) COMMENT='SalesDetail';

/**********************************/
/* Table Name: Stock */
/**********************************/
CREATE TABLE Stock(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		product_id                    		MEDIUMINT(10)		 NULL  COMMENT 'product_id',
		product_name                  		VARCHAR(100)		 NULL  COMMENT 'product_name',
		dimensions                    		VARCHAR(250)		 NULL  COMMENT 'dimensions',
		color                         		VARCHAR(50)		 NULL  COMMENT 'color',
		count                         		INT(10)		 NULL  COMMENT 'count',
		saleable_count                		INT(10)		 NULL  COMMENT 'saleable_count'
) COMMENT='Stock';

/**********************************/
/* Table Name: StockDetail */
/**********************************/
CREATE TABLE StockDetail(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		product_id                    		MEDIUMINT(10)		 NULL  COMMENT 'product_id',
		product_name                  		VARCHAR(100)		 NULL  COMMENT 'product_name',
		dimensions                    		VARCHAR(250)		 NULL  COMMENT 'dimensions',
		color                         		VARCHAR(50)		 NULL  COMMENT 'color',
		count                         		INT(10)		 NULL  COMMENT 'count',
		create_time                   		DATETIME		 NULL  COMMENT 'create_time'
) COMMENT='StockDetail';

/**********************************/
/* Table Name: Store */
/**********************************/
CREATE TABLE Store(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		name                          		VARCHAR(100)		 NULL  COMMENT 'name',
		phone                         		VARCHAR(50)		 NULL  COMMENT 'phone',
		address                       		VARCHAR(100)		 NULL  COMMENT 'address',
		lead                          		VARCHAR(100)		 NULL  COMMENT 'lead',
		remarks                       		VARCHAR(200)		 NULL  COMMENT 'remarks'
) COMMENT='Store';

/**********************************/
/* Table Name: Users */
/**********************************/
CREATE TABLE Users(
		id                            		MEDIUMINT(10)		 NOT NULL		 PRIMARY KEY AUTO_INCREMENT COMMENT 'id',
		username                      		VARCHAR(100)		 NULL  COMMENT 'username',
		name                          		VARCHAR(100)		 NULL  COMMENT 'name',
		password                      		VARCHAR(100)		 NULL  COMMENT 'password',
		store_id                      		MEDIUMINT(10)		 NULL  COMMENT 'store_id',
		role_id                       		MEDIUMINT(10)		 NULL  COMMENT 'role_id',
		sex                           		BIT		 NULL  COMMENT 'sex',
		phone                         		VARCHAR(100)		 NULL  COMMENT 'phone',
		address                       		VARCHAR(100)		 NULL  COMMENT 'address',
		id_card                       		VARCHAR(100)		 NULL  COMMENT 'id_card',
		join_date                     		DATETIME		 NULL  COMMENT 'join_date',
		salary                        		DECIMAL(18,2)		 NULL  COMMENT 'salary',
		remarks                       		VARCHAR(500)		 NULL  COMMENT 'remarks'
) COMMENT='Users';

insert roles(id,name)values(1,"超级管理员");
insert roles(id,name)values(2,"总经理");
insert roles(id,name)values(3,"财务");
insert roles(id,name)values(4,"店长");
insert roles(id,name)values(5,"导购");
insert roles(id,name)values(6,"仓管");
insert users (username,password,role_id) values("superadmin","88888888",1);
