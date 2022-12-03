# راهنمای متد GetInboxMessageWithNumber

- [راهنمای متد GetInboxMessageWithNumber](#راهنمای-متد-getinboxmessagewithnumber)
  - [پارامترهای ورودی](#پارامترهای-ورودی)
  - [خروجی Json](#خروجی-json)
  - [نمونه کد](#نمونه-کد)
    - [PHP](#php)
    - [Java](#java)
    - [C#](#c)
    - [VB.net](#vbnet)

این متد همانند متد GetInboxMessageWithNumber می باشد با این تفاوت که در این متد شما می توانید تعداد مشخصی از پیامک های دریافتی در روز اخیر که به یک شماره اختصاصی خاص ارسال شده اند را دریافت کنید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=GetInboxMessageWithNumber&username=$UserName$&password=$Password$&NumberOfMessage=$NumberOfMessage$&from=$SpecialNumber$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

<table dir="rtl" align="center">
<tr><th>نام</th><th>نوع</th><th>اجباری / اختیاری</th><th>توضیح</th></tr>
<tr><td>UserName</td><td>String</td><td>اجباری</td><td>نام کاربری</td></tr>
<tr><td>Password</td><td>String</td><td>اجباری</td><td>کلمه عبور</td></tr>
<tr><td>NumberOfMessage</td><td>Integer</td><td>اجباری</td><td>تعداد پیامک های درخواستی</td></tr>
<tr><td>SpecialNumber</td><td>String</td><td>اجباری</td><td>شماره اختصاصی ( شماره دریافت کننده پیامک )</td></tr>
</table>

## خروجی Json

<table dir="rtl" align="center">
<tr><th>کلید</th><th>توضیح</th></tr>
<tr><td>InboxID</td><td>شناسه پیامک دریافتی</td></tr>
<tr><td>SpecialNumber</td><td>شماره اختصاصی ( شماره ای پیامک را دریافت کرده است )</td></tr>
<tr><td>SenderNumber</td><td>شماره فرستنده ( شماره موبایل فرستنده پیامک )</td></tr>
<tr><td>MessageBody</td><td>متن پیامک</td></tr>
<tr><td>ReceiveDate</td><td>تاریخ و ساعت دریافت پیامک</td></tr>
<tr><td>UDH</td><td>سرآیند پیامک دریافتی</td></tr>
</table>

- [ توضیح کامل هر یک از کلمات کلیدی](https://github.com/sunwaysms/url/blob/main/Parameters.md)
- [مشاهده لیست کدهای خطا و توضیحات مربوط به هر کدام](https://github.com/sunwaysms/url/blob/main/Errors.md)

## نمونه کد

### PHP

```PHP
class SMS
{
    function get_data($Data) {
        $url = "https://sms.sunwaysms.com/smsws/HttpService?";
         $ch = curl_init();
         curl_setopt($ch, CURLOPT_URL, $url . $Data);
         curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
         curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, $timeout);
         $data = curl_exec($ch);
         curl_close($ch);
        return $data;
    }

    function GetInboxMessageWithNumber($UserName, $Password, $NumberOfMessage, $SpecialNumber) {
        $result =  $this->get_data("service=GetInboxMessageWithNumber&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberOfMessage=" . urlencode($NumberOfMessage) . "&From=" . urlencode($SpecialNumber));
        return(json_decode($result));
    }
}
```

### Java

```Java
import java.net.*;
import java.nio.charset.Charset;
import java.io.*;

import com.google.gson.*;

public class UrlAPI {

    wp-content String link = "https://sms.sunwaysms.com/smsws/HttpService?";
    wp-content Gson gson = new Gson();

    public wp-content void main(String[] args) {
        
    }

    public wp-content String getUrl(String Url) throws Exception {
        String temp = "";
        try {
            URL url = new URL(link + Url);
            // Get the response
            URLConnection urlConnection = url.openConnection();
            BufferedReader reader = new BufferedReader(new InputStreamReader(
                    urlConnection.getInputStream(), Charset.forName("UTF-8")));

            String line = "";
            while ((line = reader.readLine()) != null) {
                temp += line;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return temp;
    }

    public wp-content InboxItem[] GetInboxMessageWithNumber(String UserName,
            String Password, int NumberOfMessage, String SpecialNumber)
            throws Exception {
        String result = getUrl("service=GetInboxMessageWithNumber&UserName="
                + encode(UserName) + "&Password=" + encode(Password)
                + "&NumberOfMessage=" + encode(NumberOfMessage) + "&From="
                + encode(SpecialNumber));
        InboxItem[] inboxItems = gson.fromJson(result, InboxItem[].class);
        return inboxItems;
    }
}
```

### C#

```C#
public wp-content class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

    /// <summary>
    /// Get Inbox Message With SpecialNumber
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberOfMessage">Int Number of message</param>
    /// <param name="SpecialNumber">Your Special number ,send sms from this number</param>
    /// <returns>InboxItem</returns>
    public wp-content InboxItem[] GetInboxMessageWithNumber(string UserName, string Password, int NumberOfMessage, string SpecialNumber) {
        WebRequest request = WebRequest.Create(URL + "service=GetInboxMessageWithNumber&UserName=" + UserName + "&Password=" + Password + "&NumberOfMessage=" + NumberOfMessage + "&From=" + SpecialNumber);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<InboxItem[]>(result);
        }
    }

}
```

### VB.net

```VB
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization

Public Class API
    Const URL As String = "https://sms.sunwaysms.com/smsws/HttpService?"

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

End Class
```
