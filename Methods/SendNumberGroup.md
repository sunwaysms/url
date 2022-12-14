# راهنمای متد SendNumberGroup

- [راهنمای متد SendNumberGroup](#راهنمای-متد-sendnumbergroup)
  - [پارامترهای ورودی](#پارامترهای-ورودی)
  - [خروجی متد](#خروجی-متد)
  - [نکات مهم در مورد کار با متد SendNumberGroup](#نکات-مهم-در-مورد-کار-با-متد-sendnumbergroup)
  - [نمونه کد](#نمونه-کد)
    - [PHP](#php)
    - [Java](#java)
    - [C#](#c)
    - [VB.net](#vbnet)

برای ارسال پیامک به یک یا چند گروه خاص از دفتر تلفن موجود در سامانه مدیریت پیام کوتاه خود از این متد استفاده کنید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=SendNumberGroup&username=$UserName$&password=$Password$&NumberGroupID=$NumberGroupID$&message=$MessageBody$&from=$SpecialNumber$&DontSendRepeat=$DontSendToRepeatedNumber$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

<table dir="rtl" align="center">
<tr><th>نام</th><th>نوع</th><th>اجباری / اختیاری</th><th>توضیح</th></tr>
<tr><td>UserName</td><td>String</td><td>اجباری</td><td>نام کاربری</td></tr>
<tr><td>Password</td><td>String</td><td>اجباری</td><td>کلمه عبور</td></tr>
<tr><td>NumberGroupID</td><td>String</td><td>اجباری</td><td>شناسه گروه دفتر تلفن</td></tr>
<tr><td>MessageBody</td><td>String</td><td>اجباری</td><td>متن پیامک</td></tr>
<tr><td>SpecialNumber</td><td>String</td><td>اجباری</td><td>شماره اختصاصی</td></tr>
<tr><td><s>IsFlashMessage</s></td><td><s>Boolean</s></td><td><s>اجباری</s></td><td><s>آیا ارسال به صورت Flash انجام شود</s></td></tr>
<tr><td>DontSendToRepeatedNumber</td><td>Boolean</td><td>اجباری</td><td>به شماره های تکراری ارسال نشود؟</td></tr>
</table>

## خروجی متد

<table dir="rtl" align="center">
<tr><th>نوع</th><th>توضیح</th></tr>
<tr><td>string</td><td>کد رهگیری ارسال یا کد خطا</td></tr>
</table>

- [ توضیح کامل هر یک از کلمات کلیدی](https://github.com/sunwaysms/url/blob/main/Parameters.md)
- [مشاهده لیست کدهای خطا و توضیحات مربوط به هر کدام](https://github.com/sunwaysms/url/blob/main/Errors.md)

## نکات مهم در مورد کار با متد SendNumberGroup

- فقط کاربرانی می توانند از این متد استفاده کنند که هم کاربر وب سرویس و هم کاربر سامانه مدیریت پیام کوتاه باشند.
- مقدار خروجی این متد کد رهگیری ارسال می باشد ، که با مراجعه به سامانه مدیریت پیام کوتاه خود می توانید در لیست پیام های ارسال شده از وضعیت ارسال پیامک های خود مطلع شوید .
- شما می توانید در شناسه گروه دفتر تلفن ( NumberGroupID ) ، به یک یا چند گروه ( حداکثر 1000 گروه ) پیامک ارسال کنید .
- قبل از ارسال حتما باید با استفاده از متد GetNumberGroupData از شناسه گروه دفتر تلفن (NumberGroupID) آگاه شوید ، و مطمئن شوید گروه یا گروه های مورد نظر شما حذف نشده باشند و شناسه آن ها معتبر باشد .
- شناسه های گروه ها در کلید NumberGroupID به صورت یک رشته ارسال می شود به طوری که توسط "," از هم جدا می شوند .

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

    function SendNumberGroup($UserName, $Password, $NumberGroupID, $Message, $SpecialNumber, $IsFlash, $DontSendToRepeatedNumber) {
        $number = "";
        foreach ($NumberGroupID as $item) {
            $number = $number . $item . ",";
        }
        return $this->get_data("service=SendNumberGroup&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberGroupID=" . urlencode(rtrim($number,",")) . "&Message=" . urlencode($Message) .
        "&From=" . urlencode($SpecialNumber) . "&Flash=" . urlencode(($IsFlash ? "true" : "false")) . "&DontSendRepeat=" . urlencode(($DontSendToRepeatedNumber ? "true" : "false")));
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

    public static long SendNumberGroup(String UserName, String Password,
            long[] NumberGroupID, String Message, String SpecialNumber,
            Boolean IsFlash, Boolean DontSendToRepeatedNumber) throws Exception {
        String numberGroupID = "";
        for (long item : NumberGroupID) {
            numberGroupID += item + ",";
        }

        String result = getUrl("service=SendNumberGroup&UserName="
                + encode(UserName) + "&Password=" + encode(Password)
                + "&NumberGroupID=" + encode(rtrim(numberGroupID))
                + "&Message=" + encode(Message) + "&From="
                + encode(SpecialNumber) + "&Flash="
                + encode((IsFlash ? "true" : "false")) + "&DontSendRepeat="
                + encode((DontSendToRepeatedNumber ? "true" : "false")));

        return Long.parseLong(result);
    }
}
```

### C#

```C#
public static class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

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

End Class
```
