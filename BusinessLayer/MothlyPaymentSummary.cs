using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BoughtLeafDataAccess;
using System.Data;

namespace BoughtLeafBusinessLayer
{
    public class MothlyPaymentSummary
    {
        //Special variable
        List<SqlParameter> paraList = new List<SqlParameter>(); 

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private int month;

        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        private string supplierCode;

        public string SupplierCode
        {
            get { return supplierCode; }
            set { supplierCode = value; }
        }
        private string routeCode;

        public string RouteCode
        {
            get { return routeCode; }
            set { routeCode = value; }
        }
        private decimal greenLeafKillo;

        public decimal GreenLeafKillo
        {
            get { return greenLeafKillo; }
            set { greenLeafKillo = value; }
        }
        private decimal greenLeafRate;

        public decimal GreenLeafRate
        {
            get { return greenLeafRate; }
            set { greenLeafRate = value; }
        }

        private decimal greenLeafValue;

        public decimal GreenLeafValue
        {
            get { return greenLeafValue; }
            set { greenLeafValue = value; }
        }
        private decimal incentive;

        public decimal Incentive
        {
            get { return incentive; }
            set { incentive = value; }
        }
        private decimal otherAddition;

        public decimal OtherAddition
        {
            get { return otherAddition; }
            set { otherAddition = value; }
        }
        private decimal cFCoinBalance;

        public decimal CFCoinBalance
        {
            get { return cFCoinBalance; }
            set { cFCoinBalance = value; }
        }
        private decimal totalEarning;

        public decimal TotalEarning
        {
            get { return totalEarning; }
            set { totalEarning = value; }
        }
        private decimal fertilizer;

        public decimal Fertilizer
        {
            get { return fertilizer; }
            set { fertilizer = value; }
        }
        private decimal transport;

        public decimal Transport
        {
            get { return transport; }
            set { transport = value; }
        }
        private decimal loan;

        public decimal Loan
        {
            get { return loan; }
            set { loan = value; }
        }
        private decimal cachAdvace;

        public decimal CachAdvace
        {
            get { return cachAdvace; }
            set { cachAdvace = value; }
        }
        private decimal paySlip;

        public decimal PaySlip
        {
            get { return paySlip; }
            set { paySlip = value; }
        }
        private decimal stampDuty;

        public decimal StampDuty
        {
            get { return stampDuty; }
            set { stampDuty = value; }
        }
        private decimal madeTea;

        public decimal MadeTea
        {
            get { return madeTea; }
            set { madeTea = value; }
        }
        private decimal otherDeduction;

        public decimal OtherDeduction
        {
            get { return otherDeduction; }
            set { otherDeduction = value; }
        }
        private decimal cFDebtBalance;

        public decimal CFDebtBalance
        {
            get { return cFDebtBalance; }
            set { cFDebtBalance = value; }
        }
        private decimal totalDeduction;

        public decimal TotalDeduction
        {
            get { return totalDeduction; }
            set { totalDeduction = value; }
        }
        private decimal paymentDue;

        public decimal PaymentDue
        {
            get { return paymentDue; }
            set { paymentDue = value; }
        }
        private decimal netPay;

        public decimal NetPay
        {
            get { return netPay; }
            set { netPay = value; }
        }
        private decimal bFDebt;

        public decimal BFDebt
        {
            get { return bFDebt; }
            set { bFDebt = value; }
        }
        private decimal bFCoin;

        public decimal BFCoin
        {
            get { return bFCoin; }
            set { bFCoin = value; }
        }

        private decimal loanOutstading;

        public decimal LoanOutstading
        {
            get { return loanOutstading; }
            set { loanOutstading = value; }
        }

        private decimal fertiOutstanding;

        public decimal FertiOutstanding
        {
            get { return fertiOutstanding; }
            set { fertiOutstanding = value; }
        }

        private string editUser;

        public string EditUser
        {
            get { return editUser; }
            set { editUser = value; }
        }

        private DateTime editDateTime;

        public DateTime EditDateTime
        {
            get { return editDateTime; }
            set { editDateTime = value; }
        }

