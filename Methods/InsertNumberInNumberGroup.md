# راهنمای متد InsertNumberInNumberGroup

- [راهنمای متد InsertNumberInNumberGroup](#راهنمای-متد-insertnumberinnumbergroup)
  - [پارامترهای ورودی](#پارامترهای-ورودی)
  - [خروجی Json](#خروجی-json)
  - [نکات مهم در مورد کار با متد InsertNumberInNumberGroup](#نکات-مهم-در-مورد-کار-با-متد-insertnumberinnumbergroup)
  - [نمونه کد](#نمونه-کد)
    - [PHP](#php)
    - [Java](#java)
    - [C#](#c)
    - [VB.net](#vbnet)

برای افزودن یک یا چند شماره تلفن همراه به یک گروه خاص از دفتر تلفن سامانه مدیریت پیام کوتاه خود می توانید از این متد استفاده کنید . جهت به کارگیری آن آدرس URL زیر را فراخوانی نمایید:

```
https://sms.sunwaysms.com/smsws/HttpService.ashx?service=InsertNumberInNumberGroup&username=$UserName$&password=$Password$&NumberGroupID=$NumberGroupID$&PersonNumber=$PersonNumber$&PersonName=$PersonName$
```

با توجه به جدول ذیل کلمات کلیدی این متد را مقدار دهی نمایید.

## پارامترهای ورودی

<table dir="rtl" align="center">
<tr><th>نام</th><th>نوع</th><th>اجباری / اختیاری</th><th>توضیح</th></tr>
<tr><td>UserName</td><td>String</td><td>اجباری</td><td>نام کاربری</td></tr>
<tr><td>Password</td><td>String</td><td>اجباری</td><td>کلمه عبور</td></tr>
<tr><td>NumberGroupID</td><td>String</td><td>اجباری</td><td>شناسه گروه دفتر تلفن</td></tr>
<tr><td>PersonNumber</td><td>String</td><td>اجباری</td><td>شماره افراد مورد نظر</td></tr>
<tr><td>PersonName</td><td>String</td><td>اختیاری</td><td>نام افراد مورد نظر</td></tr>
</table>

## خروجی Json

<table dir="rtl" align="center">
<tr><th>نوع</th><th>توضیح</th></tr>
<tr><td>String</td><td>آرایه ای که نشان دهنده موفقیت آمیز بودن ثبت و یا کدهای خطا می باشد</td></tr>
</table>

- [ توضیح کامل هر یک از کلمات کلیدی](https://github.com/sunwaysms/url/blob/main/Parameters.md)
- [مشاهده لیست کدهای خطا و توضیحات مربوط به هر کدام](https://github.com/sunwaysms/url/blob/main/Errors.md)

## نکات مهم در مورد کار با متد InsertNumberInNumberGroup

- فقط کاربرانی می توانند از این متد استفاده کنند که هم کاربر وب سرویس و هم کاربر سامانه مدیریت پیام کوتاه باشند.
- پارامتر PersonName اختیاری می باشد ، به این معنی که اگر قصد ارسال آن را ندارید ، هیچ مقداری به این کلید نسبت ندهید .
- اگر کلید PersonName را به متد ارسال می نمایید دقت کنید که تعداد نام های افراد موجود در این کلید با تعداد شماره ها در کلید PersonNumber برابر باشد و همچنین نام هر فرد متناظر با شماره قرار گرفته در کلید PersonNumber ارسال گردد.
- خروجی این متد یا عدد 50 می باشد که نشان دهنده موفقیت آمیز بودن روند ثبت اطلاعات هر فرد است و یا کدهای خطا می باشد که با توجه به جدول کد خطاها از نوع خطاها اطلاع حاصل نمایید .
- نام افراد در کلید PersonNumber به صورت یک رشته ارسال می شود به طوری که توسط "," از هم جدا می شوند .
- شماره های افراد در کلید PersonName به صورت یک رشته ارسال می شود به طوری که توسط "," از هم جدا می شوند .

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

    function InsertNumberInNumberGroup($UserName, $Password, $NumberGroupID, $PersonNumber, $PersonName) {
        $person = "";
        $number = "";
        
        foreach ($PersonNumber as $item) {
            $number = $number . $item . ",";
        }
        foreach ($PersonName as $item) {
            $person = $person . $item . ",";
        }
        return $this->get_data("service=InsertNumberInNumberGroup&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberGroupID=" . urlencode($NumberGroupID) . "&PersonNumber=" . urlencode(rtrim($number,",")) . "&PersonName=" . urlencode(rtrim($person,",")));
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

    public static long[] InsertNumberInNumberGroup(String UserName,
            String Password, long NumberGroupID, String[] PersonNumber,
            String[] PersonName) throws Exception {
        String person = "", number = "";
        for (String string : PersonNumber) {
            number += string + ",";
        }

        for (String string : PersonName) {
            person += string + ",";
        }

        String result = getUrl("service=InsertNumberInNumberGroup&UserName="
                + encode(UserName) + "&Password=" + encode(Password)
                + "&NumberGroupID=" + encode(NumberGroupID) + "&PersonNumber="
                + encode(rtrim(number)) + "&PersonName="
                + encode(rtrim(person)));

        return toArrayOfLong(result);
    }
}
```

### C#

```C#
public static class API {
    const string URL = "https://sms.sunwaysms.com/smsws/HttpService?";

    /// <summary>
    /// Insert Number To PhoneBook
    /// </summary>
    /// <param name="UserName">String</param>
    /// <param name="Password">String</param>
    /// <param name="NumberGroupID">long GroupID</param>
    /// <param name="PersonNumber">Array of String </param>
    /// <param name="PersonName">Array of String </param>
    /// <returns>Array of long </returns>
    public static long[] InsertNumberInNumberGroup(string UserName, string Password, long NumberGroupID, string[] PersonNumber, string[] PersonName) {
        string person = "", number = "";
        foreach (var item in PersonNumber) {
            number += item + ",";
        }
        foreach (var item in PersonName) {
            person += item + ",";
        }
        WebRequest request = WebRequest.Create(URL + "service=InsertNumberInNumberGroup&UserName=" +
            UserName + "&Password=" + Password + "&NumberGroupID=" + NumberGroupID + "&PersonNumber=" + number.TrimEnd(',') + "&PersonName=" + person.TrimEnd(','));
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
    ''' Insert Number To PhoneBook
    ''' </summary>
    ''' <param name="UserName">String</param>
    ''' <param name="Password">String</param>
    ''' <param name="NumberGroupID">long GroupID</param>
    ''' <param name="PersonNumber">Array of String </param>
    ''' <param name="PersonName">Array of String </param>
    ''' <returns>Array of long </returns>
    Public Shared Function InsertNumberInNumberGroup(UserName As String, Password As String, NumberGroupID As Long, PersonNumber As String(), PersonName As String()) As Long()
        Dim person As String = "", number As String = ""
        For Each item As String In PersonNumber
            number += item & ","
        Next
        For Each item As String In PersonName
            person += item & ","
        Next
        Dim request As WebRequest = WebRequest.Create(URL & "service=InsertNumberInNumberGroup&UserName=" & UserName & "&Password=" & Password & "&NumberGroupID=" & NumberGroupID & "&PersonNumber=" & number.TrimEnd(","c) & "&PersonName=" & person.TrimEnd(","c))
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
