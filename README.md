# راهنمای استفاده از سرویس HTTP-URL سان‌وی
<style>
.markdown-body ul ul, .markdown-body ul ol, .markdown-body ol ol, .markdown-body ol ul {
    direction: rtl;
}
.markdown-body blockquote {
    border-left: 0;
    border-right: 0.25em solid var(--color-border-default);
}
</style>
- [راهنمای استفاده از سرویس HTTP-URL سان‌وی](#راهنمای-استفاده-از-سرویس-http-url-سانوی)
  - [۱. نگاه كلی](#۱-نگاه-كلی)
  - [۲. روش کار با وب سرویس](#۲-روش-کار-با-وب-سرویس)
  - [۳. توضیحات متدها](#۳-توضیحات-متدها)
  - [۴. نمونه کد و نمونه پروژه](#۴-نمونه-کد-و-نمونه-پروژه)
  - [تماس با ما](#تماس-با-ما)

## ۱. نگاه كلی

مستند حاضر برای آن دسته از برنامه‌نویسان طراحی شده که می‌خواهند به سادگی و با استفاده از فراخوانی URL به ارسال و دریافت پیامک بپردازند.

این راه کار یکی از پیشرفته ترین سرویس های ارسال و دریافت پیام کوتاه می باشد و شما می توانید با به کارگیری متدهای متنوع و کاربردی این سرویس اقدام به ارسال و دریافت SMS های فارسی و انگلیسی نمایید.

## ۲. روش کار با وب سرویس

برای استفاده از وب سرویس URL در ابتدا شما می بایست صاحب یک حساب کاربری باشید ، در صورت نداشتن حساب کاربری ،شما   می توانید با مراجعه به آدرس زیر

https://sms.sunwaysms.com/shop

سرویس مورد نظر خود را بصورت آنلاین خریداری نموده و یا باید با شرکت تماس حاصل نمایید و جهت خریداری و فعال سازی یک حساب کاربری اقدام نمایید . پس از فعال شدن حساب کاربری ، با داشتن نام کاربری ( UserName ) ، کلمه عبور ( Password ) ، یک یا چند شماره اختصاصی و اعتبار کافی پیام کوتاه شما میتوانید برای استفاده از وب سرویس به گام بعدی بروید .

## ۳. توضیحات متدها
 برای مشاهده جزئیات هر متد روی عنوان آن کلیک کنید:
 
- **[متد SendArray برای ارسال پیامک](https://github.com/sunwaysms/url/blob/main/Methods/SendArray.md)**
- **[متد SendArraySchedule برای ارسال پیامک در زمان خاص](https://github.com/sunwaysms/url/blob/main/Methods/SendArraySchedule.md)**
- **[متد GetMessageID برای بدست آوردن MessageID با استفاده از CheckingMessageID](https://github.com/sunwaysms/url/blob/main/Methods/GetMessageID.md)**
- **[متد GetMessageStatus برای دریافت وضعیت پیامک های ارسال شده](https://github.com/sunwaysms/url/blob/main/Methods/GetMessageStatus.md)**
- **[متد SendNumberGroup برای ارسال به یک/چند گروه خاص از دفتر تلفن کاربر سامانه](https://github.com/sunwaysms/url/blob/main/Methods/SendNumberGroup.md)**
- **[متد SendNumberGroupSchedule برای ارسال به یک یا چند گروه خاص از دفتر تلفن کاربر سامانه در زمان خاص](https://github.com/sunwaysms/url/blob/main/Methods/SendNumberGroupSchedule.md)**
- **[متد GetNumberGroupData برای دریافت اطلاعات گروه های موجود در دفتر تلفن کاربر سامانه](https://github.com/sunwaysms/url/blob/main/Methods/GetNumberGroupData.md)**
- **[متد InsertNumberInNumberGroup برای افزودن شماره تلفن همراه افراد به گروه خاص از دفتر تلفن کاربر سامانه](https://github.com/sunwaysms/url/blob/main/Methods/InsertNumberInNumberGroup.md)**
- **[متد GetInboxMessage برای دریافت تعدادی از پیامک های ورودی در روز اخیر](https://github.com/sunwaysms/url/blob/main/Methods/GetInboxMessage.md)**
- **[متد GetInboxMessageWithNumber برای دریافت تعدادی از پیامک های ورودی به شماره خاص در روز اخیر](https://github.com/sunwaysms/url/blob/main/Methods/GetInboxMessageWithNumber.md)**
- **[متد GetInboxMessageWithInboxID برای دریافت لیستی از پیامک های ورودی با ارسال شناسه اولین پیامک بازه دریافتی](https://github.com/sunwaysms/url/blob/main/Methods/GetInboxMessageWithInboxID.md)**
- **[متد GetCredit برای اطلاع از میزان اعتبار پیام کوتاه](https://github.com/sunwaysms/url/blob/main/Methods/GetCredit.md)**
- **[متد GetUserInfo برای دریافت اطلاعات کاربر](https://github.com/sunwaysms/url/blob/main/Methods/GetUserInfo.md)**

## ۴. نمونه کد و نمونه پروژه

برای آشنایی هرچه بهتر نحوه کار هریک از متدهای فوق شما می توانید از نمونه کدهای زبان‌های مختلف، نوشته شده توسط تیم فنی در انتهای هر متد و همچنین نمونه پروژه‌های آماده در پوشه SampleProjects استفاده نمایید.

## تماس با ما

در صورت نیاز به اطلاعات بیشتر ، می توانید با واحد پشتیبانی تماس حاصل فرمایید

تلفن های واحد پشتیبانی:

90007197<br>
021-91007197<br>
026-34233032<br>
026-34233045<br>
026-34233049

همچنین میتوانید موارد خود را از طریق بخش تیکت که در سامانه شما موجود می باشد برای کارشناسان ما ارسال کرده و یا از راه های ارتباطی زیر با ما در ارتباط باشید :

ایمیل: support@sunwaysms.com

ارسال فایل: 09334485858 ( در واتس اپ و تلگرام )