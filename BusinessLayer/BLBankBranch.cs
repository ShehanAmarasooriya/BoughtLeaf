using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLBankBranch
    {
        private string _branchCode;

        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }
        private string _branchName;

        public string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }
        private string _bankCode;

        public string BankCode
        {
            get { return _bankCode; }
            set { _bankCode = value; }
        }

        public void InsertBankBranch()
        {
            SQLHelper.ExecuteNonQuery("insert into BankBranch (BranchCode,BranchName,BankCode) values ('" + _branchCode + "','" + _branchName + "', '" + _bankCode + "')", CommandType.Text);
        }

        public void UpdateBranch()
        {
            SQLHelper.ExecuteNonQuery("update BankBranch set BranchCode = '" + _branchCode + "', BranchName='" + _branchName + "' where BranchCode = '" + _branchCode + "' and BankCode='" + _bankCode + "'", CommandType.Text);
        }

        public void DeleteBranch()
        {
            SQLHelper.ExecuteNonQuery("delete from BankBranch where BankCode = '" + _bankCode + "' and BranchCode = '" + _branchCode + "'", CommandType.Text);
        }

        public DataTable ListBranchDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("BranchCode"));
            dt.Columns.Add(new DataColumn("BranchName"));
            dt.Columns.Add(new DataColumn("BankCode"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT BranchCode, BranchName, BankCode FROM dbo.BankBranch", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2).Trim();
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListBranchDetails(string pBankCode)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("BranchCode"));
            dt.Columns.Add(new DataColumn("BranchName"));
            dt.Columns.Add(new DataColumn("BankCode"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT BranchCode, BranchName, BankCode FROM dbo.BankBranch where BankCode= '" + pBankCode + "'", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2).Trim();
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
    }
}
