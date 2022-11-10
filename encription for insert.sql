create table User_Profile(
_User_ID int NOT NULL,
First_Name varchar(100),
Last_Name varchar (100),
ID__AADHAR_ID bigint,
Gender varchar (50),
Mail_ID varchar (50),
uPassword varchar(50) UNIQUE,
Contact_Number bigint ,
_State varchar(50),
City varchar(50),
Pincode bigint
)

drop table User_Profile

select *from  User_Profile

insert into User_Profile values(1,'khadeeja','shirin',452376567896,'Female','shirinalnajm@gmail.com',HASHBYTES('SHA1','shirin@35'),8978654323,'kerala','tirur',676561);
insert into User_Profile values(2,'Tarun','Nag',675643234567,'Male','tarunag@gmail.com',HASHBYTES('SHA1','tarun@35'),8976567890,'andhrapradesh','telugana',876543);

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--sp for encryped password

create proc sp_GetUserData
(
@password varchar(50)
)
with encryption 
as
begin
select * from User_Profile
end

exec sp_GetUserData 'hgafrt@567'


create table forexample
(
Id int,
UserName varchar(50),
uPassword varchar (50)
);

insert into forexample values (1,'khadeeja',ENCRYPTBYPASSPHRASE('8','shirin@123'))