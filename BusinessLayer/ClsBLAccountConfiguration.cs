using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BoughtLeafDataAccess;
using System.Data;

namespace BoughtLeafBusinessLayer
{
    public class ClsBLAccountConfiguration
    {
        private String strGreenLeaf;

        public String StrGreenLeaf
        {
          get { return strGreenLeaf; }
          set { strGreenLeaf = value; }
        }
        private String strOtherAddition;

        public String StrOtherAddition
        {
          get { return strOtherAddition; }
          set { strOtherAddition = value; }
        }
        private String strIncentive;

        public String StrIncentive
        {
          get { return strIncentive; }
          set { strIncentive = value; }
        }
        private String strLeafQualityIncen;

        public String StrLeafQualityIncen
        {
            get { return strLeafQualityIncen; }
            set { strLeafQualityIncen = value; }
        }
        private String strTransportIncen;

        public String StrTransportIncen
        {
            get { return strTransportIncen; }
            set { strTransportIncen = value; }
        }
        private String strElevationIncen;

        public String StrElevationIncen
        {
            get { return strElevationIncen; }
            set { strElevationIncen = value; }
        }
        private String strSlabIncen;

        public String StrSlabIncen
        {
            get { return strSlabIncen; }
            set { strSlabIncen = value; }
        }
        private String strBFCoin;

        public String StrBFCoin
        {
          get { return strBFCoin; }
          set { strBFCoin = value; }
        }
        private String strFertilizer;

        public String StrFertilizer
        {
          get { return strFertilizer; }
          set { strFertilizer = value; }
        }
        private String strTransportDeduction;

        public String StrTransportDeduction
        {
          get { return strTransportDeduction; }
          set { strTransportDeduction = value; }
        }
        private String strLoans;

        public String StrLoans
        {
          get { return strLoans; }
          set { strLoans = value; }
        }
        private String strCashAdvance;

        public String StrCashAdvance
        {
          get { return strCashAdvance; }
          set { strCashAdvance = value; }
        }
        private String strTeaAllowance;

        public String StrTeaAllowance
        {
          get { return strTeaAllowance; }
          set { strTeaAllowance = value; }
        }
        private String strPayslip;

        public String StrPayslip
        {
          get { return strPayslip; }
          set { strPayslip = value; }
        }
        private String strStampDuty;

        public String StrStampDuty
        {
          get { return strStampDuty; }
          set { strStampDuty = value; }
        }
        private String strOtherDeduction;

        public String StrOtherDeduction
        {
          get { return strOtherDeduction; }
          set { strOtherDeduction = value; }
        }
        private String strBFDebt;

        public String StrBFDebt
        {
          get { return strBFDebt; }
          set { strBFDebt = value; }
        }
        private String strCFDebtBalance;

        public String StrCFDebtBalance
        {
          get { return strCFDebtBalance; }
          set { strCFDebtBalance = value; }
        }

        public DataSet ListBLLeafTypeAccounts()
        {
            DataSet dsLeafTypeAC = new DataSet();
            dsLeafTypeAC = SQLHelper.FillDataSet("SELECT  Name, AccountCode FROM dbo.BLMasterRates WHERE (AccountNeeded = 1) and  (Type IN ('LeafQuality'))", CommandType.Text);
            return dsLeafTypeAC;
        }
        public void SaveBLLeafTypeAccounts(String strType,String strAC)
        {
            SQLHelper.ExecuteNonQuery(" UPDATE dbo.BLMasterRates SET AccountCode='"+strAC+"' WHERE (AccountNeeded = 1) AND (Name='"+strType+"')",CommandType.Text);
        }

        public DataSet ListBLMasterSettings()
        {
            DataSet dsSettingsAC = new DataSet();
            dsSettingsAC = SQLHelper.FillDataSet("SELECT Type, Name, AccountCode FROM dbo.BLMasterSettings WHERE (AccountNeeded = 1)", CommandType.Text);
            return dsSettingsAC;
        }

        public void SaveBLMasterSettings(String strName, String strType, String strAC)
        {
            SQLHelper.ExecuteNonQuery(" UPDATE dbo.BLMasterSettings SET AccountCode='" + strAC + "' WHERE (AccountNeeded = 1) AND (Name='" + strName + "') AND (Type='" + strType + "')", CommandType.Text);
        }

        //General Accounts
        public DataSet ListBLLeafGeneralAccounts()
        {
            DataSet dsGeneralAC = new DataSet();
            dsGeneralAC = SQLHelper.FillDataSet("SELECT  TOP (1) GreenLeaf, OtherAddition, Incentive, LeafQuality, Transport, ElevationIncentive, SlabIncentive, BFCoin, Fertilizer, TransportDeduction, Loans, CashAdvance, TeaAllowance, Payslip, StampDuty, OtherDeduction, BFDebt,  CFDebtBalance FROM dbo.GLAccountSettings", CommandType.Text);
            return dsGeneralAC;
        }

        public void SaveBLLeafGeneralAccounts()
        {
            SQLHelper.ExecuteNonQuery("UPDATE dbo.GLAccountSettings  SET GreenLeaf='" + StrGreenLeaf + "', OtherAddition='" + StrOtherAddition + "', Incentive='" + StrIncentive + "',LeafQuality='"+StrLeafQualityIncen+"', Transport='"+StrTransportIncen+"', ElevationIncentive='"+StrElevationIncen+"', SlabIncentive='"+StrSlabIncen+"', BFCoin='" + StrBFCoin + "', Fertilizer='" + StrFertilizer + "', TransportDeduction='" + strTransportDeduction + "', Loans='" + StrLoans + "', CashAdvance='" + StrCashAdvance + "', TeaAllowance='" + StrTeaAllowance + "', Payslip='" + StrPayslip + "', StampDuty='" + StrStampDuty + "', OtherDeduction='" + StrOtherDeduction + "', BFDebt='" + StrBFCoin + "', CFDebtBalance='" + strCFDebtBalance + "'", CommandType.Text);
        }

        //Deduction accounts
        public DataSet ListDeductionAccounts()
        {
            DataSet dsDeductAcs = SQLHelper.FillDataSet("SELECT TOP (100) PERCENT DeductionGroupCode, DeductionCode, GLAccountCode FROM dbo.DeductionCode ORDER BY DeductionGroupCode, DeductionCode", CommandType.Text);
            return dsDeductAcs;            
        }

        public void SaveBLDeductionAccounts(String GLAC,String strDeductGroup,String strDeduct)
        {
            SQLHelper.ExecuteNonQuery("UPDATE dbo.DeductionCode SET GLAccountCode='"+GLAC+"' WHERE (DeductionGroupCode='"+strDeductGroup+"') AND (DeductionCode='"+strDeduct+"')", CommandType.Text);
        }
        

    }
}
