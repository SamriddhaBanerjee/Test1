Create procedure [dbo].[UpdateInformation]  
(  
   @StdId int,  
   @Name nvarchar (50),  
   @Address nvarchar (100),
   @Mobile nvarchar(10),
   @Email nvarchar(256)
)  
as  
begin  
   Update InforMation   
   set Name=@Name,    
   Address=@Address,
   Mobile=@Mobile, 
   Email=@Email   
   where Id=@StdId  
End
