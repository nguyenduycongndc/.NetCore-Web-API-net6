public bool DeleteCloudcode(string CLOUD_CODE)
        {
            bool blnSuccess = true;
            try
            {
                //Open connection
                DBtransaction.OpenConection();
                DBtransaction.Begintransaction();
                List<SqlParameter> LstParam = new List<SqlParameter>();
                SqlParameter param = null;
                param = new SqlParameter("@pCloudcode", CLOUD_CODE);
                LstParam.Add(param);
                if (db.RunProcedure("SP_DELETE_CLOUD_CODE", LstParam) == -1)
                {
                    blnSuccess = false;
                    return blnSuccess;
                }
            }
            catch (Exception ex)
            {
                blnSuccess = false;
                throw ex;
            }
            finally
            {
                if (blnSuccess == false)
                {
                    //Rollback
                    DBtransaction.Rolbacktransaction();
                }
                else
                {
                    DBtransaction.Committransaction();
                }
                //Close connection
                DBtransaction.CloseConnection();
            }

            return blnSuccess;
        }

        public bool InsertCloudcode(SetupCloudcodeModel setupCloudcodeModel, string JSON)
        {
            bool blnSuccess = true;
            try
            {
                //Open connection
                DBtransaction.OpenConection();
                DBtransaction.Begintransaction();
                List<SqlParameter> LstParam = new List<SqlParameter>();
                SqlParameter param = null;
                if (!setupCloudcodeModel.IS_NEW_CLOUD_CODE)
                {
                    #region Delete
                    param = new SqlParameter("@pCloudcode", setupCloudcodeModel.CLOUD_CODE);
                    LstParam.Add(param);
                    if (DBtransaction.RunProcedureMultiple("SP_DELETE_CLOUD_CODE", LstParam) == -1)
                    {
                        blnSuccess = false;
                        return blnSuccess;
                    }
                    #endregion
                }

                #region Insert
                LstParam = new List<SqlParameter>();
                param = new SqlParameter("@pCloudcode", setupCloudcodeModel.CLOUD_CODE);
                LstParam.Add(param);
                param = new SqlParameter("@pBeginDate", setupCloudcodeModel.BEGIN_DATE.Value.ToString("yyyy-MM-dd"));
                LstParam.Add(param);
                if (setupCloudcodeModel.END_DATE.HasValue)
                {
                    param = new SqlParameter("@pEndDate", setupCloudcodeModel.END_DATE.Value.ToString("yyyy-MM-dd"));
                    LstParam.Add(param);
                }
                param = new SqlParameter("@pUpdUser", BeeConvert.StrVal(setupCloudcodeModel.UPD_USER));
                LstParam.Add(param);
                param = new SqlParameter("@pPassword", setupCloudcodeModel.PASSWORD_ENCRYPT);
                LstParam.Add(param);
                param = new SqlParameter("@pJson", JSON);
                LstParam.Add(param);
                if (DBtransaction.RunProcedureMultiple("SP_INSERT_CLOUD_CODE", LstParam) == -1)
                {
                    blnSuccess = false;
                    return blnSuccess;
                }
                #endregion
            }
            catch (Exception ex)
            {
                blnSuccess = false;
                throw ex;
            }
            finally
            {
                if (blnSuccess == false)
                {
                    //Rollback
                    DBtransaction.Rolbacktransaction();
                }
                else
                {
                    DBtransaction.Committransaction();
                }
                //Close connection
                DBtransaction.CloseConnection();
            }

            return blnSuccess;
        }