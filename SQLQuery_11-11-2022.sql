create database Contractor_project
use Contractor_project

/*type of user*/
create table Type_User(id int unique ,user_type varchar(30) primary key not null ,duration datetime default (getdate()))
insert into Type_User values(1,'customer',GETDATE())
insert into Type_User values(2,'contractor',GETDATE())


select * from Type_User

/*state */
create table state_name (stateId int unique not null,stateName varchar(30)  primary key not null)
insert into  state_name values (1,'Andhra Pradesh')
insert into state_name  values(2,'telangana')
select * from state_name



/*city */
create table city_name(cityId int unique not null,cityName varchar(30)primary key not null)
insert into city_name values(1,'Machilipatnam')
insert into city_name values(2,'vijayawada')
select * from city_name

 /*map*/
 create table Map(latitude float unique not null,longitude float unique not null,PlaceID float primary key)
 --insert into Map values(12.9716, 77.5946 )
 select * from Map

 /*Gender*/
 create table Gender(genderID int unique not null,genderName varchar(30) primary key not null)
 insert into Gender values(1,'male')
 insert into Gender values(2,'female')
 insert into Gender values(3,'others')
 select * from Gender


 /*user details*/
 create table User_Details(userId int primary key identity(1,1),firstName varchar(30),lastName varchar(30),
 typeUser varchar(30) foreign key references Type_User(user_type),
 gender varchar(30) foreign key references Gender(genderName),mailId varchar(30) unique not null,password varchar(30) not null,
 phoneNumber bigint unique not null,stateName varchar(30) foreign key references state_name(stateName),
 CityName varchar(30) foreign key references city_name(cityName))

 --drop table User_Details
 --drop table Gender
 --drop table city_name
 --drop table state_name
 --drop table Contractor_details
 --drop table Service_Details


-- /* Service table*/
-- create table Service_Details(Service_ID int unique not null,_Service_Name varchar (30) primary key not null)

--select * from Service_Details

--drop table Service_Details

-- /* contractor details*/
-- create table Contractor_details(contractorID int foreign key references User_Details(userId),companyName varchar(30),License varchar(30) unique not null,
--								serviceName varchar(30) foreign key references Service_Details (_Service_Name),  
--								Latittude float foreign key references Map(latitude),longitude float foreign key references Map(longitude),Pincode bigint )

--select * from Contractor_details
--drop table Contractor_details

/*service table*/
create table Service_providing (serviceId int unique not null,ServiceName varchar(30) primary key)
insert into Service_providing values(1,'interior')
insert into Service_providing values(2,'exterior')

/*contractor details*/
create table Contractor_details (ContractorId int foreign key references User_Details(userId),CompanyName varchar(30),license varchar(30) unique not null,
[Services] varchar(30) foreign key references Service_providing(ServiceName))

drop table Contractor_details
/*Latitude float foreign key references Map(latitude),Longitude float foreign key references Map(longitude)*/

