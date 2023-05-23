create table age_of_person (name varchar(20),DOB varchar(20), 
age as (datediff(year,DOB,getdate())))
insert into age_of_person values('yamini','2000-10-03'),('NAZAR','2000-04-28'),('Balaji','1999-09-23')
select * from age_of_person;