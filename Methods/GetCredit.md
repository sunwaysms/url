# راهنمای متد GetCredit

با استفاده از این متد شما می توانید از باقیمانده اعتبار پیام کوتاه خود مطلع شوید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=GetCredit&username=$UserName$&password=$Password$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

| نام | نوع | اجباری / اختیاری | توضیح |
| --- | --- | --- | --- |
| UserName | String | اجباری | نام کاربری |
| Password | String | اجباری | کلمه عبور |

## خروجی متد

| کلید | توضیح |
| --- | --- |
| String | باقیمانده اعتبار پیام کوتاه کاربر یا کد خطا |

> توجه : توضیح کامل هر یک از کلمات کلیدی این متد در انتهای راهنما آورده شده است.
> 
> توجه : لیست انواع کد خطاها و توضیحات مربوط به هرکدام در انتهای این راهنما آورده شده است.

## نکات مهم در مورد کار با متد GetCredit

- شما می توانید قبل از هر ارسال با استفاده از این متد از باقیمانده اعتبار پیام کوتاه خود مطلع شوید و در صورت کمبود اعتبار ، از ارسال پیامک ها و بروز خطا جلوگیری نمایید .

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

    function GetCredit($UserName, $Password) {
        return $this->get_data("service=GetCredit&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password));
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

    public wp-content String GetCredit(String UserName, String Password)
            throws Exception {
        return getUrl("service=GetCredit&UserName=" + encode(UserName)
                + "&Password=" + encode(Password));
    }
}
```

### C#

```C#
public wp-content class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

    /// <summary>
    /// Get Account Credit
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <returns>long Credit</returns>
    public wp-content long GetCredit(string UserName, string Password) {
        WebRequest request = WebRequest.Create(URL + "service=GetCredit&UserName=" + UserName + "&Password=" + Password);
        request.Method = "GET";
        WebResponse response = request.GetResponse();
        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            var result = reader.ReadToEnd();
            return String.IsNullOrEmpty(result) ? -1 : long.Parse(result);
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

End Class
```
