# راهنمای متد GetUserInfo
<style>
.markdown-body ul ul, .markdown-body ul ol, .markdown-body ol ol, .markdown-body ol ul {
    direction: rtl;
}
.markdown-body blockquote {
    border-left: 0!important;
    border-right: 0.25em solid #d0d7de;
}
</style>
- [راهنمای متد GetUserInfo](#راهنمای-متد-getuserinfo)
  - [پارامترهای ورودی](#پارامترهای-ورودی)
  - [خروجی Json](#خروجی-json)
  - [نمونه کد](#نمونه-کد)
    - [PHP](#php)
    - [Java](#java)
    - [C#](#c)
    - [VB.net](#vbnet)

با استفاده از این متد شما می توانید به اطلاعات کاربر دسترسی پیدا کنید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=GetUserInfo&username=$UserName$&password=$Password$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

<table dir="rtl" align="center">
<tr><th>نام</th><th>نوع</th><th>اجباری / اختیاری</th><th>توضیح</th></tr>
<tr><td>UserName</td><td>String</td><td>اجباری</td><td>نام کاربری</td></tr>
<tr><td>Password</td><td>String</td><td>اجباری</td><td>کلمه عبور</td></tr>
</table>

## خروجی Json

<table dir="rtl" align="center">
<tr><th>کلید</th><th>توضیح</th></tr>
<tr><td>SMSCredit</td><td>میزان اعتبار کاربر به ریال</td></tr>
<tr><td>TotalSendSMS</td><td>تعداد پیامک های ارسالی کاربر</td></tr>
<tr><td>TotalReciveSMS</td><td>تعداد پیامک های دریافتی کاربر (شامل خوانده شده و خوانده نشده)</td></tr>
<tr><td>totalIncomeSMSField</td><td>تعداد پیامک های دریافتی کاربر (شامل خوانده نشده ها)</td></tr>
<tr><td>Notifications</td><td>عنوان اعلانات کاربر(به صورت اختصاصی برای کاربر ارسال شده است)</td></tr>
<tr><td>NotificationsDisc</td><td>متن اعلانات کاربر (به صورت اختصاصی برای کاربر ارسال شده است)</td></tr>
<tr><td>NotificationsDate</td><td>تاریخ ارسال اعلانات (به صورت اختصاصی برای کاربر ارسال شده است)</td></tr>
<tr><td>PublicNotifications</td><td>عنوان اعلانات کاربر (به صورت سراسری برای تمامی کاربران ارسال شده است)</td></tr>
<tr><td>PublicNotificationsDisc</td><td>متن اعلانات کاربر(به صورت سراسری برای تمامی کاربران ارسال شده است)</td></tr>
<tr><td>PublicNotificationsDate</td><td>تاریخ ارسال اعلانات (به صورت سراسری برای تمامی کاربران ارسال شده است)</td></tr>
<tr><td>Status</td><td>وضعیت کاربر (در بخش موارد حطا با ذکر شماره و توضیحات مربوطه آورده شده است)</td></tr>
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

    function GetUserInfo($UserName, $Password) {
        $result = $this->get_data("service=GetUserInfo&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password));
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

    public wp-content ProfileInfo GetUserInfo(String UserName, String Password)
            throws Exception {
        String result = getUrl("service=GetUserInfo&UserName="
                + encode(UserName) + "&Password=" + encode(Password));
        ProfileInfo profileInfo = gson.fromJson(result, ProfileInfo.class);
        return profileInfo;
    }
}
```

### C#

```C#
public wp-content class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

    /// <summary>
    /// Get User Info
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <returns>ProfileInfo</returns>
    public wp-content ProfileInfo GetUserInfo(string UserName, string Password) {
        WebRequest request = WebRequest.Create(URL + "service=GetUserInfo&UserName=" + UserName + "&Password=" + Password);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<ProfileInfo>(result);
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
```
