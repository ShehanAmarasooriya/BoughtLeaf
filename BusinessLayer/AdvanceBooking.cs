using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;


namespace BoughtLeafBusinessLayer
{
   public class AdvanceBooking
    {
        private String routeNo;

        public String RouteNo
        {
            get { return routeNo; }
            set { routeNo = value; }
        }

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

        private string suplieCode;

        public string SuplieCode
        {
            get { return suplieCode; }
            set { suplieCode = value; }
        }

        private string suplieName;

        public string SuplieName
        {
            get { return suplieName; }
            set { suplieName = value; }
        }
        private string paymentMode;

        public string PaymentMode
        {
            get { return paymentMode; }
            set { paymentMode = value; }
        }

        private decimal toDateGlQty;

        public decimal ToDateGlQty
        {
            get { return toDateGlQty; }
            set { toDateGlQty = value; }
        }
        private decimal selectedDateGlQty;

        public decimal SelectedDateGlQty
        {
            get { return selectedDateGlQty; }
            set { selectedDateGlQty = value; }
        }

        private decimal glRate;

        public decimal GlRate
        {
            get { return glRate; }
            set { glRate = value; }
        }

        private decimal toDateGlValue;

        public decimal ToDateGlValue
        {
            get { return toDateGlValue; }
            set { toDateGlValue = value; }
        }


        private decimal selectedDateGLvalue;

        public decimal SelectedDateGLvalue
        {
            get { return selectedDateGLvalue; }
            set { selectedDateGLvalue = value; }
        }


        private decimal toDateDeduction;

        public decimal ToDateDeduction
        {
            get { return toDateDeduction; }
            set { toDateDeduction = value; }
        }

        private decimal systemCalAmount;

        public decimal SystemCalAmount
        {
            get { return systemCalAmount; }
            set { systemCalAmount = value; }
        }
        private decimal advAmount;

        public decimal AdvAmount
        {
            get { return advAmount; }
            set { advAmount = value; }
        }

        private decimal advPayment;

        public decimal AdvPayment
        {
            get { return advPayment; }
            set { advPayment = value; }
        }

       private DateTime toDate;

        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        private DateTime monthfromdate; // to get all netweight current month

        public DateTime Monthfromdate
        {
            get { return monthfromdate; }
            set { monthfromdate = value; }
        }

        private DateTime fromDate;

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }

     
       private int checkAllRoute;

        public int CheckAllRoute
        {
            get { return checkAllRoute; }
            set { checkAllRoute = value; }
        }

       private decimal adRate;

        public decimal AdRate
        {
            get { return adRate; }
            set { adRate = value; }
        }
        private DateTime advBookDate;

        public DateTime AdvBookDate
        {
            get { return advBookDate; }
            set { advBookDate = value; }
        }

       

       public Decimal getGLRate(Int32 Months, Int32 Years, String Routes)
       {
           Decimal Value = 0;
           DataTable dt = new DataTable();
           dt = SQLHelper.FillDataSet("SELECT dbo.BLAdvancedMinimumRate.MinimumRate FROM dbo.BLAdvancedMinimumRate INNER JOIN dbo.Route ON dbo.BLAdvancedMinimumRate.RouteCode = dbo.Route.RouteCode WHERE (dbo.BLAdvancedMinimumRate.YearCode='" + Years + "') AND  (dbo.BLAdvancedMinimumRate.MonthCode='" + Months + "') AND (dbo.Route.RouteCode='"+Routes+"') ", CommandType.Text).Tables[0];
           if (dt.Rows.Count == 1)
           {
               Value = Convert.ToDecimal(dt.Rows[0][0].ToString());
           }
           else
               Value = 0;
           return Value;
       }

