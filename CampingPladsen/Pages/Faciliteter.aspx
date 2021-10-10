<%@ Page Title="Faciliteter" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Faciliteter.aspx.cs" Inherits="CampingProjekt.Pages.Faciliteter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FaciliteterSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="hero-image">
            <div class="hero-text">
                <h1>Faciliter</h1>
                <p>En mere detaljeret forklaring om Faciliteterne på Camp Camping </p>
            </div>
        </div>

        <div class="header">
            <div class="customContainer" style="background-color: rgba(44, 44, 44, 0.3);">
                <h1>Faciliteter</h1>
                <ul>
                    <li>Badeland</li>
                    <li>Reception</li>
                    <li>ServiceBygning</li>
                    <li><br /></li>
                    <li>Bortskaffelse af affald</li>
                    <li>Spildevand fra autocamper</li>
                    <li>Gedefold</li>
                    <li>Bålplads</li>
                </ul>
                <br>
                <div class="customContainer">
                    <img alt="Camping kort" class="center" src="file:///C:/Users/jaco583c/OneDrive%20-%20EFIF/Billeder/Camping%20picture.PNG">
                </div>
            </div>
        </div>
    </main>
</asp:Content>
