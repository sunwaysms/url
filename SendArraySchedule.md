# راهنمای متد SendArraySchedule

برای ارسال پیامک به صورت زمانبندی شده ، به یک/چند شماره از این متد استفاده کنید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=SendArraySchedule&username=$UserName$&password=$Password$&to=$RecipientNumber$&message=$MessageBody$&from=$SpecialNumber$&year=$Year$&month=$Month$&day=$Day$&hour=$Hour$&minute=$Minute$
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
| Year | Integer | اجباری | سال مورد نظر برای ارسال زمانبندی شده پیامک |
| Month | Integer | اجباری | ماه مورد نظر برای ارسال زمانبندی شده پیامک |
| Day | Integer | اجباری | روز مورد نظر برای ارسال زمانبندی شده پیامک |
| Hour | Integer | اجباری | ساعت مورد نظر برای ارسال زمانبندی شده پیامک |
| Minute | Integer | اجباری | دقیقه مورد نظر برای ارسال زمانبندی شده پیامک |

## خروجی متد

| نوع | توضیح |
| --- | --- |
| string | شناسه ارسال زمانبندی شده یا کد خطا|

> توجه : توضیح کامل هر یک از کلمات کلیدی این متد در انتهای راهنما آورده شده است.
> 
> توجه : لیست انواع کد خطاها و توضیحات مربوط به هرکدام در انتهای این راهنما آورده شده است.

## نکات مهم در مورد کار با متد SendArraySchedule

- شما می توانید با استفاده از این متد به یک یا چند شماره به صورت زمانبندی شده پیامک ارسال کنید ، به این صورت که اگر قصد ارسال تکی را دارید در کلید RecipientNumber فقط یک شماره قرار دهید و اگر قصد ارسال به بیش از یک شماره را دارید در کلید RecipientNumber می توانید تا 1000 شماره را وارد کنید .
- حتما قبل از ارسال از تکراری نبودن شماره های گیرندگان در کلید ارسالی مطمئن شوید .
- حتما تاریخ و زمان آینده را انتخاب کنید ، اگر قصد ارسال در زمان جاری را دارید ، به جای این متد از متد SendArray استفاده کنید .
- توجه کنید برخلاف متد SendArray ، خروجی این متد شناسه ارسال زمانبندی شده شما است ، به این معنی که ارسال شما هنوز در صف ارسال سیستم قرار نگرفته است و می توانید با مراجعه به سامانه مدیریت پیام کوتاه خود ، از وضعیت ارسال زمانبندی شده ( که شناسه آن را از خروجی متد SendArraySchedule دریافت کرده اید ) مطلع شوید و در صورت نیاز این ارسال را لغو کنید .
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

    function SendArraySchedule($UserName, $Password, $RecipientNumber, $Message, $SpecialNumber, $IsFlash, $Year, $Month, $Day, $Hour, $Minute) {
        $Number = "";
        foreach ($RecipientNumber as $item) {
            $Number = $Number . $item . ",";
        }
        return $this->get_data("service=SendArraySchedule&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&To=" . urlencode(rtrim($Number,",")) . "&Message=" . urlencode($Message) .
        "&From=" . urlencode($SpecialNumber) . "&Flash=" . urlencode(($IsFlash ? "true" : "false")) . "&Year=" . urlencode($Year) . "&Month=" . urlencode($Month) . "&Day=" . urlencode($Day) . "&Hour=" . urlencode($Hour) . "&Minute=" . urlencode($Minute));
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

    public wp-content long SendArraySchedule(String UserName, String Password,
            String[] RecipientNumber, String Message, String SpecialNumber,
            Boolean IsFlash, int Year, int Month, int Day, int Hour, int Minute)
            throws Exception {
        String recipientNumber = "";
        for (String item : RecipientNumber) {
            recipientNumber += item + ",";
        }

        String result = getUrl("service=SendArraySchedule&UserName="
                + encode(UserName) + "&Password=" + encode(Password) + "&To="
                + encode(rtrim(recipientNumber)) + "&Message="
                + encode(Message) + "&From=" + encode(SpecialNumber)
                + "&Flash=" + encode((IsFlash ? "true" : "false")) + "&Year="
                + encode(Year) + "&Month=" + encode(Month) + "&Day="
                + encode(Day) + "&Hour=" + encode(Hour) + "&Minute="
                + encode(Minute));

        return Long.parseLong(result);
    }
    
}
```

### C#

```C#
public wp-content class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

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
    public wp-content long SendArraySchedule(string UserName, string Password, string[] RecipientNumber, string Message, string SpecialNumber, bool IsFlash, int Year, int Month, int Day, int Hour, int Minute) {
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

End Class
```