      //get acess of edit adv Payment on datagrid view when adv Amount < adv Payment
       public string getAccessToEdit()
       {
           String status = "";
           SqlParameter param = new SqlParameter();
           SqlParameter statusParam = new SqlParameter();
           List<SqlParameter> paramList = new List<SqlParameter>();


           SqlCommand cmd = new SqlCommand();
           cmd = SQLHelper.CreateCommand("[dbo].[checkAccessDataGridView]", CommandType.StoredProcedure, paramList);
           statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
           statusParam.Direction = ParameterDirection.Output;
           SQLHelper.ExecuteNonQuery(cmd);
           status = statusParam.Value.ToString();
           cmd.Dispose();
           return status;

       }
       
       
       
       //check whether data exist or not
       //  public string getStatus()
       //{
       //    String status = "";
       //    SqlParameter param = new SqlParameter();
       //    SqlParameter statusParam = new SqlParameter();
       //    List<SqlParameter> paramList = new List<SqlParameter>();

       //    param = SQLHelper.CreateParameter("@Route", SqlDbType.VarChar);
       //    param.Value = RouteNo;
       //    paramList.Add(param);

       //    param = SQLHelper.CreateParameter("@IssueDate", SqlDbType.DateTime);
       //    param.Value = AdvBookDate;
       //    paramList.Add(param);


       //    param = SQLHelper.CreateParameter("@checkAllRoute", SqlDbType.Bit);
       //    param.Value = CheckAllRoute;
       //    paramList.Add(param);

       //    SqlCommand cmd = new SqlCommand();
       //    cmd = SQLHelper.CreateCommand("[dbo].[checkAdvanecBook]", CommandType.StoredProcedure, paramList);
       //    statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar,50);
       //    statusParam.Direction = ParameterDirection.Output;
       //    SQLHelper.ExecuteNonQuery(cmd);
       //    status = statusParam.Value.ToString();
       //    cmd.Dispose();
       //    return status;

       //}


       //check confrim or not adv Book


       public string getConfirmAdvBook()
       {
           String status = "";
           SqlParameter param = new SqlParameter();
           SqlParameter statusParam = new SqlParameter();
           List<SqlParameter> paramList = new List<SqlParameter>();

           param = SQLHelper.CreateParameter("@Route", SqlDbType.VarChar);
           param.Value = RouteNo;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@IssueDate", SqlDbType.DateTime);
           param.Value = AdvBookDate;
           paramList.Add(param);


           param = SQLHelper.CreateParameter("@SupCode", SqlDbType.VarChar);
           param.Value = suplieCode;
           paramList.Add(param);

           SqlCommand cmd = new SqlCommand();
           cmd = SQLHelper.CreateCommand("[dbo].[confirmAdvanecBook]", CommandType.StoredProcedure, paramList);
           statusParam = cmd.Parameters.Add("Confirm ", SqlDbType.VarChar, 50);
           statusParam.Direction = ParameterDirection.Output;
           SQLHelper.ExecuteNonQuery(cmd);
           status = statusParam.Value.ToString();
           cmd.Dispose();
           return status;

       }


