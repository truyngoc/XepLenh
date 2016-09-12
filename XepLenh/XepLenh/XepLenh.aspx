<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XepLenh.aspx.cs" Inherits="XepLenh.XepLenh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <span>PH</span>
                <asp:GridView ID="grvPH" runat="server"></asp:GridView>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="btnXepLenh" runat="server" CssClass="btn btn-primary" Text="STATEMENT" OnClick="btnXepLenh_Click" />
            </div>
            <div class="col-md-5">
                <span>GH</span>
                <asp:GridView ID="grvGH" runat="server"></asp:GridView>
            </div>
        </div>
        <br />
        <div class="row">
            <span>STATEMENT</span>
            <asp:GridView ID="grvStatement" runat="server"></asp:GridView>
            <br />
            <span>STATEMENT List</span>
            <asp:GridView ID="grvStatementList" runat="server"></asp:GridView>
        </div>
        <br />
        <div class="row">
            <span>PH thua</span>
            <asp:GridView ID="grvPH_Thua" runat="server"></asp:GridView>
            <br />
            <span>GH thua</span>
            <asp:GridView ID="grvGH_Thua" runat="server"></asp:GridView>
        </div>
    </div>


</asp:Content>
