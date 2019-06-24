using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLSupplier
    {
        private String strSupplierCode;

        public String StrSupplierCode
        {
            get { return strSupplierCode; }
            set { strSupplierCode = value; }
        }
        private String strSupplierName;

        public String StrSupplierName
        {
            get { return strSupplierName; }
            set { strSupplierName = value; }
        }
        private String strSupplierAddress;

        public String StrSupplierAddress
        {
            get { return strSupplierAddress; }
            set { strSupplierAddress = value; }
        }
        private String strContactNo;

        public String StrContactNo
        {
            get { return strContactNo; }
            set { strContactNo = value; }
        }
        private String strRouteCode;

        public String StrRouteCode
        {
            get { return strRouteCode; }
            set { strRouteCode = value; }
        }
        private string strTownCode;

        public string StrTownCode
        {
            get { return strTownCode; }
            set { strTownCode = value; }
        }

        private int salarySendBank;

        public int SalarySendBank
        {
            get { return salarySendBank; }
            set { salarySendBank = value; }
        }

        private String strBankCode;

        public String StrBankCode
        {
            get { return strBankCode; }
            set { strBankCode = value; }
        }
        private string bankBranch;

        public string BankBranch
        {
            get { return bankBranch; }
            set { bankBranch = value; }
        }

        private String strAccountNo;

        public String StrAccountNo
        {
            get { return strAccountNo; }
            set { strAccountNo = value; }
        }
        private Boolean blnInactiveSupplier;

        public Boolean BlnInactiveSupplier
        {
            get { return blnInactiveSupplier; }
            set { blnInactiveSupplier = value; }
        }
        private Boolean blnUnionLinked;

        public Boolean BlnUnionLinked
        {
            get { return blnUnionLinked; }
            set { blnUnionLinked = value; }
        }
        private Boolean blnStationary;

        public Boolean BlnStationary
        {
            get { return blnStationary; }
            set { blnStationary = value; }
        }
        private Decimal decExtent;

        public Decimal DecExtent
        {
            get { return decExtent; }
            set { decExtent = value; }
        }

        private byte[] image;

        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }

        private string eRemittanceID;

        public string ERemittanceID
        {
            get { return eRemittanceID; }
            set { eRemittanceID = value; }
        }
        private string electronicID;

        public string ElectronicID
        {
            get { return electronicID; }
            set { electronicID = value; }
        }
        private string govRegNo;

        public string GovRegNo
        {
            get { return govRegNo; }
            set { govRegNo = value; }
        }
        private string gLAccountNo;

        public string GLAccountNo
        {
            get { return gLAccountNo; }
            set { gLAccountNo = value; }
        }

        private string latitude;

        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        private string longitude;

        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        private string transportCode;

        public string TransportCode
        {
            get { return transportCode; }
            set { transportCode = value; }
        }



        private string transPortType;

        public string TransPortType
        {
            get { return transPortType; }
            set { transPortType = value; }
        }


        private string nicNo;

        public string NicNo
        {
            get { return nicNo; }
            set { nicNo = value; }
        }

        private Boolean boolPaymentModeActive;

        public Boolean BoolPaymentModeActive
        {
            get { return boolPaymentModeActive; }
            set { boolPaymentModeActive = value; }
        }


        private string balencePaymentMode;

        public string BalencePaymentMode
        {
            get { return balencePaymentMode; }
            set { balencePaymentMode = value; }
        }


        private string advancedPaymentMode;

        public string AdvancedPaymentMode
        {
            get { return advancedPaymentMode; }
            set { advancedPaymentMode = value; }
        }

        private String strCollector;

        public String StrCollector
        {
            get { return strCollector; }
            set { strCollector = value; }
        }


        public void InsertSupplier(string Status, String DepositRequired, Decimal DepositRate, String SlabIncentiveCode)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            SqlParameter param = SQLHelper.CreateParameter("@image", SqlDbType.Image);
            param.Value = image;
            paraList.Add(param);

            SQLHelper.ExecuteNonQuery("insert into Supplier (SupplierCode,SupplierName,SupplierAddress,ContactNo,RouteCode,TownCode,SalarySendBank,BankCode,BankBranch,AccountNo,UserID,InactiveSupplier,LinkedUnion, Stationary, Extent, Type, TrnCode, Image, ElectronicID,GovRegNo,GLAccountNo,ERemittanceID,Latitude,Longitude, TransportType, NIC, PaymentMode, AdvancePayMode, DepositRequired, DepositRate, SlabIncentiveCode,Collector,PaymodeActive) values ('" + strSupplierCode.PadLeft(5, '0') + "','" + StrSupplierName + "','" + StrSupplierAddress + "','" + StrContactNo + "','" + strRouteCode + "','" + strTownCode + "'," + SalarySendBank + ",'" + StrBankCode + "','" + bankBranch + "','" + StrAccountNo + "','" + BLUser.StrUserName + "','" + BlnInactiveSupplier + "','" + BlnUnionLinked + "','" + BlnStationary + "','" + DecExtent + "','" + Status + "','" + transportCode + "', @image,'" + electronicID + "','" + govRegNo + "','" + gLAccountNo + "','" + eRemittanceID + "','" + latitude + "','" + longitude + "', '" + transPortType + "','" + nicNo + "', '" + balencePaymentMode + "', '" + advancedPaymentMode + "','" + DepositRequired + "','" + DepositRate + "','" + SlabIncentiveCode + "','" + StrCollector + "','"+BoolPaymentModeActive+"')", CommandType.Text, paraList);
        }

        public void UpdateSupplier(String Type, String DepositRequired, Decimal DepositRate, String SlabIncentiveCode)
        {
            List<SqlParameter> paraList = new List<SqlParameter>();
            SqlParameter param = SQLHelper.CreateParameter("@image", SqlDbType.Image);
            param.Value = image;
            paraList.Add(param);

            SQLHelper.ExecuteNonQuery("update Supplier set Type = '" + Type + "', Stationary = '" + BlnStationary + "', LinkedUnion = '" + BlnUnionLinked + "',SalarySendBank=" + salarySendBank + ", SupplierName = '" + StrSupplierName + "',SupplierAddress = '" + StrSupplierAddress + "', Image=@image , ElectronicID='" + electronicID + "', GovRegNo='" + govRegNo + "', GLAccountNo='" + gLAccountNo + "', ERemittanceID='" + eRemittanceID + "',InactiveSupplier = '" + BlnInactiveSupplier + "',ContactNo = '" + StrContactNo + "',RouteCode = '" + strRouteCode + "',TownCode = '" + strTownCode + "',BankCode = '" + strBankCode + "',AccountNo = '" + StrAccountNo + "',UserID = '" + BLUser.StrUserName + "', Extent = '" + DecExtent + "',TrnCode = '" + transportCode + "',BankBranch = '" + bankBranch + "', Latitude = '" + latitude + "',Longitude = '" + longitude + "', TransportType ='" + transPortType + "', NIC='" + NicNo + "', PaymentMode='" + balencePaymentMode + "', AdvancePayMode ='" + advancedPaymentMode + "',DepositRequired='" + DepositRequired + "',DepositRate='" + DepositRate + "',SlabIncentiveCode='" + SlabIncentiveCode + "',Collector='" + StrCollector + "',PaymodeActive='"+BoolPaymentModeActive+ "' where SupplierCode = '" + StrSupplierCode + "'", CommandType.Text, paraList);
        }

        public void DeleteSupplier(String pRouteCode)
        {
            SQLHelper.ExecuteNonQuery("delete from Supplier where SupplierCode = '" + StrSupplierCode + "' and RouteCode = '" + pRouteCode + "'", CommandType.Text);
        }

        public DataTable ListSupplierDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode")); //0
            dt.Columns.Add(new DataColumn("SupplierName")); //1
            dt.Columns.Add(new DataColumn("SupplierAddress")); //2
            dt.Columns.Add(new DataColumn("ContactNo")); //3
            dt.Columns.Add(new DataColumn("Route")); //4
            dt.Columns.Add(new DataColumn("SalarySendBank")); //5
            dt.Columns.Add(new DataColumn("Bank")); //6
            dt.Columns.Add(new DataColumn("BankBranch")); //7
            dt.Columns.Add(new DataColumn("AccountNo")); //8
            dt.Columns.Add(new DataColumn("Inactive Supplier")); //9
            dt.Columns.Add(new DataColumn("Union Linked")); //10
            dt.Columns.Add(new DataColumn("Stationary")); //11
            dt.Columns.Add(new DataColumn("Extent")); //12
            dt.Columns.Add(new DataColumn("Type")); //13
            dt.Columns.Add(new DataColumn("Transport")); //14
            dt.Columns.Add(new DataColumn("ElectronicID")); //15
            dt.Columns.Add(new DataColumn("GovRegNo")); //16
            dt.Columns.Add(new DataColumn("GLAccountNo")); //17
            dt.Columns.Add(new DataColumn("ERemittanceID")); //18
            dt.Columns.Add(new DataColumn("Latitude")); //19
            dt.Columns.Add(new DataColumn("Longitude")); //20
            dt.Columns.Add(new DataColumn("TownCode")); //21


            dt.Columns.Add(new DataColumn("TransportType"));
            dt.Columns.Add(new DataColumn("NIC"));
            dt.Columns.Add(new DataColumn("PaymentMode"));
            dt.Columns.Add(new DataColumn("AdvancePayMode"));

            dt.Columns.Add(new DataColumn("DepositRequired"));//26
            dt.Columns.Add(new DataColumn("DepositRate"));//27
            dt.Columns.Add(new DataColumn("SlabIncentiveCode"));//28
            dt.Columns.Add(new DataColumn("Collector")); //29

            dt.Columns.Add(new DataColumn("PaymodeActive")); //30




            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            //sachintha comment this one and make presentage
            dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, SupplierName, SupplierAddress, ContactNo, RouteCode, SalarySendBank, BankCode, BankBranch, AccountNo, InactiveSupplier, LinkedUnion, Stationary, Extent, Type, TrnCode, ElectronicID, GovRegNo, GLAccountNo, ERemittanceID, Latitude, Longitude,TownCode,TransportType, NIC, PaymentMode, AdvancePayMode, DepositRequired, DepositRate, SlabIncentiveCode,Collector,PaymodeActive FROM dbo.Supplier WHERE (RouteCode LIKE '%') ORDER BY ABS(SupplierCode)", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4);
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetBoolean(5);
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetString(6);
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetString(7);
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetString(8);
                }
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetBoolean(9);
                }
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetBoolean(10);
                }
                if (!dataReader.IsDBNull(11))
                {
                    dtrow[11] = dataReader.GetBoolean(11);
                }
                if (!dataReader.IsDBNull(12))
                {
                    dtrow[12] = dataReader.GetDecimal(12).ToString();
                }
                if (!dataReader.IsDBNull(13))
                {
                    dtrow[13] = dataReader.GetString(13);
                }
                if (!dataReader.IsDBNull(14))
                {
                    dtrow[14] = dataReader.GetString(14);
                }
                if (!dataReader.IsDBNull(15))
                {
                    dtrow[15] = dataReader.GetString(15);
                }
                if (!dataReader.IsDBNull(16))
                {
                    dtrow[16] = dataReader.GetString(16);
                }
                if (!dataReader.IsDBNull(17))
                {
                    dtrow[17] = dataReader.GetString(17);
                }
                if (!dataReader.IsDBNull(18))
                {
                    dtrow[18] = dataReader.GetString(18);
                }
                if (!dataReader.IsDBNull(19))
                {
                    dtrow[19] = dataReader.GetString(19).ToString();
                }
                if (!dataReader.IsDBNull(20))
                {
                    dtrow[20] = dataReader.GetString(20).ToString();
                }
                if (!dataReader.IsDBNull(21))
                {
                    dtrow[21] = dataReader.GetString(21).ToString();
                }


                if (!dataReader.IsDBNull(22))
                {
                    dtrow[22] = dataReader.GetString(22).ToString();
                }

                if (!dataReader.IsDBNull(23))
                {
                    dtrow[23] = dataReader.GetString(23).ToString();
                }

                if (!dataReader.IsDBNull(24))
                {
                    dtrow[24] = dataReader.GetString(24).ToString();
                }

                if (!dataReader.IsDBNull(25))
                {
                    dtrow[25] = dataReader.GetString(25).ToString();
                }


                if (!dataReader.IsDBNull(26))
                {
                    dtrow["DepositRequired"] = dataReader.GetString(26).ToString();
                }
                if (!dataReader.IsDBNull(27))
                {
                    dtrow["DepositRate"] = dataReader.GetDecimal(27).ToString();
                }
                if (!dataReader.IsDBNull(28))
                {
                    dtrow["SlabIncentiveCode"] = dataReader.GetString(28).ToString();
                }
                if (!dataReader.IsDBNull(29))
                {
                    dtrow["Collector"] = dataReader.GetString(29).ToString();
                }
                else
                {
                    dtrow["Collector"] = "NA";
                }
                if (!dataReader.IsDBNull(30))
                {
                    dtrow["PaymodeActive"] = dataReader.GetBoolean(30);
                }
                else
                {
                    dtrow["PaymodeActive"] = false;
                }
                dt.Rows.Add(dtrow);
            }





            dataReader.Close();
            return dt;
        }

        public DataTable ListSupplierDetails(String strText, String strSearchBy)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode")); //0
            dt.Columns.Add(new DataColumn("SupplierName")); //1
            dt.Columns.Add(new DataColumn("SupplierAddress")); //2
            dt.Columns.Add(new DataColumn("ContactNo")); //3
            dt.Columns.Add(new DataColumn("Route")); //4
            dt.Columns.Add(new DataColumn("SalarySendBank")); //5
            dt.Columns.Add(new DataColumn("Bank")); //6
            dt.Columns.Add(new DataColumn("BankBranch")); //7
            dt.Columns.Add(new DataColumn("AccountNo")); //8
            dt.Columns.Add(new DataColumn("Inactive Supplier")); //9
            dt.Columns.Add(new DataColumn("Union Linked")); //10
            dt.Columns.Add(new DataColumn("Stationary")); //11
            dt.Columns.Add(new DataColumn("Extent")); //12
            dt.Columns.Add(new DataColumn("Type")); //13
            dt.Columns.Add(new DataColumn("Transport")); //14
            dt.Columns.Add(new DataColumn("ElectronicID")); //15
            dt.Columns.Add(new DataColumn("GovRegNo")); //16
            dt.Columns.Add(new DataColumn("GLAccountNo")); //17
            dt.Columns.Add(new DataColumn("ERemittanceID")); //18
            dt.Columns.Add(new DataColumn("Latitude")); //19
            dt.Columns.Add(new DataColumn("Longitude")); //20
            dt.Columns.Add(new DataColumn("TownCode")); //21
            dt.Columns.Add(new DataColumn("Collector")); //22

            dt.Columns.Add(new DataColumn("SlabIncentiveCode")); //23
            dt.Columns.Add(new DataColumn("DepositRequired")); //24
            dt.Columns.Add(new DataColumn("DepositRate")); //25



            dt.Columns.Add(new DataColumn("TransportType")); //26
            dt.Columns.Add(new DataColumn("NIC")); //27           
            dt.Columns.Add(new DataColumn("PaymentMode")); //28
            dt.Columns.Add(new DataColumn("AdvancePayMode")); //29

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            if (strSearchBy.ToUpper().Equals("NAME"))
                dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, SupplierName, SupplierAddress, ContactNo, RouteCode, SalarySendBank, BankCode, BankBranch, AccountNo, InactiveSupplier, LinkedUnion, Stationary, Extent, Type, TrnCode, ElectronicID, GovRegNo, GLAccountNo, ERemittanceID, Latitude, Longitude,TownCode,Collector,SlabIncentiveCode, DepositRequired,DepositRate,TransportType, NIC, PaymentMode, AdvancePayMode FROM dbo.Supplier WHERE (SupplierName LIKE '%" + strText + "%') ORDER BY ABS(SupplierCode)", CommandType.Text);
            else
                dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, SupplierName, SupplierAddress, ContactNo, RouteCode, SalarySendBank, BankCode, BankBranch, AccountNo, InactiveSupplier, LinkedUnion, Stationary, Extent, Type, TrnCode, ElectronicID, GovRegNo, GLAccountNo, ERemittanceID, Latitude, Longitude,TownCode,Collector,SlabIncentiveCode, DepositRequired,DepositRate,TransportType, NIC, PaymentMode, AdvancePayMode FROM dbo.Supplier WHERE (SupplierCode LIKE '" + strText + "') ORDER BY ABS(SupplierCode)", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4);
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetBoolean(5);
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetString(6);
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetString(7);
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetString(8);
                }
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetBoolean(9);
                }
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetBoolean(10);
                }
                if (!dataReader.IsDBNull(11))
                {
                    dtrow[11] = dataReader.GetBoolean(11);
                }
                if (!dataReader.IsDBNull(12))
                {
                    dtrow[12] = dataReader.GetDecimal(12).ToString();
                }
                if (!dataReader.IsDBNull(13))
                {
                    dtrow[13] = dataReader.GetString(13);
                }
                if (!dataReader.IsDBNull(14))
                {
                    dtrow[14] = dataReader.GetString(14);
                }
                if (!dataReader.IsDBNull(15))
                {
                    dtrow[15] = dataReader.GetString(15);
                }
                if (!dataReader.IsDBNull(16))
                {
                    dtrow[16] = dataReader.GetString(16);
                }
                if (!dataReader.IsDBNull(17))
                {
                    dtrow[17] = dataReader.GetString(17);
                }
                if (!dataReader.IsDBNull(18))
                {
                    dtrow[18] = dataReader.GetString(18);
                }
                if (!dataReader.IsDBNull(19))
                {
                    dtrow[19] = dataReader.GetString(19).ToString();
                }
                if (!dataReader.IsDBNull(20))
                {
                    dtrow[20] = dataReader.GetString(20).ToString();
                }
                if (!dataReader.IsDBNull(21))
                {
                    dtrow[21] = dataReader.GetString(21).ToString();
                }
                if (!dataReader.IsDBNull(22))
                {
                    dtrow[22] = dataReader.GetString(22).ToString();
                }
                if (!dataReader.IsDBNull(23))
                {

                    dtrow[23] = dataReader.GetString(23).ToString();
                }
                else
                { dtrow[23] = 0; }

                if (!dataReader.IsDBNull(24))
                {
                    dtrow[24] = dataReader.GetString(24).ToString();
                }
                else { dtrow[24] = 0; }


                if (!dataReader.IsDBNull(25))
                {
                    dtrow[25] = dataReader.GetDecimal(25);
                }
             


                if (!dataReader.IsDBNull(26))
                {
                    dtrow[26] = dataReader.GetString(26).ToString();
                }
          


                if (!dataReader.IsDBNull(27))
                {
                    dtrow[27] = dataReader.GetString(27).ToString();
                }
        


                if (!dataReader.IsDBNull(28))
                {
                    dtrow[28] = dataReader.GetString(28).ToString();
                }
                else
                    dtrow[28] = 0;


                if (!dataReader.IsDBNull(29))
                {
                    dtrow[29] = dataReader.GetString(29).ToString();
                }
                else
                    dtrow[29] = 0;




                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListSupplierDetails(String SupplierName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("SupplierAddress"));
            dt.Columns.Add(new DataColumn("ContactNo"));
            dt.Columns.Add(new DataColumn("Town"));
            dt.Columns.Add(new DataColumn("Bank"));
            dt.Columns.Add(new DataColumn("AccountNo"));
            dt.Columns.Add(new DataColumn("CreatedBy"));
            dt.Columns.Add(new DataColumn("DateCreated"));
            dt.Columns.Add(new DataColumn("Inactive Supplier"));
            dt.Columns.Add(new DataColumn("Union Linked"));
            dt.Columns.Add(new DataColumn("Stationary"));
            dt.Columns.Add(new DataColumn("Extent"));
            dt.Columns.Add(new DataColumn("Type"));
            dt.Columns.Add(new DataColumn("Image"));
            dt.Columns.Add(new DataColumn("ElectronicID"));
            dt.Columns.Add(new DataColumn("GovRegNo"));
            dt.Columns.Add(new DataColumn("GLAccountNo"));
            dt.Columns.Add(new DataColumn("ERemittanceID"));
            dt.Columns.Add(new DataColumn("BankBranch"));
            dt.Columns.Add(new DataColumn("Collector"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierAddress, dbo.Supplier.ContactNo, dbo.Town.TownName, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.Supplier.UserID, dbo.Supplier.CreateDateTime,dbo.Supplier.InactiveSupplier,dbo.Supplier.LinkedUnion,dbo.Supplier.Stationary,dbo.Supplier.Extent,dbo.Supplier.Type,dbo.Supplier.Image, dbo.Supplier.ElectronicID,dbo.Supplier.GovRegNo,dbo.Supplier.GLAccountNo ,dbo.Supplier.ERemittanceID, dbo.Supplier.BankBranch, dbo.Supplier.Collector FROM dbo.Supplier INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode WHERE     (dbo.Town.TownCode = '" + strRouteCode + "') AND (dbo.Supplier.SupplierName LIKE '%" + SupplierName + "%') ORDER BY dbo.Supplier.SupplierName", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3).ToString();
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4).ToString();
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetString(5).ToString();
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetString(6).ToString();
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetString(7).ToString();
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetDateTime(8);
                }
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetBoolean(9);
                }
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetBoolean(10);
                }
                if (!dataReader.IsDBNull(11))
                {
                    dtrow[11] = dataReader.GetBoolean(11);
                }
                if (!dataReader.IsDBNull(12))
                {
                    dtrow[12] = dataReader.GetDecimal(12);
                }
                if (!dataReader.IsDBNull(13))
                {
                    dtrow[13] = dataReader.GetString(13).ToString();
                }
                if (!dataReader.IsDBNull(14))
                {
                    dtrow[14] = dataReader.GetInt32(14);
                }
                if (!dataReader.IsDBNull(15))
                {
                    dtrow[15] = dataReader.GetString(15).ToString();
                }
                if (!dataReader.IsDBNull(16))
                {
                    dtrow[16] = dataReader.GetString(16).ToString();
                }
                if (!dataReader.IsDBNull(17))
                {
                    dtrow[17] = dataReader.GetString(17).ToString();
                }
                if (!dataReader.IsDBNull(18))
                {
                    dtrow[18] = dataReader.GetString(18).ToString();
                }
                if (!dataReader.IsDBNull(19))
                {
                    dtrow[19] = dataReader.GetString(19).ToString();
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable getSupImage(string pSupCode, string pRouteCode)
        {
            return SQLHelper.FillDataSet("SELECT Image, RouteCode FROM dbo.Supplier WHERE (SupplierCode = '" + pSupCode + "') AND (RouteCode = '" + pRouteCode + "')", CommandType.Text).Tables[0];
        }

        public string getSupplierName(string pRoute, string pSupCode)
        {
            string SupplierName = "NA";

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Supplier.SupplierName FROM dbo.Supplier WHERE (dbo.Supplier.SupplierCode = '" + pSupCode + "') AND (dbo.Supplier.InactiveSupplier = 0) AND (dbo.Supplier.RouteCode LIKE '" + pRoute + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    SupplierName = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return SupplierName;
        }

        //New Method overload make by sachintha udara
        // 2016.10.25
        //start
        public String getSupplierName(string pSupCode)
        {
            String SupplierName = "NA";


            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Supplier.SupplierName FROM dbo.Supplier WHERE (dbo.Supplier.SupplierCode = '" + pSupCode + "') AND (dbo.Supplier.InactiveSupplier = 0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    SupplierName = dataReader.GetString(0).Trim();
                }

            }
            dataReader.Close();
            return SupplierName;
        }
        
        //end

        public String getRoute(String codeSuplier)
        {
            String SupplierCode = "NA";

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT RouteCode FROM dbo.Supplier WHERE (SupplierCode = '" + codeSuplier + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    SupplierCode = dataReader.GetString(0).Trim();
                }

            }
            dataReader.Close();
            return SupplierCode;
        }

        public String getSupplierTranCode(string pSupCode)
        {
            String SupplierNameTrn = "NA";


            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT TrnCode FROM dbo.Supplier WHERE (SupplierCode = '" + pSupCode + "') AND (InactiveSupplier = 0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    SupplierNameTrn = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return SupplierNameTrn;
        }

        public String getSupplierTransportType(string pSupCode)
        {
            String SuppTransportType = "NA";

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT  TransportType AS Expr1 FROM  dbo.Supplier WHERE (SupplierCode = '" + pSupCode + "') AND (TransportType IS NOT NULL)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    SuppTransportType = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return SuppTransportType;
        }

        public DataSet viewSupplierList()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierAddress, dbo.Supplier.ContactNo, dbo.Route.RouteName, dbo.Supplier.AccountNo, dbo.Bank.BankName, dbo.Supplier.InactiveSupplier FROM dbo.Supplier INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text);
            da.SelectCommand = SQLHelper.CreateCommand("SELECT        TOP (100) PERCENT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierAddress, dbo.Supplier.ContactNo, dbo.Route.RouteName,  dbo.Supplier.AccountNo, dbo.Bank.BankName, dbo.Supplier.InactiveSupplier, dbo.BankBranch.BranchCode, dbo.BankBranch.BranchName, dbo.Supplier.Collector FROM            dbo.Supplier INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankCode = dbo.BankBranch.BankCode AND dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode INNER JOIN dbo.Bank ON dbo.BankBranch.BankCode = dbo.Bank.BankCode ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text);

            da.Fill(ds, "SuplierList");
            return ds;
        }

        public DataSet TransportCodeWiseSuppliers(int month, int year)
        {
            DataSet oDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();

            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.DailyGreenLeaf.SupplierCode, dbo.DailyGreenLeaf.CollectedDate, dbo.DailyGreenLeaf.transportCost, dbo.DailyGreenLeaf.GreenLeafCollected, dbo.Supplier.SupplierName FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode WHERE (YEAR(dbo.DailyGreenLeaf.CollectedDate) = " + year + ") AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = " + month + ") AND (dbo.DailyGreenLeaf.transportCost > 0)", CommandType.Text);
            da.Fill(oDataSet, "TransportCodeWise");
            return oDataSet;
        }

        public DataSet TransportCodeWiseSuppliersWithouCost(int month, int year)
        {
            DataSet oDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();

            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.DailyGreenLeaf.SupplierCode, dbo.DailyGreenLeaf.CollectedDate, dbo.DailyGreenLeaf.transportCost, dbo.DailyGreenLeaf.GreenLeafCollected, dbo.Supplier.SupplierName FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode WHERE (YEAR(dbo.DailyGreenLeaf.CollectedDate) = " + year + ") AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = " + month + ") AND (dbo.DailyGreenLeaf.transportCost <= 0) AND (dbo.DailyGreenLeaf.GreenLeafCollected > 0)", CommandType.Text);
            da.Fill(oDataSet, "TransportCodeWise");
            return oDataSet;
        }

        public DataSet getTypeList()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT Type FROM dbo.Supplier GROUP BY Type", CommandType.Text);

            da.Fill(ds, "SuplierList");
            return ds;
        }
        public DataSet getRouteWiseSuppliersWithIncentives(String RouteNo)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT SupplierCode, SupplierName, '0' AS Incentive, '0' AS TransportIncentive FROM dbo.Supplier WHERE (RouteCode = '" + RouteNo + "')ORDER BY ABS(SupplierCode)", CommandType.Text);

            da.Fill(ds, "SuplierList");
            return ds;
        }

        public DataSet getRouteWiseSuppliersWithIncentives()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT SupplierCode, SupplierName, '0' AS Incentive, '0' AS TransportIncentive FROM dbo.Supplier ORDER BY ABS(SupplierCode)", CommandType.Text);

            da.Fill(ds, "SuplierList");
            return ds;
        }

        public DataTable getRouteWiseSuppliersWithIncentives1(String strRoute)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("ElivationIncentive"));
            dt.Columns.Add(new DataColumn("TransportIncentive"));
            dt.Columns.Add(new DataColumn("RegularIncentive"));
            DataRow dtrow;
            SqlDataReader dataReader;
            SqlDataReader dataReaderIncentive;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT RouteCode, SupplierCode, SupplierName FROM dbo.Supplier WHERE (RouteCode like '" + strRoute + "') AND (InactiveSupplier = 0)", CommandType.Text);
            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(1))
                {
                    dtrow[0] = dataReader.GetString(1).Trim();
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[1] = dataReader.GetString(2).Trim();
                }

                dtrow[2] = 0;
                dtrow[3] = 0;
                dtrow[4] = 0;
                dataReaderIncentive = SQLHelper.ExecuteReader("SELECT ISNULL(Incentive, 0) AS Expr1, ISNULL(transportIncentive, 0) AS Expr2, ISNULL(RegularIncentive, 0) AS RegIncentive FROM dbo.BLMasterSupplierIncentives WHERE (RouteNo = '" + dataReader.GetString(0).Trim() + "') AND (SupplierCode = '" + dataReader.GetString(1).Trim() + "')", CommandType.Text);
                while (dataReaderIncentive.Read())
                {
                    if (!dataReaderIncentive.IsDBNull(0))
                    {
                        dtrow[2] = dataReaderIncentive.GetDecimal(0);
                    }
                    if (!dataReaderIncentive.IsDBNull(1))
                    {
                        dtrow[3] = dataReaderIncentive.GetDecimal(1);
                    }
                    if (!dataReaderIncentive.IsDBNull(2))
                    {
                        dtrow[4] = dataReaderIncentive.GetDecimal(2);
                    }
                }
                dt.Rows.Add(dtrow);
                dataReaderIncentive.Close();
            }
            dataReader.Close();
            return dt;

        }

        public DataTable ListActiveSuppliers(String RouteNo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, SupplierName FROM dbo.Supplier WHERE (InactiveSupplier = 0) AND (RouteCode like '" + RouteNo + "') ORDER BY SupplierName", CommandType.Text);

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

        public DataTable ListActiveSuppliersOfRoute(String RouteNo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("SupplierAddress"));
            dt.Columns.Add(new DataColumn("RouteCode"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, SupplierName, SupplierAddress, RouteCode FROM dbo.Supplier WHERE (InactiveSupplier = 0) AND (RouteCode like '" + RouteNo + "') ORDER BY SupplierName", CommandType.Text);

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
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3).Trim();
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListActiveSuppliersOfRoute(String RouteNo, String SearchText)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("SupplierAddress"));
            dt.Columns.Add(new DataColumn("RouteCode"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT  TOP (100) PERCENT SupplierCode, SupplierName, SupplierAddress, RouteCode FROM dbo.Supplier WHERE (SupplierCode LIKE '%" + SearchText + "%') OR (SupplierName LIKE '%" + SearchText + "%') GROUP BY SupplierCode, SupplierName, SupplierAddress, RouteCode HAVING        (RouteCode like '" + RouteNo + "')", CommandType.Text);

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
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3).Trim();
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
        public DataTable ListActiveSuppliers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("LinkedUnion"));
            dt.Columns.Add(new DataColumn("Stationary"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode,SupplierName,LinkedUnion,Stationary FROM dbo.Supplier WHERE (InactiveSupplier = 0)order by SupplierCode", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(0).Trim() + " - " + dataReader.GetString(1).Trim();
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetBoolean(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetBoolean(3);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
        public String getSupplierTown()
        {
            String SupplierName = "NA";

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT TownCode FROM dbo.Supplier WHERE (SupplierCode = '" + StrSupplierCode + "') and (InactiveSupplier = 0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    SupplierName = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return SupplierName;
        }

        /// <summary>
        /// Sachintha Udara Make new Supplier Route Code Get with given supplier code
        /// </summary>
        /// <param name="pSupCode"></param>
        /// <returns>routeCode</returns>
        public string getSupplierRoute(string pSupCode)
        {
            string supRouteCode = "NA";

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT RouteCode FROM dbo.Supplier WHERE (SupplierCode = '" + pSupCode + "') and (InactiveSupplier = 0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    supRouteCode = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return supRouteCode;
        }

        public Int32 getDateCount(Int32 Year, Int32 Month)
        {
            Int32 Count = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT COUNT(CollectedDate) AS DateCount FROM dbo.DailyGreenLeaf WHERE (Processed = 0) AND (RouteNo <> 'Direct') AND (SupplierCode = '" + StrSupplierCode + "') AND (YEAR(CollectedDate) = '" + Year + "') AND (MONTH(CollectedDate) = '" + Month + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Count = dataReader.GetInt32(0);
                }
            }
            dataReader.Close();
            return Count;
        }

        //Sachintha Udara Make for DeductionTRN Form Supplier Summary 
        #region DeductionTRN Supplier Summary

        public decimal getSupCurrentLeaf(string pSupCode, Int32 intYear, Int32 intMonth)
        {
            decimal leaf = 0;

            SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (SupplierCode = '" + pSupCode + "') AND (CollectedDate BETWEEN CONVERT(DATETIME, '" + new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) + "', 102) AND CONVERT(DATETIME, '" + DateTime.Now.Date + "', 102))", CommandType.Text);

            dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (SupplierCode = '" + pSupCode + "') AND (year(CollectedDate)='" + intYear + "') AND (month(CollectedDate)='" + intMonth + "') ", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    leaf = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return leaf;
        }

        public decimal getSupCurrentFertOut(string pSupCode)
        {
            decimal ferti = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(BalanceAmount) AS Expr3 FROM dbo.SupplierDeductions WHERE (SupplierCode = '" + pSupCode + "') AND (DeductionGroupCode = 'FET') AND (BalanceAmount>0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    ferti = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return ferti;
        }

        public decimal getSupCurrentLoanOut(string pSupCode)
        {
            decimal ferti = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(BalanceAmount) AS Expr3 FROM dbo.SupplierDeductions WHERE (SupplierCode = '" + pSupCode + "') AND (DeductionGroupCode = 'LOAN')  AND (BalanceAmount>0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    ferti = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return ferti;
        }

        public decimal getSupCurrentAdvanceOut(string pSupCode)
        {
            decimal ferti = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(BalanceAmount) AS Expr3 FROM dbo.SupplierDeductions WHERE (SupplierCode = '" + pSupCode + "') AND (DeductionGroupCode = 'ADVANCE')  AND (BalanceAmount>0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    ferti = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return ferti;
        }

        public decimal getSupCurrentOtherOut(string pSupCode)
        {
            decimal ferti = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(BalanceAmount) AS Expr3 FROM dbo.SupplierDeductions WHERE (SupplierCode = '" + pSupCode + "') AND (DeductionGroupCode NOT IN('FET', 'LOAN', 'ADVANCE'))  AND (BalanceAmount>0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    ferti = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return ferti;
        }
        #endregion

        public string getMobileNumber(string pSupCode)
        {
            string mob = string.Empty;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT ContactNo FROM dbo.Supplier WHERE(SupplierCode = '" + pSupCode + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    mob = dataReader.GetString(0);
                }
            }
            dataReader.Close();
            return mob;
        }


        public DataSet GetBoughtLeafSuppliersByCode(string routeCode, string townCode)
        {
            try
            {
                DataSet ds;
                List<SqlParameter> paraList = new List<SqlParameter>();
                SqlParameter param = SQLHelper.CreateParameter("@RouteCode", SqlDbType.VarChar);
                param.Value = routeCode;
                paraList.Add(param);

                SqlParameter param1 = SQLHelper.CreateParameter("@TownCode", SqlDbType.VarChar);
                param.Value = townCode;
                paraList.Add(param1);

                ds = SQLHelper.FillDataSet("GetBoughtLeafSuppliersByCode", CommandType.StoredProcedure, paraList);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet viewSupplierList(string RouteCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierAddress, dbo.Supplier.ContactNo, dbo.Route.RouteName, dbo.Supplier.AccountNo, dbo.Bank.BankName, dbo.Supplier.InactiveSupplier FROM dbo.Supplier INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text);
            // da.SelectCommand = SQLHelper.CreateCommand("SELECT        TOP (100) PERCENT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierAddress, dbo.Supplier.ContactNo, dbo.Route.RouteName,  dbo.Supplier.AccountNo, dbo.Bank.BankName, dbo.Supplier.InactiveSupplier, dbo.BankBranch.BranchCode, dbo.BankBranch.BranchName FROM            dbo.Supplier INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankCode = dbo.BankBranch.BankCode AND dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode INNER JOIN dbo.Bank ON dbo.BankBranch.BankCode = dbo.Bank.BankCode ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text);
            if (RouteCode != "ALL")
                da.SelectCommand = SQLHelper.CreateCommand("SELECT    TOP (100) PERCENT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierAddress, dbo.Supplier.ContactNo, dbo.Route.RouteName, dbo.Supplier.AccountNo, dbo.Bank.BankName, dbo.Supplier.InactiveSupplier, dbo.BankBranch.BranchCode, dbo.BankBranch.BranchName, dbo.Supplier.NIC, dbo.Supplier.TrnCode, dbo.Supplier.TransportType, dbo.Supplier.PaymentMode, dbo.Supplier.AdvancePayMode FROM            dbo.Supplier INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankCode = dbo.BankBranch.BankCode AND dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode INNER JOIN dbo.Bank ON dbo.Bank.BankCode = dbo.BankBranch.BankCode WHERE        (dbo.Route.RouteCode = '" + RouteCode + "') ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text);
            else
                da.SelectCommand = SQLHelper.CreateCommand("SELECT    TOP (100) PERCENT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierAddress, dbo.Supplier.ContactNo, dbo.Route.RouteName, dbo.Supplier.AccountNo, dbo.Bank.BankName, dbo.Supplier.InactiveSupplier, dbo.BankBranch.BranchCode, dbo.BankBranch.BranchName, dbo.Supplier.NIC, dbo.Supplier.TrnCode, dbo.Supplier.TransportType, dbo.Supplier.PaymentMode, dbo.Supplier.AdvancePayMode FROM            dbo.Supplier INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankCode = dbo.BankBranch.BankCode AND dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode INNER JOIN dbo.Bank ON dbo.Bank.BankCode = dbo.BankBranch.BankCode ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text);
            da.Fill(ds, "SuplierList");
            return ds;
        }
        public DataSet RouteLoad()
        {
            DataSet ds = new DataSet();

            ds = SQLHelper.FillDataSet("SELECT        TOP (100) PERCENT RouteCode+' - '+RouteName as RouteName, RouteCode FROM  dbo.Route ", CommandType.Text);
            DataRow dr = ds.Tables[0].NewRow();
            dr["RouteName"] = "ALL - All Division";
            dr["RouteCode"] = "ALL";
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].DefaultView.Sort = "RouteName ASC";

            return ds;
        }
    }
}