       //load advance book
       public DataTable ListAdvBook()
       {
           DataTable dt = new DataTable();
           
           dt.Columns.Add(new DataColumn("Route"));//0
           dt.Columns.Add(new DataColumn("SupCode"));//1
           dt.Columns.Add(new DataColumn("SupplierName"));//2
           dt.Columns.Add(new DataColumn("Payment Mode"));
           dt.Columns.Add(new DataColumn("Selected Date Range GL Qty"));//3
           dt.Columns.Add(new DataColumn("To Date GL Qty"));
           dt.Columns.Add(new DataColumn("GL Rate"));//
           dt.Columns.Add(new DataColumn("Selected Date Range GLValue"));
           dt.Columns.Add(new DataColumn("To Date GLValue"));
           dt.Columns.Add(new DataColumn("ToDate Deduction"));//4
           dt.Columns.Add(new DataColumn("System Calculate Amount"));
           dt.Columns.Add(new DataColumn("Advance Amount"));
           dt.Columns.Add(new DataColumn("Advance Payment"));
           dt.Columns.Add(new DataColumn("Confirm"));  //to chehck whether adv book or not
           dt.Columns.Add(new DataColumn("From"));  //to chehck whether adv book or not
           


           DataRow dtrow;
           SqlDataReader dataReader;
           SqlDataReader dataReader2;
           if (checkAllRoute == 1)
           {

               dataReader2 = SQLHelper.ExecuteReader("SELECT RouteCode,SupplierCode,SupplierName,PaymentMode,SelectedDateGreenleafQty,ToDateGreenLeafQty,GreenLeafRate,SelectedDateGreenleafValue,ToDateGreenLeafValue,ToDateDeuction,SystemCalculateAmount,AdvanedAmount,Advancedpayment,ConfirmBook FROM [dbo].[BLAdavancedBook] WHERE IssueDate='" + AdvBookDate + "'", CommandType.Text);
           }
           else
           {
               dataReader2 = SQLHelper.ExecuteReader("SELECT RouteCode,SupplierCode,SupplierName,PaymentMode,SelectedDateGreenleafQty,ToDateGreenLeafQty,GreenLeafRate,SelectedDateGreenleafValue,ToDateGreenLeafValue,ToDateDeuction,SystemCalculateAmount,AdvanedAmount,Advancedpayment,ConfirmBook FROM [dbo].[BLAdavancedBook] WHERE IssueDate='" + AdvBookDate + "' AND RouteCode='" + RouteNo + "'", CommandType.Text);
           }

           while (dataReader2.Read())
           {
               dtrow = dt.NewRow();
               if (!dataReader2.IsDBNull(0))
               {

                   dtrow[0] = dataReader2.GetString(0).Trim(); //RouteCode
               }

               if (!dataReader2.IsDBNull(1))
               {

                   dtrow[1] = dataReader2.GetString(1).Trim();  //SupplierCode
               }
               if (!dataReader2.IsDBNull(2))
               {
                   dtrow[2] = dataReader2.GetString(2).Trim();  //SupplierName
               }
               if (!dataReader2.IsDBNull(3))
               {
                   dtrow[3] = dataReader2.GetString(3).Trim();  //PaymentMode
               }

               if (!dataReader2.IsDBNull(4))
               {
                   dtrow[4] = dataReader2.GetDecimal(4).ToString("N2");  //Selected Date Range GL Qty
               }

               if (!dataReader2.IsDBNull(5))
               {
                   dtrow[5] = dataReader2.GetDecimal(5).ToString("N2");  //To  Date Range GL Qty
               }

               if (!dataReader2.IsDBNull(6))
               {
                   dtrow[6] = dataReader2.GetDecimal(6).ToString("N2");  //ToDate GL Rate
               }

               if (!dataReader2.IsDBNull(7))
               {
                   dtrow[7] = dataReader2.GetDecimal(7).ToString("N2");  //Selected Date Range GL Value
               }

               if (!dataReader2.IsDBNull(8))
               {
                   dtrow[8] = dataReader2.GetDecimal(8).ToString("N2");  //To Date Range GL Value
               }

               if (!dataReader2.IsDBNull(9))
               {
                   dtrow[9] = dataReader2.GetDecimal(9).ToString("N2");  //ToDate Deduction
               }
               if (!dataReader2.IsDBNull(10))
               {
                   dtrow[10] = dataReader2.GetDecimal(10).ToString("N2");  //System cal amount
               }
               if (!dataReader2.IsDBNull(11))
               {
                   dtrow[11] = dataReader2.GetDecimal(11).ToString("N2");  //Advanec Amount
               }
               if (!dataReader2.IsDBNull(12))
               {
                   dtrow[12] = dataReader2.GetDecimal(12).ToString("N2");  //Advanec Payment
               }
               if (!dataReader2.IsDBNull(13))
               {
                   dtrow[13] = dataReader2.GetBoolean(13);  //confirm adv Book
               }
               dtrow[14] = "S";  //to chehck whether load from this table
               dt.Rows.Add(dtrow);
           }
                dataReader2.Close();
                 dtrow = dt.NewRow();



           if (checkAllRoute == 1)
           {
               dataReader = SQLHelper.ExecuteReader("SELECT dbo.Supplier.RouteCode, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, CASE WHEN dbo.Supplier.PaymodeActive = 1 THEN dbo.Supplier.PaymentMode ELSE CASE WHEN dbo.MonthlyPaymentSummary.GreenLeafKillo * '" + GlRate + "' - dbo.MonthlyPaymentSummary.TotalDeduction > dbo.BLAdvancedMinimumRate.advMinCheAmount THEN 'Cheque' ELSE 'Cash' END END AS PayMode, SUM(dbo.DailyGreenLeaf.NetWeight) AS NetWeight, dbo.MonthlyPaymentSummary.TotalDeduction AS TotalDeduction, derivedtbl_1.Expr1 AS AllNetwight FROM dbo.Supplier INNER JOIN dbo.DailyGreenLeaf ON dbo.Supplier.SupplierCode = dbo.DailyGreenLeaf.SupplierCode INNER JOIN dbo.BLAdvancedMinimumRate ON dbo.Supplier.RouteCode = dbo.BLAdvancedMinimumRate.RouteCode INNER JOIN dbo.MonthlyPaymentSummary ON dbo.Supplier.SupplierCode = dbo.MonthlyPaymentSummary.SupplierCode AND dbo.BLAdvancedMinimumRate.YearCode = dbo.MonthlyPaymentSummary.Year AND dbo.BLAdvancedMinimumRate.MonthCode = dbo.MonthlyPaymentSummary.Month INNER JOIN (SELECT RouteNo, SupplierCode, SUM(NetWeight) AS Expr1 FROM dbo.DailyGreenLeaf AS DailyGreenLeaf_1 WHERE (CollectedDate BETWEEN CONVERT(DATETIME, '" + Monthfromdate + "', 102) AND CONVERT(DATETIME, '" + ToDate + "', 102)) GROUP BY RouteNo, SupplierCode) AS derivedtbl_1 ON dbo.DailyGreenLeaf.RouteNo = derivedtbl_1.RouteNo AND dbo.DailyGreenLeaf.SupplierCode = derivedtbl_1.SupplierCode WHERE (dbo.DailyGreenLeaf.CollectedDate BETWEEN CONVERT(DATETIME, '" + FromDate + "', 102) AND CONVERT(DATETIME, '" + ToDate + "', 102)) AND (dbo.MonthlyPaymentSummary.Year = '" + Year + "') AND (dbo.MonthlyPaymentSummary.Month = '" + Month + "') AND ((dbo.Supplier.RouteCode + dbo.Supplier.SupplierCode) NOT IN (SELECT RouteCode + SupplierCode AS Expr1 FROM dbo.BLAdavancedBook WHERE (IssueDate = '" + advBookDate + "'))) GROUP BY dbo.Supplier.RouteCode, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, CASE WHEN dbo.Supplier.PaymodeActive = 1 THEN dbo.Supplier.PaymentMode ELSE CASE WHEN dbo.MonthlyPaymentSummary.GreenLeafKillo * '" + GlRate + "' - dbo.MonthlyPaymentSummary.TotalDeduction > dbo.BLAdvancedMinimumRate.advMinCheAmount THEN 'Cheque' ELSE 'Cash' END END, derivedtbl_1.Expr1,dbo.MonthlyPaymentSummary.TotalDeduction", CommandType.Text);
           }
           else
           {
               dataReader = SQLHelper.ExecuteReader("SELECT dbo.Supplier.RouteCode, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, CASE WHEN dbo.Supplier.PaymodeActive = 1 THEN dbo.Supplier.PaymentMode ELSE CASE WHEN dbo.MonthlyPaymentSummary.GreenLeafKillo * '" + GlRate + "' - dbo.MonthlyPaymentSummary.TotalDeduction > dbo.BLAdvancedMinimumRate.advMinCheAmount THEN 'Cheque' ELSE 'Cash' END END AS PayMode, SUM(dbo.DailyGreenLeaf.NetWeight) AS NetWeight,dbo.MonthlyPaymentSummary.TotalDeduction AS TotalDeduction, derivedtbl_1.Expr1 AS AllNetwight FROM dbo.Supplier INNER JOIN dbo.DailyGreenLeaf ON dbo.Supplier.SupplierCode = dbo.DailyGreenLeaf.SupplierCode INNER JOIN dbo.BLAdvancedMinimumRate ON dbo.Supplier.RouteCode = dbo.BLAdvancedMinimumRate.RouteCode INNER JOIN dbo.MonthlyPaymentSummary ON dbo.Supplier.SupplierCode = dbo.MonthlyPaymentSummary.SupplierCode AND dbo.BLAdvancedMinimumRate.YearCode = dbo.MonthlyPaymentSummary.Year AND dbo.BLAdvancedMinimumRate.MonthCode = dbo.MonthlyPaymentSummary.Month INNER JOIN (SELECT RouteNo, SupplierCode, SUM(NetWeight) AS Expr1 FROM dbo.DailyGreenLeaf AS DailyGreenLeaf_1 WHERE (CollectedDate BETWEEN CONVERT(DATETIME, '" + monthfromdate + "', 102) AND CONVERT(DATETIME, '" + ToDate + "', 102)) GROUP BY RouteNo, SupplierCode) AS derivedtbl_1 ON dbo.DailyGreenLeaf.RouteNo = derivedtbl_1.RouteNo AND dbo.DailyGreenLeaf.SupplierCode = derivedtbl_1.SupplierCode WHERE (dbo.DailyGreenLeaf.CollectedDate BETWEEN CONVERT(DATETIME, '" + FromDate + "', 102) AND CONVERT(DATETIME, '" + ToDate + "', 102)) AND (dbo.MonthlyPaymentSummary.Year = '" + Year + "') AND (dbo.MonthlyPaymentSummary.Month = '" + Month + "') AND (dbo.Supplier.RouteCode='" + RouteNo + "') AND ((dbo.Supplier.RouteCode + dbo.Supplier.SupplierCode) NOT IN (SELECT RouteCode + SupplierCode AS Expr1 FROM dbo.BLAdavancedBook WHERE (IssueDate = '" + advBookDate + "'))) GROUP BY dbo.Supplier.RouteCode, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, CASE WHEN dbo.Supplier.PaymodeActive = 1 THEN dbo.Supplier.PaymentMode ELSE CASE WHEN dbo.MonthlyPaymentSummary.GreenLeafKillo * '" + GlRate + "' - dbo.MonthlyPaymentSummary.TotalDeduction > dbo.BLAdvancedMinimumRate.advMinCheAmount THEN 'Cheque' ELSE 'Cash' END END, derivedtbl_1.Expr1,dbo.MonthlyPaymentSummary.TotalDeduction", CommandType.Text);
           }

           while (dataReader.Read())
           {
               dtrow = dt.NewRow();
               string route = dataReader.GetString(0).Trim();
               if (!dataReader.IsDBNull(0))
               {
                  
                   dtrow[0] = route.ToString(); //Route
               }
               string supcode=dataReader.GetString(1).Trim(); 

               if (!dataReader.IsDBNull(1))
               {
                   
                   dtrow[1] = supcode.ToString();  //SupplierCode
               }
               if (!dataReader.IsDBNull(2))
               {
                   dtrow[2] = dataReader.GetString(2).Trim();  //SupplierName
               }
               if (!dataReader.IsDBNull(3))
               {
                   dtrow[3] = dataReader.GetString(3).Trim();  //PaymentMode
               }

               if (!dataReader.IsDBNull(4))
               {
                   dtrow[4] = dataReader.GetDecimal(4).ToString("N2");  //Selected date range GL Qty
               }

               if (!dataReader.IsDBNull(6))
               {
                   dtrow[5] = dataReader.GetDecimal(6).ToString("N2");  //To Date  GL Qty
               }

               //chehck whether ToDate decution null or not
                decimal c=0; // Todate Decution
               if (dataReader.IsDBNull(5))
                   c = 0;
               else
                   c = dataReader.GetDecimal(5);

               if (glRate != 0)
               {
                   decimal a = (string.IsNullOrEmpty(dataReader.GetDecimal(4).ToString()) ? 0 : dataReader.GetDecimal(4) )* glRate;
                   dtrow[7] = a.ToString("N2");                              //Seleted Date  Range  GLValue

                   decimal a2 = (string.IsNullOrEmpty(dataReader.GetDecimal(6).ToString()) ? 0 : dataReader.GetDecimal(6)) * glRate;
                   dtrow[8] = a2.ToString("N2");                              //To Date GLValue
                   
                   decimal b = a2 - c;   //system Calculate Amount
                   if(b>0)
                    dtrow[10] = b.ToString("N2");
                   else
                    dtrow[10] =0;

               }

               if (!dataReader.IsDBNull(5))
               { 
                   dtrow[9] = c.ToString("N2"); //ToDateDeduction
               }

               if (adRate != 0)
               {

                   decimal b = (dataReader.GetDecimal(6) * glRate) - c;  //Round value
               
                   decimal n=b-(b%100);   //round a Avaneced Payment Value to hundred
                   decimal e = n * (adRate/100);   //Advance Amount rate pass from txtbook
                   if (e > 0)
                   {
                       dtrow[11] = e.ToString("N2");
                       dtrow[12] = e.ToString("N2");
                   }
                   else
                   {
                       dtrow[11] =0;
                       dtrow[12] = 0;
                   }

                   
               }
               dtrow[13] = "N";   //to chehck get data from load diffrent table no colour in datagridview

              
               dt.Rows.Add(dtrow);
           }
           dataReader.Close();
          
           return dt;


       }
    
