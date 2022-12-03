Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization

Public Class API
    Const URL As String = "http://sms.sunwaysms.com/smsws/HttpService.ashx?"
    ''' <summary>
    ''' Send Array 
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="RecipientNumber">Send SMS to this numbers</param>
    ''' <param name="Message">Text of your SMS</param>
    ''' <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    ''' <param name="IsFlash">True/False</param>
    ''' <param name="CheckingMessageID">Your local ID for message</param>
    ''' <returns>MessageID for each SMS</returns>
    Public Shared Function SendArray(UserName As String, Password As String, RecipientNumber As String(), Message As String, SpecialNumber As String, IsFlash As Boolean, CheckingMessageID As Long()) As Long()
        Dim _recipientNumber As String = "", checkingMessageID__4 As String = ""
        For Each item As Long In RecipientNumber
            _recipientNumber += item & ","
        Next

        For Each item As Long In CheckingMessageID
            checkingMessageID__4 += item & ","
        Next

        Dim request As WebRequest = WebRequest.Create(URL & "service=SendArray&UserName=" & UserName & "&Password=" & Password & "&To=" & _recipientNumber.TrimEnd(","c) & "&Message=" & Message & "&From=" & SpecialNumber & "&Flash=" & (If(IsFlash, "true", "false")) & "&chkMessageId=" & checkingMessageID__4.TrimEnd(","c))
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Return (If(result, "")).Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries).[Select](Function(s)
                                                                                                                 Dim out_int = 0L
                                                                                                                 Long.TryParse(s.Trim(), out_int)
                                                                                                                 Return out_int

                                                                                                             End Function).ToArray()
        End Using
    End Function

    ''' <summary>
    ''' Send Array Schedule
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="RecipientNumber">Send SMS to this numbers</param>
    ''' <param name="Message">Text of your SMS</param>
    ''' <param name="SpecialNumber"></param>
    ''' <param name="IsFlash">True/False</param>
    ''' <param name="Year">int</param>
    ''' <param name="Month">int</param>
    ''' <param name="Day">int</param>
    ''' <param name="Hour">int</param>
    ''' <param name="Minute">int</param>
    ''' <returns>MessageID</returns>
    Public Shared Function SendArraySchedule(UserName As String, Password As String, RecipientNumber As String(), Message As String, SpecialNumber As String, IsFlash As Boolean, _
        Year As Integer, Month As Integer, Day As Integer, Hour As Integer, Minute As Integer) As Long
        Dim _recipientNumber As String = ""
        For Each item As Long In RecipientNumber
            _recipientNumber += item & ","
        Next

        Dim request As WebRequest = WebRequest.Create(URL & "service=SendArraySchedule&UserName=" & UserName & "&Password=" & Password & "&To=" & _recipientNumber.TrimEnd(","c) & "&Message=" & Message & "&From=" & SpecialNumber & "&Flash=" & (If(IsFlash, "true", "false")) & "&Year=" & Year & "&Month=" & Month & "&Day=" & Day & "&Hour=" & Hour & "&Minute=" & Minute)
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim out_int = 0L
            Long.TryParse(result.Trim(), out_int)
            Return out_int
        End Using
    End Function

    ''' <summary>
    ''' Get Message ID
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="CheckingMessageID">Your local ID for message</param>
    ''' <returns>MessageIDs</returns>
    Public Shared Function GetMessageID(UserName As String, Password As String, CheckingMessageID As Long()) As Long()
        Dim _checkingMessageID As String = ""
        For Each item As Long In CheckingMessageID
            _checkingMessageID += item & ","
        Next

        Dim request As WebRequest = WebRequest.Create(URL & "service=GetMessageID&UserName=" & UserName & "&Password=" & Password & "&chkMessageId=" & _checkingMessageID.TrimEnd(","c))
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Return (If(result, "")).Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries).[Select](Function(s) 
                                                                                                                 Dim out_int = 0L
                                                                                                                 Long.TryParse(s.Trim(), out_int)
                                                                                                                 Return out_int

                                                                                                             End Function).ToArray()
        End Using
    End Function


    ''' <summary>
    ''' Get Message Status
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="MessageID">long[] MessageIDs</param>
    ''' <returns></returns>
    Public Shared Function GetMessageStatus(UserName As String, Password As String, MessageID As Long()) As Long()
        Dim _messageID As String = ""
        For Each item As Long In MessageID
            _messageID += item & ","
        Next

        Dim request As WebRequest = WebRequest.Create(URL & "service=GetMessageStatus&UserName=" & UserName & "&Password=" & Password & "&MessageID=" & _messageID.TrimEnd(","c))
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Return (If(result, "")).Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries).[Select](Function(s)
                                                                                                                 Dim out_int = 0L
                                                                                                                 Long.TryParse(s.Trim(), out_int)
                                                                                                                 Return out_int

                                                                                                             End Function).ToArray()
        End Using
    End Function

    Public Class NumberGroupItem
        Public Property NumberGroupID() As Long
            Get
                Return m_NumberGroupID
            End Get
            Set(value As Long)
                m_NumberGroupID = value
            End Set
        End Property
        Private m_NumberGroupID As Long
        Public Property NumberCount() As Integer
            Get
                Return m_NumberCount
            End Get
            Set(value As Integer)
                m_NumberCount = value
            End Set
        End Property
        Private m_NumberCount As Integer
        Public Property FarsiName() As String
            Get
                Return m_FarsiName
            End Get
            Set(value As String)
                m_FarsiName = value
            End Set
        End Property
        Private m_FarsiName As String
        Public Property EnglishName() As String
            Get
                Return m_EnglishName
            End Get
            Set(value As String)
                m_EnglishName = value
            End Set
        End Property
        Private m_EnglishName As String
        Public Property Priority() As Integer
            Get
                Return m_Priority
            End Get
            Set(value As Integer)
                m_Priority = value
            End Set
        End Property
        Private m_Priority As Integer
    End Class

    ''' <summary>
    ''' Get Number Group Data
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <returns>NumberGroupItem</returns>
    Public Shared Function GetNumberGroupData(UserName As String, Password As String) As NumberGroupItem()
        Dim request As WebRequest = WebRequest.Create(URL & "service=GetNumberGroupData&UserName=" & UserName & "&Password=" & Password)
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim serializer As New JavaScriptSerializer()
            Return serializer.Deserialize(Of NumberGroupItem())(result)
        End Using
    End Function

    ''' <summary>
    ''' Send To Group Number
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="NumberGroupID">long[] GroupIDs</param>
    ''' <param name="Message">Text of your SMS</param>
    ''' <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    ''' <param name="IsFlash">True/False</param>
    ''' <param name="DontSendToRepeatedNumber">True/False</param>
    ''' <returns>SendID for Send To Group</returns>
    Public Shared Function SendNumberGroup(UserName As String, Password As String, NumberGroupID As Long(), Message As String, SpecialNumber As String, IsFlash As Boolean, _
        DontSendToRepeatedNumber As Boolean) As Long
        Dim _numberGroupID As String = ""
        For Each item As Long In NumberGroupID
            _numberGroupID += item & ","
        Next
        Dim request As WebRequest = WebRequest.Create(URL & "service=SendNumberGroup&UserName=" & UserName & "&Password=" & Password & "&NumberGroupID=" & _numberGroupID.TrimEnd(","c) & "&Message=" & Message & "&From=" & SpecialNumber & "&Flash=" & (If(IsFlash, "true", "false")) & "&DontSendRepeat=" & (If(DontSendToRepeatedNumber, "true", "false")))
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim out_int = 0L
            Long.TryParse(result.Trim(), out_int)
            Return out_int
        End Using
    End Function

    ''' <summary>
    ''' Send Number Group Schedule
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="NumberGroupID">long[] GroupIDs</param>
    ''' <param name="Message">Text of your SMS</param>
    ''' <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    ''' <param name="IsFlash">True/False</param>
    ''' <param name="DontSendToRepeatedNumber">True/False</param>
    ''' <param name="Year">int</param>
    ''' <param name="Month">int</param>
    ''' <param name="Day">int</param>
    ''' <param name="Hour">int</param>
    ''' <param name="Minute">int</param>
    ''' <returns>SendID for Send To Group</returns>
    Public Shared Function SendNumberGroupSchedule(UserName As String, Password As String, NumberGroupID As Long(), Message As String, SpecialNumber As String, IsFlash As Boolean, _
        DontSendToRepeatedNumber As Boolean, Year As Integer, Month As Integer, Day As Integer, Hour As Integer, Minute As Integer) As Long
        Dim _numberGroupID As String = ""
        For Each item As Long In NumberGroupID
            _numberGroupID += item & ","
        Next
        Dim request As WebRequest = WebRequest.Create(URL & "service=SendNumberGroupSchedule&UserName=" & UserName & "&Password=" & Password & "&NumberGroupID=" & _numberGroupID.TrimEnd(","c) & "&Message=" & Message & "&From=" & SpecialNumber & "&Flash=" & (If(IsFlash, "true", "false")) & "&DontSendRepeat=" & (If(DontSendToRepeatedNumber, "true", "false")) & "&Year=" & Year & "&Month=" & Month & "&Day=" & Day & "&Hour=" & Hour & "&Minute=" & Minute)
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim out_int = 0L
            Long.TryParse(result.Trim(), out_int)
            Return out_int
        End Using
    End Function

    ''' <summary>
    ''' Insert Number To PhoneBook
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="NumberGroupID">long GroupID</param>
    ''' <param name="PersonNumber">Array of String </param>
    ''' <param name="PersonName">Array of String </param>
    ''' <returns>Array of long </returns>
    Public Shared Function InsertNumberInNumberGroup(UserName As String, Password As String, NumberGroupID As Long, PersonNumber As String(), PersonName As String()) As Long()
        Dim person As String = "", number As String = ""
        For Each item As String In PersonNumber
            number += item & ","
        Next
        For Each item As String In PersonName
            person += item & ","
        Next
        Dim request As WebRequest = WebRequest.Create(URL & "service=InsertNumberInNumberGroup&UserName=" & UserName & "&Password=" & Password & "&NumberGroupID=" & NumberGroupID & "&PersonNumber=" & number.TrimEnd(","c) & "&PersonName=" & person.TrimEnd(","c))
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Return (If(result, "")).Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries).[Select](Function(s)
                                                                                                                 Dim out_int = 0L
                                                                                                                 Long.TryParse(s.Trim(), out_int)
                                                                                                                 Return out_int

                                                                                                             End Function).ToArray()
        End Using
    End Function

    Public Class InboxItem
        Public Property InboxID() As Long
            Get
                Return m_InboxID
            End Get
            Set(value As Long)
                m_InboxID = value
            End Set
        End Property
        Private m_InboxID As Long
        Public Property SpecialNumber() As String
            Get
                Return m_SpecialNumber
            End Get
            Set(value As String)
                m_SpecialNumber = value
            End Set
        End Property
        Private m_SpecialNumber As String
        Public Property SenderNumber() As String
            Get
                Return m_SenderNumber
            End Get
            Set(value As String)
                m_SenderNumber = value
            End Set
        End Property
        Private m_SenderNumber As String
        Public Property MessageBody() As String
            Get
                Return m_MessageBody
            End Get
            Set(value As String)
                m_MessageBody = value
            End Set
        End Property
        Private m_MessageBody As String
        Public Property ReceiveDate() As String
            Get
                Return m_ReceiveDate
            End Get
            Set(value As String)
                m_ReceiveDate = value
            End Set
        End Property
        Private m_ReceiveDate As String
        Public Property UDH() As String
            Get
                Return m_UDH
            End Get
            Set(value As String)
                m_UDH = value
            End Set
        End Property
        Private m_UDH As String
    End Class

    ''' <summary>
    ''' Get Inbox Message
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="NumberOfMessage">Int Number of message</param>
    ''' <returns>InboxItem</returns>
    Public Shared Function GetInboxMessage(UserName As String, Password As String, NumberOfMessage As Integer) As InboxItem()
        Dim request As WebRequest = WebRequest.Create(URL & "service=GetInboxMessage&UserName=" & UserName & "&Password=" & Password & "&NumberOfMessage=" & NumberOfMessage)
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim serializer As New JavaScriptSerializer()
            Return serializer.Deserialize(Of InboxItem())(result)
        End Using
    End Function



    ''' <summary>
    ''' Get Inbox Message With SpecialNumber
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="NumberOfMessage">Int Number of message</param>
    ''' <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    ''' <returns>InboxItem</returns>
    Public Shared Function GetInboxMessageWithNumber(UserName As String, Password As String, NumberOfMessage As Integer, SpecialNumber As String) As InboxItem()
        Dim request As WebRequest = WebRequest.Create(URL & "service=GetInboxMessageWithNumber&UserName=" & UserName & "&Password=" & Password & "&NumberOfMessage=" & NumberOfMessage & "&From=" & SpecialNumber)
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim serializer As New JavaScriptSerializer()
            Return serializer.Deserialize(Of InboxItem())(result)
        End Using
    End Function

    Public MustInherit Class ResultBase

        Public Property Status() As Integer
            Get
                Return m_Status
            End Get
            Set(value As Integer)
                m_Status = value
            End Set
        End Property
        Private m_Status As Integer

    End Class

    Public Class ResultInbox
        Inherits ResultBase

        Public Property Messages() As InboxItem2()
            Get
                Return m_Messages
            End Get
            Set(value As InboxItem2())
                m_Messages = value
            End Set
        End Property
        Private m_Messages As InboxItem2()

    End Class

    Public Class InboxItem2
        Public Property InboxID() As Long
            Get
                Return m_InboxID
            End Get
            Set(value As Long)
                m_InboxID = value
            End Set
        End Property
        Private m_InboxID As Long
        Public Property SpecialNumber() As String
            Get
                Return m_SpecialNumber
            End Get
            Set(value As String)
                m_SpecialNumber = value
            End Set
        End Property
        Private m_SpecialNumber As String
        Public Property SenderNumber() As String
            Get
                Return m_SenderNumber
            End Get
            Set(value As String)
                m_SenderNumber = value
            End Set
        End Property
        Private m_SenderNumber As String
        Public Property MessageBody() As String
            Get
                Return m_MessageBody
            End Get
            Set(value As String)
                m_MessageBody = value
            End Set
        End Property
        Private m_MessageBody As String
        Public Property ReceiveDate() As DateTime
            Get
                Return m_ReceiveDate
            End Get
            Set(value As DateTime)
                m_ReceiveDate = value
            End Set
        End Property
        Private m_ReceiveDate As DateTime
        Public Property UDH() As String
            Get
                Return m_UDH
            End Get
            Set(value As String)
                m_UDH = value
            End Set
        End Property
        Private m_UDH As String
    End Class

    ''' <summary>
    ''' Get Inbox Message With Last InboxID
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="NumberOfMessage">int</param>
    ''' <param name="InboxID">int</param>
    ''' <param name="IsReaded">True/False</param>
    ''' <returns>ResultInbox</returns>
    Public Shared Function GetInboxMessageWithInboxID(UserName As String, Password As String, NumberOfMessage As Integer, InboxID As Integer, IsReaded As Boolean) As ResultInbox
        Dim request As WebRequest = WebRequest.Create(URL & "service=GetInboxMessageWithInboxID&UserName=" & UserName & "&Password=" & Password & "&NumberOfMessage=" & NumberOfMessage & "&InboxID=" & InboxID & "&IsReaded=" & (If(IsReaded, "true", "false")))
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim serializer As New JavaScriptSerializer()
            Return serializer.Deserialize(Of ResultInbox)(result)
        End Using
    End Function

    ''' <summary>
    ''' Get Account Credit
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <returns>long Credit</returns>
    Public Shared Function GetCredit(UserName As String, Password As String) As Long
        Dim request As WebRequest = WebRequest.Create(URL & "service=GetCredit&UserName=" & UserName & "&Password=" & Password)
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()
        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Return If([String].IsNullOrEmpty(result), -1, Long.Parse(result))
        End Using
    End Function

    Public Class ProfileInfo
        Public Property SMSCredit() As Integer
            Get
                Return m_SMSCredit
            End Get
            Set(value As Integer)
                m_SMSCredit = value
            End Set
        End Property
        Private m_SMSCredit As Integer
        Public Property TotalSendSMS() As Integer
            Get
                Return m_TotalSendSMS
            End Get
            Set(value As Integer)
                m_TotalSendSMS = value
            End Set
        End Property
        Private m_TotalSendSMS As Integer
        Public Property TotalReciveSMS() As Integer
            Get
                Return m_TotalReciveSMS
            End Get
            Set(value As Integer)
                m_TotalReciveSMS = value
            End Set
        End Property
        Private m_TotalReciveSMS As Integer
        Public Property TotalIncomeSMS() As Integer
            Get
                Return m_TotalIncomeSMS
            End Get
            Set(value As Integer)
                m_TotalIncomeSMS = value
            End Set
        End Property
        Private m_TotalIncomeSMS As Integer
        Public Property Notifications() As String
            Get
                Return m_Notifications
            End Get
            Set(value As String)
                m_Notifications = value
            End Set
        End Property
        Private m_Notifications As String
        Public Property NotificationsDisc() As String
            Get
                Return m_NotificationsDisc
            End Get
            Set(value As String)
                m_NotificationsDisc = value
            End Set
        End Property
        Private m_NotificationsDisc As String
        Public Property NotificationsDate() As DateTime
            Get
                Return m_NotificationsDate
            End Get
            Set(value As DateTime)
                m_NotificationsDate = value
            End Set
        End Property
        Private m_NotificationsDate As DateTime
        Public Property PublicNotifications() As String
            Get
                Return m_PublicNotifications
            End Get
            Set(value As String)
                m_PublicNotifications = value
            End Set
        End Property
        Private m_PublicNotifications As String
        Public Property PublicNotificationsDisc() As String
            Get
                Return m_PublicNotificationsDisc
            End Get
            Set(value As String)
                m_PublicNotificationsDisc = value
            End Set
        End Property
        Private m_PublicNotificationsDisc As String
        Public Property PublicNotificationsDate() As DateTime
            Get
                Return m_PublicNotificationsDate
            End Get
            Set(value As DateTime)
                m_PublicNotificationsDate = value
            End Set
        End Property
        Private m_PublicNotificationsDate As DateTime
        Public Property Status() As Long
            Get
                Return m_Status
            End Get
            Set(value As Long)
                m_Status = value
            End Set
        End Property
        Private m_Status As Long
    End Class

    ''' <summary>
    ''' Get User Info
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <returns>ProfileInfo</returns>
    Public Shared Function GetUserInfo(UserName As String, Password As String) As ProfileInfo
        Dim request As WebRequest = WebRequest.Create(URL & "service=GetUserInfo&UserName=" & UserName & "&Password=" & Password)
        request.Method = "GET"
        Dim response As WebResponse = request.GetResponse()

        Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
            Dim result = reader.ReadToEnd()
            Dim serializer As New JavaScriptSerializer()
            Return serializer.Deserialize(Of ProfileInfo)(result)
        End Using
    End Function

End Class
