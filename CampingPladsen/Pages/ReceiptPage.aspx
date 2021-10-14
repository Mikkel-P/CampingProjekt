<%@ Page Title="ReceiptPage" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReceiptPage.aspx.cs" Inherits="CampingProjekt.Pages.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <br />
        <br />
        <br />
        <br />

        
        <h1 style="color: #FFFFFF; background-color: #666666; position: page; width: 900px; height: 100px; text-align: center;">Din Reservation er blevet Booket</h1>

        <br />
        <br />


        <asp:Label ID="TotalPrice" runat="server" Text="Total pris"></asp:Label>
        <asp:SqlDataSource ID="TotalPriceOutput" runat="server" ConnectionString="<%$ ConnectionStrings:CampingDBConnectionString %>" SelectCommand="SELECT MAX (Total_pris) AS &quot;Total Pris&quot; FROM Total_pris;"></asp:SqlDataSource>

    </main>
</asp:Content>
