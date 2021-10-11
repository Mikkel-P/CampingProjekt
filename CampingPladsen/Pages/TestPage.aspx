<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="CampingProjekt.Pages.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <br />
        <br />
        <br />
        <br />

        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>


    </main>
</asp:Content>
