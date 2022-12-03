<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.Net Url(Http) Sample</title>
    <link href="CSS/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class='dForm'>
            <asp:Label ID="Alarm" runat="server" Text="خوش آمدید" ForeColor="Firebrick"></asp:Label>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>1 . </strong>اطلاعات اصلی مورد نیاز در هر یک از متد ها</div>
            <div class='dRight'>
                <div>نام کاربری :</div>
                <div>رمز عبور :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>2 . </strong>ارسال پیام کوتاه</div>
            <div class='dRight'>
                <div>شماره اختصاصی :</div>
                <div class='m'>
                    شماره گیرنده :<br />
                    <span class='small'>( شماره ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span>
                </div>
                <div class='m'>
                    CheckingMessageID:<br />
                    <span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span>
                </div>
                <div class='m'>متن پیام :</div>
                <div>ارسال بصورت Flash</div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="SendArraySpecialNumber" runat="server"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendArrayRecipientNumber" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendArrayCheckingMessageID" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendArrayMessageBody" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div>
                    <asp:CheckBox ID="SendArrayIsFlash" runat="server" />
                </div>
                <div class='c'>
                    <asp:LinkButton ID="SendArrayAction" runat="server" OnClick="SendArrayAction_Click">ارسال پیام کوتاه</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="SendArrayResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>3 . </strong>ارسال پیام کوتاه زمانبندی شده</div>
            <div class='dRight'>
                <div>شماره اختصاصی :</div>
                <div class='m'>
                    شماره گیرنده :<br />
                    <span class='small'>( شماره ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span>
                </div>
                <div class='m'>متن پیام :</div>
                <div>ارسال بصورت Flash</div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="SendArrayScheduleSpecialNumber" runat="server"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendArrayScheduleRecipientNumber" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendArrayScheduleMessageBody" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div>
                    <asp:CheckBox ID="SendArrayScheduleIsFlash" runat="server" />
                </div>
                <div class='c'>
                    <asp:LinkButton ID="SendArrayScheduleAction" runat="server" OnClick="SendArrayScheduleAction_Click">ارسال پیام کوتاه زمانبندی شده</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="SendArrayScheduleResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>4 . </strong>بدست آوردن MessageID</div>
            <div class='dRight'>
                <div class='m'>
                    CheckingMessageID:<br />
                    <span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span>
                </div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div class='m'>
                    <asp:TextBox ID="GetMessageIDCheckingMessageID" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='c'>
                    <asp:LinkButton ID="GetMessageIDActive" runat="server" OnClick="GetMessageIDAction_Click">بدست آوردن MessageID</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="GetMessageIDResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'>دریافت آخرین وضعیت پیام های ارسال شده</div>
            <div class='dRight'>
                <div class='m'>
                    شناسه پیامک :<br />
                    <span class='small'>( شناسه ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span>
                </div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div class='m'>
                    <asp:TextBox ID="GetMessageStatusMessageID" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='c'>
                    <asp:LinkButton ID="GetMessageStatusAction" runat="server" OnClick="GetMessageStatusAction_Click">دریافت آخرین وضعیت پیام های ارسال شده</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="GetMessageStatusResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>4 . </strong>دریافت اطلاعات گروه شماره های دفتر تلفن</div>
            <div class='dRight'>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div class='c'>
                    <asp:LinkButton ID="GetNumberGroupDataAction" runat="server" OnClick="GetNumberGroupDataAction_Click">دریافت اطلاعات گروه شماره های دفتر تلفن</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="GetNumberGroupDataResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>5 . </strong>ارسال پیام کوتاه به گروه شماره های دفتر تلفن</div>
            <div class='dRight'>
                <div>شماره اختصاصی :</div>
                <div class='m'>
                    شناسه گروه ها :<br />
                    <span class='small'>( شناسه ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span>
                </div>
                <div class='m'>متن پیام :</div>
                <div>ارسال بصورت Flash</div>
                <div>عدم ارسال به شماره های تکراری</div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="SendNumberGroupSpecialNumber" runat="server"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendNumberGroupNumberGroupID" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendNumberGroupMessageBody" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div>
                    <asp:CheckBox ID="SendNumberGroupIsFlash" runat="server" />
                </div>
                <div>
                    <asp:CheckBox ID="SendNumberGroupDontSendRepeated" runat="server" />
                </div>
                <div class='c'>
                    <asp:LinkButton ID="SendNumberGroupAction" runat="server" OnClick="SendNumberGroupAction_Click">ارسال پیام کوتاه به گروه شماره های دفتر تلفن</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="SendNumberGroupResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>6 . </strong>ارسال پیام کوتاه زمانبندی شده به گروه شماره های دفتر تلفن</div>
            <div class='dRight'>
                <div>شماره اختصاصی :</div>
                <div class='m'>
                    شناسه گروه ها :<br />
                    <span class='small'>( شناسه ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span>
                </div>
                <div class='m'>متن پیام :</div>
                <div>ارسال بصورت Flash</div>
                <div>عدم ارسال به شماره های تکراری</div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="SendNumberGroupScheduleSpecialNumber" runat="server"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendNumberGroupScheduleNumberGroupID" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="SendNumberGroupScheduleMessageBody" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div>
                    <asp:CheckBox ID="SendNumberGroupScheduleIsFlash" runat="server" />
                </div>
                <div>
                    <asp:CheckBox ID="SendNumberGroupScheduleDontSendRepeated" runat="server" />
                </div>
                <div class='c'>
                    <asp:LinkButton ID="SendNumberGroupScheduleAction" runat="server" OnClick="SendNumberGroupScheduleAction_Click">ارسال پیام کوتاه زمانبندی شده به گروه شماره های دفتر تلفن</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="SendNumberGroupScheduleResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'><strong>7 . </strong>ثبت شماره در گروه شماره های دفتر تلفن</div>
            <div class='dRight'>
                <div>شناسه گروه :</div>
                <div class='m'>
                    شماره افراد :<br />
                    <span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span>
                </div>
                <div class='m'>
                    نام افراد :<br />
                    <span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span>
                </div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="InsertNumberInNumberGroupNumberGroupID" runat="server"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="InsertNumberInNumberGroupPersonNumber" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='m'>
                    <asp:TextBox ID="InsertNumberInNumberGroupPersonName" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </div>
                <div class='c'>
                    <asp:LinkButton ID="InsertNumberInNumberGroupAction" runat="server" OnClick="InsertNumberInNumberGroupAction_Click">ثبت شماره در گروه شماره های دفتر تلفن</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="InsertNumberInNumberGroupResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'>دریافت آخرین پیام های رسیده در روز اخیر</div>
            <div class='dRight'>
                <div>تعداد :</div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="GetInboxMessageNumberOfMessage" runat="server"></asp:TextBox>
                </div>
                <div class='c'>
                    <asp:LinkButton ID="GetInboxMessageAction" runat="server" OnClick="GetInboxMessageAction_Click">دریافت آخرین پیام های رسیده در روز اخیر</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="GetInboxMessageResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'>دریافت آخرین پیام های رسیده در روز اخیر به شماره خاص</div>
            <div class='dRight'>
                <div>تعداد :</div>
                <div>شماره اختصاصی :</div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="GetInboxMessageWithNumberNumberOfMessage" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="GetInboxMessageWithNumberSpecialNumber" runat="server"></asp:TextBox>
                </div>
                <div class='c'>
                    <asp:LinkButton ID="GetInboxMessageWithNumberAction" runat="server" OnClick="GetInboxMessageWithNumberAction_Click">دریافت آخرین پیام های رسیده در روز اخیر به شماره خاص</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="GetInboxMessageWithNumberResult" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'>دریافت میزان اعتبار پیام کوتاه</div>
            <div class='dRight'>
                <div></div>
                <div class='e'>میزان اعتبار (ریال) :</div>
            </div>
            <div class='dLeft'>
                <div class='c'>
                    <asp:LinkButton ID="GetCreditAction" runat="server" OnClick="GetCreditAction_Click">دریافت میزان اعتبار پیام کوتاه</asp:LinkButton>
                </div>
                <div class='e'>
                    <asp:TextBox ID="GetCreditResult" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class='clear'></div>
        </div>

        <div class='dForm'>
            <div class='dTitle'>دریافت آخرین پیام های رسیده با آخرین ID پیام دریافتی</div>
            <div class='dRight'>
                <div>تعداد :</div>
                <div>آخرین ID :</div>
                <div>فقط خوانده نشده ها :</div>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div>
                    <asp:TextBox ID="GetInboxMessageWithLastInboxIDCount" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="GetInboxMessageWithLastInboxIDID" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="GetInboxMessageWithLastInboxIDReaded">
                        <asp:ListItem Text="بله" Value="false"></asp:ListItem>
                        <asp:ListItem Text="خیر" Value="true"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class='c'>
                    <asp:LinkButton ID="GetInboxMessageWithLastInboxAction" runat="server" OnClick="GetInboxMessageWithLastInboxAction_Click">دریافت آخرین پیام های رسیده با آخرین ID پیام دریافتی</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:DataGrid ID="GetInboxMessageWithLastInboxID" runat="server" Width="100%" CellPadding="5"></asp:DataGrid>
            <div class='clear'></div>
        </div>

         <div class='dForm'>
            <div class='dTitle'>دریافت اطلاعات کاربری</div>
            <div class='dRight'>
                <div></div>
                <div class='e'>نتیجه :</div>
            </div>
            <div class='dLeft'>
                <div class='c'>
                    <asp:LinkButton ID="GetUserInfo" runat="server" OnClick="GetUserInfo_Click">دریافت اطلاعات کاربری</asp:LinkButton>
                </div>
                <div class='e'></div>
            </div>
            <asp:Label ID="GetUserInfoData" runat="server" Width="100%" CellPadding="5"></asp:Label>
            <div class='clear'></div>
        </div>
    </form>
</body>
</html>
