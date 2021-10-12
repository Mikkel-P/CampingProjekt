<%@ Page Title="TestPage" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="CampingProjekt.Pages.TestPage" %>
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

        <asp:DataList ID="DataList1" runat="server" DataKeyField="Person_type" DataSourceID="Person_pris_tabel">
            <ItemTemplate>
                Person_type:
                <asp:Label ID="Person_typeLabel" runat="server" Text='<%# Eval("Person_type") %>' />
                <br />
                Højsæson:
                <asp:Label ID="HøjsæsonLabel" runat="server" Text='<%# Eval("Højsæson") %>' />
                <br />
                Lavsæson:
                <asp:Label ID="LavsæsonLabel" runat="server" Text='<%# Eval("Lavsæson") %>' />
                <br />
<br />
            </ItemTemplate>
    </asp:DataList>

    <asp:SqlDataSource ID="Person_pris_tabel" runat="server" ConnectionString="<%$ ConnectionStrings:CampingDBConnectionString %>" SelectCommand="SELECT * FROM [Person_type_tabel]"></asp:SqlDataSource>

    </main>
</asp:Content>
