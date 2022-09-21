USE [DB_TEST]
GO
/****** Object:  StoredProcedure [dbo].[SP_USER]    Script Date: 9/21/2022 10:18:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_USER] 
	@user_name nvarchar(MAX),
	@is_active INT,
	@start_number INT,
	@page_size INT

AS
BEGIN
	
	SET NOCOUNT ON;
	IF (@start_number < 1)
		SELECT @start_number = 1;
    
	SELECT * from [dbo].[users] as U
		WHERE 
				@user_name is null 
				or U.user_name LIKE N'%' + @user_name + '%'
				and (@is_active = -1 
				or (
				(@is_active = 0 AND (ISNULL(U.is_active, 0) = 1))
					OR
				(@is_active = 1 AND (ISNULL(U.is_active, 0) IN (0,1)))
				)
				)
		ORDER BY id
		OFFSET @page_size * (@start_number - 1) ROWS
		FETCH NEXT @page_size ROWS ONLY;
END
