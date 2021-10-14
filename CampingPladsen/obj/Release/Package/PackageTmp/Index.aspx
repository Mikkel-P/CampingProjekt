<%@ Page Title="Forside" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CampingProjekt.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/IndexSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

          <%-- Top Image Start --%>

        <div class="customContainer">
            <img src="https://www.tcmworld.org/wp-content/uploads/2020/01/be-the-sunshine-scaled.jpg" alt="Notebook">
            <div class="content">
                <h1>Camp Camping</h1>
                <p>Velkommen til vores hyggelige camping 200m fra stranden. Vi tilbyder flere overdækkede terasser, en lille café og masser af familiehygge i naturskønt område!</p>
            </div>
        </div>

         <%-- Top Image End --%>

           <%-- General Info Start --%>

        <div class="homeText" style="color: #000000">
            <h2>General Info</h2>
            <p>
               man kan tage kontakt til campingpladsen ved enten at ringe eller sende en e-mail til receptionen og 
               bestille enten en plads til en campingvogn/autocamper inklusiv strøm og brug af pladsens faciliteter. 
               Man kan også vælge at bestille en af hytterne hvis de er ledige hvilket naturligvis også er inklusive 
               strøm og faciliteter.For at kunne lave en fuld
            </p>

        </div>

         <%-- General Info End --%>

    </main>
</asp:Content>
