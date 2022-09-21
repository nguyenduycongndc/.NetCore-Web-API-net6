USE [AS_TEST_NEW]
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_CLOUD_CODE]    Script Date: 9/15/2022 3:44:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_DELETE_CLOUD_CODE]
(
	-- Add the parameters for the stored procedure here
	@pCloudcode varchar(50)
)
AS
BEGIN
--
--    WAITFOR DELAY '00:05:02';
--
	DELETE FROM [dbo].as_pwd_upd_history 
				WHERE  as_pwd_upd_history.uniq_key IN (SELECT as_pwd_upd_history.uniq_key 
															FROM as_pwd_upd_history INNER JOIN m_staffs 
															ON as_pwd_upd_history.staff_uniq_key = m_staffs.uniq_key 
																WHERE ( m_staffs.cloud_code = @pCloudcode ));
	------------------------------------
	DELETE FROM [dbo].[as_sync_history] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[gs_permission_screen] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[gs_permission_sub_sys] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_area_groups] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_basic_score] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_holiday_days] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_initial_value_info] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_license_mng] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM m_order_codes_lst 
				WHERE  m_order_codes_lst.uniq_key IN (SELECT m_order_codes_lst.uniq_key 
															FROM   m_order_codes_lst INNER JOIN m_order_groups 
															ON m_order_codes_lst.order_group_uniq_key = m_order_groups.uniq_key 
																WHERE  ( m_order_groups.cloud_code = @pCloudcode ));
	------------------------------------
	DELETE FROM [dbo].[m_order_groups] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_other_services] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_other_works] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_permission_groups] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_record_setting_elapsed_record] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_record_setting_excretion_icon] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_record_setting_select_item] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_registered_info_own_company] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_registered_info_service_provider] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_service_skills] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_staffs_other_info] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_staff_types] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_system_setting] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_weighted_point] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_work_patterns] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[od_corresponding_staff_monthly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[od_corresponding_staff_weekly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[od_user_order_detail_monthly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[od_user_order_detail_weekly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[od_user_order_main_monthly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[od_user_order_main_weekly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[od_user_order_monthly] 
				WHERE  [cloud_code] = @pCloudcode;  
	------------------------------------
	DELETE FROM [dbo].[od_user_order_weekly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[rc_bath_records] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[rc_elapsed_records] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[rc_excretion_records] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[rc_meal_moisture_records] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[rc_staff_timelines] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[rc_vital_records] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM st_employment_conditions 
				WHERE  st_employment_conditions.uniq_key IN (SELECT st_employment_conditions.uniq_key 
																	 FROM st_employment_conditions INNER JOIN m_staffs 
																	 ON st_employment_conditions.staff_uniq_key = m_staffs.uniq_key 
																		WHERE ( m_staffs.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM st_staff_area 
				WHERE  st_staff_area.uniq_key IN (SELECT st_staff_area.uniq_key 
												  FROM st_staff_area INNER JOIN m_staffs 
												  ON st_staff_area.staff_uniq_key = m_staffs.uniq_key 
													WHERE  ( m_staffs.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM st_staff_qualification 
				WHERE  st_staff_qualification.uniq_key IN (SELECT st_staff_qualification.uniq_key 
													FROM st_staff_qualification INNER JOIN m_staffs 
													ON st_staff_qualification.staff_uniq_key = m_staffs.uniq_key 
														WHERE  ( m_staffs.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM st_staff_service 
				WHERE  st_staff_service.uniq_key IN (SELECT st_staff_service.uniq_key 
													FROM   st_staff_service INNER JOIN m_staffs 
                                                    ON st_staff_service.staff_uniq_key = m_staffs.uniq_key 
														WHERE  ( m_staffs.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM st_staff_service_skill 
				WHERE  st_staff_service_skill.uniq_key IN (SELECT st_staff_service_skill.uniq_key 
                                           FROM st_staff_service_skill INNER JOIN m_staffs 
                                           ON st_staff_service_skill.staff_uniq_key = m_staffs.uniq_key 
											WHERE  ( m_staffs.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM st_working_times 
				WHERE  st_working_times.uniq_key IN (SELECT st_working_times.uniq_key 
                                     FROM st_working_times INNER JOIN m_staffs 
                                     ON st_working_times.staff_uniq_key = m_staffs.uniq_key 
										WHERE  ( m_staffs.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM [dbo].[t_binary] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[t_daily_business_simple_mail_group] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[t_help_visit_plan] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[t_schedule_management_inhouse_monthly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[t_schedule_management_inhouse_weekly] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[t_unassigned_visit_plan] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[t_user_info_notice] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM us_priority_staff 
				WHERE  us_priority_staff.uniq_key IN (SELECT us_priority_staff.uniq_key 
                                      FROM us_priority_staff INNER JOIN m_user_patients 
                                      ON us_priority_staff.user_uniq_key = m_user_patients.uniq_key 
                                      INNER JOIN m_staffs 
                                      ON us_priority_staff.staff_uniq_key = m_staffs.uniq_key 
										WHERE  ( m_user_patients.cloud_code = @pCloudcode ) 
                                             AND ( m_staffs.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM us_user_area 
				WHERE  us_user_area.uniq_key IN (SELECT us_user_area.uniq_key 
														FROM   us_user_area INNER JOIN m_user_patients 
														ON us_user_area.user_uniq_key = m_user_patients.uniq_key 
														INNER JOIN m_area_groups 
														ON us_user_area.area_group_uniq_key = m_area_groups.uniq_key 
															WHERE  ( m_user_patients.cloud_code = @pCloudcode ) 
															AND ( m_area_groups.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM us_user_doctors 
				WHERE  us_user_doctors.uniq_key IN (SELECT us_user_doctors.uniq_key 
														FROM   us_user_doctors INNER JOIN m_user_patients 
														ON us_user_doctors.user_uniq_key = m_user_patients.uniq_key 
														WHERE  ( m_user_patients.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM us_user_family_contacts 
				WHERE  us_user_family_contacts.uniq_key IN (SELECT us_user_family_contacts.uniq_key 
																FROM   us_user_family_contacts INNER JOIN m_user_patients 
																ON us_user_family_contacts.user_uniq_key = 
					   m_user_patients.uniq_key 
															WHERE  ( 
							  m_user_patients.cloud_code = @pCloudcode )); 
	------------------------------------
	DELETE FROM us_user_service 
				WHERE  us_user_service.uniq_key IN(SELECT us_user_service.uniq_key 
												   FROM   us_user_service 
														  INNER JOIN m_user_patients 
																  ON 
														  us_user_service.user_uniq_key = 
														  m_user_patients.uniq_key 
														  INNER JOIN m_services 
																  ON 
														  us_user_service.service_uniq_key = 
														  m_services.uniq_key 
												   WHERE  ( m_user_patients.cloud_code = 
															@pCloudcode )); 
	------------------------------------
	DELETE FROM [dbo].[vp_corresponding_staff] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM vp_visit_plan_table 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[ws_work_hope_period_status] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[ws_work_hope_submission_period] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[ws_work_hope_table] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_staffs] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	DELETE FROM [dbo].[m_user_patients] 
				WHERE  [cloud_code] = @pCloudcode; 
	------------------------------------
	return 0;
END
