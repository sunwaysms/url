<?php

function val($key){
    if (isset($_POST[$key])) return $_POST[$key];
    return "";
}

date_default_timezone_set('Asia/Tehran');
	include 'SMS.php';
	include_once("dBug.php");
    $Status = 'خوش آمدید';
    $Result_SendSMS = '';
    $Result_SendSMSSchedule = '';
    $Result_GetMessageID = '';
    $Result_GetMessageStatus = '';
    $Result_GetNumberGroupData = '';
    $Result_SendNumberGroup = '';
    $Result_SendNumberGroupSchedule = '';
    $Result_InsertNumberInNumberGroup = '';
    $Result_GetInboxMessage = '';
    $Result_GetInboxMessageWithNumber = '';
    $Result_GetCreditAction = '';

    if ($_SERVER['REQUEST_METHOD'] == 'POST'){
        $SMS = new SMS();
   
        switch($_POST['ApiType']){
            case 'SendSMS':            
                $numbers= explode(';', $_POST['SendArrayRecipientNumber']);
                $checkNumber= explode(';', $_POST['SendArrayCheckingMessageID']);
                
                
                $Result_SendSMS = $SMS->SendArray($_POST['UserName'],$_POST['Password'],$numbers, $_POST['SendArrayMessageBody'], $_POST['SendArraySpecialNumber'], isset($_POST['SendArrayIsFlash']), $checkNumber);
                $Status = 'ارسال پیام با موفقیت انجام شد';

                break;
            case 'SendSMSSchedule':
                $numbers= explode(';', $_POST['SendArrayScheduleRecipientNumber']);
                
                $Year = date('Y');
                $Month = date('m');
                $Day = date('d')+1;
                $Hour = intval(date('H'));
                $Minute = intval(date('i')) + 5;
                
                $Result_SendSMSSchedule = $SMS->SendArraySchedule($_POST['UserName'],$_POST['Password'],$numbers, $_POST['SendArrayScheduleMessageBody'], $_POST['SendArrayScheduleSpecialNumber'], isset($_POST['SendArrayScheduleIsFlash']), $Year, $Month, $Day, $Hour, $Minute);
                $Status = 'ارسال پیام زمانبندی با موفقیت انجام شد';

                break;

                
            case 'GetMessageIDActive':
                $numbers= explode(';', $_POST['SendArrayScheduleRecipientNumber']);
                $Result_GetMessageID = $SMS->GetMessageID($_POST['UserName'],$_POST['Password'],$numbers);
                break;
            case 'GetMessageStatusAction':
                $numbers= explode(';', $_POST['GetMessageStatusMessageID']);
                $Result_GetMessageStatus = $SMS->GetMessageStatus($_POST['UserName'],$_POST['Password'],$numbers);
               
                break;
            case 'GetNumberGroupDataAction':
                $Result_GetNumberGroupData = $SMS->GetNumberGroupData($_POST['UserName'],$_POST['Password']);
                $Status = 'ارسال پیام با موفقیت انجام شد';
                break;
            case 'SendNumberGroupAction':
                $numbers= explode(';', $_POST['SendNumberGroupNumberGroupID']);
                
                $Result_SendNumberGroup = $SMS->SendNumberGroup($_POST['UserName'],$_POST['Password'],$numbers, $_POST['SendNumberGroupMessageBody'], $_POST['SendNumberGroupSpecialNumber'], isset($_POST['SendNumberGroupIsFlash']), isset($_POST['SendNumberGroupDontSendRepeated']));
                $Status = 'ارسال پیام با موفقیت انجام شد';

                break;
            case 'SendNumberGroupScheduleAction':
                $numbers= explode(';', $_POST['SendNumberGroupScheduleNumberGroupID']);
                
                $Year = date('Y');
                $Month = date('m');
                $Day = date('d');
                $Hour = intval(date('H'));
                $Minute = intval(date('i')) + 5;
                
                $Result_SendNumberGroupSchedule = $SMS->SendNumberGroupSchedule($_POST['UserName'],$_POST['Password'],$numbers, $_POST['SendNumberGroupScheduleMessageBody'], $_POST['SendNumberGroupScheduleSpecialNumber'], isset($_POST['SendNumberGroupScheduleIsFlash']), isset($_POST['SendNumberGroupScheduleDontSendRepeated']), $Year, $Month, $Day, $Hour, $Minute);
                $Status = 'ارسال پیام زمانبندی با موفقیت انجام شد';

                break;
            case 'InsertNumberInNumberGroup':
                $numbers= explode(';', $_POST['InsertNumberInNumberGroupPersonNumber']);
                $names= explode(';', $_POST['InsertNumberInNumberGroupPersonName']);
                
                $Result_InsertNumberInNumberGroup = $SMS->InsertNumberInNumberGroup($_POST['UserName'],$_POST['Password'],$_POST['InsertNumberInNumberGroupNumberGroupID'], $numbers, $names);
                $Status = 'شماره های مورد نظر ثبت شد';
                break;
                
            case 'GetInboxMessageAction':
                $Result_GetInboxMessage = $SMS->GetInboxMessage($_POST['UserName'],$_POST['Password'],$_POST['GetInboxMessageNumberOfMessage']);
			break;
            case 'GetInboxMessageWithNumberAction':
                $Result_GetInboxMessageWithNumber = $SMS->GetInboxMessageWithNumber($_POST['UserName'],$_POST['Password'],$_POST['GetInboxMessageWithNumberNumberOfMessage'], $_POST['GetInboxMessageWithNumberSpecialNumber']);
                break;
            case 'GetCreditAction':
                $Result_GetCreditAction = $SMS->GetCredit($_POST['UserName'],$_POST['Password']);
                
                break;
			case 'GetInboxMessageWithLastInboxIDAction':
			if($_POST['GetInboxMessageWithLastInboxIDReaded'] == 'true') 
					{
						$IsReaded = true;
					}
					else
					{
						$IsReaded = false;
					}
                $Result_GetInboxMessageWithLastInboxID = $SMS->GetInboxMessageWithInboxID($_POST['UserName'],$_POST['Password'],$_POST['GetInboxMessageWithLastInboxIDCount'], $_POST['GetInboxMessageWithLastInboxIDID'],$IsReaded);
			break;	
				
			case 'GetUserInfoAction':
                $Result_GetUserInfoAction = $SMS->GetUserInfo($_POST['UserName'],$_POST['Password']);
			break;	
        }
    }

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>
	PHP Url (Http) Sample
