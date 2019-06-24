using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO.Ports;
using System.Threading;


namespace BoughtLeafBusinessLayer
{
    public class SMSHelper
    {
        private SerialPort _serialPort;
        AutoResetEvent receiveNow;
        SMSSettings smsSettings = new SMSSettings();

        //Open and Configure Port
        private SerialPort OpenPort()
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();

            DataTable dt = smsSettings.getSMSSettings();
            try
            {
                port.PortName = dt.Rows[0][0].ToString();
                port.BaudRate = Convert.ToInt32(dt.Rows[0][1]);
                port.DataBits = Convert.ToInt32(dt.Rows[0][2]);
                port.StopBits = StopBits.One;
                port.Parity = Parity.None;
                port.ReadTimeout = Convert.ToInt32(dt.Rows[0][3]);
                port.WriteTimeout = Convert.ToInt32(dt.Rows[0][4]);
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return port;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Connect Port
        public void connectPort()
        {
            try
            {
                _serialPort = OpenPort();
            }
            catch { }
        }

        //Close Port
        public void closePort()
        {
            try
            {
                _serialPort.Close();
                _serialPort.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                _serialPort = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Send SMS 
        public bool SendMessage(string phoneNo, string message)
        {
            bool isSend = false;
            try
            {
                string recievedData = SendATCommand(_serialPort, "AT", 300, "No phone connected");
                string command = "AT+CMGF=1" + char.ConvertFromUtf32(13);
                recievedData = SendATCommand(_serialPort, command, 300, "Failed to set message format.");

                command = "AT+CMGS=\"" + phoneNo + "\"" + char.ConvertFromUtf32(13);
                recievedData = SendATCommand(_serialPort, command, 300, "Failed to accept phoneNo");

                command = message + char.ConvertFromUtf32(26);
                recievedData = SendATCommand(_serialPort, command, 3000, "Failed to send message"); //3 seconds

                if (recievedData.EndsWith("\r\nOK\r\n"))
                    isSend = true;
                else if (recievedData.Contains("ERROR"))
                    isSend = false;

                return isSend;
            }
            catch
            {
                return isSend;
            }
        }

        //Send ATCommand 
        private string SendATCommand(SerialPort port, string command, int resTimeout, string errMessage)
        {
            try
            {
                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                string input = ReadResponse(port, resTimeout);
                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException("No success message was received.");
                return input;
            }
            catch
            {
                return "ERROR";
            }
        }

        //Read Response in each step of SMS
        private string ReadResponse(SerialPort port, int timeout)
        {
            string serialPortData = string.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string data = port.ReadExisting();
                        serialPortData += data;
                    }
                    else
                    {
                        if (serialPortData.Length > 0)
                            throw new ApplicationException("Response received is incomplete.");
                        else
                            throw new ApplicationException("No data received from phone.");
                    }
                } while (!serialPortData.EndsWith("\r\nOK\r\n") && !serialPortData.EndsWith("\r\n> ") && !serialPortData.EndsWith("\r\nERROR\r\n"));
            }
            catch
            {
                return "ERROR";
            }
            return serialPortData;
        }
    }
}
