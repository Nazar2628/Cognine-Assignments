create table pronounction(name varchar(20))
insert into pronounction values('suresh'),('Sureth'),
('Surexh'),('Surezh'),
('Surfah'),
('Suriah'),('Surich'),('Surieh'),('Suryah'),('Susanh'),('Susas'),('ramesh'),('somesh')
select name from pronounction where soundex(name)=soundex('suresh')