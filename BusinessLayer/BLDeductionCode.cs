using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLDeductionCode
    {
        private string strDeductionCode;

        public string StrDeductionCode
        {
            get { return strDeductionCode; }
            set { strDeductionCode = value; }
        }
        private string strDeductionName;

        public string StrDeductionName
        {
            get { return strDeductionName; }
            set { strDeductionName = value; }
        }
        private int strDeductionPriority;

        public int StrDeductionPriority
        {
            get { return strDeductionPriority; }
            set { strDeductionPriority = value; }
        }
        private string strDeductionAccountCode;

        public string StrDeductionAccountCode
        {
            get { return strDeductionAccountCode; }
            set { strDeductionAccountCode = value; }
        }

        private Boolean strDeductionUntillStop;

        public Boolean StrDeductionUntillStop
        {
            get { return strDeductionUntillStop; }
            set { strDeductionUntillStop = value; }
        }

        private string strDeductionGroupCode;

        public string StrDeductionGroupCode
        {
            get { return strDeductionGroupCode; }
            set { strDeductionGroupCode = value; }
        }

        private String strBankCode;

        public String StrBankCode
        {
            get { return strBankCode; }
            set { strBankCode = value; }
        }
        private String strBranchCode;

        public String StrBranchCode
        {
            get { return strBranchCode; }
            set { strBranchCode = value; }
        }

        private decimal deductAmount;

        public decimal DeductAmount
        {
            get { return deductAmount; }
            set { deductAmount = value; }
        }

        private decimal commissionAmount;

        public decimal CommissionAmount
        {
            get { return commissionAmount; }
            set { commissionAmount = value; }
        }

        public DataTable ViewAllDeduction()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("DeductionCode")); //0
            dt.Columns.Add(new DataColumn("DeductionName")); //1
            dt.Columns.Add(new DataColumn("DeductionAmount")); //2
            dt.Columns.Add(new DataColumn("Commission")); //3
            dt.Columns.Add(new DataColumn("Priority")); //4
            dt.Columns.Add(new DataColumn("AccountCode")); //5
            dt.Columns.Add(new DataColumn("UserID")); //6
            dt.Columns.Add(new DataColumn("DeductUntilStop")); //7
            dt.Columns.Add(new DataColumn("DeductionGroupCode")); //8

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT DeductionCode, DeductionName, DeductionAmount,CommissionAmount, Priority,GLAccountCode,UserId,DeductUntilStop,DeductionGroupCode FROM DeductionCode", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1).Trim();
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetDecimal(2).ToString();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3).ToString();
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetInt32(4).ToString();
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetString(5).Trim();
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetString(6).Trim();
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetBoolean(7);
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetString(8).Trim();
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;

        }

        public DataTable ViewAllDeductionByGroup(String pGroup)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("DeductionCode")); //0
            dt.Columns.Add(new DataColumn("DeductionName")); //1
            dt.Columns.Add(new DataColumn("Priority")); //2
            dt.Columns.Add(new DataColumn("AccountCode")); //3
            dt.Columns.Add(new DataColumn("UserID")); //4
            dt.Columns.Add(new DataColumn("DeductUntilStop")); //5
            dt.Columns.Add(new DataColumn("DeductionGroupCode")); //6
            dt.Columns.Add(new DataColumn("BankCode")); //7
            dt.Columns.Add(new DataColumn("BranchCode")); //8
            dt.Columns.Add(new DataColumn("DeductionAmount")); //9
            dt.Columns.Add(new DataColumn("Commission")); //10

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT DeductionCode,DeductionName,Priority,GLAccountCode,UserId,DeductUntilStop,DeductionGroupCode,BankCode,BranchCode,DeductionAmount,CommissionAmount FROM DeductionCode WHERE DeductionGroupCode = '" + pGroup + "'", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1).Trim();
                }

                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetInt32(2).ToString();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3).Trim();
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4).Trim();
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetBoolean(5);
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetString(6).Trim();
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetString(7).Trim();
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetString(8).Trim();
                }
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetDecimal(9);
                }
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetDecimal(10);
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        private List<SqlParameter> setParameterList()
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@DeductionCode", SqlDbType.VarChar);
            param.Value = StrDeductionCode;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@DeductionName", SqlDbType.VarChar);
            param.Value = StrDeductionName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@Priority", SqlDbType.Int);
            param.Value = StrDeductionPriority;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@AccountCode", SqlDbType.VarChar);
            param.Value = StrDeductionAccountCode;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@UserId", SqlDbType.VarChar);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@DeductUntilStop", SqlDbType.Bit);
            param.Value = StrDeductionUntillStop;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@DeductionGroupCode", SqlDbType.VarChar);
            param.Value = StrDeductionGroupCode;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@BankCode", SqlDbType.VarChar);
            param.Value = StrBankCode;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@BranchCode", SqlDbType.VarChar);
            param.Value = StrBranchCode;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@DeductAmount", SqlDbType.VarChar);
            param.Value = deductAmount;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@CommissionAmount", SqlDbType.VarChar);
            param.Value = commissionAmount;
            paramList.Add(param);

            return paramList;
        }

        public string AddDeduction()
        {
            String status = "";
            SqlParameter statusParam = new SqlParameter();
            SqlCommand cmd = SQLHelper.CreateCommand("sp_InsertDeductionCodes", CommandType.StoredProcedure, setParameterList());
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 100);
            statusParam.Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();

            return status;

        }

        public string UpdateDeduction()
        {
            String status = "";
            SqlParameter statusParam = new SqlParameter();
            SqlCommand cmd = SQLHelper.CreateCommand("SP_UpdateDeductionCodes", CommandType.StoredProcedure, setParameterList());
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 100);
            statusParam.Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();

            return status;
        }

        public string DeleteDeduction()
        {
            String status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter identityParam = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@DeductionCode", SqlDbType.VarChar);
            param.Value = strDeductionCode;
            paramList.Add(param);


            SqlCommand cmd = SQLHelper.CreateCommand("SP_DeleteDeductionCodes", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 100);
            statusParam.Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();

            return status;
        }

        public decimal getDeductionAmount(string pDeductCode)
        {
            decimal amount = 0;

            SqlDataReader reader;

            reader = SQLHelper.ExecuteReader("SELECT DeductionAmount FROM DeductionCode WHERE DeductionCode = '" + pDeductCode + "'", CommandType.Text);
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    amount = reader.GetDecimal(0);
                }
            }
            return amount;
        }

        public decimal getDeductionCommisionAmount(string pDeductCode)
        {
            decimal amount = 0;

            SqlDataReader reader;

            reader = SQLHelper.ExecuteReader("SELECT CommissionAmount FROM DeductionCode WHERE DeductionCode = '" + pDeductCode + "'", CommandType.Text);
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    amount = reader.GetDecimal(0);
                }
            }
            return amount;
        }

        public int checkDeductionCodeInDeductoinTRN(string pDeductCode) 
        {
            int count = 0;

            SqlDataReader reader;

            reader = SQLHelper.ExecuteReader("SELECT COUNT([DeductCode]) FROM [dbo].[SupplierDeductions] WHERE [DeductCode] = '" + pDeductCode + "'", CommandType.Text);
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    count = reader.GetInt32(0);
                }
            }
            return count;
        }
    }
}
