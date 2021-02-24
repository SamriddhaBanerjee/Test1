Create procedure [dbo].[DeleteStudent]  
(  
   @StdId int  
)  
as   
begin  
   Delete from InforMation where Id=@StdId  
End