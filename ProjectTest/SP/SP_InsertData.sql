USE [AS_TEST_NEW]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_CLOUD_CODE]    Script Date: 9/15/2022 3:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_INSERT_CLOUD_CODE]
(
	-- Add the parameters for the stored procedure here
	@pCloudcode varchar(50),
	@pBeginDate varchar(50),
	@pEndDate varchar(50) = null,
	@pUpdUser varchar(50),
	@pPassword varchar(max),
	@pJson varchar(max)
)
AS
BEGIN
--
--	WAITFOR DELAY '00:05:02';
--
	DECLARE @beginDate datetime;
	DECLARE @endDate datetime;
	DECLARE @ERROR_MESSAGE nvarchar(max) = '';
	--
	set @beginDate = convert(datetime, @pBeginDate + ' ' + convert(varchar, getdate(), 8));
	if(@pEndDate is not null or @pEndDate <> '')
	begin
		set @endDate = convert(datetime, @pEndDate + ' ' + '00:00');
	end
	else
	begin
		select @endDate = [dbo].FUNC_CONVERT_STRING_TO_DATETIME_YYYYMMddHHmmss('2999-12-31 00:00');
	end
	--
	INSERT INTO [dbo].[M_LICENSE_MNG] values(newid(),@pCloudcode,100,1,@beginDate,@endDate,@pUpdUser,getdate(),getdate());
	--
	INSERT INTO M_SYSTEM_SETTING
	(
		UNIQ_KEY,
		CLOUD_CODE,
		PWD_AVAILABLE_PERIOD_FLG,
		PWD_AVAILABLE_PERIOD_DAYS,
		WAGE_CALCULATION_CLOSING_DATE,
		WORK_ASSIGNMENT_INTERVAL,
		MAXIMUM_WORKING_HOURS_ONE_DAY,
		MAXIMUM_WORKING_HOURS_ONE_WEEK,
		MAXIMUM_WORKING_HOURS_ONE_MONTH,
		RESET_PWD_STANDARD_MSG,
		NUMBER_OF_CONTINUOUS_VISIT_TIMES,
		PERIOD_DAYS_FOR_NUMBER_OF_VISIT_TIMES,
		USE_NUMBER_OF_VISIT_TIMES_FLG,
		UPD_USER,
		UPD_DATE,
		CREATED_DATE,
		NOT_CHECK_CHECKINOUT_TIME_FLG,
		CHANGE_CHECKINOUT_TIME_FLG,
		CHECKINOUT_BY_SCHEDULE_FLG
	)
	SELECT 
		newid(),
		CLOUD_CODE,
		PWD_AVAILABLE_PERIOD_FLG,
		PWD_AVAILABLE_PERIOD_DAYS,
		WAGE_CALCULATION_CLOSING_DATE,
		WORK_ASSIGNMENT_INTERVAL,
		MAXIMUM_WORKING_HOURS_ONE_DAY,
		MAXIMUM_WORKING_HOURS_ONE_WEEK,
		MAXIMUM_WORKING_HOURS_ONE_MONTH,
		NULL,
		0,
		30,
		1,
		UPD_USER,
		getdate(),
		getdate(),
		0,
		0,
		0
	FROM OPENJSON(@pJson)
	WITH
	(
		CLOUD_CODE varchar(10),
		PWD_AVAILABLE_PERIOD_FLG bit,
		PWD_AVAILABLE_PERIOD_DAYS smallint,
		WAGE_CALCULATION_CLOSING_DATE tinyint,
		WORK_ASSIGNMENT_INTERVAL varchar(6),
		MAXIMUM_WORKING_HOURS_ONE_DAY varchar(6),
		MAXIMUM_WORKING_HOURS_ONE_WEEK varchar(6),
		MAXIMUM_WORKING_HOURS_ONE_MONTH varchar(6),
		UPD_USER varchar(50)
	)
	--INSERT INTO [dbo].[M_SYSTEM_SETTING] values(newid(),@pCloudcode,'1',60,25,':',':',':',':',NULL,NULL,NULL,NULL,'beesystem_dev','2020-01-15 18:00:00.000','2020-01-15 18:00:00.000');
	--
	INSERT INTO [dbo].[M_STAFF_TYPES] values(newid(),@pCloudcode,'T1',N'????',1,1,@pUpdUser,getdate(),0,NULL,getdate());
	INSERT INTO [dbo].[M_STAFF_TYPES] values(newid(),@pCloudcode,'T2',N'?????',2,1,@pUpdUser,getdate(),0,NULL,getdate());
	INSERT INTO [dbo].[M_STAFF_TYPES] values(newid(),@pCloudcode,'T3',N'?????',3,1,@pUpdUser,getdate(),0,NULL,getdate());
	INSERT INTO [dbo].[M_STAFF_TYPES] values(newid(),@pCloudcode,'T4',N'??????',4,1,@pUpdUser,getdate(),0,NULL,getdate());
	--
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','SKILL_MATCHING','YES_MATCHED',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','SKILL_MATCHING','NOT_MATCH',-3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_0',-1000,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_1',5,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_2',4,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_3',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_4',2,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_5',1,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_NULL',0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_0',0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_3',1,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_5',2,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_10',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_CONTINUOUS_VISIT_TIMES','NUMBER_LESS_3',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_CONTINUOUS_VISIT_TIMES','NUMBER_GREATER_3',-1000,@pUpdUser,getdate(),getdate());
	-------------------
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','SKILL_MATCHING','YES_MATCHED',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','SKILL_MATCHING','NOT_MATCH',-3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_0',-1000,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_1',5,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_2',4,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_3',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_4',2,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_5',1,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF','PRIORITY_NULL',0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_0',0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_3',1,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_5',2,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD','NUMBER_PERIOD_10',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_CONTINUOUS_VISIT_TIMES','NUMBER_LESS_3',3,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_BASIC_SCORE] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_CONTINUOUS_VISIT_TIMES','NUMBER_GREATER_3',-1000,@pUpdUser,getdate(),getdate());
	--
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','SKILL_MATCHING',NULL,0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF',NULL,25,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD',NULL,0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'9C9BE993-5FAD-4996-924A-2DDE72D59454',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_CONTINUOUS_VISIT_TIMES',NULL,0,@pUpdUser,getdate(),getdate());
	-------------------
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','SKILL_MATCHING',NULL,0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','PRIORITY_STAFF',NULL,25,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_VISIT_TIMES_ONE_PERIOD',NULL,0,@pUpdUser,getdate(),getdate());
	INSERT INTO [dbo].[M_WEIGHTED_POINT] values(newid(),@pCloudcode,'C30BD5F7-0CCA-4AE7-A9F6-0B2DC0FC163A',@beginDate,'2999-12-31 00:00:00.000','NUMBER_OF_CONTINUOUS_VISIT_TIMES',NULL,0,@pUpdUser,getdate(),getdate());
	--
	INSERT INTO [dbo].[M_STAFFS] values(newid(),@pCloudcode,'9999999999','????????','',' ???????? ','','TRUE',1,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,@pPassword,NULL,NULL,NULL,NULL,0,NULL,2,NULL,NULL,NULL,NULL,NULL,@pUpdUser,getdate(),'FALSE',NULL,getdate(),'',NULL,getdate(),NULL,NULL,NULL);
	--
	--INSERT INTO [dbo].[T_DAILY_BUSINESS_SIMPLE_MAIL_GROUP] values(newid(),@pCloudcode,N'????????','a','99999999',N'????????',N'?????????????','1',@pUpdUser,getdate(),0,NULL,getdate(),'');
	--
	return 0;
END