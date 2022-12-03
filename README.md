# راهنمای استفاده از سرویس HTTP-URL سان‌وی

# ۱. نگاه كلی

مستند حاضر برای آن دسته از برنامه‌نويسان طراحی شده که می‌خواهند به سادگی و با استفاده از فراخوانی URL به ارسال و دريافت پيامک بپردازند.

این راه کار یکی از پیشرفته ترین سرویس های ارسال و دریافت پیام کوتاه می باشد و شما می توانید با به کارگیری متدهای متنوع و کاربردی این سرویس اقدام به ارسال و دریافت SMS های فارسی و انگلیسی نمایید.

# ۲. روش کار با وب سرویس

برای استفاده از وب سرویس URL در ابتدا شما می بایست صاحب یک حساب کاربری باشید ، در صورت نداشتن حساب کاربری ،شما   می توانید با مراجعه به آدرس زیر

https://sms.sunwaysms.com/shop

سرویس مورد نظر خود را بصورت آنلاین خریداری نموده و یا باید با شرکت تماس حاصل نمایید و جهت خریداری و فعال سازی یک حساب کاربری اقدام نمایید . پس از فعال شدن حساب کاربری ، با داشتن نام کاربری ( UserName ) ، کلمه عبور ( Password ) ، یک یا چند شماره اختصاصی و اعتبار کافی پیام کوتاه شما میتوانید برای استفاده از وب سرویس به گام بعدی بروید .

 ذیل توضیح مختصر در مورد هریک از متدها آمده است:
 
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

> توجه : برای آشنایی هرچه بهتر نحوه کار هریک از متدهای فوق شما می توانید از نمونه کد های نوشته شده توسط تیم فنی استفاده نمایید.
