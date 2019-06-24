using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class SupplierDeduction
    {
        private Int32 intEmpDeductId;

        public Int32 IntEmpDeductId
        {
            get { return intEmpDeductId; }
            set { intEmpDeductId = value; }
        }
        private Int32 intMonth;

        public Int32 IntMonth
        {
            get { return intMonth; }
            set { intMonth = value; }
        }

        private Int32 intYear;

        public Int32 IntYear
        {
            get { return intYear; }
            set { intYear = value; }
        }

        private string strRouteNo;

        public string StrRouteNo
        {
            get { return strRouteNo; }
            set { strRouteNo = value; }
        }

        private Int32 intCategory;

        public Int32 IntCategory
        {
            get { return intCategory; }
            set { intCategory = value; }
        }

        private string strDeductionGroupCode;

        public string StrDeductionGroupCode
        {
            get { return strDeductionGroupCode; }
            set { strDeductionGroupCode = value; }
        }

        private Int32 intDeductGroupId;

        public Int32 IntDeductGroupId
        {
            get { return intDeductGroupId; }
            set { intDeductGroupId = value; }
        }
        private Int32 intNoOfMonths;

        public Int32 IntNoOfMonths
        {
            get { return intNoOfMonths; }
            set { intNoOfMonths = value; }
        }
        private Int32 intFromMonth;

        public Int32 IntFromMonth
        {
            get { return intFromMonth; }
            set { intFromMonth = value; }
        }
        private Int32 intFromYear;

        public Int32 IntFromYear
        {
            get { return intFromYear; }
            set { intFromYear = value; }
        }

        private DateTime fromDate;

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }

        private decimal noBags;

        public decimal NoBags
        {
            get { return noBags; }
            set { noBags = value; }
        }
        private decimal costPerBag;

        public decimal CostPerBag
        {
            get { return costPerBag; }
            set { costPerBag = value; }
        }

        private Decimal costPerBagCommission;

        public Decimal CostPerBagCommission
        {
            get { return costPerBagCommission; }
            set { costPerBagCommission = value; }
        }

        private Decimal decDeductAmount;

        public Decimal DecDeductAmount
        {
            get { return decDeductAmount; }
            set { decDeductAmount = value; }
        }

        private string strDeductionCode;

        public string StrDeductionCode
        {
            get { return strDeductionCode; }
            set { strDeductionCode = value; }
        }

        private Int32 intDeduction;

        public Int32 IntDeduction
        {
            get { return intDeduction; }
            set { intDeduction = value; }
        }
        private float flAmount;

        public float FlAmount
        {
            get { return flAmount; }
            set { flAmount = value; }
        }
        private String strSupNo;

        public String StrSupNo
        {
            get { return strSupNo; }
            set { strSupNo = value; }
        }
        private String strName;

        public String StrName
        {
            get { return strName; }
            set { strName = value; }
        }
        private String strUserId;

        public String StrUserId
        {
            get { return strUserId; }
            set { strUserId = value; }
        }
        private Boolean boolPeriodYesNo;

        public Boolean BoolPeriodYesNo
        {
            get { return boolPeriodYesNo; }
            set { boolPeriodYesNo = value; }
        }
        private DateTime dtPeriodFrom;

        public DateTime DtPeriodFrom
        {
            get { return dtPeriodFrom; }
            set { dtPeriodFrom = value; }
        }
        private DateTime dtPeriodTo;

        public DateTime DtPeriodTo
        {
            get { return dtPeriodTo; }
            set { dtPeriodTo = value; }
        }
        private Boolean boolAllCat;

        public Boolean BoolAllCat
        {
            get { return boolAllCat; }
            set { boolAllCat = value; }
        }
        private Int32 intFixedDeductId;

        public Int32 IntFixedDeductId
        {
            get { return intFixedDeductId; }
            set { intFixedDeductId = value; }
        }

        private Decimal decPrincipalAmount;

        public Decimal DecPrincipalAmount
        {
            get { return decPrincipalAmount; }
            set { decPrincipalAmount = value; }
        }
        private Decimal decBalanceAmount;

        public Decimal DecBalanceAmount
        {
            get { return decBalanceAmount; }
            set { decBalanceAmount = value; }
        }
        private Decimal decRecoveredAmount;

        public Decimal DecRecoveredAmount
        {
            get { return decRecoveredAmount; }
            set { decRecoveredAmount = value; }
        }
        private Decimal decRecoveredInstallments;

        public Decimal DecRecoveredInstallments
        {
            get { return decRecoveredInstallments; }
            set { decRecoveredInstallments = value; }
        }

        private Boolean boolCloseYesNo;

        public Boolean BoolCloseYesNo
        {
            get { return boolCloseYesNo; }
            set { boolCloseYesNo = value; }
        }
        private DateTime dtLastUpdate;

        public DateTime DtLastUpdate
        {
            get { return dtLastUpdate; }
            set { dtLastUpdate = value; }
        }

        private String gurantor1;

        public String Gurantor1
        {
            get { return gurantor1; }
            set { gurantor1 = value; }
        }
        private String gurantor2;

        public String Gurantor2
        {
            get { return gurantor2; }
            set { gurantor2 = value; }
        }

        private String strGur1Div;

        public String StrGur1Div
        {
            get { return strGur1Div; }
            set { strGur1Div = value; }
        }
        private String strGur2Div;

        public String StrGur2Div
        {
            get { return strGur2Div; }
            set { strGur2Div = value; }
        }

        private String strReason;

        public String StrReason
        {
            get { return strReason; }
            set { strReason = value; }
        }
        private Boolean boolFixed;

        public Boolean BoolFixed
        {
            get { return boolFixed; }
            set { boolFixed = value; }
        }

        private String strPayeeACNo;

        public String StrPayeeACNo
        {
            get { return strPayeeACNo; }
            set { strPayeeACNo = value; }
        }
        private String strPayeeACName;

        public String StrPayeeACName
        {
            get { return strPayeeACName; }
            set { strPayeeACName = value; }
        }
        private String strPayeeAmount;

        public String StrPayeeAmount
        {
            get { return strPayeeAmount; }
            set { strPayeeAmount = value; }
        }
        private Decimal decPayeeAmount;

        public Decimal DecPayeeAmount
        {
            get { return decPayeeAmount; }
            set { decPayeeAmount = value; }
        }

        //public String DeleteFixedDeduction()
        //{
        //    String status = "";
        //    SqlParameter param = new SqlParameter();
        //    SqlParameter identityParam = new SqlParameter();
        //    SqlParameter statusParam = new SqlParameter();
        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    param = SQLHelper.CreateParameter("@EmpDeductId", SqlDbType.Int, 4);
        //    param.Value = IntEmpDeductId;
        //    paramList.Add(param);
        //    SqlCommand cmd = SQLHelper.CreateCommand("spDeleteEmpDeductions", CommandType.StoredProcedure, paramList);
        //    statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
        //    statusParam.Direction = ParameterDirection.Output;
        //    SQLHelper.ExecuteNonQuery(cmd);
        //    status = statusParam.Value.ToString();
        //    return status;
        //}

        //ISURU
        //Insert Fixed Deductions
        public String InsertDeductions()
        {
            String status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter identityParam = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@DeductionGroupCode", SqlDbType.VarChar, 50);
            param.Value = StrDeductionGroupCode;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@DeductCode", SqlDbType.VarChar, 50);
            param.Value = StrDeductionCode;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@RouteNo", SqlDbType.VarChar, 50);
            param.Value = strRouteNo;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@SupNo", SqlDbType.VarChar, 50);
            param.Value = strSupNo;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@DeductAmount", SqlDbType.Float);
            param.Value = DecDeductAmount;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@NoOfMonths", SqlDbType.Int, 4);
            param.Value = IntNoOfMonths;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@StartMonth", SqlDbType.Int, 4);
            param.Value = IntFromMonth;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@StartYear", SqlDbType.Int, 4);
            param.Value = IntFromYear;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@StartDate", SqlDbType.DateTime);
            param.Value = fromDate;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@NoBags", SqlDbType.Decimal);
            param.Value = noBags;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@CostPerBags", SqlDbType.Decimal);
            param.Value = costPerBag;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@CostPerBagsCom", SqlDbType.Decimal);
            param.Value = costPerBagCommission;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@UserId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@RepeatUntilStop", SqlDbType.Bit);
            param.Value = BoolFixed;
            paramList.Add(param);

            SqlCommand cmd = SQLHelper.CreateCommand("SP_InsertSupplierDeductions", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@RTNValue", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();
            return status;
        }

        //ISURU
        //Update Fixed Deductions
        public String UpdateDeductions()
        {
            String status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter identityParam = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();
            param = SQLHelper.CreateParameter("@DeductionGroupCode", SqlDbType.VarChar, 50);
            param.Value = StrDeductionGroupCode;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@DeductCode", SqlDbType.VarChar, 50);
            param.Value = StrDeductionCode;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@RouteNo", SqlDbType.VarChar, 50);
            param.Value = strRouteNo;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@SupNo", SqlDbType.VarChar, 50);
            param.Value = strSupNo;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@DeductAmount", SqlDbType.Float);
            param.Value = DecDeductAmount;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@NoOfMonths", SqlDbType.Int, 4);
            param.Value = IntNoOfMonths;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@StartMonth", SqlDbType.Int, 4);
            param.Value = IntFromMonth;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@StartYear", SqlDbType.Int, 4);
            param.Value = IntFromYear;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@StartDate", SqlDbType.DateTime);
            param.Value = fromDate;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@NoBags", SqlDbType.Decimal);
            param.Value = noBags;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@CostPerBags", SqlDbType.Decimal);
            param.Value = costPerBag;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@CostPerBagsCom", SqlDbType.Decimal);
            param.Value = costPerBagCommission;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@UserId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@RepeatUntilStop", SqlDbType.Bit);
            param.Value = BoolFixed;
            paramList.Add(param);

            SqlCommand cmd = SQLHelper.CreateCommand("SP_UpdateSupplierDeductions", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@RTNValue", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            status = statusParam.Value.ToString();
            return status;
        }

        public void DeleteFixedDeductions()
        {
            SQLHelper.ExecuteNonQuery("INSERT INTO [dbo].[DeleteLog]([DeletedDate],[RefNo],[ReferenceTable],[EmpNo],[Amount],[Narration1],[Naration2],DeletedBy) VALUES(getdate(),'" + IntFixedDeductId + "','PRFixedDeductions','" + strSupNo + "' ,'" + DecDeductAmount + "','" + IntDeductGroupId.ToString() + "','" + IntDeduction.ToString() + "','" + BLUser.StrUserName + "')", CommandType.Text);
            SQLHelper.ExecuteNonQuery("DELETE FROM SupplierDeductions WHERE (FixedDeductionId  = '" + IntFixedDeductId + "') ", CommandType.Text);
        }

        public void TerminateFixedDeductions()
        {
            SQLHelper.ExecuteNonQuery("UPDATE SupplierDeductions SET CloseYesNo = 1, TerminatedBy='" + StrUserId + "', TerminateReson='" + StrReason + "' WHERE (FixedDeductionId='" + intFixedDeductId + "')", CommandType.Text);
        }

        public void DirectPaymentFixedDeductions(DateTime dtDPDate, Int32 intDPYear, Int32 intDPMonth, String strDPDiv, String strDPEmp, String DeductCode, String GroupCode, Decimal decDPAmount, String strDPRefNo, String strDPReason)
        {
            SQLHelper.ExecuteNonQuery("UPDATE dbo.CHKFixedDeductions SET DirectPayment=DirectPayment+'" + decDPAmount + "',BalanceAmount=BalanceAmount-'" + decDPAmount + "' WHERE (StartYear = '" + intDPYear + "') AND (StartMonth = '" + intDPMonth + "') AND (DivisionId = '" + strDPDiv + "') AND (EmpNo = '" + strDPEmp + "')  AND (DeductionId = '" + DeductCode + "')", CommandType.Text);
            SQLHelper.ExecuteNonQuery("INSERT INTO CHKFixedDeductDirectPayment ([DateOfPayment],[DivisionID],[EmpNo],[DeductGroupId],[DeductId],[RefNo],[Amount],[Reason],[CreateDateTime],[UserID]) VALUES('" + dtDPDate + "','" + strDPDiv + "','" + strDPEmp + "','" + GroupCode + "','" + DeductCode + "','" + strDPRefNo + "','" + decDPAmount + "','" + strDPReason + "',getdate(),'" + BLUser.StrUserName + "')", CommandType.Text);
        }

        //Isuru
        //Check Whether Is Recovered  Given Fixed Deduction In Previous Months
        public Boolean IsRecoveredDeduction(DateTime pDate, Int32 PYear, Int32 PMonth, String GroupCode, String DeductCode, String strSup)
        {
            Boolean boolIsRecovered = false;
            DataSet dsRecoveries = new DataSet();
            dsRecoveries = SQLHelper.FillDataSet("SELECT StartYear, StartMonth, RouteNo, SupplierCode, DeductionGroupCode, DeductCode, RecoveredAmount FROM dbo.SupplierDeductions WHERE (StartYear = '" + PYear + "') AND (StartMonth = '" + PMonth + "') AND (SupplierCode = '" + strSup + "') AND (DeductionGroupCode = '" + GroupCode + "') AND (DeductCode = '" + DeductCode + "') AND (StartDate = '" + pDate + "') AND (RecoveredAmount > 0)", CommandType.Text);
            if (dsRecoveries.Tables[0].Rows.Count > 0)
                boolIsRecovered = true;
            else
                boolIsRecovered = false;
            return boolIsRecovered;
        }

        //Sachintha Udara Create
        public DataTable ListOutstandingFixedDeductions(string GroupCode, string DeductCode, string strSup, string groupType)
        {
            DataTable dt = new DataTable();
            SqlDataReader reader;
            DataRow drow;
            dt.Columns.Add("SupplierCode");//0
            dt.Columns.Add("FromYear");//1
            dt.Columns.Add("FromMonth");//2
            dt.Columns.Add("IssueDate");//3
            dt.Columns.Add("DeductGroup");//4
            dt.Columns.Add("DeductCode");//5
            dt.Columns.Add("No.Bags");//6
            dt.Columns.Add("CostPerBag");//7
            dt.Columns.Add("MoAmount");//8
            dt.Columns.Add("NoOfMonths");//9
            dt.Columns.Add("Balance");//10
            dt.Columns.Add("Ref#");//11
            dt.Columns.Add("Route");//12
            dt.Columns.Add("DeductionType");//13

            reader = SQLHelper.ExecuteReader("SELECT dbo.SupplierDeductions.SupplierCode, dbo.SupplierDeductions.StartYear, dbo.SupplierDeductions.StartMonth, dbo.SupplierDeductions.StartDate, dbo.DeductionGroup.DeductionGroupCode AS GroupShortName, dbo.DeductionCode.DeductionCode, dbo.SupplierDeductions.NoBags, dbo.SupplierDeductions.CostPerBag, dbo.SupplierDeductions.DeductAmount, dbo.SupplierDeductions.NoOfMonths, dbo.SupplierDeductions.BalanceAmount, dbo.SupplierDeductions.FixedDeductionId, dbo.SupplierDeductions.RouteNo, 'FIXED' AS Expr1 FROM dbo.DeductionGroup INNER JOIN dbo.SupplierDeductions ON dbo.DeductionGroup.DeductionGroupCode = dbo.SupplierDeductions.DeductionGroupCode INNER JOIN dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode WHERE (dbo.SupplierDeductions.DeductionGroupCode LIKE '" + GroupCode + "') AND (dbo.SupplierDeductions.DeductCode LIKE '" + DeductCode + "') AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.BalanceAmount > 0) AND  (dbo.SupplierDeductions.SupplierCode LIKE '" + strSup + "') AND (dbo.SupplierDeductions.CloseYesNo = 0) ORDER BY dbo.SupplierDeductions.FixedDeductionId DESC", CommandType.Text);
            drow = dt.NewRow();
            while (reader.Read())
            {
                drow = dt.NewRow();
                if (!reader.IsDBNull(0))
                {
                    drow[0] = reader.GetString(0).Trim();
                }
                if (!reader.IsDBNull(1))
                {
                    drow[1] = reader.GetInt32(1);
                }
                if (!reader.IsDBNull(2))
                {
                    drow[2] = reader.GetInt32(2);
                }
                if (!reader.IsDBNull(3))
                {
                    drow[3] = reader.GetDateTime(3);
                }
                if (!reader.IsDBNull(4))
                {
                    drow[4] = reader.GetString(4);
                }
                if (!reader.IsDBNull(5))
                {
                    drow[5] = reader.GetString(5);
                }
                if (!reader.IsDBNull(6))
                {
                    drow[6] = reader.GetDecimal(6);
                }
                if (!reader.IsDBNull(7))
                {
                    drow[7] = reader.GetDecimal(7);
                }
                if (!reader.IsDBNull(8))
                {
                    drow[8] = reader.GetDecimal(8);
                }
                if (!reader.IsDBNull(9))
                {
                    drow[9] = reader.GetInt32(9);
                }
                if (!reader.IsDBNull(10))
                {
                    drow[10] = reader.GetDecimal(10);
                }
                if (!reader.IsDBNull(11))
                {
                    drow[11] = reader.GetInt32(11);
                }
                if (!reader.IsDBNull(12))
                {
                    drow[12] = reader.GetString(12);
                }
                if (!reader.IsDBNull(13))
                {
                    drow[13] = reader.GetString(13);
                }
                dt.Rows.Add(drow);
            }
            //if (!groupType.Equals("Tea_Ferti"))
            //{
            //    dt.Columns.Remove("IssueDate");//3
            //    dt.Columns.Remove("No.Bags");//6
            //    dt.Columns.Remove("CostPerBag");//7
            //}
            return dt;
        }

        //Isuru
        //Get Outstanding Fixed Deduction Total
        public Decimal GetOutstandingFixedDeductionTotal(String GroupCode, String DeductCode, String strEmp)
        {
            SqlDataReader fixedTotalReader;
            Decimal decFixedTotal = 0;
            fixedTotalReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.SupplierDeductions.PrincipalAmount) AS Expr1 FROM dbo.DeductionCode INNER JOIN dbo.DeductionGroup ON dbo.DeductionCode.DeductionGroupCode = dbo.DeductionGroup.DeductionGroupCode INNER JOIN dbo.SupplierDeductions ON dbo.DeductionCode.DeductionCode = dbo.SupplierDeductions.DeductCode AND  dbo.DeductionCode.DeductionGroupCode = dbo.SupplierDeductions.DeductionGroupCode WHERE     (dbo.SupplierDeductions.DeductionGroupCode = '" + GroupCode + "') AND (dbo.SupplierDeductions.DeductCode = '" + DeductCode + "')  AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.SupplierCode LIKE '%')", CommandType.Text);
            while (fixedTotalReader.Read())
            {
                if (!fixedTotalReader.IsDBNull(0))
                {
                    decFixedTotal = fixedTotalReader.GetDecimal(0);
                }
            }
            return decFixedTotal;
        }

        public void settleDeduction(int pYear, int pMonth, string pSupplierCode)
        {
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT PrincipalAmount,DeductionGroupCode,DeductCode, NoOfMonths, StartYear, StartMonth, StartDate, RouteNo FROM dbo.SupplierDeductions WHERE (BalanceAmount > 0) AND (SupplierCode = '" + pSupplierCode + "') AND (Approval = 1) AND (CloseYesNo = 0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    decimal AmountSettled = 0;
                    int NoofMonths = 0;

                    AmountSettled = dataReader.GetDecimal(0) / dataReader.GetInt32(3);
                    NoofMonths = dataReader.GetInt32(3) - 1;
                    SQLHelper.ExecuteNonQuery("UPDATE dbo.SupplierDeductions SET RecoveredInstallments = (RecoveredInstallments + 1), BalanceAmount = (BalanceAmount - " + AmountSettled + "), RecoveredAmount = (RecoveredAmount + " + AmountSettled + "), DeductedYear ='" + pYear + "' , DeductedMonth = '" + pMonth + "', DeductedAmount = " + AmountSettled + " WHERE DeductCode='" + dataReader.GetString(2) + "' AND  StartYear = '" + dataReader.GetInt32(4) + "' AND StartMonth = '" + dataReader.GetInt32(5) + "' AND SupplierCode = '" + pSupplierCode + "' AND StartDate='" + dataReader.GetDateTime(6) + "'", CommandType.Text);
                    SQLHelper.ExecuteNonQuery("INSERT INTO [dbo].[SupplierDeductionsSettlement]([Suppliyer],[StartYear],[StartMonth],[StartDate],[DeductYear],[DeductMonth],[DeductionGroupCode],[DeductCode],[RouteCode],[Description],[Amount],[CreateDateTime],[UserId]) VALUES ('" + pSupplierCode + "', '" + dataReader.GetInt32(4) + "', '" + dataReader.GetInt32(5) + "','" + dataReader.GetDateTime(6) + "','" + pYear + "','" + pMonth + "','" + dataReader.GetString(1) + "','" + dataReader.GetString(2) + "','" + dataReader.GetString(7) + "','NA', " + AmountSettled + ", '" + DateTime.Now.Date + "','" + BLUser.StrUserName + "')", CommandType.Text);
                }
            }
            dataReader.Close();
        }

        public decimal getSupDeduction(int pYear, int pMonth, string pSupplierCode, string pDeductGroup)
        {
            decimal deductAmount = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT Amount FROM [dbo].[SupplierDeductionsSettlement] WHERE (DeductYear = '" + pYear + "') AND (DeductMonth = '" + pMonth + "') AND (Suppliyer = '" + pSupplierCode + "') AND (DeductionGroupCode LIKE '" + pDeductGroup + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    deductAmount += dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return deductAmount;
        }

        public void cancelAllDeduction(int pYear, int pMonth)
        {
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT [Suppliyer],[DeductCode],[Amount],[StartYear],[StartMonth],[StartDate] FROM [dbo].[SupplierDeductionsSettlement] WHERE [DeductYear]='" + pYear + "' AND [DeductMonth]='" + pMonth + "'", CommandType.Text);
            while (dataReader.Read())
            {
                SQLHelper.ExecuteNonQuery("UPDATE dbo.SupplierDeductions SET RecoveredInstallments = (RecoveredInstallments - 1), RecoveredAmount = (RecoveredAmount - " + dataReader.GetDecimal(2) + "), BalanceAmount = (BalanceAmount + " + dataReader.GetDecimal(2) + "), DeductedYear = '0', DeductedMonth = '0', DeductedAmount='0' where DeductCode='" + dataReader.GetString(1) + "' AND  StartYear = '" + dataReader.GetInt32(3) + "' AND StartMonth = '" + dataReader.GetInt32(4) + "' AND StartDate = '" + dataReader.GetDateTime(5) + "' AND SupplierCode = '" + dataReader.GetString(0) + "'", CommandType.Text);
            }
            dataReader.Close();

            SQLHelper.ExecuteNonQuery("DELETE FROM [dbo].[SupplierDeductionsSettlement] WHERE (DeductYear = '" + pYear + "') AND (DeductMonth = '" + pMonth + "')", CommandType.Text);
        }

        public DataTable ListSupplierDeductionForApproval(int pYear, int pMonth, string pDeductGroup)
        {
            if ((pDeductGroup.Equals("FET")) || (pDeductGroup.Equals("TEA")))
                return SQLHelper.FillDataSet("SELECT DeductCode, StartYear, StartMonth, StartDate, SupplierCode, Approval, RouteNo, NoBags, CostPerBag, CostPerBagCommission, NoOfMonths, DeductAmount, PrincipalAmount  FROM dbo.SupplierDeductions WHERE StartYear = " + pYear + " AND StartMonth = " + pMonth + " AND DeductionGroupCode LIKE ('" + pDeductGroup + "')", CommandType.Text).Tables[0];
            else if (pDeductGroup.Equals("%"))
                return SQLHelper.FillDataSet("SELECT DeductCode, StartYear, StartMonth, StartDate, SupplierCode, Approval, RouteNo, NoBags, CostPerBag, CostPerBagCommission, NoOfMonths, DeductAmount, PrincipalAmount  FROM dbo.SupplierDeductions WHERE StartYear = " + pYear + " AND StartMonth = " + pMonth + " AND DeductionGroupCode LIKE ('" + pDeductGroup + "')", CommandType.Text).Tables[0];
            else
                return SQLHelper.FillDataSet("SELECT DeductCode, StartYear, StartMonth, StartDate, SupplierCode, Approval, RouteNo, NoOfMonths, DeductAmount, PrincipalAmount  FROM dbo.SupplierDeductions WHERE StartYear = " + pYear + " AND StartMonth = " + pMonth + " AND DeductionGroupCode LIKE ('" + pDeductGroup + "') AND DeductionGroupCode NOT IN ('FET', 'TEA')", CommandType.Text).Tables[0];
        }

        public void ApprovalSuppllierDeduction(string pSupCode, string pDeductCode, int pStartYear, int pStartMonth, DateTime pStartDate, bool pApproval)
        {
            SQLHelper.FillDataSet("UPDATE [dbo].[SupplierDeductions] SET [Approval] = '" + pApproval + "' WHERE [DeductCode]='" + pDeductCode + "' AND [StartYear]='" + pStartYear + "' AND [StartMonth]='" + pStartMonth + "' AND [StartDate]='" + pStartDate + "' AND [SupplierCode]='" + pSupCode + "' ", CommandType.Text);
        }

        public DataSet GetDeductionRegister()
        {
            DataSet dsDeductReg = new DataSet("DeductRegister");
            dsDeductReg = SQLHelper.FillDataSet("SELECT DeductionGroupCode, DeductCode, StartYear, StartMonth, SupplierCode, DeductAmount, RouteNo FROM dbo.SupplierDeductions WHERE        (BalanceAmount > 0)", CommandType.Text);
            return dsDeductReg;
        }
    }
}