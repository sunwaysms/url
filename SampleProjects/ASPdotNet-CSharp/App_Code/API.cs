using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;


public static class API {
    const string URL = "http://sms.sunwaysms.com/smsws/HttpService.ashx?";

    /// <summary>
    /// Send Array 
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="RecipientNumber">Send SMS to this numbers</param>
    /// <param name="Message">Text of your SMS</param>
    /// <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    /// <param name="IsFlash">True/False</param>
    /// <param name="CheckingMessageID">Your local ID for message</param>
    /// <returns>MessageID for each SMS</returns>
    public static long[] SendArray(string UserName, string Password, string[] RecipientNumber, string Message, string SpecialNumber, bool IsFlash, long[] CheckingMessageID) {
        string recipientNumber = "", checkingMessageID = "";
        foreach (var item in RecipientNumber) {
            recipientNumber += item + ",";
        }

        foreach (var item in CheckingMessageID) {
            checkingMessageID += item + ",";
        }

        WebRequest request = WebRequest.Create(URL + "service=SendArray&UserName=" +
            UserName + "&Password=" + Password + "&To=" + recipientNumber.TrimEnd(',') + "&Message=" + Message + "&From=" + SpecialNumber +
            "&Flash=" + (IsFlash ? "true" : "false") + "&chkMessageId=" + checkingMessageID.TrimEnd(','));
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            return (result ?? "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => {
                var out_int = 0L;
                long.TryParse(s.Trim(), out out_int);
                return out_int;
            }).ToArray();
        }
    }

    /// <summary>
    /// Send Array Schedule
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="RecipientNumber">Send SMS to this numbers</param>
    /// <param name="Message">Text of your SMS</param>
    /// <param name="SpecialNumber"></param>
    /// <param name="IsFlash">True/False</param>
    /// <param name="Year">int</param>
    /// <param name="Month">int</param>
    /// <param name="Day">int</param>
    /// <param name="Hour">int</param>
    /// <param name="Minute">int</param>
    /// <returns>MessageID</returns>
    public static long SendArraySchedule(string UserName, string Password, string[] RecipientNumber, string Message, string SpecialNumber, bool IsFlash, int Year, int Month, int Day, int Hour, int Minute) {
        string recipientNumber = "";
        foreach (var item in RecipientNumber) {
            recipientNumber += item + ",";
        }

        WebRequest request = WebRequest.Create(URL + "service=SendArraySchedule&UserName=" +
            UserName + "&Password=" + Password + "&To=" + recipientNumber.TrimEnd(',') + "&Message=" + Message + "&From=" + SpecialNumber +
            "&Flash=" + (IsFlash ? "true" : "false") + "&Year=" + Year + "&Month=" + Month + "&Day=" + Day + "&Hour=" + Hour + "&Minute=" + Minute);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            var out_int = 0L;
            long.TryParse(result.Trim(), out out_int);
            return out_int;
        }
    }

    /// <summary>
    /// Get Message ID
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="CheckingMessageID">Your local ID for message</param>
    /// <returns>MessageIDs</returns>
    public static long[] GetMessageID(string UserName, string Password, long[] CheckingMessageID) {
        string checkingMessageID = "";
        foreach (var item in CheckingMessageID) {
            checkingMessageID += item + ",";
        }

        WebRequest request = WebRequest.Create(URL + "service=GetMessageID&UserName=" +
            UserName + "&Password=" + Password + "&chkMessageId=" + checkingMessageID.TrimEnd(','));
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            return (result ?? "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => {
                var out_int = 0L;
                long.TryParse(s.Trim(), out out_int);
                return out_int;
            }).ToArray();
        }
    }


    /// <summary>
    /// Get Message Status
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="MessageID">long[] MessageIDs</param>
    /// <returns></returns>
    public static long[] GetMessageStatus(string UserName, string Password, long[] MessageID) {
        string messageID = "";
        foreach (var item in MessageID) {
            messageID += item + ",";
        }

        WebRequest request = WebRequest.Create(URL + "service=GetMessageStatus&UserName=" +
            UserName + "&Password=" + Password + "&MessageID=" + messageID.TrimEnd(','));
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            return (result ?? "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => {
                var out_int = 0L;
                long.TryParse(s.Trim(), out out_int);
                return out_int;
            }).ToArray();
        }
    }

    public class NumberGroupItem {
        public long NumberGroupID { get; set; }
        public int NumberCount { get; set; }
        public string FarsiName { get; set; }
        public string EnglishName { get; set; }
        public int Priority { get; set; }
    }

    /// <summary>
    /// Get Number Group Data
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <returns>NumberGroupItem</returns>
    public static NumberGroupItem[] GetNumberGroupData(string UserName, string Password) {
        WebRequest request = WebRequest.Create(URL + "service=GetNumberGroupData&UserName=" + UserName + "&Password=" + Password);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<NumberGroupItem[]>(result);
        }
    }

    /// <summary>
    /// Send To Group Number
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberGroupID">long[] GroupIDs</param>
    /// <param name="Message">Text of your SMS</param>
    /// <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    /// <param name="IsFlash">True/False</param>
    /// <param name="DontSendToRepeatedNumber">True/False</param>
    /// <returns>SendID for Send To Group</returns>
    public static long SendNumberGroup(string UserName, string Password, long[] NumberGroupID, string Message, string SpecialNumber, bool IsFlash, bool DontSendToRepeatedNumber) {
        string numberGroupID = "";
        foreach (var item in NumberGroupID) {
            numberGroupID += item + ",";
        }
        WebRequest request = WebRequest.Create(URL + "service=SendNumberGroup&UserName=" +
            UserName + "&Password=" + Password + "&NumberGroupID=" + numberGroupID.TrimEnd(',') + "&Message=" + Message + "&From=" + SpecialNumber + "&Flash=" + (IsFlash ? "true" : "false")
            + "&DontSendRepeat=" + (DontSendToRepeatedNumber ? "true" : "false"));
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            var out_int = 0L;
            long.TryParse(result.Trim(), out out_int);
            return out_int;
        }
    }

    /// <summary>
    /// Send Number Group Schedule
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberGroupID">long[] GroupIDs</param>
    /// <param name="Message">Text of your SMS</param>
    /// <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    /// <param name="IsFlash">True/False</param>
    /// <param name="DontSendToRepeatedNumber">True/False</param>
    /// <param name="Year">int</param>
    /// <param name="Month">int</param>
    /// <param name="Day">int</param>
    /// <param name="Hour">int</param>
    /// <param name="Minute">int</param>
    /// <returns>SendID for Send To Group</returns>
    public static long SendNumberGroupSchedule(string UserName, string Password, long[] NumberGroupID, string Message, string SpecialNumber, bool IsFlash, bool DontSendToRepeatedNumber, int Year, int Month, int Day, int Hour, int Minute) {
        string numberGroupID = "";
        foreach (var item in NumberGroupID) {
            numberGroupID += item + ",";
        }
        WebRequest request = WebRequest.Create(URL + "service=SendNumberGroupSchedule&UserName=" +
            UserName + "&Password=" + Password + "&NumberGroupID=" + numberGroupID.TrimEnd(',') + "&Message=" + Message + "&From=" + SpecialNumber + "&Flash=" + (IsFlash ? "true" : "false")
            + "&DontSendRepeat=" + (DontSendToRepeatedNumber ? "true" : "false") + "&Year=" + Year + "&Month=" + Month + "&Day=" + Day + "&Hour=" + Hour + "&Minute=" + Minute);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            var out_int = 0L;
            long.TryParse(result.Trim(), out out_int);
            return out_int;
        }
    }

    /// <summary>
    /// Insert Number To PhoneBook
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberGroupID">long GroupID</param>
    /// <param name="PersonNumber">Array of String </param>
    /// <param name="PersonName">Array of String </param>
    /// <returns>Array of long </returns>
    public static long[] InsertNumberInNumberGroup(string UserName, string Password, long NumberGroupID, string[] PersonNumber, string[] PersonName) {
        string person = "", number = "";
        foreach (var item in PersonNumber) {
            number += item + ",";
        }
        foreach (var item in PersonName) {
            person += item + ",";
        }
        WebRequest request = WebRequest.Create(URL + "service=InsertNumberInNumberGroup&UserName=" +
            UserName + "&Password=" + Password + "&NumberGroupID=" + NumberGroupID + "&PersonNumber=" + number.TrimEnd(',') + "&PersonName=" + person.TrimEnd(','));
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            return (result ?? "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => {
                var out_int = 0L;
                long.TryParse(s.Trim(), out out_int);
                return out_int;
            }).ToArray();
        }
    }

    public class InboxItem {
        public long InboxID { get; set; }
        public string SpecialNumber { get; set; }
        public string SenderNumber { get; set; }
        public string MessageBody { get; set; }
        public string ReceiveDate { get; set; }
        public string UDH { get; set; }
    }

    /// <summary>
    /// Get Inbox Message
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberOfMessage">Int Number of message</param>
    /// <returns>InboxItem</returns>
    public static InboxItem[] GetInboxMessage(string UserName, string Password, int NumberOfMessage) {
        WebRequest request = WebRequest.Create(URL + "service=GetInboxMessage&UserName=" + UserName + "&Password=" + Password + "&NumberOfMessage=" + NumberOfMessage);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<InboxItem[]>(result);
        }
    }



    /// <summary>
    /// Get Inbox Message With SpecialNumber
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberOfMessage">Int Number of message</param>
    /// <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    /// <returns>InboxItem</returns>
    public static InboxItem[] GetInboxMessageWithNumber(string UserName, string Password, int NumberOfMessage, string SpecialNumber) {
        WebRequest request = WebRequest.Create(URL + "service=GetInboxMessageWithNumber&UserName=" + UserName + "&Password=" + Password + "&NumberOfMessage=" + NumberOfMessage + "&From=" + SpecialNumber);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<InboxItem[]>(result);
        }
    }

    public abstract class ResultBase {

        public int Status { get; set; }

    }

    public class ResultInbox : ResultBase {

        public InboxItem2[] Messages { get; set; }

    }

    public class InboxItem2 {
        public long InboxID { get; set; }
        public string SpecialNumber { get; set; }
        public string SenderNumber { get; set; }
        public string MessageBody { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string UDH { get; set; }
    }

    /// <summary>
    /// Get Inbox Message With Last InboxID
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberOfMessage">int</param>
    /// <param name="InboxID">int</param>
    /// <param name="IsReaded">True/False</param>
    /// <returns>ResultInbox</returns>
    public static ResultInbox GetInboxMessageWithInboxID(string UserName, string Password, int NumberOfMessage, int InboxID, bool IsReaded) {
        WebRequest request = WebRequest.Create(URL + "service=GetInboxMessageWithInboxID&UserName=" + UserName + "&Password=" + Password + "&NumberOfMessage=" + NumberOfMessage + "&InboxID=" + InboxID + "&IsReaded=" + (IsReaded ? "true" : "false"));
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<ResultInbox>(result);
        }
    }

    /// <summary>
    /// Get Account Credit
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <returns>long Credit</returns>
    public static long GetCredit(string UserName, string Password) {
        WebRequest request = WebRequest.Create(URL + "service=GetCredit&UserName=" + UserName + "&Password=" + Password);
        request.Method = "GET";
        WebResponse response = request.GetResponse();
        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            return String.IsNullOrEmpty(result) ? -1 : long.Parse(result);
        }
    }

    public class ProfileInfo {
        public int SMSCredit { get; set; }
        public int TotalSendSMS { get; set; }
        public int TotalReciveSMS { get; set; }
        public int TotalIncomeSMS { get; set; }
        public string Notifications { get; set; }
        public string NotificationsDisc { get; set; }
        public DateTime NotificationsDate { get; set; }
        public string PublicNotifications { get; set; }
        public string PublicNotificationsDisc { get; set; }
        public DateTime PublicNotificationsDate { get; set; }
        public long Status { get; set; }
    }

    /// <summary>
    /// Get User Info
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <returns>ProfileInfo</returns>
    public static ProfileInfo GetUserInfo(string UserName, string Password) {
        WebRequest request = WebRequest.Create(URL + "service=GetUserInfo&UserName=" + UserName + "&Password=" + Password);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<ProfileInfo>(result);
        }
    }
}