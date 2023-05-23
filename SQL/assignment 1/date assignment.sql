create table calander(Given_date varchar(20),
	[Year] as (DATEPART(YEAR, Given_date)),
	[Month] as (DATEPART (MONTH,Given_date)),
	[DayOfYear] as (DATEPART (DayOfYear, Given_date)),
	[Day of  Month] as (DATEPART (DAY, Given_date)),
	[Week] as (DATEPART (WEEK, Given_date)),
	[Weekday] as (DATEPART (WEEKDAY,Given_date)))
insert into calander values('2004-11-03'),('2022-10-03'),('2000-04-28'),('2001-10-06')
select * from calander;