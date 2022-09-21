USE [AS_TEST_NEW]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONTRACT_INFORMATION]    Script Date: 9/20/2022 9:36:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_CONTRACT_INFORMATION]
	-- Add the parameters for the stored procedure here
	(
	@pCloudCode varchar(10),
	@pContractorName varchar(max)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		MNG.UNIQ_KEY, MNG.CLOUD_CODE, P.NAME, MNG.MAXIMUM_NUMBER_OF_TERMINALS, MNG.AVAILABLE_FLG, MNG.BEGIN_DATE, MNG.END_DATE, MNG.UPD_USER, MNG.UPD_DATE, MNG.CREATED_DATE 
		from 
		[M_LICENSE_MNG] as MNG
		Inner join M_REGISTERED_INFO_OWN_COMPANY C on  C.CLOUD_CODE = MNG.CLOUD_CODE
		Inner join M_REGISTERED_INFO_SERVICE_PROVIDER P on(P.CLOUD_CODE = MNG.CLOUD_CODE AND (P.PK_SERVICE_PROVIDER =  C.SELF_PK_OFFICE_11 OR P.PK_SERVICE_PROVIDER =  C.SELF_PK_OFFICE_13))
		where MNG.CLOUD_CODE = @pCloudCode and P.NAME = @pContractorName
END
