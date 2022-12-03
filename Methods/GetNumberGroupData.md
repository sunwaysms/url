# راهنمای متد GetNumberGroupData
<style>
.markdown-body ul ul, .markdown-body ul ol, .markdown-body ol ol, .markdown-body ol ul {
    direction: rtl;
}
.markdown-body blockquote {
    border-left: 0;
    border-right: 0.25em solid var(--color-border-default);
}
</style>
- [راهنمای متد GetNumberGroupData](#راهنمای-متد-getnumbergroupdata)
  - [پارامترهای ورودی](#پارامترهای-ورودی)
  - [خروجی Json](#خروجی-json)
  - [نکات مهم در مورد کار با متد GetNumberGroupData](#نکات-مهم-در-مورد-کار-با-متد-getnumbergroupdata)
  - [نمونه کد](#نمونه-کد)
    - [PHP](#php)
    - [Java](#java)
    - [C#](#c)
    - [VB.net](#vbnet)

برای دریافت اطلاعات گروه های موجود در دفتر تلفن سامانه مدیریت ارسال و دریافت پیام کوتاه خود از این متد استفاده نمایید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید :

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=GetNumberGroupData&username=$UserName$&Password=$Password$
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
<tr><td>NumberGroupID</td><td>شناسه گروه شماره ها دفتر تلفن</td></tr>
<tr><td>NumberCount</td><td>تعداد شماره های موجود در گروه</td></tr>
<tr><td>FarsiName</td><td>نام فارسی گروه</td></tr>
<tr><td>EnglishName</td><td>نام انگلیسی گروه</td></tr>
<tr><td>Priority</td><td>اولویت تعیین شده برای گروه توسط کاربر</td></tr>
</table>

- [ توضیح کامل هر یک از کلمات کلیدی](https://github.com/sunwaysms/url/blob/main/Parameters.md)
- [مشاهده لیست کدهای خطا و توضیحات مربوط به هر کدام](https://github.com/sunwaysms/url/blob/main/Errors.md)

## نکات مهم در مورد کار با متد GetNumberGroupData

- فقط کاربرانی می توانند از این متد استفاده کنند که هم کاربر وب سرویس و هم کاربر سامانه مدیریت پیام کوتاه باشند.
- دقت کنید که خروجی این متد اطلاعات گروه دفتر تلفن شما است ، که با استفاده از این اطلاعات و متد SendNumberGroup یا SendNumberGroupSchedule می توانید پیام گروهی ارسال کنید .

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

    function GetNumberGroupData($UserName, $Password) {
        $result = $this->get_data("service=GetNumberGroupData&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password));
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

    public wp-content NumberGroupItem[] GetNumberGroupData(String UserName,
            String Password) throws Exception {
        String result = getUrl("service=GetNumberGroupData&UserName="
                + encode(UserName) + "&Password=" + encode(Password));
        NumberGroupItem[] groupItems = gson.fromJson(result,
                NumberGroupItem[].class);
        return groupItems;
    }
}
```

### C#

```C#
public wp-content class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

    /// <summary>
    /// Get Number Group Data
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <returns>NumberGroupItem</returns>
    public wp-content NumberGroupItem[] GetNumberGroupData(string UserName, string Password) {
        WebRequest request = WebRequest.Create(URL + "service=GetNumberGroupData&UserName=" + UserName + "&Password=" + Password);
        request.Method = "GET";
        WebResponse response = request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<NumberGroupItem[]>(result);
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
    
End Class
```