        public void parameterAssign()
        {
            SqlParameter param = null;

            param = SQLHelper.CreateParameter("@year", SqlDbType.Int);
            param.Value = year;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@month", SqlDbType.Int);
            param.Value = month;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@supplier", SqlDbType.VarChar);
            param.Value = supplierCode;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@routeCode", SqlDbType.VarChar);
            param.Value = routeCode;
            paraList.Add(param);

            param = SQLHelper.CreateParameter("@greenLeafKillo", SqlDbType.Decimal);
            param.Value = greenLeafKillo;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@greenLeafRate", SqlDbType.Decimal);
            param.Value = greenLeafRate;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@greenLeafValue", SqlDbType.Decimal);
            param.Value = greenLeafValue;
            paraList.Add(param);

            param = SQLHelper.CreateParameter("@incentive", SqlDbType.Decimal);
            param.Value = incentive;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@otherAddition", SqlDbType.Decimal);
            param.Value = otherAddition;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@cfCoinBal", SqlDbType.Decimal);
            param.Value = cFCoinBalance;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@totalEarning", SqlDbType.Decimal);
            param.Value = totalEarning;
            paraList.Add(param);

            param = SQLHelper.CreateParameter("@fertilizer", SqlDbType.Decimal);
            param.Value = fertilizer;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@transport", SqlDbType.Decimal);
            param.Value = transport;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@loan", SqlDbType.Decimal);
            param.Value = loan;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@cashAdvance", SqlDbType.Decimal);
            param.Value = cachAdvace;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@paySlip", SqlDbType.Decimal);
            param.Value = paySlip;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@stampDuty", SqlDbType.Decimal);
            param.Value = stampDuty;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@madeTea", SqlDbType.Decimal);
            param.Value = madeTea;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@otherDeduct", SqlDbType.Decimal);
            param.Value = otherDeduction;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@cfDebtBal", SqlDbType.Decimal);
            param.Value = cFDebtBalance;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@totalDedcut", SqlDbType.Decimal);
            param.Value = totalDeduction;
            paraList.Add(param);

            param = SQLHelper.CreateParameter("@paymentDue", SqlDbType.Decimal);
            param.Value = paymentDue;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@netPay", SqlDbType.Decimal);
            param.Value = netPay;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@bfDept", SqlDbType.Decimal);
            param.Value = bFDebt;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@bfCoin", SqlDbType.Decimal);
            param.Value = bFCoin;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@FertiOutstanding", SqlDbType.Decimal);
            param.Value = fertiOutstanding;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@LoanOutstading", SqlDbType.Decimal);
            param.Value = loanOutstading;
            paraList.Add(param);

            param = SQLHelper.CreateParameter("@editUser", SqlDbType.VarChar);
            param.Value = BoughtLeafBusinessLayer.BLUser.StrUserName;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@editDate", SqlDbType.DateTime);
            param.Value = DateTime.Now;
            paraList.Add(param);
        }


        public void insertMonthlyPaymentSummary() 
        {
            specialCalculation();
            parameterAssign();
            SQLHelper.ExecuteNonQuery("SP_ProcessMonthlyPaymentSummary", CommandType.StoredProcedure, paraList);
            paraList.Clear();
        }

        private void specialCalculation() 
        {
            totalDeduction = fertilizer + transport + loan + cachAdvace + paySlip + stampDuty + madeTea + otherDeduction + cFDebtBalance;
            paymentDue = totalEarning - totalDeduction;
            // confirm this poblem
            if (paymentDue < 0)
            {
                bFDebt = (-1) * paymentDue;// this is Plus value
                netPay = 0;
            }
            else
            {
                netPay = paymentDue;
                bFDebt = 0;
            }

            bFCoin = 0; // because illukthanna estate payment through cheque
        }

        public void deleteMonthyPaymenySummary(int year, int month, string routeCode) 
        {
            paraList.Clear();
            SqlParameter param = new SqlParameter();
            param = SQLHelper.CreateParameter("@year", SqlDbType.Int);
            param.Value = year;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@month", SqlDbType.Int);
            param.Value = month;
            paraList.Add(param);
            param = SQLHelper.CreateParameter("@routeCode", SqlDbType.VarChar);
            param.Value = routeCode;
            paraList.Add(param);
            SQLHelper.ExecuteNonQuery("SP_ProcessReverseMonthlyPaymentSummary", CommandType.StoredProcedure, paraList);
            paraList.Clear();
        }

