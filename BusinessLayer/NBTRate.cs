using System;
using System.Collections.Generic;
using System.Text;
using BoughtLeafDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace BoughtLeafBusinessLayer
{
   public class NBTRate
    {
       public void InsertNBTRate(decimal NBTRate)
       {
           SQLHelper.ExecuteNonQuery("Update Compnay set NBTRate ='" + NBTRate + "'", CommandType.Text);
       }

       public DataSet ListNBTRate()
       {
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter();
           SqlCommand command = new SqlCommand();
           da.SelectCommand = SQLHelper.CreateCommand("SELECT NBTRate FROM Compnay", CommandType.Text);

           da.Fill(ds, "NBT");
           return ds;
       }
    }
}
