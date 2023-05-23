select * into empassin from cognine_employees;
select * from empassin
select * into managerassin from empassin where id in(104,101)
insert into managerassin values(104,'Sumith','Manager'),(101,'Sudhir','Manager'),(102,'Pradeep','Manager')
select * from empassin union  select * from managerassin ;