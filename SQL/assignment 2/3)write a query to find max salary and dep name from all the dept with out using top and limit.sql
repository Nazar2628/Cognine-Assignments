CREATE TABLE department(
empno int not null primary key,
ename varchar(50) not null,
job varchar(50) not null,
sal int,
deptno int not null);
insert into department values (7369,'SMITH','CLERK',7902,800,20),
(7499,'ALLEN','SALESMAN',7698,1600,30),
(7521,'WARD','SALESMAN',7698,1250,30),
(7566,'JONES','MANAGER',7839,2975,20),
(7698,'BLAKE','MANAGER',7839,2850,30),
(7782,'CLARK','MANAGER',783,2450,10),
(7788,'SCOTT','ANALYST',7566,3000,20),
(7839,'KING','PRESIDENT',null,5000,10),
(7844,'TURNER','SALESMAN',7698,1500,30),
(7876,'ADAMS','CLERK',7788,1100,20),
(7900,'JAMES','CLERK',7698,950,30),
 (7934,'MILLER','CLERK',7782,1300,10),
(7902,'FORD','ANALYST',7566,3000,20),
(7654,'MARTIN','SALESMAN',7698,1250,30);

alter table department  add department_name varchar(20)
update department set department_name='SALES' where deptno=30

select department_name,max(salary) max_salary from department group by department_name;
select * from department;