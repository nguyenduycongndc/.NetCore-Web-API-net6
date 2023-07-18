-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_SEARCH_USER] 
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
				(@is_active = 0 AND (ISNULL(U.is_active, 0) = 0))
					OR
				--(@is_active = 1 AND (ISNULL(U.is_active, 0) IN (0,1)))
				(@is_active = 1 AND (ISNULL(U.is_active, 1) = 1))
				)
				)
		ORDER BY id
		OFFSET @page_size * (@start_number - 1) ROWS
		FETCH NEXT @page_size ROWS ONLY;
END
GO
