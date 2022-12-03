Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports System.Text
Imports System.Xml.Serialization
Imports System.IO

Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub

    Protected Sub SendArrayAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(SendArrayRecipientNumber.Text) Then
                Dim RecipientNumberString As String() = SendArrayRecipientNumber.Text.Split(";"c)
                Dim CheckingMessageIDString As String() = New String() {}
                Dim CheckingMessageID As Long() = New Long() {}
                If Not String.IsNullOrEmpty(SendArrayCheckingMessageID.Text) Then
                    CheckingMessageIDString = SendArrayCheckingMessageID.Text.Split(";"c)
                    CheckingMessageID = New Long(CheckingMessageIDString.Length - 1) {}
                    For i As Integer = 0 To CheckingMessageIDString.Length - 1
                        CheckingMessageID(i) = Long.Parse(CheckingMessageIDString(i))
                    Next
                End If

                Dim Result As Long() = API.SendArray(UserName.Text, Password.Text, RecipientNumberString, SendArrayMessageBody.Text, _
                    SendArraySpecialNumber.Text, SendArrayIsFlash.Checked, CheckingMessageID)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("#")
                ResultTable.Columns.Add("RecipientNumber")
                ResultTable.Columns.Add("MessageID")

                For i As Integer = 0 To Result.Length - 1
                    Dim ResultRow As DataRow = ResultTable.NewRow()
                    ResultRow("#") = i + 1
                    Try
                        ResultRow("RecipientNumber") = RecipientNumberString(i)
                    Catch
                    End Try
                    If Result(i) < 1000 Then
                        ResultRow("MessageID") = CType(Result(i), MethodStatus.Status)
                    Else
                        ResultRow("MessageID") = Result(i)
                    End If
                    ResultTable.Rows.Add(ResultRow)
                Next

                SendArrayResult.DataSource = ResultTable
                SendArrayResult.DataBind()

                Alarm.Text = "ارسال پیام با موفقیت انجام شد"
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub SendArrayScheduleAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(SendArrayScheduleRecipientNumber.Text) Then
                Dim RecipientNumberString As String() = SendArrayScheduleRecipientNumber.Text.Split(";"c)
                Dim ScheduleDate As DateTime = DateTime.Now.AddMinutes(5)

                Dim Result As Long = API.SendArraySchedule(UserName.Text, Password.Text, RecipientNumberString, SendArrayScheduleMessageBody.Text, _
                    SendArrayScheduleSpecialNumber.Text, SendArrayScheduleIsFlash.Checked, ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, ScheduleDate.Hour, _
                    ScheduleDate.Minute)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("SendScheduleID")

                Dim ResultRow As DataRow = ResultTable.NewRow()
                If Result < 1000 Then
                    ResultRow("SendScheduleID") = CType(Result, MethodStatus.Status)
                Else
                    ResultRow("SendScheduleID") = Result
                End If
                ResultTable.Rows.Add(ResultRow)

                SendArrayScheduleResult.DataSource = ResultTable
                SendArrayScheduleResult.DataBind()

                Alarm.Text = "ارسال پیام با موفقیت انجام شد"
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub GetMessageIDAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(GetMessageIDCheckingMessageID.Text) Then
                Dim CheckingMessageIDString As String() = GetMessageIDCheckingMessageID.Text.Split(";"c)
                Dim CheckingMessageID As Long() = New Long(CheckingMessageIDString.Length - 1) {}
                For i As Integer = 0 To CheckingMessageIDString.Length - 1
                    CheckingMessageID(i) = Long.Parse(CheckingMessageIDString(i))
                Next

                Dim Result As Long() = API.GetMessageID(UserName.Text, Password.Text, CheckingMessageID)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("#")
                ResultTable.Columns.Add("CheckingMessageID")
                ResultTable.Columns.Add("MessageID")

                For i As Integer = 0 To Result.Length - 1
                    Dim ResultRow As DataRow = ResultTable.NewRow()
                    ResultRow("#") = i + 1
                    Try
                        ResultRow("CheckingMessageID") = CheckingMessageID(i)
                    Catch
                    End Try
                    If Result(i) < 1000 Then
                        ResultRow("MessageID") = CType(Result(i), MethodStatus.Status)
                    Else
                        ResultRow("MessageID") = Result(i)
                    End If
                    ResultTable.Rows.Add(ResultRow)
                Next

                GetMessageIDResult.DataSource = ResultTable
                GetMessageIDResult.DataBind()

                Alarm.Text = "ارسال پیام با موفقیت انجام شد"
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub GetMessageStatusAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(GetMessageStatusMessageID.Text) Then

                Dim MessgaeIDString As String() = GetMessageStatusMessageID.Text.Split(";"c)
                Dim MessageID As Long() = New Long(MessgaeIDString.Length - 1) {}
                For i As Integer = 0 To MessgaeIDString.Length - 1
                    MessageID(i) = Long.Parse(MessgaeIDString(i))
                Next

                Dim Result As Long() = API.GetMessageStatus(UserName.Text, Password.Text, MessageID)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("#")
                ResultTable.Columns.Add("MessageID")
                ResultTable.Columns.Add("MessageStatus")

                For i As Integer = 0 To MessageID.Length - 1
                    Dim ResultRow As DataRow = ResultTable.NewRow()
                    ResultRow("#") = i + 1
                    ResultRow("MessageID") = MessageID(i)
                    ResultRow("MessageStatus") = CType(Result(i), MethodStatus.Status)
                    ResultTable.Rows.Add(ResultRow)
                Next

                GetMessageStatusResult.DataSource = ResultTable
                GetMessageStatusResult.DataBind()
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub GetNumberGroupDataAction_Click(sender As Object, e As EventArgs)
        Try
            Dim RecipientNumberString As String() = SendArrayScheduleRecipientNumber.Text.Split(";"c)
            Dim ScheduleDate As DateTime = DateTime.Now.AddMinutes(5)

            Dim Result = API.GetNumberGroupData(UserName.Text, Password.Text)

            Dim ResultTable As New DataTable()
            ResultTable.Columns.Add("#")
            ResultTable.Columns.Add("NumberGroupID")
            ResultTable.Columns.Add("NumberCount")
            ResultTable.Columns.Add("FarsiName")
            ResultTable.Columns.Add("EnglishName")
            ResultTable.Columns.Add("Priority")

            For Each item As API.NumberGroupItem In Result
                Dim ResultRow As DataRow = ResultTable.NewRow()
                ResultRow("#") = ResultTable.Rows.Count + 1
                ResultRow("NumberGroupID") = item.NumberGroupID
                ResultRow("NumberCount") = item.NumberCount
                ResultRow("FarsiName") = item.FarsiName
                ResultRow("EnglishName") = item.EnglishName
                ResultRow("Priority") = item.Priority
                ResultTable.Rows.Add(ResultRow)
            Next

            GetNumberGroupDataResult.DataSource = ResultTable
            GetNumberGroupDataResult.DataBind()

            Alarm.Text = "ارسال پیام با موفقیت انجام شد"
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub SendNumberGroupAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(SendNumberGroupNumberGroupID.Text) Then
                Dim NumberGroupIDString As String() = SendNumberGroupNumberGroupID.Text.Split(";"c)
                Dim NumberGroupID As Long() = New Long(NumberGroupIDString.Length - 1) {}
                For i As Integer = 0 To NumberGroupIDString.Length - 1
                    NumberGroupID(i) = Long.Parse(NumberGroupIDString(i))
                Next

                Dim Result As Long = API.SendNumberGroup(UserName.Text, Password.Text, NumberGroupID, SendNumberGroupMessageBody.Text, _
                    SendNumberGroupSpecialNumber.Text, SendNumberGroupIsFlash.Checked, SendNumberGroupDontSendRepeated.Checked)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("SendID")

                Dim ResultRow As DataRow = ResultTable.NewRow()
                If Result < 1000 Then
                    ResultRow("SendID") = CType(Result, MethodStatus.Status)
                Else
                    ResultRow("SendID") = Result
                End If
                ResultTable.Rows.Add(ResultRow)

                SendNumberGroupResult.DataSource = ResultTable
                SendNumberGroupResult.DataBind()

                Alarm.Text = "ارسال پیام با موفقیت انجام شد"
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub SendNumberGroupScheduleAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(SendNumberGroupScheduleNumberGroupID.Text) Then
                Dim NumberGroupIDString As String() = SendNumberGroupScheduleNumberGroupID.Text.Split(";"c)
                Dim NumberGroupID As Long() = New Long(NumberGroupIDString.Length - 1) {}
                For i As Integer = 0 To NumberGroupIDString.Length - 1
                    NumberGroupID(i) = Long.Parse(NumberGroupIDString(i))
                Next
                Dim ScheduleDate As DateTime = DateTime.Now.AddMinutes(5)

                Dim Result As Long = API.SendNumberGroupSchedule(UserName.Text, Password.Text, NumberGroupID, SendNumberGroupScheduleMessageBody.Text, _
                    SendNumberGroupScheduleSpecialNumber.Text, SendNumberGroupScheduleIsFlash.Checked, SendNumberGroupScheduleDontSendRepeated.Checked, ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, _
                    ScheduleDate.Hour, ScheduleDate.Minute)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("SendScheduleID")

                Dim ResultRow As DataRow = ResultTable.NewRow()
                If Result < 1000 Then
                    ResultRow("SendScheduleID") = CType(Result, MethodStatus.Status)
                Else
                    ResultRow("SendScheduleID") = Result
                End If
                ResultTable.Rows.Add(ResultRow)

                SendNumberGroupScheduleResult.DataSource = ResultTable
                SendNumberGroupScheduleResult.DataBind()

                Alarm.Text = "ارسال پیام با موفقیت انجام شد"
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub InsertNumberInNumberGroupAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(InsertNumberInNumberGroupNumberGroupID.Text) Then
                Dim NumberGroupID As Long = Long.Parse(InsertNumberInNumberGroupNumberGroupID.Text)
                Dim PersonNumber As String() = InsertNumberInNumberGroupPersonNumber.Text.Split(";"c)
                Dim PersonName As String() = InsertNumberInNumberGroupPersonName.Text.Split(";"c)

                Dim Result As Long() = API.InsertNumberInNumberGroup(UserName.Text, Password.Text, NumberGroupID, PersonNumber, _
                    PersonName)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("#")
                ResultTable.Columns.Add("PersonNumber")
                ResultTable.Columns.Add("PersonName")
                ResultTable.Columns.Add("InsertResult")

                For i As Integer = 0 To Result.Length - 1
                    Dim ResultRow As DataRow = ResultTable.NewRow()
                    ResultRow("#") = i + 1

                    Try
                        ResultRow("PersonNumber") = PersonNumber(i)
                    Catch
                    End Try

                    Try
                        ResultRow("PersonName") = PersonName(i)
                    Catch
                    End Try

                    ResultRow("InsertResult") = CType(Result(i), MethodStatus.Status)
                    ResultTable.Rows.Add(ResultRow)
                Next


                InsertNumberInNumberGroupResult.DataSource = ResultTable
                InsertNumberInNumberGroupResult.DataBind()

                Alarm.Text = "ارسال پیام با موفقیت انجام شد"
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub GetInboxMessageAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(GetInboxMessageNumberOfMessage.Text) Then

                Dim Result = API.GetInboxMessage(UserName.Text, Password.Text, Integer.Parse(GetInboxMessageNumberOfMessage.Text))

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("#")
                ResultTable.Columns.Add("InboxID")
                ResultTable.Columns.Add("SpecialNumber")
                ResultTable.Columns.Add("SenderNumber")
                ResultTable.Columns.Add("MessageBody")
                ResultTable.Columns.Add("ReceiveDate")
                ResultTable.Columns.Add("UDH")

                For Each item As API.InboxItem In Result
                    Dim ResultRow As DataRow = ResultTable.NewRow()
                    ResultRow("#") = ResultTable.Rows.Count + 1
                    ResultRow("InboxID") = item.InboxID
                    ResultRow("SpecialNumber") = item.SpecialNumber
                    ResultRow("SenderNumber") = item.SenderNumber
                    ResultRow("MessageBody") = item.MessageBody
                    ResultRow("ReceiveDate") = item.ReceiveDate
                    ResultRow("UDH") = item.UDH
                    ResultTable.Rows.Add(ResultRow)
                Next

                GetInboxMessageResult.DataSource = ResultTable
                GetInboxMessageResult.DataBind()
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub GetInboxMessageWithNumberAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(GetInboxMessageWithNumberNumberOfMessage.Text) AndAlso Not String.IsNullOrEmpty(GetInboxMessageWithNumberSpecialNumber.Text) Then

                Dim Result = API.GetInboxMessageWithNumber(UserName.Text, Password.Text, Integer.Parse(GetInboxMessageWithNumberNumberOfMessage.Text), GetInboxMessageWithNumberSpecialNumber.Text)

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("#")
                ResultTable.Columns.Add("InboxID")
                ResultTable.Columns.Add("SpecialNumber")
                ResultTable.Columns.Add("SenderNumber")
                ResultTable.Columns.Add("MessageBody")
                ResultTable.Columns.Add("ReceiveDate")
                ResultTable.Columns.Add("UDH")

                For Each item As API.InboxItem In Result
                    Dim ResultRow As DataRow = ResultTable.NewRow()
                    ResultRow("#") = ResultTable.Rows.Count + 1
                    ResultRow("InboxID") = item.InboxID
                    ResultRow("SpecialNumber") = item.SpecialNumber
                    ResultRow("SenderNumber") = item.SenderNumber
                    ResultRow("MessageBody") = item.MessageBody
                    ResultRow("ReceiveDate") = item.ReceiveDate
                    ResultRow("UDH") = item.UDH
                    ResultTable.Rows.Add(ResultRow)
                Next

                GetInboxMessageWithNumberResult.DataSource = ResultTable
                GetInboxMessageWithNumberResult.DataBind()
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub GetCreditAction_Click(sender As Object, e As EventArgs)
        Try
            Dim Result As Long = API.GetCredit(UserName.Text, Password.Text)
            GetCreditResult.Text = Result.ToString()
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub


    Protected Sub AddMessageID_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub GetInboxMessageWithLastInboxAction_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(GetInboxMessageWithLastInboxIDCount.Text) AndAlso Not String.IsNullOrEmpty(GetInboxMessageWithLastInboxIDID.Text) Then

                Dim Result = API.GetInboxMessageWithInboxID(UserName.Text, Password.Text, Integer.Parse(GetInboxMessageWithLastInboxIDCount.Text), Integer.Parse(GetInboxMessageWithLastInboxIDID.Text), _
                    (GetInboxMessageWithLastInboxIDReaded.SelectedValue = "true"))

                Dim ResultTable As New DataTable()
                ResultTable.Columns.Add("#")
                ResultTable.Columns.Add("InboxID")
                ResultTable.Columns.Add("SpecialNumber")
                ResultTable.Columns.Add("SenderNumber")
                ResultTable.Columns.Add("MessageBody")
                ResultTable.Columns.Add("ReceiveDate")
                ResultTable.Columns.Add("UDH")

                For Each item As API.InboxItem2 In Result.Messages
                    Dim ResultRow As DataRow = ResultTable.NewRow()
                    ResultRow("#") = ResultTable.Rows.Count + 1
                    ResultRow("InboxID") = item.InboxID
                    ResultRow("SpecialNumber") = item.SpecialNumber
                    ResultRow("SenderNumber") = item.SenderNumber
                    ResultRow("MessageBody") = item.MessageBody
                    ResultRow("ReceiveDate") = item.ReceiveDate
                    ResultRow("UDH") = item.UDH
                    ResultTable.Rows.Add(ResultRow)
                Next

                GetInboxMessageWithLastInboxID.DataSource = ResultTable
                GetInboxMessageWithLastInboxID.DataBind()
            End If
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub

    Protected Sub GetUserInfo_Click(sender As Object, e As EventArgs)
        Try
            Dim Result = API.GetUserInfo(UserName.Text, Password.Text)
            Dim st As New StringBuilder()
            st.Append("عنوان اطلاعیه : " & Convert.ToString(Result.Notifications) & "<br><hr>")
            st.Append("تاریخ اطلاعیه : " & Convert.ToString(Result.NotificationsDate) & "<br><hr>")
            st.Append("متن اطلاعیه : " & Convert.ToString(Result.NotificationsDisc) & "<br><hr>")
            st.Append("عنوان اطلاعیه عمومی : " & Convert.ToString(Result.PublicNotifications) & "<br><hr>")
            st.Append("تاریخ اطلاعیه عمومی : " & Convert.ToString(Result.PublicNotificationsDate) & "<br><hr>")
            st.Append("متن اطلاعیه عمومی : " & Convert.ToString(Result.PublicNotificationsDisc) & "<br><hr>")
            st.Append("میزان اعتبار پیام کوتاه : " & Convert.ToString(Result.SMSCredit) & "<br><hr>")
            st.Append("تعداد پیامک های خوانده نشده : " & Convert.ToString(Result.TotalIncomeSMS) & "<br><hr>")
            st.Append("تعداد پیامک های دریافتی : " & Convert.ToString(Result.TotalReciveSMS) & "<br><hr>")
            st.Append("تعداد پیامک های ارسال شده : " & Convert.ToString(Result.TotalSendSMS) & "<br><hr>")
            GetUserInfoData.Text = st.ToString()
        Catch EX As Exception
            Alarm.Text = "خطای محلی : " & EX.Message
        End Try
    End Sub
End Class