        public DataSet getSupplierPaymentsDetail(int cunYear, int cunMonth, string supCode) 
        {
            return SQLHelper.FillDataSet("SELECT p.[SupplierCode],s.[SupplierName],p.[Year],p.[Month],p.[RouteCode],p.[GreenLeafKillo],p.[GreenLeafValue],p.[Incentive],p.[OtherAddition],p.[CFCoinBalance],p.[TotalEarning],p.[Fertilizer],p.[Transport],p.[Loan],p.[CashAdvance],p.[PaySlip],p.[StampDuty],p.[MadeTea],p.[OtherDeduction],p.[CFDebtBalance],p.[TotalDeduction],p.[PaymentDue],p.[NetPay],p.[BFCoin],p.[BFDebt] FROM [dbo].[MonthlyPaymentSummary] p, [dbo].[Supplier] s WHERE [Year]=" + cunYear + " AND [Month]=" + cunMonth + " AND p.[SupplierCode] LIKE '" + supCode + "' AND s.[SupplierCode] = p.[SupplierCode] ORDER BY  CONVERT( INT , p.[SupplierCode])", CommandType.Text);
        }

        public DataSet getSupplierPaymentsDetail(int cunYear, int cunMonth, string supCode,string strRoute)
        {
            return SQLHelper.FillDataSet("SELECT p.[SupplierCode],s.[SupplierName],p.[Year],p.[Month],p.[RouteCode],p.[GreenLeafKillo],p.[GreenLeafValue],p.[Incentive],p.[OtherAddition],p.[CFCoinBalance],p.[TotalEarning],p.[Fertilizer],p.[Transport],p.[Loan],p.[CashAdvance],p.[PaySlip],p.[StampDuty],p.[MadeTea],p.[OtherDeduction],p.[CFDebtBalance],p.[TotalDeduction],p.[PaymentDue],p.[NetPay],p.[BFCoin],p.[BFDebt],s.[SalarySendBank],s.[RouteCode], p.PaymentMode,p.[RegularIncentive] FROM [dbo].[MonthlyPaymentSummary] p, [dbo].[Supplier] s WHERE [Year]=" + cunYear + " AND [Month]=" + cunMonth + " AND p.[SupplierCode] LIKE '" + supCode + "' AND s.[SupplierCode] = p.[SupplierCode] AND (p.RouteCode LIKE '" + strRoute + "')  ORDER BY  CONVERT( INT , p.[SupplierCode])", CommandType.Text);
        }

        public DataSet getSupplierPaymentsDetailByRoute(int cunYear, int cunMonth)
        {
            return SQLHelper.FillDataSet("SELECT r.[RouteCode],r.[RouteName],SUM(p.[GreenLeafKillo]) AS 'GreenLeafKillo',SUM(p.[GreenLeafValue]) AS 'GreenLeafValue',SUM(p.[Incentive]) AS 'Incentive',SUM(p.[OtherAddition]) AS 'OtherAddition',SUM(p.[CFCoinBalance]) AS 'CFCoinBalance',SUM(p.[TotalEarning]) AS 'TotalEarning',SUM(p.[Fertilizer]) AS 'Fertilizer',SUM(p.[Transport]) AS 'Transport',SUM(p.[Loan]) AS 'Loan',SUM(p.[CashAdvance]) AS 'CashAdvance',SUM(p.[PaySlip]) AS 'PaySlip',SUM(p.[StampDuty]) AS 'StampDuty',SUM(p.[MadeTea]) AS 'MadeTea',SUM(p.[OtherDeduction]) AS 'OtherDeduction',SUM(p.[CFDebtBalance]) AS 'CFDebtBalance',SUM(p.[TotalDeduction]) AS 'TotalDeduction',SUM(p.[PaymentDue]) AS 'PaymentDue',SUM(case when (p.[PaymentDue]<0) then 0 else p.[PaymentDue] end) AS 'NetPay',SUM(p.[BFCoin]) AS 'BFCoin',SUM(p.[BFDebt]) AS 'BFDebt' FROM [dbo].[MonthlyPaymentSummary] p,[dbo].[Route] r WHERE [Year]=" + cunYear + " AND [Month]=" + cunMonth + "  AND r.[RouteCode] = p.[RouteCode] GROUP BY  r.[RouteCode], r.[RouteName]", CommandType.Text);
        }

