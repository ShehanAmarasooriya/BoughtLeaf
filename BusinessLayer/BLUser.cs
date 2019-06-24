using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLUser
    {
        private Decimal minRatetext_box;

        public Decimal MinRatetext_box
        {
            get { return minRatetext_box; }
            set { minRatetext_box = value; }
        }
    
        private static Boolean boolDayBlockAvailable;

        public static Boolean BoolDayBlockAvailable
        {
            get { return BLUser.boolDayBlockAvailable; }
            set { BLUser.boolDayBlockAvailable = value; }
        }
        private static Int32 usesID;

        public static Int32 UsesID
        {
            get { return BLUser.usesID; }
            set { BLUser.usesID = value; }
        }

        private static String strUserName;

        public static String StrUserName
        {
            get { return BLUser.strUserName; }
            set { BLUser.strUserName = value; }
        }
        private static String strUserPassword;

        public static String StrUserPassword
        {
            get { return BLUser.strUserPassword; }
            set { BLUser.strUserPassword = value; }
        }
        private static String strEstate;

        public static String StrEstate
        {
            get { return BLUser.strEstate; }
            set { BLUser.strEstate = value; }
        }
        private static String strDivision;

        public static String StrDivision
        {
            get { return BLUser.strDivision; }
            set { BLUser.strDivision = value; }
        }
        private static String strYear;

        public static String StrYear
        {
            get { return BLUser.strYear; }
            set { BLUser.strYear = value; }
        }
        private static String strMonth;

        public static String StrMonth
        {
            get { return BLUser.strMonth; }
            set { BLUser.strMonth = value; }
        }
        private String strMenuID;

        public String StrMenuID
        {
            get { return strMenuID; }
            set { strMenuID = value; }
        }

        private String strMenuName;

        public String StrMenuName
        {
            get { return strMenuName; }
            set { strMenuName = value; }
        }

        private Int32 intCompanyKey;

        public Int32 IntCompanyKey
        {
            get { return intCompanyKey; }
            set { intCompanyKey = value; }
        }
        private String strDepartmentCode;

        public String StrDepartmentCode
        {
            get { return strDepartmentCode; }
            set { strDepartmentCode = value; }
        }
        private String strCurrencyCode;

        public String StrCurrencyCode
        {
            get { return strCurrencyCode; }
            set { strCurrencyCode = value; }
        }
        private String sUserName;

        public String SUserName
        {
            get { return sUserName; }
            set { sUserName = value; }
        }
        private String sUserPassword;

        public String SUserPassword
        {
            get { return sUserPassword; }
            set { sUserPassword = value; }
        }
        private String sEstate;

        public String SEstate
        {
            get { return sEstate; }
            set { sEstate = value; }
        }
        private String sDivision;

        public String SDivision
        {
            get { return sDivision; }
            set { sDivision = value; }
        }
        private Int32 intMenuId;

        public Int32 IntMenuId
        {
            get { return intMenuId; }
            set { intMenuId = value; }
        }
        private String strRole;

        public String StrRole
        {
            get { return strRole; }
            set { strRole = value; }
        }

        //private String strMonthID;

        public static String strMonthID;

        public Boolean checkValidUser(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@Password", SqlDbType.VarChar);
            param.Value = StrUserPassword;
            paramList.Add(param);

            Boolean validUser = false;

            SqlDataReader dataReader;

            dataReader = SQLHelper.ExecuteReader("SELECT UserID FROM dbo.[User] WHERE (UserID = '" + StrUserName + "') AND (Password = '" + StrUserPassword + "')", CommandType.Text, paramList);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    validUser = true;
                }
            }
            dataReader.Close();
            return validUser;
        }

        public DataTable ListUserPermissionbyUserIDPassword(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@Password", SqlDbType.VarChar);
            param.Value = StrUserPassword;
            paramList.Add(param);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MenuName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Menu.MenuID FROM dbo.[User] INNER JOIN dbo.UserPermission ON dbo.[User].UserID = dbo.UserPermission.UserID COLLATE SQL_Latin1_General_CP1_CI_AS INNER JOIN dbo.Menu ON dbo.UserPermission.MenuID = dbo.Menu.MenuID WHERE (dbo.[User].UserID = '" + StrUserName + "') AND (dbo.[User].Password = '" + StrUserPassword + "')", CommandType.Text, paramList);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListUserPermissionbyUserID(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Password"));
            dt.Columns.Add(new DataColumn("MenuName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.[User].Password, dbo.Menu.MenuName FROM dbo.[User] INNER JOIN dbo.UserPermission ON dbo.[User].UserID = dbo.UserPermission.UserID COLLATE SQL_Latin1_General_CP1_CI_AS INNER JOIN dbo.Menu ON dbo.UserPermission.MenuID = dbo.Menu.MenuID WHERE    (dbo.[User].UserID = '" + StrUserName + "')", CommandType.Text, paramList);

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



        public DataTable ListAllMenuItems()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MenuID"));
            dt.Columns.Add(new DataColumn("MenuName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT     MenuID, MenuName FROM         dbo.Menu order by autoid", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1);
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;

        }

        public void InsertUser(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@Password", SqlDbType.VarChar);
            param.Value = StrUserPassword;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@CreatedBy", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@UserRole", SqlDbType.VarChar);
            param.Value = StrRole;
            paramList.Add(param);

            SQLHelper.ExecuteNonQuery("sp_InsertUser", CommandType.StoredProcedure, paramList);
        }

        public void PasswordChange(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@Password", SqlDbType.VarChar);
            param.Value = StrUserPassword;
            paramList.Add(param);

            SQLHelper.ExecuteNonQuery("update [User] set Password ='" + StrUserPassword + "' where UserID='" + StrUserName + "'", CommandType.Text, paramList);
        }

        public void DeleteUserPermission(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            SQLHelper.ExecuteNonQuery("delete from userpermission where userid = '" + StrUserName + "'", CommandType.Text, paramList);
        }

        public void DeleteUser(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            SQLHelper.ExecuteNonQuery("delete from [user] where userid = '" + StrUserName + "'", CommandType.Text, paramList);
        }

        public void InsertUserPermission(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = StrUserName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@MenuID", SqlDbType.VarChar);
            param.Value = myUser.StrMenuID;
            paramList.Add(param);

            SQLHelper.ExecuteNonQuery("SP_InsertUserPermission", CommandType.StoredProcedure, paramList);
        }

        public String FindMenuIdbyMenuName(BLUser myUser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@MenuName", SqlDbType.VarChar);
            param.Value = myUser.StrMenuName;
            paramList.Add(param);

            String MenuID = "";

            SqlDataReader dataReader;

            dataReader = SQLHelper.ExecuteReader("SELECT MenuID FROM dbo.Menu WHERE (MenuName = '" + myUser.StrMenuName + "')", CommandType.Text, paramList);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    MenuID = dataReader.GetString(0);
                }
            }
            dataReader.Close();
            return MenuID;
        }

        public void InsertMenu()
        {
            SQLHelper.ExecuteNonQuery("insert into Menu (MenuID,MenuName) values ('" + StrMenuID + "','" + StrMenuName + "')", CommandType.Text);
        }

        public void DeleteMenu()
        {
            SQLHelper.ExecuteNonQuery("delete from Menu", CommandType.Text);
        }
        
        public static String getCompanyName()
        {
            String CompanyName = "";

            SqlDataReader dataReader;

            //dataReader = SQLHelper.ExecuteReader("SELECT FactoryName FROM dbo.Factory", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT CompanyName FROM dbo.Company", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    CompanyName = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return CompanyName;
        }

        public static String getCompanyCode()
        {
            String CompanyCode = "";

            SqlDataReader dataReader;

            //dataReader = SQLHelper.ExecuteReader("SELECT FactoryName FROM dbo.Factory", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT CompanyCode FROM dbo.Company", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    CompanyCode = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return CompanyCode;
        }

        

        public static String getFactoryName()
        {
            String factoryName = "";

            SqlDataReader dataReader;

            dataReader = SQLHelper.ExecuteReader("SELECT FactoryName FROM dbo.Factory", CommandType.Text);
            
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    factoryName = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return factoryName;
        }
       

        public void DatabaseChange()
        {
            String dbChanges = "ALTER TABLE MonthlyPayments ADD OtherAddition decimal(18, 2)";
            SQLHelper.ExecuteNonQuery(dbChanges, CommandType.Text);

            dbChanges = "CREATE TABLE [dbo].[OtherAdditions]([YearCode] [int] NOT NULL,[MonthCode] [int] NOT NULL,[SupplierCode] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[IssueDate] [datetime] NOT NULL,[Amount] [decimal](18, 2) NOT NULL,[Remarks] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[UserID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[CreateDateTime] [datetime] NOT NULL CONSTRAINT [DF_OtherAdditions_CreateDateTime]  DEFAULT (getdate()),[Cancel] [bit] NOT NULL CONSTRAINT [DF_OtherAdditions_Cancel]  DEFAULT ((0)),[Processed] [bit] NOT NULL CONSTRAINT [DF_OtherAdditions_Processed]  DEFAULT ((0)),CONSTRAINT [PK_OtherAdditions] PRIMARY KEY CLUSTERED ([YearCode] ASC,[MonthCode] ASC,[SupplierCode] ASC,[IssueDate] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]";
            SQLHelper.ExecuteNonQuery(dbChanges, CommandType.Text);
        }
        public void DatabaseChange1()
        {
            String dbChanges = "ALTER TABLE Supplier  ADD Stationary bit NOT NULL DEFAULT ((1))";
            SQLHelper.ExecuteNonQuery(dbChanges, CommandType.Text);

            dbChanges = "ALTER TABLE OtherPaymentSettings  ADD StationaryCharge decimal(18, 2) NOT NULL DEFAULT ((5))";
            SQLHelper.ExecuteNonQuery(dbChanges, CommandType.Text);

            dbChanges = "ALTER TABLE MonthlyPayments  ADD StationaryAmount decimal(18, 2) NOT NULL DEFAULT ((0))";
            SQLHelper.ExecuteNonQuery(dbChanges, CommandType.Text);
        }

        public static Boolean IsIncentiveLevelsSettingRouteWise()
        {
            Boolean IsIncentiveLevelsRouteWise = true;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("select Value from dbo.Setting where Type='IsIncentiveLevelsRouteWise'", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    IsIncentiveLevelsRouteWise = dataReader.GetBoolean(0);
                }
            }
            dataReader.Close();
            return IsIncentiveLevelsRouteWise;
        }

        public void updateIncentiveLevelsSetting(Boolean value)
        {
            SQLHelper.ExecuteNonQuery("update dbo.Setting   set Value='" + value + "' where Type='IsIncentiveLevelsRouteWise'", CommandType.Text);
        }

        public DataTable ListAllUsers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("Password"));
            dt.Columns.Add(new DataColumn("CreatedDate"));
            dt.Columns.Add(new DataColumn("UserRole"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT UserID, Password,CreateDatetime,UserRole FROM [User]", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = "Password encrypted";
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetDateTime(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3).Trim();
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListAllRoles()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RoleName"));
            dt.Columns.Add(new DataColumn("IsActive"));
            dt.Columns.Add(new DataColumn("IsAdmin"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT UserRole, ActiveStatus, IsAdmin FROM dbo.UserRole", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetBoolean(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetBoolean(2);
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public void InsertRole(String RoleName, Boolean ActiveRole, Boolean isAdmin)
        {
            SQLHelper.ExecuteNonQuery("insert into UserRole(UserRole,ActiveStatus,IsAdmin) Values('" + RoleName + "','" + ActiveRole + "','" + isAdmin + "')", CommandType.Text);
        }

        public void InsertRolePermission(String RoleName, String MenuName)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@RoleName", SqlDbType.VarChar, 50);
            param.Value = RoleName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@MenuName", SqlDbType.VarChar, 50);
            param.Value = MenuName;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@CreatedUser", SqlDbType.VarChar, 50);
            param.Value = BoughtLeafBusinessLayer.BLUser.StrUserName;
            paramList.Add(param);

            SQLHelper.ExecuteNonQuery("SP_InsertRolePermission", CommandType.StoredProcedure, paramList);
        }

        public void DeleteUserRolePermission(String strUserRole)
        {
            SQLHelper.ExecuteNonQuery("delete from userpermission where UserRole = '" + strUserRole + "'", CommandType.Text);
        }

        public void DeleteRole(String RoleName)
        {

            SQLHelper.ExecuteNonQuery("delete from [UserRole] where UserRole = '" + RoleName + "'", CommandType.Text);
            SQLHelper.ExecuteNonQuery("INSERT INTO [UserAudit] (UserName, Password,UserID,TransactionDate,TransactionType) VALUES ('" + RoleName + "','NA','" + BoughtLeafBusinessLayer.BLUser.StrUserName + "',getdate(),'DELETED')", CommandType.Text);
        }

        public void UpdateUser(String strRole, String strUserName)
        {
            SQLHelper.ExecuteNonQuery("update dbo.[User] set UserRole='" + strRole + "' where UserID='" + strUserName + "'", CommandType.Text);
        }

        public DataTable ListUserPermissionbyRole(String struser)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@Role", SqlDbType.VarChar);
            param.Value = struser;
            paramList.Add(param);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MenuName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Menu.MenuItem FROM dbo.UserPermission INNER JOIN dbo.Menu ON dbo.UserPermission.MenuName = dbo.Menu.MenuItem WHERE     (dbo.UserPermission.UserRole = '" + struser + "')", CommandType.Text, paramList);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;

        }

        public void DeleteRolePermission(String strRole)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
            param.Value = strRole;
            paramList.Add(param);

            SQLHelper.ExecuteNonQuery("delete from userpermission where UserRole = '" + strRole + "'", CommandType.Text, paramList);
        }
    }
}
