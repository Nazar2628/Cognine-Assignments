select department, location from department_details group by department,location 
having sum(salary) > 2*avg(salary) and max(basicpay) > 3*min(basicpay);