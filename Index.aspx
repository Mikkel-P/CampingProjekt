<%@ Page Title="Forside" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CampingProjekt.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/IndexSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="customContainer">
            <img src="https://www.tcmworld.org/wp-content/uploads/2020/01/be-the-sunshine-scaled.jpg" alt="Notebook">
            <div class="content">
                <h1>Camp Camping</h1>
                <p>Velkommen til vores hyggelige camping 200m fra stranden. Vi tilbyder flere overdækkede terasser, en lille café og masser af familiehygge i naturskønt område!</p>
            </div>
        </div>

        <div class="homeText">
            <h2>General Info</h2>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </p>

        </div>
    </main>
</asp:Content>