        public DataSet getPreviousMonthDebts(int cunYear, int cunMonth) 
        {
            return SQLHelper.FillDataSet("SELECT p.[SupplierCode],s.[SupplierName],r.[RouteCode],r.[RouteName],p.[Year],p.[Month],p.[GreenLeafKillo],p.[GreenLeafValue],p.[Incentive],p.[OtherAddition],p.[CFCoinBalance],p.[TotalEarning],p.[Fertilizer],p.[Transport],p.[Loan],p.[CashAdvance],p.[PaySlip],p.[StampDuty],p.[MadeTea],p.[OtherDeduction],p.[CFDebtBalance],p.[TotalDeduction],p.[PaymentDue],p.[NetPay],p.[BFCoin],p.[BFDebt] FROM [dbo].[MonthlyPaymentSummary] p, [dbo].[Supplier] s , [dbo].[Route] r WHERE [Year]=" + cunYear + " AND [Month]=" + cunMonth + " AND p.[SupplierCode] LIKE '%' AND s.[SupplierCode] = p.[SupplierCode] AND r.[RouteCode] = s.[RouteCode] AND p.[CFDebtBalance] > 0 ORDER BY  CONVERT( INT , p.[SupplierCode])", CommandType.Text);
        }

        public DataSet getNextMonthDebts(int cunYear, int cunMonth)
        {
            return SQLHelper.FillDataSet(" SELECT p.[SupplierCode],s.[SupplierName],r.[RouteCode],r.[RouteName],p.[Year],p.[Month],p.[GreenLeafKillo],p.[GreenLeafValue],p.[Incentive],p.[OtherAddition],p.[CFCoinBalance],p.[TotalEarning],p.[Fertilizer],p.[Transport],p.[Loan],p.[CashAdvance],p.[PaySlip],p.[StampDuty],p.[MadeTea],p.[OtherDeduction],p.[CFDebtBalance],p.[TotalDeduction],p.[PaymentDue],p.[NetPay],p.[BFCoin],p.[BFDebt] FROM [dbo].[MonthlyPaymentSummary] p, [dbo].[Supplier] s , [dbo].[Route] r WHERE [Year]=" + cunYear + " AND [Month]=" + cunMonth + " AND p.[SupplierCode] LIKE '%' AND s.[SupplierCode] = p.[SupplierCode] AND r.[RouteCode] = s.[RouteCode] AND P.[BFDebt] > 0 ORDER BY  CONVERT( INT , p.[SupplierCode])", CommandType.Text);
        }

        public DataSet getMonthlyDeductionSummary(int pYear, int pMonth, string pSupCode)
        {
            //return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductionsSettlement.Suppliyer, dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName, SUM(dbo.SupplierDeductionsSettlement.Amount) AS Amount FROM dbo.DeductionGroup INNER JOIN dbo.SupplierDeductionsSettlement ON dbo.DeductionGroup.DeductionGroupCode = dbo.SupplierDeductionsSettlement.DeductionGroupCode INNER JOIN dbo.Supplier ON dbo.SupplierDeductionsSettlement.Suppliyer = dbo.Supplier.SupplierCode WHERE (dbo.SupplierDeductionsSettlement.Suppliyer LIKE '" + pSupCode + "') AND (dbo.SupplierDeductionsSettlement.DeductYear = '" + pYear + "') AND (dbo.SupplierDeductionsSettlement.DeductMonth = '" + pMonth + "') GROUP BY dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.Suppliyer, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName", CommandType.Text);
            return SQLHelper.FillDataSet("SELECT        dbo.Route.RouteCode, dbo.Route.RouteName, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierMonthDeductions.DeductYear,  dbo.SupplierMonthDeductions.DeductMonth, dbo.SupplierMonthDeductions.DeductGroup, dbo.SupplierMonthDeductions.DeductCode,  dbo.SupplierMonthDeductions.Amount, DeductionCode.DeductionAmount, DeductionCode.CommissionAmount FROM dbo.SupplierMonthDeductions INNER JOIN dbo.Supplier ON dbo.SupplierMonthDeductions.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode  INNER JOIN DeductionCode ON SupplierMonthDeductions.DeductCode = DeductionCode.DeductionCode WHERE (dbo.Supplier.SupplierCode LIKE '" + pSupCode + "') AND (dbo.SupplierMonthDeductions.DeductYear = '" + pYear + "') AND (dbo.SupplierMonthDeductions.DeductMonth = '" + pMonth + "')", CommandType.Text);
        }

