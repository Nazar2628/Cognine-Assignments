create table cognine_employees(id int,name varchar(20),position varchar(20),mg_id int);
insert into cognine_employees values (206,'balaji','ASE',104),(207,'Nazar','ASE',104),(208,'Yamini','ASE',104),(104,'Sumith','Manager',101)
create table cognine_managers (mg_id int,Manager_name varchar(20),heirarchylevel varchar(20));
insert into cognine_managers values(104,'Sumith','Mid level'),(101,'Sudhir','Upper level')
select e.id,e.name,m.Manager_name,m.heirarchylevel from 
cognine_employees e join cognine_managers m on e.mg_id=m.mg_id where e.id=104