       //load issue date
       public DataTable  GetIssueDate(Int32 year,Int32 month)
       {
           DataTable dt = new DataTable();
           SqlDataReader dataReader;
           dt.Columns.Add("IssueDate");
           DataRow drow;
           drow = dt.NewRow();
           dataReader = SQLHelper.ExecuteReader("SELECT  IssueDate FROM BLAdvanceBook_DateRange WHERE (Year = '" + Year + "') AND (Month='" + Month + "') ORDER BY IssueDate ASC", CommandType.Text);
           while (dataReader.Read())
           {
               drow = dt.NewRow();
               if (!dataReader.IsDBNull(0))
               {
                   drow[0] = dataReader.GetDateTime(0).ToShortDateString();
               }
               dt.Rows.Add(drow);
           }
           dataReader.Close();
           return dt;



       }
     
      //Get issue date Range
       public DataSet GetIssueDateRange(DateTime issueDate)
       {
           DataSet ds = new DataSet();
           ds = SQLHelper.FillDataSet("SELECT FromDate,ToDate  FROM BLAdvanceBook_DateRange WHERE (IssueDate = '" + issueDate + "')", CommandType.Text);
           return ds;
       }

 
       //insert adv book with delete satus
       public void insertAdvancedBook_Log()
       {
           SQLHelper.ExecuteNonQuery("INSERT INTO [dbo].[BLAdavancedBook_Log] ([RouteCode] ,[Year] ,[Month] ,[SupplierCode] ,[SupplierName] ,[PaymentMode] ,[ToDateGreenLeafQty] ,[SelectedDateGreenleafQty] ,[GreenLeafRate] ,[ToDateGreenLeafValue] ,[SelectedDateGreenleafValue] ,[ToDateDeuction] ,[SystemCalculateAmount] ,[AdvaneAmount] ,[Advancepayment] ,[CreateDateTime] ,[UserID] ,[Status] ,[FromDate] ,[ToDate] ,[IssueDate]) VALUES('" + RouteNo + "','" + Year + "','" + Month + "','" + SuplieCode + "','" + SuplieName + "','" + PaymentMode + "','" + ToDateGlQty + "','" + SelectedDateGlQty + "','" + GlRate + "','" + ToDateGlValue + "','" + SelectedDateGLvalue + "','" + ToDateDeduction + "','" + SystemCalAmount + "','" + AdvAmount + "','" + AdvPayment + "','" + DateTime.Now.Date + "','" + BLUser.StrUserName + "','Delete','" + FromDate + "','" + ToDate + "','" + AdvBookDate + "')", CommandType.Text);

       }


