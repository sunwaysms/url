# راهنمای متد GetMessageID

- [راهنمای متد GetMessageID](#راهنمای-متد-getmessageid)
  - [پارامترهای ورودی](#پارامترهای-ورودی)
  - [خروجی متد](#خروجی-متد)
  - [نکات مهم در مورد کار با متد GetMessageID](#نکات-مهم-در-مورد-کار-با-متد-getmessageid)
  - [نمونه کد](#نمونه-کد)
    - [PHP](#php)
    - [Java](#java)
    - [C#](#c)
    - [VB.net](#vbnet)

در مواقع خاص ( قطع شدن ارتباط با سرور ، از کار افتادن سیستم کاربر ، بروز خطا و ... ) ، می توانید با استفاده از این متد و فرستادن شناسه های منحصر بفرد پیامک در سمت Application خودتان ( CheckingMessageID ) از شناسه پیام کوتاه سمت سرور ( MessageID ) مطلع شوید و با فرستادن آن به متد GetMessageStatus از وضعیت پیامک خود اطمینان حاصل کنید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=GetMessageID&username=$UserName$&password=$Password$&chkMessageId=$CheckingMessageID$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

<table dir="rtl" align="center">
<tr><th>نام</th><th>نوع</th><th>اجباری / اختیاری</th><th>توضیح</th></tr>
<tr><td>UserName</td><td>String</td><td>اجباری</td><td>نام کاربری</td></tr>
<tr><td>Password</td><td>String</td><td>اجباری</td><td>کلمه عبور</td></tr>
<tr><td>CheckingMessageID</td><td>String</td><td>اجباری</td><td>شناسه پیامک کاربر</td></tr>
</table>

## خروجی متد

<table dir="rtl" align="center">
<tr><th>نوع</th><th>توضیح</th></tr>
<tr><td>string</td><td>شناسه پیامک یا کد خطا</td></tr>
</table>

- [ توضیح کامل هر یک از کلمات کلیدی](https://github.com/sunwaysms/url/blob/main/Parameters.md)
- [مشاهده لیست کدهای خطا و توضیحات مربوط به هر کدام](https://github.com/sunwaysms/url/blob/main/Errors.md)

## نکات مهم در مورد کار با متد GetMessageID

- در هنگام ارسال CheckingMessageID به متد SendArray از منحصر به فرد بودن آن در سمت Application خودتان اطمینان حاصل کنید ، زیرا در غیر این صورت در هنگام استفاده از متد GetMessageID اطلاعات اشتباه بدست می آورید .
- در خروجی این متد اگر یک عدد بزرگتر از 1000 به شما بازگشت داده شد به معنی شناسه پیامک ( MessageID ) می باشد و در غیر این صورت نشان دهنده یک کد خطا می باشد ، که معمولا کد خطای "شناسه کاربری شما ( CheckingMessageID ) نامعتبر است" به شما بازگشت داده می شود که ، به این معنی که این پیام ارسال نگشته است یا شناسه پیامک ارسال شده مربوط به پیامکی می باشد که بیش از یک ماه از ارسال آن می گذرد .
- شناسه های منحصر بفرد پیامک در کلید CheckingMessageID به صورت یک رشته ارسال می شود به طوری که توسط "," از هم جدا می شوند .
- خروجی این متد یک رشته شامل شناسه ( MessageID ) پیامک ها است که توسط "," از هم جدا شده اند . در صورت بروز خطا شماره خطا برگردانده می شود .

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

    function GetMessageID($UserName, $Password, $CheckingMessageID) {
        $chkMessageID = "";
        foreach ($CheckingMessageID as $item) {
            $chkMessageID = $chkMessageID . $item . ",";
        }
        return $this->get_data("service=GetMessageID&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&chkMessageId=" . urlencode(rtrim($chkMessageID,",")));
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

    static String link = "https://sms.sunwaysms.com/smsws/HttpService?";
    static Gson gson = new Gson();

    public static void main(String[] args) {
        
    }

    public static String getUrl(String Url) throws Exception {
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

    public static long[] GetMessageID(String UserName, String Password,
            long[] CheckingMessageID) throws Exception {
        String checkingMessageID = "";
        for (long item : CheckingMessageID) {
            checkingMessageID += item + ",";
        }

        String result = getUrl("service=GetMessageID&UserName="
                + encode(UserName) + "&Password=" + encode(Password)
                + "&chkMessageId=" + encode(rtrim(checkingMessageID)));

        return toArrayOfLong(result);
    }
    
}
```

### C#

```C#
public static class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

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


End Class
```
