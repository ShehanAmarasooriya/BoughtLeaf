using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLDeductionGroup
    {
        private string strDeductionGroupCode;

        public string StrDeductionGroupCode
        {
            get { return strDeductionGroupCode; }
            set { strDeductionGroupCode = value; }
        }
        private string strGroupName;

        public string StrGroupName
        {
            get { return strGroupName; }
            set { strGroupName = value; }
        }
        private int strPriority;

        public int StrPriority
        {
            get { return strPriority; }
            set { strPriority = value; }
        }

        private string strGroupType;

        public string StrGroupType
        {
            get { return strGroupType; }
            set { strGroupType = value; }
        }
        private bool boolDeductAmnt;

        public bool BoolDeductAmnt
        {
            get { return boolDeductAmnt; }
            set { boolDeductAmnt = value; }
        }

        private List<SqlParameter> makeParaList()
        {
            
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@DeductionGroupCode", SqlDbType.VarChar);
            param.Value = strDeductionGroupCode;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@GroupName", SqlDbType.VarChar);
            param.Value = strGroupName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@Priority", SqlDbType.VarChar);
            param.Value = strPriority;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@UserId", SqlDbType.VarChar);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@GroupType", SqlDbType.VarChar);
            param.Value = strGroupType;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@DeductAmount", SqlDbType.Bit);
            param.Value = boolDeductAmnt;
            paramList.Add(param);

            return paramList;
        }

        public string AddDeductionGroup()
        {
            String status = "";
            SqlParameter statusParam = new SqlParameter();
            SqlCommand cmd = SQLHelper.CreateCommand("sp_InsertDeductionGroups", CommandType.StoredProcedure, makeParaList());
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 100);
            statusParam.Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();

            return status;
        }

        public string UpdateDeductionGroup()
        {
            String status = "";
            SqlParameter statusParam = new SqlParameter();
            SqlCommand cmd = SQLHelper.CreateCommand("sp_UpdateDeductionGroups", CommandType.StoredProcedure, makeParaList());
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 100);
            statusParam.Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();

            return status;
        }

        public string DeleteDeductionGroup()
        {
            String status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter identityParam = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@DeductionGroupCode", SqlDbType.VarChar);
            param.Value = strDeductionGroupCode;
            paramList.Add(param);

            SqlCommand cmd = SQLHelper.CreateCommand("sp_DeleteDeductionGroups", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 100);
            statusParam.Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();

            return status;
        }

        public DataTable ViewAllDeductionGroup()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("GroupCode"));
            dt.Columns.Add(new DataColumn("GroupName"));
            dt.Columns.Add(new DataColumn("Priority"));
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("GroupType"));
            dt.Columns.Add(new DataColumn("DeductionAmount"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT DeductionGroupCode,GroupName,Priority,UserId,GroupType,DeductAmountActiveBit FROM DeductionGroup", CommandType.Text);

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
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable LoadComboboxGroupCode()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("GroupCode"));
            dt.Columns.Add(new DataColumn("GroupName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT DeductionGroupCode,GroupName FROM dbo.DeductionGroup", CommandType.Text);

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
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public bool statusOfDeductAmnt(string pDeductGroupCode) 
        {
            bool status = false;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT DeductAmountActiveBit FROM DeductionGroup where DeductionGroupCode = '" + pDeductGroupCode + "'", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    status = dataReader.GetBoolean(0);
                }
            }
            return status;
        }

        public string deductType(string pDeductGroupCode) 
        {
            string type = string.Empty;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT GroupType FROM DeductionGroup where DeductionGroupCode = '" + pDeductGroupCode + "'", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    type = dataReader.GetString(0);
                }
            }
            return type;
        }

        public int checkDeductionGroupInDeductoinCode(string pDeductGroup)
        {
            int count = 0;

            SqlDataReader reader;

            reader = SQLHelper.ExecuteReader("SELECT COUNT([DeductionGroupCode]) FROM [dbo].[DeductionCode] WHERE [DeductionGroupCode] = '" + pDeductGroup + "'", CommandType.Text);
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
