using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void SendArrayAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(SendArrayRecipientNumber.Text)) {
                string[] RecipientNumberString = SendArrayRecipientNumber.Text.Split(';');
                string[] CheckingMessageIDString = new string[] { };
                long[] CheckingMessageID = new long[] { };
                if (!string.IsNullOrEmpty(SendArrayCheckingMessageID.Text)) {
                    CheckingMessageIDString = SendArrayCheckingMessageID.Text.Split(';');
                    CheckingMessageID = new long[CheckingMessageIDString.Length];
                    for (int i = 0; i < CheckingMessageIDString.Length; i++) {
                        CheckingMessageID[i] = long.Parse(CheckingMessageIDString[i]);
                    }
                }

                long[] Result = API.SendArray(UserName.Text, Password.Text, RecipientNumberString, SendArrayMessageBody.Text, SendArraySpecialNumber.Text, SendArrayIsFlash.Checked, CheckingMessageID);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("#");
                ResultTable.Columns.Add("RecipientNumber");
                ResultTable.Columns.Add("MessageID");

                for (int i = 0; i < Result.Length; i++) {
                    DataRow ResultRow = ResultTable.NewRow();
                    ResultRow["#"] = i + 1;
                    try {
                        ResultRow["RecipientNumber"] = RecipientNumberString[i];
                    } catch { }
                    if (Result[i] < 1000)
                        ResultRow["MessageID"] = (MethodStatus.Status)Result[i];
                    else
                        ResultRow["MessageID"] = Result[i];
                    ResultTable.Rows.Add(ResultRow);
                }

                SendArrayResult.DataSource = ResultTable;
                SendArrayResult.DataBind();

                Alarm.Text = "ارسال پیام با موفقیت انجام شد";
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void SendArrayScheduleAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(SendArrayScheduleRecipientNumber.Text)) {
                string[] RecipientNumberString = SendArrayScheduleRecipientNumber.Text.Split(';');
                DateTime ScheduleDate = DateTime.Now.AddMinutes(5);

                long Result = API.SendArraySchedule(UserName.Text, Password.Text, RecipientNumberString, SendArrayScheduleMessageBody.Text, SendArrayScheduleSpecialNumber.Text, SendArrayScheduleIsFlash.Checked, ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, ScheduleDate.Hour, ScheduleDate.Minute);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("SendScheduleID");

                DataRow ResultRow = ResultTable.NewRow();
                if (Result < 1000)
                    ResultRow["SendScheduleID"] = (MethodStatus.Status)Result;
                else
                    ResultRow["SendScheduleID"] = Result;
                ResultTable.Rows.Add(ResultRow);

                SendArrayScheduleResult.DataSource = ResultTable;
                SendArrayScheduleResult.DataBind();

                Alarm.Text = "ارسال پیام با موفقیت انجام شد";
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void GetMessageIDAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(GetMessageIDCheckingMessageID.Text)) {
                string[] CheckingMessageIDString = GetMessageIDCheckingMessageID.Text.Split(';');
                long[] CheckingMessageID = new long[CheckingMessageIDString.Length];
                for (int i = 0; i < CheckingMessageIDString.Length; i++) {
                    CheckingMessageID[i] = long.Parse(CheckingMessageIDString[i]);
                }

                long[] Result = API.GetMessageID(UserName.Text, Password.Text, CheckingMessageID);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("#");
                ResultTable.Columns.Add("CheckingMessageID");
                ResultTable.Columns.Add("MessageID");

                for (int i = 0; i < Result.Length; i++) {
                    DataRow ResultRow = ResultTable.NewRow();
                    ResultRow["#"] = i + 1;
                    try {
                        ResultRow["CheckingMessageID"] = CheckingMessageID[i];
                    } catch { }
                    if (Result[i] < 1000)
                        ResultRow["MessageID"] = (MethodStatus.Status)Result[i];
                    else
                        ResultRow["MessageID"] = Result[i];
                    ResultTable.Rows.Add(ResultRow);
                }

                GetMessageIDResult.DataSource = ResultTable;
                GetMessageIDResult.DataBind();

                Alarm.Text = "ارسال پیام با موفقیت انجام شد";
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void GetMessageStatusAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(GetMessageStatusMessageID.Text)) {

                string[] MessgaeIDString = GetMessageStatusMessageID.Text.Split(';');
                long[] MessageID = new long[MessgaeIDString.Length];
                for (int i = 0; i < MessgaeIDString.Length; i++) {
                    MessageID[i] = long.Parse(MessgaeIDString[i]);
                }

                long[] Result = API.GetMessageStatus(UserName.Text, Password.Text, MessageID);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("#");
                ResultTable.Columns.Add("MessageID");
                ResultTable.Columns.Add("MessageStatus");

                for (int i = 0; i < MessageID.Length; i++) {
                    DataRow ResultRow = ResultTable.NewRow();
                    ResultRow["#"] = i + 1;
                    ResultRow["MessageID"] = MessageID[i];
                    ResultRow["MessageStatus"] = (MethodStatus.Status)Result[i];
                    ResultTable.Rows.Add(ResultRow);
                }

                GetMessageStatusResult.DataSource = ResultTable;
                GetMessageStatusResult.DataBind();
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void GetNumberGroupDataAction_Click(object sender, EventArgs e) {
        try {
            string[] RecipientNumberString = SendArrayScheduleRecipientNumber.Text.Split(';');
            DateTime ScheduleDate = DateTime.Now.AddMinutes(5);

            var Result = API.GetNumberGroupData(UserName.Text, Password.Text);

            DataTable ResultTable = new DataTable();
            ResultTable.Columns.Add("#");
            ResultTable.Columns.Add("NumberGroupID");
            ResultTable.Columns.Add("NumberCount");
            ResultTable.Columns.Add("FarsiName");
            ResultTable.Columns.Add("EnglishName");
            ResultTable.Columns.Add("Priority");

            foreach (var item in Result) {
                DataRow ResultRow = ResultTable.NewRow();
                ResultRow["#"] = ResultTable.Rows.Count + 1;
                ResultRow["NumberGroupID"] = item.NumberGroupID;
                ResultRow["NumberCount"] = item.NumberCount;
                ResultRow["FarsiName"] = item.FarsiName;
                ResultRow["EnglishName"] = item.EnglishName;
                ResultRow["Priority"] = item.Priority;
                ResultTable.Rows.Add(ResultRow);
            }

            GetNumberGroupDataResult.DataSource = ResultTable;
            GetNumberGroupDataResult.DataBind();

            Alarm.Text = "ارسال پیام با موفقیت انجام شد";
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void SendNumberGroupAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(SendNumberGroupNumberGroupID.Text)) {
                string[] NumberGroupIDString = SendNumberGroupNumberGroupID.Text.Split(';');
                long[] NumberGroupID = new long[NumberGroupIDString.Length];
                for (int i = 0; i < NumberGroupIDString.Length; i++) {
                    NumberGroupID[i] = long.Parse(NumberGroupIDString[i]);
                }

                long Result = API.SendNumberGroup(UserName.Text, Password.Text, NumberGroupID, SendNumberGroupMessageBody.Text, SendNumberGroupSpecialNumber.Text, SendNumberGroupIsFlash.Checked, SendNumberGroupDontSendRepeated.Checked);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("SendID");

                DataRow ResultRow = ResultTable.NewRow();
                if (Result < 1000)
                    ResultRow["SendID"] = (MethodStatus.Status)Result;
                else
                    ResultRow["SendID"] = Result;
                ResultTable.Rows.Add(ResultRow);

                SendNumberGroupResult.DataSource = ResultTable;
                SendNumberGroupResult.DataBind();

                Alarm.Text = "ارسال پیام با موفقیت انجام شد";
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void SendNumberGroupScheduleAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(SendNumberGroupScheduleNumberGroupID.Text)) {
                string[] NumberGroupIDString = SendNumberGroupScheduleNumberGroupID.Text.Split(';');
                long[] NumberGroupID = new long[NumberGroupIDString.Length];
                for (int i = 0; i < NumberGroupIDString.Length; i++) {
                    NumberGroupID[i] = long.Parse(NumberGroupIDString[i]);
                }
                DateTime ScheduleDate = DateTime.Now.AddMinutes(5);

                long Result = API.SendNumberGroupSchedule(UserName.Text, Password.Text, NumberGroupID, SendNumberGroupScheduleMessageBody.Text, SendNumberGroupScheduleSpecialNumber.Text, SendNumberGroupScheduleIsFlash.Checked, SendNumberGroupScheduleDontSendRepeated.Checked, ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, ScheduleDate.Hour, ScheduleDate.Minute);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("SendScheduleID");

                DataRow ResultRow = ResultTable.NewRow();
                if (Result < 1000)
                    ResultRow["SendScheduleID"] = (MethodStatus.Status)Result;
                else
                    ResultRow["SendScheduleID"] = Result;
                ResultTable.Rows.Add(ResultRow);

                SendNumberGroupScheduleResult.DataSource = ResultTable;
                SendNumberGroupScheduleResult.DataBind();

                Alarm.Text = "ارسال پیام با موفقیت انجام شد";
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void InsertNumberInNumberGroupAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(InsertNumberInNumberGroupNumberGroupID.Text)) {
                long NumberGroupID = long.Parse(InsertNumberInNumberGroupNumberGroupID.Text);
                string[] PersonNumber = InsertNumberInNumberGroupPersonNumber.Text.Split(';');
                string[] PersonName = InsertNumberInNumberGroupPersonName.Text.Split(';');

                long[] Result = API.InsertNumberInNumberGroup(UserName.Text, Password.Text, NumberGroupID, PersonNumber, PersonName);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("#");
                ResultTable.Columns.Add("PersonNumber");
                ResultTable.Columns.Add("PersonName");
                ResultTable.Columns.Add("InsertResult");

                for (int i = 0; i < Result.Length; i++) {
                    DataRow ResultRow = ResultTable.NewRow();
                    ResultRow["#"] = i + 1;

                    try {
                        ResultRow["PersonNumber"] = PersonNumber[i];
                    } catch { }

                    try {
                        ResultRow["PersonName"] = PersonName[i];
                    } catch { }

                    ResultRow["InsertResult"] = (MethodStatus.Status)Result[i];
                    ResultTable.Rows.Add(ResultRow);
                }


                InsertNumberInNumberGroupResult.DataSource = ResultTable;
                InsertNumberInNumberGroupResult.DataBind();

                Alarm.Text = "ارسال پیام با موفقیت انجام شد";
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void GetInboxMessageAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(GetInboxMessageNumberOfMessage.Text)) {

                var Result = API.GetInboxMessage(UserName.Text, Password.Text, int.Parse(GetInboxMessageNumberOfMessage.Text));

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("#");
                ResultTable.Columns.Add("InboxID");
                ResultTable.Columns.Add("SpecialNumber");
                ResultTable.Columns.Add("SenderNumber");
                ResultTable.Columns.Add("MessageBody");
                ResultTable.Columns.Add("ReceiveDate");
                ResultTable.Columns.Add("UDH");

                foreach (var item in Result) {
                    DataRow ResultRow = ResultTable.NewRow();
                    ResultRow["#"] = ResultTable.Rows.Count + 1;
                    ResultRow["InboxID"] = item.InboxID;
                    ResultRow["SpecialNumber"] = item.SpecialNumber;
                    ResultRow["SenderNumber"] = item.SenderNumber;
                    ResultRow["MessageBody"] = item.MessageBody;
                    ResultRow["ReceiveDate"] = item.ReceiveDate;
                    ResultRow["UDH"] = item.UDH;
                    ResultTable.Rows.Add(ResultRow);
                }

                GetInboxMessageResult.DataSource = ResultTable;
                GetInboxMessageResult.DataBind();
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void GetInboxMessageWithNumberAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(GetInboxMessageWithNumberNumberOfMessage.Text) && !string.IsNullOrEmpty(GetInboxMessageWithNumberSpecialNumber.Text)) {

                var Result = API.GetInboxMessageWithNumber(UserName.Text, Password.Text, int.Parse(GetInboxMessageWithNumberNumberOfMessage.Text), GetInboxMessageWithNumberSpecialNumber.Text);

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("#");
                ResultTable.Columns.Add("InboxID");
                ResultTable.Columns.Add("SpecialNumber");
                ResultTable.Columns.Add("SenderNumber");
                ResultTable.Columns.Add("MessageBody");
                ResultTable.Columns.Add("ReceiveDate");
                ResultTable.Columns.Add("UDH");

                foreach (var item in Result) {
                    DataRow ResultRow = ResultTable.NewRow();
                    ResultRow["#"] = ResultTable.Rows.Count + 1;
                    ResultRow["InboxID"] = item.InboxID;
                    ResultRow["SpecialNumber"] = item.SpecialNumber;
                    ResultRow["SenderNumber"] = item.SenderNumber;
                    ResultRow["MessageBody"] = item.MessageBody;
                    ResultRow["ReceiveDate"] = item.ReceiveDate;
                    ResultRow["UDH"] = item.UDH;
                    ResultTable.Rows.Add(ResultRow);
                }

                GetInboxMessageWithNumberResult.DataSource = ResultTable;
                GetInboxMessageWithNumberResult.DataBind();
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void GetCreditAction_Click(object sender, EventArgs e) {
        try {
            long Result = API.GetCredit(UserName.Text, Password.Text);
            GetCreditResult.Text = Result.ToString();
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }


    protected void AddMessageID_Click(object sender, EventArgs e) {

    }
    protected void GetInboxMessageWithLastInboxAction_Click(object sender, EventArgs e) {
        try {
            if (!string.IsNullOrEmpty(GetInboxMessageWithLastInboxIDCount.Text) && !string.IsNullOrEmpty(GetInboxMessageWithLastInboxIDID.Text)) {

                var Result = API.GetInboxMessageWithInboxID(UserName.Text, Password.Text, int.Parse(GetInboxMessageWithLastInboxIDCount.Text), int.Parse(GetInboxMessageWithLastInboxIDID.Text), (GetInboxMessageWithLastInboxIDReaded.SelectedValue == "true" ? true : false));

                DataTable ResultTable = new DataTable();
                ResultTable.Columns.Add("#");
                ResultTable.Columns.Add("InboxID");
                ResultTable.Columns.Add("SpecialNumber");
                ResultTable.Columns.Add("SenderNumber");
                ResultTable.Columns.Add("MessageBody");
                ResultTable.Columns.Add("ReceiveDate");
                ResultTable.Columns.Add("UDH");

                foreach (var item in Result.Messages) {
                    DataRow ResultRow = ResultTable.NewRow();
                    ResultRow["#"] = ResultTable.Rows.Count + 1;
                    ResultRow["InboxID"] = item.InboxID;
                    ResultRow["SpecialNumber"] = item.SpecialNumber;
                    ResultRow["SenderNumber"] = item.SenderNumber;
                    ResultRow["MessageBody"] = item.MessageBody;
                    ResultRow["ReceiveDate"] = item.ReceiveDate;
                    ResultRow["UDH"] = item.UDH;
                    ResultTable.Rows.Add(ResultRow);
                }

                GetInboxMessageWithLastInboxID.DataSource = ResultTable;
                GetInboxMessageWithLastInboxID.DataBind();
            }
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }

    protected void GetUserInfo_Click(object sender, EventArgs e) {
        try {
            var Result = API.GetUserInfo(UserName.Text, Password.Text);
            StringBuilder st = new StringBuilder();
            st.Append("عنوان اطلاعیه : " + Result.Notifications + "<br><hr>");
            st.Append("تاریخ اطلاعیه : " + Result.NotificationsDate + "<br><hr>");
            st.Append("متن اطلاعیه : " + Result.NotificationsDisc + "<br><hr>");
            st.Append("عنوان اطلاعیه عمومی : " + Result.PublicNotifications + "<br><hr>");
            st.Append("تاریخ اطلاعیه عمومی : " + Result.PublicNotificationsDate + "<br><hr>");
            st.Append("متن اطلاعیه عمومی : " + Result.PublicNotificationsDisc + "<br><hr>");
            st.Append("میزان اعتبار پیام کوتاه : " + Result.SMSCredit + "<br><hr>");
            st.Append("تعداد پیامک های خوانده نشده : " + Result.TotalIncomeSMS + "<br><hr>");
            st.Append("تعداد پیامک های دریافتی : " + Result.TotalReciveSMS + "<br><hr>");
            st.Append("تعداد پیامک های ارسال شده : " + Result.TotalSendSMS + "<br><hr>");
            GetUserInfoData.Text = st.ToString();
        } catch (Exception EX) {
            Alarm.Text = "خطای محلی : " + EX.Message;
        }
    }
}
