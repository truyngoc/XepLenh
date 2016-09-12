<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountDownTimer1.aspx.cs" Inherits="XepLenh.CountDownTimer1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language ="javascript" >
        var tim;
       
        var min = 20;
        var sec = 60;
        var f = new Date();
        function f1() {
            f2();
            document.getElementById("starttime").innerHTML = "Your started your Exam at " + f.getHours() + ":" + f.getMinutes();
             
            document.getElementById("endtime").innerHTML = "Your  time is :"+f.toLocaleTimeString();
        }
        function f2() {
            if (parseInt(sec) > 0) {
                sec = parseInt(sec) - 1;
                document.getElementById("showtime").innerHTML = "Your Left Time  is :"+min+" Minutes ," + sec+" Seconds";
                tim = setTimeout("f2()", 1000);
            }
            else {
                if (parseInt(sec) == 0) {
                    min = parseInt(min) - 1;
                    if (parseInt(min) == 0) {
                        clearTimeout(tim);
                        location.href = "default5.aspx";
                    }
                    else {
                        sec = 60;
                        document.getElementById("showtime").innerHTML = "Your Left Time  is :" + min + " Minutes ," + sec + " Seconds";
                        tim = setTimeout("f2()", 1000);
                    }
                }
               
            }
        }
    </script>
</head>
 
<body onload="f1()">
    <form id="form1" runat="server">
    <div>
      <table width="100%" align="center">
        <tr>
          <td colspan="2">
            <h2>This is head part for showing timer and all other details</h2>
          </td>
        </tr>
        <tr>
          <td>
            <div id="starttime"></div>
 
            <div id="endtime"></div>
 
            <div id="showtime"></div>
          </td>
        </tr>
        <tr>
  </tr>
      </table>
      
 
   
 
    </div>
    </form>
</body>
</html>