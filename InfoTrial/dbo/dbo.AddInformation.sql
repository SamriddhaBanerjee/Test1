Create procedure [dbo].[AddInformation]  
(  
   @Name nvarchar (50),    
   @Address nvarchar (100),
   @Mobile_Num nvarchar(10),
   @Email nvarchar(256) 
)  
as  
begin  
   Insert into InforMation values(@Name,@Address,@Mobile_Num,@Email)  
End