        public DataSet getMonthlyDeductionSummaryDeductionCodewise(int pYear, int pMonth, string pSupCode, string DeductCode)
        {
            //return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductionsSettlement.Suppliyer, dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName, SUM(dbo.SupplierDeductionsSettlement.Amount) AS Amount FROM dbo.DeductionGroup INNER JOIN dbo.SupplierDeductionsSettlement ON dbo.DeductionGroup.DeductionGroupCode = dbo.SupplierDeductionsSettlement.DeductionGroupCode INNER JOIN dbo.Supplier ON dbo.SupplierDeductionsSettlement.Suppliyer = dbo.Supplier.SupplierCode WHERE (dbo.SupplierDeductionsSettlement.Suppliyer LIKE '" + pSupCode + "') AND (dbo.SupplierDeductionsSettlement.DeductYear = '" + pYear + "') AND (dbo.SupplierDeductionsSettlement.DeductMonth = '" + pMonth + "') GROUP BY dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.Suppliyer, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName", CommandType.Text);
            return SQLHelper.FillDataSet("SELECT        dbo.Route.RouteCode, dbo.Route.RouteName, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierMonthDeductions.DeductYear,  dbo.SupplierMonthDeductions.DeductMonth, dbo.SupplierMonthDeductions.DeductGroup, dbo.SupplierMonthDeductions.DeductCode,  dbo.SupplierMonthDeductions.Amount, dbo.DeductionCode.DeductionAmount, dbo.DeductionCode.CommissionAmount FROM dbo.SupplierMonthDeductions INNER JOIN dbo.Supplier ON dbo.SupplierMonthDeductions.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode INNER JOIN dbo.DeductionCode ON dbo.SupplierMonthDeductions.DeductCode = dbo.DeductionCode.DeductionCode WHERE (dbo.Supplier.SupplierCode LIKE '" + pSupCode + "') AND (dbo.SupplierMonthDeductions.DeductYear = '" + pYear + "') AND (dbo.SupplierMonthDeductions.DeductMonth = '" + pMonth + "') AND (dbo.SupplierMonthDeductions.DeductCode  like '" + DeductCode  + "')", CommandType.Text);
        }

        public DataSet getMonthlyDeductionSummaryRoutewise(int pYear, int pMonth, string pSupCode, string DeductCode, string RouteCode)
        {
            //return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductionsSettlement.Suppliyer, dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName, SUM(dbo.SupplierDeductionsSettlement.Amount) AS Amount FROM dbo.DeductionGroup INNER JOIN dbo.SupplierDeductionsSettlement ON dbo.DeductionGroup.DeductionGroupCode = dbo.SupplierDeductionsSettlement.DeductionGroupCode INNER JOIN dbo.Supplier ON dbo.SupplierDeductionsSettlement.Suppliyer = dbo.Supplier.SupplierCode WHERE (dbo.SupplierDeductionsSettlement.Suppliyer LIKE '" + pSupCode + "') AND (dbo.SupplierDeductionsSettlement.DeductYear = '" + pYear + "') AND (dbo.SupplierDeductionsSettlement.DeductMonth = '" + pMonth + "') GROUP BY dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.Suppliyer, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName", CommandType.Text);
            return SQLHelper.FillDataSet("SELECT        dbo.Route.RouteCode, dbo.Route.RouteName, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierMonthDeductions.DeductYear,  dbo.SupplierMonthDeductions.DeductMonth, dbo.SupplierMonthDeductions.DeductGroup, dbo.SupplierMonthDeductions.DeductCode,  dbo.SupplierMonthDeductions.Amount, dbo.DeductionCode.DeductionAmount, dbo.DeductionCode.CommissionAmount FROM dbo.SupplierMonthDeductions INNER JOIN dbo.Supplier ON dbo.SupplierMonthDeductions.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode INNER JOIN dbo.DeductionCode ON dbo.SupplierMonthDeductions.DeductCode = dbo.DeductionCode.DeductionCode WHERE (dbo.Supplier.SupplierCode LIKE '" + pSupCode + "') AND (dbo.SupplierMonthDeductions.DeductYear = '" + pYear + "') AND (dbo.SupplierMonthDeductions.DeductMonth = '" + pMonth + "') AND (dbo.SupplierMonthDeductions.DeductCode  like '" + DeductCode + "') AND (dbo.SupplierMonthDeductions.Route  like '" + RouteCode + "')", CommandType.Text);
        }


