<%@ Page Title="Faciliteter" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Faciliteter.aspx.cs" Inherits="CampingProjekt.Pages.Faciliteter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/FaciliteterSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

         <%-- Top Image Start --%>

    
        <div class="hero-image" style="text-align: center">
            <div class="hero-text" style="background-image: url('../Images/Camping Picture Sunset.jpg'); color: #FFFFFF;">
                    <br />
                <h1>Faciliter</h1>
                <p>En mere detaljeret forklaring om Faciliteterne på Camp Camping </p>
            </div>
        </div>

         <%-- Top Image End --%>


         <%-- Facility List Start --%>

        <div class="header" style="text-align: center; font-size: 28px;">
            <div class="customContainer" style="background-color: rgba(44, 44, 44, 0.3); width: 1000px; height: 1130px; color: #FFFFFF;">
                <h1>Facilitets Liste</h1>
                <ul style="text-align: center; display: inline-block;">
                    <li>Badeland</li>
                    <li>Reception</li>  
                    <li>ServiceBygning</li>
                    <li><br /></li>
                    <li>Bortskaffelse af affald</li>
                    <li>Spildevand fra autocamper</li>
                    <li>Gedefold</li>
                    <li>Bålplads</li>
                </ul>

                 <%-- Facility List End --%>

                <br>

                 <%-- Facility Image Start --%>

                <div class="customContainer">
                        <img src="../Images/Camping%20picture.PNG"/>
                </div>

                  <%-- Facility Image End --%>

            </div>
        </div>
    </main>
</asp:Content>