</title><link href="CSS/Style.css" rel="stylesheet" type="text/css" /></head>
<body>

<form method="POST">

    <div class='dForm'><span id="Alarm" style="color:Firebrick;"><?php echo $Status ?></span></div>
    <div class='dForm'>
        <div class='dTitle'><strong>1 . </strong>اطلاعات اصلی مورد نیاز در هر یک از متد ها</div>
        <div class='dRight'>
            <div>نام کاربری :</div>
            <div class='e'>رمز عبور :</div>
        </div>
        <div class='dLeft'>
            <div><input name="UserName" type="text" id="UserName" value="<?php echo val("UserName"); ?>" /></div>
            <div class='e'><input name="Password" type="text" id="Password" value="<?php echo val("Password"); ?>" /></div>
        </div>
        <div class='clear'></div>
    </div>

    <div class='dForm'>
        <div class='dTitle'><strong>2 . </strong>ارسال پیام کوتاه</div>
        <div class='dRight'>
            <div>شماره اختصاصی :</div>
            <div class='m'>شماره گیرنده :<br /><span class='small'>( شماره ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span></div>
            <div class='m'>CheckingMessageID:<br /><span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span></div>
            <div class='m'>متن پیام :</div>
            <div>ارسال بصورت Flash</div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div><input name="SendArraySpecialNumber" type="text" id="SendArraySpecialNumber" /></div>
            <div class='m'><textarea value="<?php echo val("SendArrayRecipientNumber"); ?>" name="SendArrayRecipientNumber" rows="2" cols="20" id="SendArrayRecipientNumber" style="height:50px;"></textarea></div>
            <div class='m'><textarea value="<?php echo val("SendArrayCheckingMessageID"); ?>" name="SendArrayCheckingMessageID" rows="2" cols="20" id="SendArrayCheckingMessageID" style="height:50px;"></textarea></div>
            <div class='m'><textarea value="<?php echo val("SendArrayMessageBody"); ?>" name="SendArrayMessageBody" rows="2" cols="20" id="SendArrayMessageBody" style="height:50px;"></textarea></div>
            <div><input id="SendArrayIsFlash" type="checkbox" name="SendArrayIsFlash" /></div>
            <div class='c'><button type="submit" name="ApiType" value="SendSMS" id="SendArrayAction">ارسال پیام کوتاه</button></div>
            <div class='e'></div>
        </div>
        <div><?php echo $Result_SendSMS; ?></div>
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'><strong>3 . </strong>ارسال پیام کوتاه زمانبندی شده</div>
        <div class='dRight'>
            <div>شماره اختصاصی :</div>
            <div class='m'>شماره گیرنده :<br /><span class='small'>( شماره ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span></div>
            <div class='m'>متن پیام :</div>
            <div>ارسال بصورت Flash</div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div><input name="SendArrayScheduleSpecialNumber" type="text" id="SendArrayScheduleSpecialNumber" value="<?php echo val("SendArrayScheduleSpecialNumber"); ?>" /></div>
            <div class='m'><textarea name="SendArrayScheduleRecipientNumber" rows="2" cols="20" id="SendArrayScheduleRecipientNumber" value="<?php echo val("SendArrayScheduleRecipientNumber"); ?>" style="height:50px;"></textarea></div>
            <div class='m'><textarea name="SendArrayScheduleMessageBody" rows="2" cols="20" id="SendArrayScheduleMessageBody" value="<?php echo val("SendArrayScheduleMessageBody"); ?>" style="height:50px;"></textarea></div>
            <div><input id="SendArrayScheduleIsFlash" type="checkbox" name="SendArrayScheduleIsFlash" /></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="SendSMSSchedule" id="SendArrayScheduleAction">ارسال پیام کوتاه زمانبندی شده</button></div>
            <div class='e'></div>
        </div>
        <div><?php echo $Result_SendSMSSchedule; ?></div>
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'><strong>4 . </strong>بدست آوردن MessageID</div>
        <div class='dRight'>
            <div class='m'>CheckingMessageID:<br /><span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span></div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div class='m'><textarea name="GetMessageIDCheckingMessageID" value="<?php echo val("GetMessageIDCheckingMessageID"); ?>" rows="2" cols="20" id="GetMessageIDCheckingMessageID" style="height:50px;"></textarea></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="GetMessageIDActive" id="GetMessageIDActive">بدست آوردن MessageID</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php echo $Result_GetMessageID; ?></div>
    
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'>دریافت آخرین وضعیت پیام های ارسال شده</div>
        <div class='dRight'>
            <div class='m'>شناسه پیامک :<br /><span class='small'>( شناسه ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span></div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div class='m'><textarea name="GetMessageStatusMessageID" rows="2" cols="20" id="GetMessageStatusMessageID" style="height:50px;"></textarea></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="GetMessageStatusAction" id="GetMessageStatusAction">دریافت آخرین وضعیت پیام های ارسال شده</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php echo $Result_GetMessageStatus; ?></div>
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'><strong>4 . </strong>دریافت اطلاعات گروه شماره های دفتر تلفن</div>
        <div class='dRight'>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div class='c'>
                <button type="submit" name="ApiType" value="GetNumberGroupDataAction" id="GetNumberGroupDataAction">دریافت اطلاعات گروه شماره های دفتر تلفن</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php new dBug($Result_GetNumberGroupData); ?></div>
    
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'><strong>5 . </strong>ارسال پیام کوتاه به گروه شماره های دفتر تلفن</div>
        <div class='dRight'>
            <div>شماره اختصاصی :</div>
            <div class='m'>شناسه گروه ها :<br /><span class='small'>( شناسه ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span></div>
            <div class='m'>متن پیام :</div>
            <div>ارسال بصورت Flash</div>
            <div>عدم ارسال به شماره های تکراری</div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div><input name="SendNumberGroupSpecialNumber" type="text" id="SendNumberGroupSpecialNumber" /></div>
            <div class='m'><textarea name="SendNumberGroupNumberGroupID" rows="2" cols="20" id="SendNumberGroupNumberGroupID" style="height:50px;"></textarea></div>
            <div class='m'><textarea name="SendNumberGroupMessageBody" rows="2" cols="20" id="SendNumberGroupMessageBody" style="height:50px;"></textarea></div>
            <div><input id="SendNumberGroupIsFlash" type="checkbox" name="SendNumberGroupIsFlash" /></div>
            <div><input id="SendNumberGroupDontSendRepeated" type="checkbox" name="SendNumberGroupDontSendRepeated" /></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="SendNumberGroupAction" id="SendNumberGroupAction">ارسال پیام کوتاه به گروه شماره های دفتر تلفن</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php echo $Result_SendNumberGroup; ?></div>
    
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'><strong>6 . </strong>ارسال پیام کوتاه زمانبندی شده به گروه شماره های دفتر تلفن</div>
        <div class='dRight'>
            <div>شماره اختصاصی :</div>
            <div class='m'>شناسه گروه ها :<br /><span class='small'>( شناسه ها را با ' </span>;<span class='small'> ' از یکدیگر جدا کنید )</span></div>
            <div class='m'>متن پیام :</div>
            <div>ارسال بصورت Flash</div>
            <div>عدم ارسال به شماره های تکراری</div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div><input name="SendNumberGroupScheduleSpecialNumber" type="text" id="SendNumberGroupScheduleSpecialNumber" /></div>
            <div class='m'><textarea name="SendNumberGroupScheduleNumberGroupID" rows="2" cols="20" id="SendNumberGroupScheduleNumberGroupID" style="height:50px;"></textarea></div>
            <div class='m'><textarea name="SendNumberGroupScheduleMessageBody" rows="2" cols="20" id="SendNumberGroupScheduleMessageBody" style="height:50px;"></textarea></div>
            <div><input id="SendNumberGroupScheduleIsFlash" type="checkbox" name="SendNumberGroupScheduleIsFlash" /></div>
            <div><input id="SendNumberGroupScheduleDontSendRepeated" type="checkbox" name="SendNumberGroupScheduleDontSendRepeated" /></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="SendNumberGroupScheduleAction" id="SendNumberGroupScheduleAction">ارسال پیام کوتاه زمانبندی شده به گروه شماره های دفتر تلفن</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php echo $Result_SendNumberGroupSchedule; ?></div>
    
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'><strong>7 . </strong>ثبت شماره در گروه شماره های دفتر تلفن</div>
        <div class='dRight'>
            <div>شناسه گروه :</div>
            <div class='m'>شماره افراد :<br /><span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span></div>
            <div class='m'>نام افراد :<br /><span class='small'>( با ' </span>;<span class='small'> ' جدا کنید )</span></div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div><input name="InsertNumberInNumberGroupNumberGroupID" type="text" id="InsertNumberInNumberGroupNumberGroupID" /></div>
            <div class='m'><textarea name="InsertNumberInNumberGroupPersonNumber" rows="2" cols="20" id="InsertNumberInNumberGroupPersonNumber" style="height:50px;"></textarea></div>
            <div class='m'><textarea name="InsertNumberInNumberGroupPersonName" rows="2" cols="20" id="InsertNumberInNumberGroupPersonName" style="height:50px;"></textarea></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="InsertNumberInNumberGroup" id="InsertNumberInNumberGroup">ثبت شماره در گروه شماره های دفتر تلفن</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php echo $Result_InsertNumberInNumberGroup; ?></div>
    
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'>دریافت آخرین پیام های رسیده در روز اخیر</div>
        <div class='dRight'>
            <div>تعداد :</div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div><input name="GetInboxMessageNumberOfMessage" type="text" id="GetInboxMessageNumberOfMessage" /></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="GetInboxMessageAction" id="GetInboxMessageAction">دریافت آخرین پیام های رسیده در روز اخیر</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php new dBug($Result_GetInboxMessage); ?></div>
    
        <div class='clear'></div>
    </div>
    <div class='dForm'>
        <div class='dTitle'>دریافت آخرین پیام های رسیده در روز اخیر به شماره خاص</div>
        <div class='dRight'>
            <div>تعداد :</div>
            <div>شماره اختصاصی :</div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
            <div><input name="GetInboxMessageWithNumberNumberOfMessage" type="text" id="GetInboxMessageWithNumberNumberOfMessage" /></div>
            <div><input name="GetInboxMessageWithNumberSpecialNumber" type="text" id="GetInboxMessageWithNumberSpecialNumber" /></div>
            <div class='c'>
                <button type="submit" name="ApiType" value="GetInboxMessageWithNumberAction" id="GetInboxMessageWithNumberAction">دریافت آخرین پیام های رسیده در روز اخیر به شماره خاص</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php new dBug($Result_GetInboxMessageWithNumber); ?></div>
    
        <div class='clear'></div>
    </div>

    <div class='dForm'>
        <div class='dTitle'>دریافت میزان اعتبار پیام کوتاه</div>
        <div class='dRight'>
            <div></div>
            <div class='e'>میزان اعتبار (ریال) :</div>
        </div>
        <div class='dLeft'>
            <div class='c'>
                <button type="submit" name="ApiType" value="GetCreditAction" id="GetCreditAction">دریافت میزان اعتبار پیام کوتاه</button>
            </div>
        </div>
        <div><?php echo $Result_GetCreditAction; ?></div>
        <div class='clear'></div>
    </div>
	
	 <div class='dForm'>
        <div class='dTitle'>دریافت آخرین پیام های رسیده با آخرین ID پیام دریافتی </div>
        <div class='dRight'>
            <div>تعداد :</div>
            <div>آخرین ID :</div>
            <div>فقط خوانده نشده ها :</div>
            <div></div>
            <div class='e'>نتیجه :</div>
        </div>
        <div class='dLeft'>
		    <div><input name="GetInboxMessageWithLastInboxIDCount" type="text" id ="GetInboxMessageWithLastInboxIDCount" /></div>
            <div><input name="GetInboxMessageWithLastInboxIDID" type="text" id ="GetInboxMessageWithLastInboxIDID" /></div>
            <div>
				<select id="GetInboxMessageWithLastInboxIDReaded" name="GetInboxMessageWithLastInboxIDReaded">
					<option value="false" >بله</option>
                    <option value="true" >خیر</option>
                 </select>
            </div>
            <div class='c'>
                <button type="submit" name="ApiType" value="GetInboxMessageWithLastInboxIDAction" id="GetInboxMessageWithLastInboxIDAction">دریافت آخرین پیام های رسیده با آخرین ID پیام دریافتی</button>
            </div>
            <div class='e'></div>
        </div>
        <div><?php new dBug($Result_GetInboxMessageWithLastInboxID); ?></div>
    
        <div class='clear'></div>
    </div>
	 <div class='dForm'>
		<div class='dTitle'>دریافت اطلاعات کاربری</div>
		<div class='dRight'>
			<div></div>
			<div class='e'>نتیجه :</div>
		</div>
		<div class='dLeft'>
			<div class='c'>
				 <button type="submit" name="ApiType" value="GetUserInfoAction" id="GetUserInfoAction">دریافت اطلاعات کاربری</button>
			</div>
			<div class='e'></div>
		</div>
		 <div><?php new dBug($Result_GetUserInfoAction); ?></div>
		<div class='clear'></div>
	</div>
</form>
</body>
</html>