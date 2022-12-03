# راهنمای متد SendArray

برای ارسال پیامک ، به یک/چند شماره از این متد استفاده کنید . با توجه به جدول ذیل پارامتر های این متد را مقدار دهی کنید . خروجی این متد شناسه پیامک های ارسال شده است که مقدار آن به صورت یک آرایه از اعداد بزرگتر از 1000 می باشد ، اگر مقدار عدد بازگشتی کمتر از 1000 باشد به معنی بروز خطا در ارسال است . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=SendArray&username=$UserName$&password=$Password$&to=$RecipientNumber$&message=$MessageBody$&from=$SpecialNumber&$chkMessageId=$CheckingMessageID$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

| نام | نوع | اجباری / اختیاری | توضیح |
| --- | --- | --- | --- |
| UserName | String | اجباری | نام کاربری |
| Password | String | اجباری | کلمه عبور |
| RecipientNumber | String | اجباری | شماره گیرنده ویا گیرندگان ( شماره تلفن همراه مقصد ) |
| MessageBody | String | اجباری | متن پیامک |
| SpecialNumber | String | اجباری | شماره اختصاصی ( شماره فرستنده پیامک ) |
| ~~IsFlashMessage~~ | ~~Boolean~~ | ~~اجباری~~ | ~~آیا ارسال به صورت Flash انجام شود~~ |
| CheckingMessageID | String | اختیاری | شناسه پیامک کاربر |

## خروجی متد

| نوع | توضیح |
| --- | --- |
| string | شامل شناسه پیامک یا کد خطا |

> توجه : توضیح کامل هر یک از کلمات کلیدی این متد در انتهای راهنما آورده شده است.
> 
> توجه : لیست انواع کد خطاها و توضیحات مربوط به هرکدام در انتهای این راهنما آورده شده است.

## نکات مهم در مورد کار با متد SendArray

- شما می توانید با استفاده از این متد به یک یا چند شماره پیامک ارسال کنید ، به این صورت که اگر قصد ارسال تکی را دارید در کلید RecipientNumber فقط یک شماره قرار دهید و اگر قصد ارسال به بیش از یک شماره را دارید در کلید RecipientNumber می توانید تا 1000 شماره را وارد کنید .
- حتما قبل از ارسال از تکراری نبودن شماره های گیرندگان در آرایه ارسالی مطمئن شوید .
- شما می توانید برای اطمینان از ارسال شدن پیامک های خود ، از کلید CheckingMessageID استفاده کنید . نحوه کار با کلید CheckingMessageID به این صورت می باشد که درهنگام استفاده از متد SendArray ، به همراه کلید RecipientNumber و به همان تعداد شماره های داخل آن ، شناسه های منحصر بفرد پیامک در سمت Application خودتان را در کلید CheckingMessageID قرار دهید و در هنگام بروز خطا ، قطع شدن ارتباط با سرور و ... ، مقادیر CheckingMessageID که قبلا در متد ارسال قرار داده اید را به GetMessageID بفرستید و مقدار MessageID متناظر در سرور را بدست آورید ، و در نهایت با استفاده از متد GetMessageStatus از وضعیت آن پیام ها مطلع گردید.
- شماره های گیرنده در کلیدRecipientNumber به صورت یک رشته ارسال می شود به طوری که توسط "," از هم جدا می شوند.
- شناسه های منحصر بفرد پیامک در کلید CheckingMessageID به صورت یک رشته ارسال می شود به طوری که توسط "," از هم جدا می شوند.
- خروجی این متد یک رشته شامل شناسه پیامک ها است که توسط "," از هم جدا شده اند . در صورت بروز خطا شماره خطا برگردانده می شود.

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
    
    function SendArray($UserName, $Password, $RecipientNumber, $Message, $SpecialNumber, $IsFlash, $CheckingMessageID) {
        $Number = "";
        $chkMessageID = "";
        foreach ($RecipientNumber as $item) {
            $Number = $Number . $item . ",";
        }

        foreach ($CheckingMessageID as $item) {
            $chkMessageID = $chkMessageID . $item . ",";
        }

         return $this->get_data("service=SendArray&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&To=" . urlencode(rtrim($Number,",")) . "&Message=" . urlencode($Message) .
         "&From=" . urlencode($SpecialNumber) . "&Flash=" . urlencode(($IsFlash ? "true" : "false")) . "&chkMessageId=" . urlencode(rtrim($chkMessageID,",")));
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

    public wp-content long[] SendArray(String UserName, String Password,
            String[] RecipientNumber, String Message, String SpecialNumber,
            Boolean IsFlash, long[] CheckingMessageID) throws Exception {
        String recipientNumber = "", checkingMessageID = "";

        for (String item : RecipientNumber) {
            recipientNumber += item + ",";
        }
        for (long item : CheckingMessageID) {
            checkingMessageID += item + ",";
        }

        String result = getUrl("service=SendArray&UserName=" + encode(UserName)
                + "&Password=" + encode(Password) + "&To="
                + encode(rtrim(recipientNumber)) + "&Message="
                + encode(Message) + "&From=" + encode(SpecialNumber)
                + "&Flash=" + encode((IsFlash ? "true" : "false"))
                + "&chkMessageId=" + encode(rtrim(checkingMessageID)));

        return toArrayOfLong(result);
    }
}
```

### C#

```C#
public wp-content class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

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
    public wp-content long[] SendArray(string UserName, string Password, string[] RecipientNumber, string Message, string SpecialNumber, bool IsFlash, long[] CheckingMessageID) {
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

End Class
```