        public int getMonthlyActiveSupplier(int cunYear, int cunMonth) 
        {
            int count = 0;
            SqlDataReader datareader = SQLHelper.ExecuteReader("SELECT COUNT(SupplierCode) AS Expr1 FROM dbo.MonthlyPaymentSummary WHERE (GreenLeafKillo + GreenLeafValue + Incentive + OtherAddition + CFCoinBalance + Fertilizer + Transport + Loan + CashAdvance + PaySlip + OtherDeduction + MadeTea +  StampDuty + CFDebtBalance > 0) AND (Year = " + cunYear + " ) AND (Month = " + cunMonth + ")", CommandType.Text);
            while (datareader.Read()) 
            {
                if (!datareader.IsDBNull(0))
                    count = datareader.GetInt32(0);
            }

            return count;
        }

        public Decimal getBankPaymentSummaryTotal(int Year, int Month)
        {
            Decimal decBankTotal = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT  SUM(PaymentDue) AS Expr1 FROM dbo.MonthlyPaymentSummary WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (PaymentDue > 0) GROUP BY PaymentMode HAVING (PaymentMode = 'Bank')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                    decBankTotal = dataReader.GetDecimal(0);
            }
            dataReader.Close();
            return decBankTotal;
        }

        public Decimal getCashPaymentSummaryTotal(int Year, int Month)
        {
            Decimal decBankTotal = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(PaymentDue) AS Expr1 FROM dbo.MonthlyPaymentSummary WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (PaymentDue > 0) AND (PaymentMode = 'Cash')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                    decBankTotal = dataReader.GetDecimal(0);
            }
            dataReader.Close();
            return decBankTotal;
        }

        public decimal getBFDebtBalance(int pYear, int pMonth, string pSupplierCode)
        {
            decimal CFDebtBalance = 0;

            DateTime IssueDate = new DateTime(pYear, pMonth, DateTime.DaysInMonth(pYear, pMonth));
            int LastYear = IssueDate.AddMonths(-1).Year;
            int LastMonth = IssueDate.AddMonths(-1).Month;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT BFDebt FROM dbo.MonthlyPaymentSummary WHERE (Year = " + LastYear + ") AND (Month = " + LastMonth + ") AND (SupplierCode = '" + pSupplierCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    CFDebtBalance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return CFDebtBalance;
        }

        public decimal getBFCoinBalance(int pYear, int pMonth, string pSupplierCode) 
        {
            decimal BFCoinBalance = 0;

            DateTime IssueDate = new DateTime(pYear, pMonth, DateTime.DaysInMonth(pYear, pMonth));
            int LastYear = IssueDate.AddMonths(-1).Year;
            int LastMonth = IssueDate.AddMonths(-1).Month;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT BFCoin FROM dbo.MonthlyPaymentSummary WHERE (Year = " + LastYear + ") AND (Month = " + LastMonth + ") AND (SupplierCode = '" + pSupplierCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    BFCoinBalance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return BFCoinBalance;
        }

        public decimal getOutstanding(string pSupCode, string pDeductCode)
        {
            decimal Balance = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(BalanceAmount) AS 'FERT' FROM dbo.SupplierDeductions WHERE (DeductionGroupCode = '" + pDeductCode + "') AND (SupplierCode = '" + pSupCode + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Balance = Balance + dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Balance;
        }

        public DataSet getSupplierIncentiveDetail(int cunYear, int cunMonth, string supCode , string supRoute)
        {
            return SQLHelper.FillDataSet("SELECT        TOP (100) PERCENT p.Year, p.Month, p.SupplierCode, s.SupplierName, p.RouteCode, SUM(p.Incentive) AS Incentive, SUM(p.GoodLeafKilos) AS GoodLeafKilos, SUM(p.GoodLeafIncentive) AS GoodLeafIncentive,  SUM(p.ElivationKilos) AS ElivationKilos, SUM(p.ElivationIncentive) AS ElivationIncentive, SUM(p.SlabIncentive) AS SlabIncentive, SUM(p.TransportIncentive) AS TransportIncentive, SUM(p.RegularIncentive) AS RegularIncentive FROM            dbo.MonthlyPaymentSummary AS p INNER JOIN dbo.Supplier AS s ON p.SupplierCode = s.SupplierCode WHERE      (p.RouteCode like '" + supRoute + "') AND    (p.SupplierCode LIKE '" + supCode + "') AND (p.Year = '" + cunYear + "') AND (p.Month = '" + cunMonth + "') GROUP BY p.Year, p.Month, p.SupplierCode, s.SupplierName, p.RouteCode", CommandType.Text);
        }

        public DataSet getSkippedDeductions(String strRoute, int ProYear, int ProMonth)
        {
            return SQLHelper.FillDataSet("SELECT        dbo.BLSkippedDeduction.Route, dbo.BLSkippedDeduction.Year, dbo.BLSkippedDeduction.Month, dbo.BLSkippedDeduction.SuppliyerCode,  dbo.BLSkippedDeduction.DeductionGroup, dbo.BLSkippedDeduction.DeductionCode, dbo.BLSkippedDeduction.DeductionAmount,  dbo.BLSkippedDeduction.ExpectedDeductAmount, dbo.Supplier.SupplierName, dbo.DeductionGroup.GroupName, dbo.DeductionCode.DeductionName FROM            dbo.BLSkippedDeduction INNER JOIN dbo.Supplier ON dbo.BLSkippedDeduction.SuppliyerCode = dbo.Supplier.SupplierCode INNER JOIN dbo.DeductionCode ON dbo.BLSkippedDeduction.DeductionCode = dbo.DeductionCode.DeductionCode INNER JOIN dbo.DeductionGroup ON dbo.BLSkippedDeduction.DeductionGroup = dbo.DeductionGroup.DeductionGroupCode WHERE        (dbo.BLSkippedDeduction.Year = '"+ProYear+"') AND (dbo.BLSkippedDeduction.Month = '"+ProMonth+"') AND (dbo.BLSkippedDeduction.Route LIKE '"+strRoute+"')", CommandType.Text);
        }

        public DataSet getSupplierPaymentsDeductionDetail(int cunYear, int cunMonth, string supCode, string strRoute)
        {
            return SQLHelper.FillDataSet("SELECT dbo.SupplierMonthDeductions.DeductGroup, dbo.DeductionGroup.GroupName, dbo.SupplierMonthDeductions.DeductCode, dbo.DeductionCode.DeductionName, SUM(dbo.SupplierMonthDeductions.Amount) AS Amount FROM            dbo.SupplierMonthDeductions INNER JOIN dbo.DeductionGroup ON dbo.SupplierMonthDeductions.DeductGroup = dbo.DeductionGroup.DeductionGroupCode INNER JOIN dbo.DeductionCode ON dbo.SupplierMonthDeductions.DeductCode = dbo.DeductionCode.DeductionCode WHERE        (dbo.SupplierMonthDeductions.SupplierCode LIKE '" + supCode + "') AND (dbo.SupplierMonthDeductions.Route LIKE '" + strRoute + "') AND (dbo.SupplierMonthDeductions.DeductYear = '"+cunYear+"') AND (dbo.SupplierMonthDeductions.DeductMonth = '"+cunMonth+"') GROUP BY dbo.SupplierMonthDeductions.DeductYear, dbo.SupplierMonthDeductions.DeductMonth, dbo.SupplierMonthDeductions.DeductGroup, dbo.DeductionGroup.GroupName, dbo.SupplierMonthDeductions.DeductCode,  dbo.DeductionCode.DeductionName", CommandType.Text); 
        }

        public DataSet getCreditAvailabilityPaymentSummary(int cunYear, int cunMonth,int lastMonth, string supCode, string strRoute)
        {
            return SQLHelper.FillDataSet("SELECT TOP 30 Year, Month, SupplierCode, RouteCode, GreenLeafKillo, GreenLeafValue, PaymentDue, CFDebtBalance, LeafDays FROM dbo.MonthlyPaymentSummary WHERE (Year = '" + cunYear + "') AND (Month <='" +cunMonth + "') AND (SupplierCode = '" + supCode + "') AND (RouteCode like '" + strRoute + "')", CommandType.Text);
        }

        public DataSet ListCollectorPayment(int intYear, int intMonth, String Collector)
        {
            DataSet dsCPayment = new DataSet();
            dsCPayment = SQLHelper.FillDataSet("SELECT dbo.CollectorMonthlyPaymentSummary.Year, dbo.CollectorMonthlyPaymentSummary.Month, dbo.CollectorMonthlyPaymentSummary.Collector, dbo.CollectorMonthlyPaymentSummary.GLGrossWeight,  dbo.CollectorMonthlyPaymentSummary.GLNetWeight, dbo.CollectorMonthlyPaymentSummary.CollectorIncentive, dbo.CollectorMonthlyPaymentSummary.TransportIncentive,  dbo.CollectorMonthlyPaymentSummary.SuppTransportDeductions, dbo.CollectorMonthlyPaymentSummary.SuppManureTransport, dbo.CollectorMonthlyPaymentSummary.CollectorPayment AS TotalEarnings,  dbo.CollectorMonthlyPaymentSummary.DebtsBF, dbo.CollectorMonthlyPaymentSummary.StampDuty, dbo.CollectorMonthlyPaymentSummary.OtherDedution, dbo.CollectorMonthlyPaymentSummary.SuppDebts,  dbo.CollectorMonthlyPaymentSummary.TotalDeduction, dbo.CollectorMonthlyPaymentSummary.Balance, dbo.CollectorMonthlyPaymentSummary.DebtsCF, dbo.CollectorMaster.CollectorName FROM dbo.CollectorMonthlyPaymentSummary INNER JOIN dbo.CollectorMaster ON dbo.CollectorMonthlyPaymentSummary.Collector = dbo.CollectorMaster.CollectorCode WHERE        (dbo.CollectorMonthlyPaymentSummary.Year = '" + intYear + "') AND (dbo.CollectorMonthlyPaymentSummary.Month = '" + intMonth + "') AND (dbo.CollectorMonthlyPaymentSummary.Collector LIKE '" + Collector + "')", CommandType.Text);
            return dsCPayment;
        }

        public DataSet getMonthlyDepositFundContribution(int pYear, int pMonth, string pSupCode)
        {
            //return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductionsSettlement.Suppliyer, dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName, SUM(dbo.SupplierDeductionsSettlement.Amount) AS Amount FROM dbo.DeductionGroup INNER JOIN dbo.SupplierDeductionsSettlement ON dbo.DeductionGroup.DeductionGroupCode = dbo.SupplierDeductionsSettlement.DeductionGroupCode INNER JOIN dbo.Supplier ON dbo.SupplierDeductionsSettlement.Suppliyer = dbo.Supplier.SupplierCode WHERE (dbo.SupplierDeductionsSettlement.Suppliyer LIKE '" + pSupCode + "') AND (dbo.SupplierDeductionsSettlement.DeductYear = '" + pYear + "') AND (dbo.SupplierDeductionsSettlement.DeductMonth = '" + pMonth + "') GROUP BY dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.Suppliyer, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName", CommandType.Text);
            return SQLHelper.FillDataSet("SELECT        TOP (200) DepositedYear, DepositedMonth, SupplierCode, Route, Amount, DepositCalculatedQty, Narration, Rate, (SELECT        SUM(GreenLeafKillo) AS GLKilos FROM MonthlyPaymentSummary WHERE (SupplierCode = BLSupplierDepositFund.SupplierCode) AND (Month = BLSupplierDepositFund.DepositedMonth) AND (Year = BLSupplierDepositFund.DepositedYear)) AS Expr1 FROM BLSupplierDepositFund WHERE        (DepositedYear = 2018) AND (DepositedMonth = 7) AND (SupplierCode LIKE '%')", CommandType.Text);
        }
    }
}
