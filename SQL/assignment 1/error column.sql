create table restrictcolumn(
basicpay int,
tax int,
add_on int ,
total as convert(float,'int'));
insert into restrictcolumn values(40,57,61)
 select * from restrictcolumn