select  * from emp;

select * from(select ename, sal, dense_rank() over(order by sal desc) as r  from emp) as sal3 where r=2;

with ranksal as (select ename, sal, dense_rank() over(order by sal desc) as ranks from emp)
select sal from ranksal where ranks=2;