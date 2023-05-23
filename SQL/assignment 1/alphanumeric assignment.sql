--create table alphanumeric(alphanumeric varchar(20));
--insert into alphanumeric values('dcjvf562rf33'),('67tr4gfrb74'),('iehhgb873v8rt'),('rgeh4b15feg45v')
Create function ExtractNumbers
(  
  @alphanumeric varchar(20)  
)  
Returns varchar(20)  
As  
Begin  
  Declare @numberIndex int = Patindex('%[^0-9]%', @alphanumeric)  
  Begin  
    While @numberIndex > 0  
    Begin  
      Set @alphanumeric = Stuff(@alphanumeric, @numberIndex, 1, '' )  
      Set @numberIndex = Patindex('%[^0-9]%', @alphanumeric )  
    End  
  End  
  Return @alphanumeric
End


Create function Extractalpha
(  
  @alphanumeric varchar(20)  
)  
Returns varchar(20)  
As  
Begin  
  Declare @alphabetIndex int = Patindex('%[^A-Za-z]%', @alphanumeric)  
  Begin  
    While @alphabetIndex > 0  
    Begin  
      Set @alphanumeric = Stuff(@alphanumeric, @alphabetIndex, 1, '' )  
      Set @alphabetIndex = Patindex('%[^A-Za-z]%', @alphanumeric )  
    End  
  End  
  Return @alphanumeric
End
select alphanumeric,dbo.Extractnumbers(alphanumeric) as number,dbo.Extractalpha(alphanumeric) as alphabet from alphanumeric;
