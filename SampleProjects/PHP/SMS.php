<?php
class SMS
{
	function get_data($Data) {
		$url = "http://sms.sunwaysms.com/smsws/HttpService.ashx?";
		 $ch = curl_init();
		 curl_setopt($ch, CURLOPT_URL, $url . $Data);
		 curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
		 curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, $timeout);
		 $data = curl_exec($ch);
		 curl_close($ch);
		return $data;
	}
	
	function SendArray($UserName, $Password, $RecipientNumber, $Message, $SpecialNumber, $IsFlash, $CheckingMessageID) {
		$Number = "";
		$chkMessageID = "";
		foreach ($RecipientNumber as $item) {
			$Number = $Number . $item . ",";
		}

		foreach ($CheckingMessageID as $item) {
			$chkMessageID = $chkMessageID . $item . ",";
		}

		 return $this->get_data("service=SendArray&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&To=" . urlencode(rtrim($Number,",")) . "&Message=" . urlencode($Message) .
		 "&From=" . urlencode($SpecialNumber) . "&Flash=" . urlencode(($IsFlash ? "true" : "false")) . "&chkMessageId=" . urlencode(rtrim($chkMessageID,",")));
	}

	function SendArraySchedule($UserName, $Password, $RecipientNumber, $Message, $SpecialNumber, $IsFlash, $Year, $Month, $Day, $Hour, $Minute) {
		$Number = "";
		foreach ($RecipientNumber as $item) {
			$Number = $Number . $item . ",";
		}
		return $this->get_data("service=SendArraySchedule&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&To=" . urlencode(rtrim($Number,",")) . "&Message=" . urlencode($Message) .
		"&From=" . urlencode($SpecialNumber) . "&Flash=" . urlencode(($IsFlash ? "true" : "false")) . "&Year=" . urlencode($Year) . "&Month=" . urlencode($Month) . "&Day=" . urlencode($Day) . "&Hour=" . urlencode($Hour) . "&Minute=" . urlencode($Minute));
	}

	function GetMessageID($UserName, $Password, $CheckingMessageID) {
		$chkMessageID = "";
		foreach ($CheckingMessageID as $item) {
			$chkMessageID = $chkMessageID . $item . ",";
		}
		return $this->get_data("service=GetMessageID&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&chkMessageId=" . urlencode(rtrim($chkMessageID,",")));
	}

	function GetMessageStatus($UserName, $Password, $MessageID) {
		$message = "";
		foreach ($MessageID as $item) {
			$message = $message . $item . ",";
		}
		return $this->get_data("service=GetMessageStatus&UserName=" . urlencode($UserName) . "&Password=" .  urlencode($Password) . "&MessageID=" .  urlencode(rtrim($message,",")));
	}

	function GetNumberGroupData($UserName, $Password) {
		$result = $this->get_data("service=GetNumberGroupData&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password));
		return(json_decode($result));
	}


	function SendNumberGroup($UserName, $Password, $NumberGroupID, $Message, $SpecialNumber, $IsFlash, $DontSendToRepeatedNumber) {
		$number = "";
		foreach ($NumberGroupID as $item) {
			$number = $number . $item . ",";
		}
		return $this->get_data("service=SendNumberGroup&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberGroupID=" . urlencode(rtrim($number,",")) . "&Message=" . urlencode($Message) .
		"&From=" . urlencode($SpecialNumber) . "&Flash=" . urlencode(($IsFlash ? "true" : "false")) . "&DontSendRepeat=" . urlencode(($DontSendToRepeatedNumber ? "true" : "false")));
	}

	function SendNumberGroupSchedule($UserName, $Password, $NumberGroupID, $Message, $SpecialNumber, $IsFlash, $DontSendToRepeatedNumber, $Year, $Month, $Day, $Hour, $Minute) {
		$number = "";
		foreach ($NumberGroupID as $item) {
			$number = $number . $item . ",";
		}
		return $this->get_data("service=SendNumberGroupSchedule&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberGroupID=" . urlencode(rtrim($number,",")) . "&Message=" . urlencode($Message) .
			"&From=" . urlencode($SpecialNumber) . "&Flash=" . urlencode(($IsFlash ? "true" : "false")) . "&DontSendRepeat=" . urlencode(($DontSendToRepeatedNumber ? "true" : "false")) . "&Year=" . urlencode($Year) . "&Month=" 
			. urlencode(Month) . "&Day=" . urlencode($Day) . "&Hour=" . urlencode($Hour) . "&Minute=" . urlencode($Minute));
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

	function GetInboxMessage($UserName, $Password, $NumberOfMessage) {
		$result = $this->get_data("service=GetInboxMessage&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberOfMessage=" . urlencode($NumberOfMessage));
		return(json_decode($result));
	}

	function GetInboxMessageWithNumber($UserName, $Password, $NumberOfMessage, $SpecialNumber) {
		$result =  $this->get_data("service=GetInboxMessageWithNumber&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberOfMessage=" . urlencode($NumberOfMessage) . "&From=" . urlencode($SpecialNumber));
		return(json_decode($result));
	}

	function  GetInboxMessageWithInboxID($UserName, $Password, $NumberOfMessage, $InboxID, $IsReaded) {
		$result= $this->get_data("service=GetInboxMessageWithInboxID&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password) . "&NumberOfMessage=" . urlencode($NumberOfMessage) .
		"&InboxID=" . urlencode($InboxID) . "&IsReaded=" . urlencode(($IsReaded ? "true" : "false")));
		return(json_decode($result));
	}

	function GetCredit($UserName, $Password) {
		return $this->get_data("service=GetCredit&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password));
	}

	function GetUserInfo($UserName, $Password) {
		$result = $this->get_data("service=GetUserInfo&UserName=" . urlencode($UserName) . "&Password=" . urlencode($Password));
		return(json_decode($result));
	}
}	

 class Method_Status
    {
        const MessageIDIsInvalid = 0;
        const PendingStatus = 1;
        const DeliveredToPhone = 2;
        const FailedToPhone = 3;
        const DeliveredToServiceCenter = 4;
        const FailedToServiceCenter = 5;
        const InDisableList = 6;
        const InSendQueue = 7;
        const Sending = 8;
        const LowCredit = 9;
        const NotSent = 10;
  
        const Successful = 50;
 
        const UserNameOrPasswordIsWrong = 51;
        const UserNameOrPasswordIsEmpty = 52;
        const RecipientNumberLengthIsMoreThanUsual = 53;
        const RecipientNumberIsEmpty = 54;
        const RecipientNumberIsNull = 55;
        const MessageIDLengthIsMoreThanUsual = 56;
        const MessageIDIsEmpty = 57;
        const MessageIDIsNull = 58;
        const MessageBodyIsEmpty = 59;
        const InThisTimeServerCannotRespond = 60;
        const SpecialNumberIsInvalid = 61;
        const SpecialNumberIsEmpty = 62;
        const ThisIPIsInvalid = 63;
        const WSIDIsWrong = 64;
        const NumberOfMessageIsWrong = 65;
        const CheckingMessageIDLengthIsNotEqualWithRecipientNumberLength = 66;
        const CheckingMessageIDLengthIsMoreThanUsual = 67;
        const CheckingMessageIDIsEmpty = 68;
        const CheckingMessageIDIsNull = 69;
        const YourUserIsInActive = 70;
        const DomainIsInvalid = 71;
        const TimeIsWrong = 72;
        const DateIsWrong = 73;
        const NumberGroupIDLengthIsMoreThanUsual = 74;
        const NumberGroupIDIsEmpty = 75;
        const NumberGroupIDIsNull = 76;
        const YouAreNotWebServiceUser = 77;
        const YouAreNotSMSPanelUser = 78;
        const PersonNameLengthIsNotEqualWithPersonNumberLength = 79;
        const ServiceIsInActive = 80;
        const PersonNumberLengthIsMoreThanUsual = 81;
        const PersonNumberIsEmpty = 82;
        const PersonNumberIsNull = 83;
        const NumberGroupIDIsInvalid = 84;
        const RecipientNumberFormatIsWrong = 201;
        const RecipientNumberOperatorIsInvalid = 202;
        const YouCanNotSendThisBecauseYourCreditIsNotEnough = 203;
        const CheckingMessageIDIsNotValid = 204;
        const PersonNumberFormatIsWrong = 205;
        const PersonNumberOperatorIsInvalid = 206;
    }


?>