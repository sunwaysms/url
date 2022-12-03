# راهنمای متد GetMessageStatus

برای اطلاع از وضعیت پیامک های ارسال شده از این متد استفاده کنید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=GetMessageStatus&username=$UserName$&password=$Password$&MessageID=$MessageID$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

| نام | نوع | اجباری / اختیاری | توضیح |
| --- | --- | --- | --- |
| UserName | String | اجباری | نام کاربری |
| Password | String | اجباری | کلمه عبور |
| MessageID | String | شناسه پیامک |

## خروجی متد

| نوع | توضیح |
| --- | --- |
| string | شامل وضعیت پیامک تا این لحظه و یا کد خطا |

> توجه : توضیح کامل هر یک از کلمات کلیدی این متد در انتهای راهنما آورده شده است.
> 
> توجه : لیست انواع کد خطاها و توضیحات مربوط به هرکدام در انتهای این راهنما آورده شده است.

## نکات مهم در مورد کار با متد GetMessageStatus

- شما با استفاده از شناسه پیامک ( MessageID که خروجی متد SendArray یا GetMessageID می باشد ) به عنوان کلید متد GetMessageStatus ، می توانید از وضعیت پیامک ارسال شده مطلع شوید .
- شناسه های پیامک در کلید MessageID به صورت یک رشته ارسال می شود به طوری که توسط "," از هم جدا می شوند.
- خروجی این متد یک رشته شامل وضعیت پیامک ارسالی است که توسط "," از هم جدا شده اند . در صورت بروز خطا شماره خطا برگردانده می شود . دقت کنید که وضعیت پیامک یک عدد کوچکتر از 50 می باشد ، در غیر این صورت مقدار بازگشتی نشان دهنده یک کد خطا می باشد . کد و توضیحات مربوط به وضعیت پیامک در جدول ذیل ذکر شده است:

## وضعیت پیامک های ارسال شده

| کد | توضیح |
| --- | --- |
| 0 | شناسه پیامک نامعتبر است ( یا ممکن است شناسه پیامک ارسال شده مربوط به پیامکی باشد که بیش از یک ماه از ارسال آن می گذرد )<br/>وضعیت این پیامک را مجددا بررسی نفرمایید زیرا تغییری در وضعیت آن حاصل نمی شود |
| 1 | هنوز وضعیتی دریافت نشده است ، سیستم در حال پیگیری وضعیت پیامک از مخابرات است<br/>می توانید وضعیت این پیامک را مجددا بررسی فرمایید زیرا تغییر خواهد کرد |
| 2 | پیامک به موبایل گیرنده رسیده است<br/>وضعیت این پیامک را مجددا بررسی نفرمایید زیرا تغییری در وضعیت آن حاصل نمی شود |
| 3 | پیامک به موبایل گیرنده نرسیده است ، به یکی از دلایل ذیل :<br/>۱. پر بودن Inbox موبایل گیرنده پیام<br/>۲. خاموش بودن موبایل گیرنده پیام<br/>۳. در دسترس نبودن موبایل گیرنده پیام<br/>۴. اختلال در شبکه BTS<br/>وضعیت این پیامک را مجددا بررسی نفرمایید زیرا تغییری در وضعیت آن حاصل نمی شود |
| 4 | پیامک به مرکز مخابراتی رسیده است ( در صف ارسال مخابرات قرار گرفته است و بزودی به موبایل گیرنده ارسال می گردد )<br/>می توانید وضعیت این پیامک را مجددا بررسی فرمایید زیرا تغییر خواهد کرد |
| 5 | پیامک به مرکز مخابراتی نرسیده است ( این وضعیت زمانی رخ می دهد که مرکز مخابراتی نتواند به اپراتور تلفن همراه شماره گیرنده ، پیامک ارسال کند )<br/>وضعیت این پیامک را مجددا بررسی نفرمایید زیرا تغییری در وضعیت آن حاصل نمی شود |
| 6 | شماره موبایل گیرنده پیامک به درخواست کاربر در لیست غیر فعال مخابرات قرار گرفته است<br/>هزینه این ارسال به کاربر برگردانده می شود<br/>وضعیت این پیامک را مجددا بررسی نفرمایید زیرا تغییری در وضعیت آن حاصل نمی شود |
| 7 | پیامک در صف ارسال قرار دارد ( سرور هنوز شروع به ارسال پیامک نکرده است )<br/>می توانید وضعیت این پیامک را مجددا بررسی فرمایید زیرا تغییر خواهد کرد |
| 8 | سرور در حال ارسال پیامک می باشد<br/>می توانید وضعیت این پیامک را مجددا بررسی فرمایید زیرا تغییر خواهد کرد |
| 9 | در زمان ارسال به علت کمبود اعتبار پیام کوتاه ، این پیامک ارسال نشده است<br/>وضعیت این پیامک را مجددا بررسی نفرمایید زیرا تغییری در وضعیت آن حاصل نمی شود |
| 10 | پیامک ارسال نشده است ( به دلیل اختلالات ارتباطی پیامک ارسال نشده است اما سرور به مدت 2 ساعت تلاش به ارسال مجدد این پیامک می کند و اگر طی این 2 ساعت نتواند پیامک را ارسال کند ، هزینه آن را به کاربر برمی گرداند<br/>می توانید وضعیت این پیامک را مجددا بررسی فرمایید زیرا تغییر خواهد کرد |
| 11 | پیامک هنوز توسط اپراتور تأیید نشده است<br/>می توانید وضعیت این پیامک را مجددا بررسی فرمایید زیرا تغییر خواهد کرد |
| 12 | پیامک در لیست کنسل شده یا فیلتر شده قرار دارد<br/>وضعیت این پیامک را مجددا بررسی نفرمایید زیرا تغییری در وضعیت آن حاصل نمی شود |

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

    function GetMessageStatus($UserName, $Password, $MessageID) {
        $message = "";
        foreach ($MessageID as $item) {
            $message = $message . $item . ",";
        }
        return $this->get_data("service=GetMessageStatus&UserName=" . urlencode($UserName) . "&Password=" .  urlencode($Password) . "&MessageID=" .  urlencode(rtrim($message,",")));
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

    public wp-content long[] GetMessageStatus(String UserName, String Password,
            long[] MessageID) throws Exception {
        String messageID = "";
        for (long item : MessageID) {
            messageID += item + ",";
        }

        String result = getUrl("service=GetMessageStatus&UserName="
                + encode(UserName) + "&Password=" + encode(Password)
                + "&MessageID=" + encode(rtrim(messageID)));
        return toArrayOfLong(result);
    }
}
```

### C#

```C#
public wp-content class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

    /// <summary>
    /// Get Message Status
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="MessageID">long[] MessageIDs</param>
    /// <returns></returns>
    public wp-content long[] GetMessageStatus(string UserName, string Password, long[] MessageID) {
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

End Class
```