       public void deleteAdvanedBook()
       {
           if(CheckAllRoute==1)
               SQLHelper.ExecuteNonQuery("DELETE FROM dbo.BLAdavancedBook WHERE IssueDate='" + advBookDate + "' AND SupplierCode='"+SuplieCode+"'", CommandType.Text);
           else
               SQLHelper.ExecuteNonQuery("DELETE FROM dbo.BLAdavancedBook WHERE RouteCode='" + RouteNo + "' AND IssueDate='" + advBookDate + "' AND SupplierCode='" + SuplieCode + "' ", CommandType.Text);

       }

       //insert advance Book
       public void AddAdvancedBook()
       {
           SqlParameter param = new SqlParameter();
           List<SqlParameter> paramList = new List<SqlParameter>();

           param = SQLHelper.CreateParameter("@Route", SqlDbType.VarChar);
           param.Value = RouteNo;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@Year", SqlDbType.Int);
           param.Value = Year;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@Month", SqlDbType.Int);
           param.Value = Month;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@SupCode", SqlDbType.VarChar);
           param.Value = SuplieCode;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@SupName", SqlDbType.VarChar);
           param.Value = SuplieName;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@PaymentMode", SqlDbType.VarChar);
           param.Value = PaymentMode;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@SelectedDateRangeGLQty", SqlDbType.Decimal);
           param.Value = SelectedDateGlQty;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@ToDateGLQty", SqlDbType.Decimal);
           param.Value = ToDateGlQty;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@GLRate", SqlDbType.Decimal);
           param.Value = GlRate;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@SelectedDateRangeGLValue", SqlDbType.Decimal);
           param.Value = SelectedDateGLvalue;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@ToDateGLValue", SqlDbType.Decimal);
           param.Value = ToDateGlValue;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@ToDateDeduction", SqlDbType.Decimal);
           param.Value = ToDateDeduction;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@SystemCalculateAmount", SqlDbType.Decimal);
           param.Value = SystemCalAmount;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@AdvancedAmount", SqlDbType.Decimal);
           param.Value = AdvAmount;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@AdvancedPayment", SqlDbType.Decimal);
           param.Value = AdvPayment;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@UserID", SqlDbType.VarChar);
           param.Value = BLUser.StrUserName;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@FromDate", SqlDbType.VarChar);
           param.Value = FromDate;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@ToDate", SqlDbType.VarChar);
           param.Value = ToDate;
           paramList.Add(param);

           param = SQLHelper.CreateParameter("@IssueDate", SqlDbType.DateTime);
           param.Value = AdvBookDate;
           paramList.Add(param);


           SQLHelper.ExecuteNonQuery("SP_InsertAdvancedBook", CommandType.StoredProcedure, paramList);
          
       }


       public void confirmAdvBook()
       {
           SQLHelper.ExecuteNonQuery("UPDATE dbo.BLAdavancedBook  set ConfirmBook=1  WHERE RouteCode='" + RouteNo + "' AND Year='" + Year + "' AND Month='" + Month + "' AND SupplierCode='" + SuplieCode + "' AND IssueDate='" + advBookDate + "'", CommandType.Text);
       }

       public void cancelConfirmAdvBook()
       {
           SQLHelper.ExecuteNonQuery("UPDATE dbo.BLAdavancedBook  set ConfirmBook=0  WHERE RouteCode='" + RouteNo + "' AND Year='" + Year + "' AND Month='" + Month + "' AND SupplierCode='" + SuplieCode + "' AND IssueDate='" + advBookDate + "'", CommandType.Text);
       }
    }
}
