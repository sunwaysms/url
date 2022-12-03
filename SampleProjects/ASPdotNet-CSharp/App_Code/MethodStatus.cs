using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class MethodStatus {
    public enum Status {
        /// <summary>
        /// کد معتبر نیست 0
        /// </summary>
        MessageIDIsInvalid = 0,
        /// <summary>
        /// بروز رسانی کنید 1
        /// </summary>
        PendingStatus = 1,
        /// <summary>
        /// رسیده به گوشی 2
        /// </summary>
        DeliveredToPhone = 2,
        /// <summary>
        /// نرسیده به گوشی 3
        /// </summary>
        FailedToPhone = 3,
        /// <summary>
        /// رسیده به مخابرات 4
        /// </summary>
        DeliveredToServiceCenter = 4,
        /// <summary>
        /// نرسیده به مخابرات 5
        /// </summary>
        FailedToServiceCenter = 5,
        /// <summary>
        /// در لیست غیر فعال مخابرات 6
        /// </summary>
        InDisableList = 6,
        /// <summary>
        /// در صف ارسال 7
        /// </summary>
        InSendQueue = 7,
        /// <summary>
        /// در حال ارسال 8
        /// </summary>
        Sending = 8,
        /// <summary>
        /// کمبود اعتبار 9
        /// </summary>
        LowCredit = 9,
        /// <summary>
        /// ارسال نشده 10
        /// </summary>
        NotSent = 10,
        /// <summary>
        /// منتظر تایید توسط اپراتور 11
        /// </summary>
        WaitingForAccept = 11,
        /// <summary>
        /// کنسل شده/فیلتر شده 12
        /// </summary>
        CancelOrFilter = 12,
        /// <summary>
        /// با موفقیت  50
        /// </summary>
        Successful = 50,
        /// <summary>
        /// نام کاربری و یا رمز عبور اشتباه می باشد 51
        /// </summary>
        UserNameOrPasswordIsWrong = 51,
        /// <summary>
        /// نام کاربری و یا رمز عبور خالی می باشد 52
        /// </summary>
        UserNameOrPasswordIsEmpty = 52,
        /// <summary>
        /// طول شماره های دریافتی بیش از حد معمول می باشد  53
        /// </summary>
        RecipientNumberLengthIsMoreThanUsual = 53,
        /// <summary>
        /// شماره های ارسال خالی می باشند 54
        /// </summary>
        RecipientNumberIsEmpty = 54,
        /// <summary>
        /// شماره های ارسال تهی می باشند 55
        /// </summary>
        RecipientNumberIsNull = 55,
        /// <summary>
        /// طول آی دی پیام ها بیشتر از حد معمول می باشد 56
        /// </summary>
        MessageIDLengthIsMoreThanUsual = 56,
        /// <summary>
        /// آی دی پیام ها خالی می باشند 57
        /// </summary>
        MessageIDIsEmpty = 57,
        /// <summary>
        /// آی دی پیام ها تهی می باشند 58
        /// </summary>
        MessageIDIsNull = 58,
        /// <summary>
        /// متن پیام خالی می باشد 59
        /// </summary>
        MessageBodyIsEmpty = 59,
        /// <summary>
        /// در حال حاضر سرویس قادر به پاسخگویی نمی باشد 60
        /// </summary>
        InThisTimeServerCannotRespond = 60,
        /// <summary>
        /// شماره خط اختصاصی نامعتبر می باشد 61
        /// </summary>
        SpecialNumberIsInvalid = 61,
        /// <summary>
        /// شماره خط اختصاصی خالی می باشد 62
        /// </summary>
        SpecialNumberIsEmpty = 62,
        /// <summary>
        /// آی پی نامعتبر می باشد 63
        /// </summary>
        ThisIPIsInvalid = 63,
        /// <summary>
        /// شماره wsid نا معتبر می باشد 64
        /// </summary>
        WSIDIsWrong = 64,
        /// <summary>
        /// تعداد پیام ها صحیح نمی باشد 65
        /// </summary>
        NumberOfMessageIsWrong = 65,
        /// <summary>
        /// تعداد آی دی ها با تعداد شمارها یکسان نمی باشد 66
        /// </summary>
        CheckingMessageIDLengthIsNotEqualWithRecipientNumberLength = 66,
        /// <summary>
        /// طول آی دی ها بیشتر از حد معمول می باشد 67
        /// </summary>
        CheckingMessageIDLengthIsMoreThanUsual = 67,
        /// <summary>
        /// آی دی خالی می باشد 68
        /// </summary>
        CheckingMessageIDIsEmpty = 68,
        /// <summary>
        /// آی دی تهی می باشد 69
        /// </summary>
        CheckingMessageIDIsNull = 69,
        /// <summary>
        /// کاربر شما غیر فعال می باشد 70
        /// </summary>
        YourUserIsInActive = 70,
        /// <summary>
        /// دامنه نامعتبر می باشد 71
        /// </summary>
        DomainIsInvalid = 71,
        /// <summary>
        /// ساعت دریافتی اشتباه می باشد 72
        /// </summary>
        TimeIsWrong = 72,
        /// <summary>
        /// تاریخ دریافتی اشتباه می باشد 73
        /// </summary>
        DateIsWrong = 73,
        /// <summary>
        /// تعداد آی دی گروه ها بیشتر از حد مجاز می باشد 74
        /// </summary>
        NumberGroupIDLengthIsMoreThanUsual = 74,
        /// <summary>
        /// آی دی گروه ها خالی می باشد 75
        /// </summary>
        NumberGroupIDIsEmpty = 75,
        /// <summary>
        /// آی دی گروه ها تهی می باشد 76
        /// </summary>
        NumberGroupIDIsNull = 76,
        /// <summary>
        /// شما کاربر وب سرویس نمی باشید 77
        /// </summary>
        YouAreNotWebServiceUser = 77,
        /// <summary>
        /// شما کاربر پنل نمی باشید 78
        /// </summary>
        YouAreNotSMSPanelUser = 78,
        /// <summary>
        /// تعداد نام ها با تعداد شماره ها برابر نمی باشد 79
        /// </summary>
        PersonNameLengthIsNotEqualWithPersonNumberLength = 79,
        /// <summary>
        /// سرویس غیر فعال می باشد 80
        /// </summary>
        ServiceIsInActive = 80,
        /// <summary>
        /// طول نام ها بیشتر از حد مجاز می باشد 81
        /// </summary>
        PersonNumberLengthIsMoreThanUsual = 81,
        /// <summary>
        /// نام خالی می باشد 82
        /// </summary>
        PersonNumberIsEmpty = 82,
        /// <summary>
        /// نام تهی می باشد 83
        /// </summary>
        PersonNumberIsNull = 83,
        /// <summary>
        /// آی دی گروه نامعتبر می باشد 84
        /// </summary>
        NumberGroupIDIsInvalid = 84,
        /// <summary>
        /// فرمت شماره نامعتبر می باشد 201
        /// </summary>
        RecipientNumberFormatIsWrong = 201,
        /// <summary>
        /// اپراتور شماره نامعتبر می باشد 202
        /// </summary>
        RecipientNumberOperatorIsInvalid = 202,
        /// <summary>
        /// عدم ارسال پیام به دلیل کمبود اعتبار 203
        /// </summary>
        YouCanNotSendThisBecauseYourCreditIsNotEnough = 203,
        /// <summary> 
        /// آی دی نامعتبر می باشد 204
        /// </summary>
        CheckingMessageIDIsNotValid = 204,
        /// <summary>
        /// فرمت شماره نا معتبر می باشد 205
        /// </summary>
        PersonNumberFormatIsWrong = 205,
        /// <summary>
        /// اپراتور شماره نامعتبر می باشد 206
        /// </summary>
        PersonNumberOperatorIsInvalid = 206,
        /// <summary>
        /// عنوان انگلیسی گروه نامعتبر می باشد 207
        /// </summary>
        GroupEnTitleNotValid = 207,
        /// <summary>
        /// موقتا غیر فعال می باشد 666
        /// </summary>
        TemporaryDisable = 666,
        /// <summary>
        /// آدرس آی پی مسدود می باشد 777
        /// </summary>
        IPIsBanned = 777
    }
}