<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountDownJquery.aspx.cs" Inherits="XepLenh.CountDownJquery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>--%>
    <link rel="stylesheet" type="text/css" href="Content/jquery.countdown.css">
    <script type="text/javascript" src="Scripts/jquery.plugin.js"></script>
    <script type="text/javascript" src="Scripts/jquery.countdown.js"></script>


    <style>
        .countdown { float: left; width: 240px; }
    </style>


    <div class="row">
        <input type="button" onclick="setCountDownTime()" value="Dem nguoc" />
        <div class="col-md-2">
            <div id="noDays" class="countdown"></div>
        </div>
    </div>
    <div>
        <asp:GridView ID="grvCountDown" runat="server" AutoGenerateColumns="false" OnRowDataBound="grvCountDown_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="CreateDate" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate" , "{0:dd/MM/yyyy HH:mm:ss}") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Count down" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblCountDown" runat="server" CssClass="countdown" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>



    <script>
        function setCountDownTime()
        {
            var liftoffTime = new Date();
            liftoffTime.setDate(liftoffTime.getDate() + 5);

            alert(liftoffTime.toDateString());

            $('#noDays').countdown({ until: liftoffTime, format: 'HMS' });
        }
        
        function setRowCountDownTime(liftoffTime, labeltimeId) {
            var liftoffTime = new Date();
            liftoffTime.setDate(liftoffTime.getDate() + 5);


            $(labeltimeId).countdown({ until: liftoffTime, format: 'HMS' });
        }
    </script>

</asp:Content>
