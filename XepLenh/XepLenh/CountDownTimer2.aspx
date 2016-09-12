<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountDownTimer2.aspx.cs" Inherits="XepLenh.CountDownTimer2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>
        TargetDate = "12/31/2020 5:00 AM";
        BackColor = "palegreen";
        ForeColor = "navy";
        CountActive = true;
        CountStepper = -1;
        LeadingZero = true;
        DisplayFormat = "%%D%% Days, %%H%% Hours, %%M%% Minutes, %%S%% Seconds.";
        FinishMessage = "It is finally here!";
    </script>
    <script src="http://scripts.hashemian.com/js/countdown.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
