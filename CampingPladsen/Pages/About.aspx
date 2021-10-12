<%@ Page Title="Om Os" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CampingProjekt.Pages.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/AboutSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <br />
        <br />
     
        <div class="hero-image" >
           <asp:Image ID="Image1" runat="server" Height="111px" Width="776px"/>
                 <h1 style="color: #FFFFFF">Welcome to Camp Camping</h1>
            </div>



        <div class="row">
            <div class="column" style="background-color: rgba(44, 44, 44, .3);">
                <h1>About Us</h1>

        <div class="hero-text">
        </div>

                <p>Campingpladsen er placeret i det altid smukke Midtjylland – En perle ikke langt fra Lalandia, Givskud Zoo og ikke mindst Legoland der trækker langt de fleste kunder over til campingpladsen.
                    <br>
                    Derudover har pladsen direkte adgang til en å med gode fiskemuligheder samt mulighed for udlejning af kajakker og kanoer.Selve pladsen har plads til, og er godkendt til,
                    <br>
                    217 pladser på deres i alt ca. 4 hektar. Derudover er der 7 hytter på 16 m2 hver og 6 luksus hytter på 20 m2. </p>
            </div>
            <div class="column" style="background-color: rgba(44, 44, 44, .3);">
                <h1>Fordele ved camping på Camp Camping</h1>
                <p>At skabe minder: Camping er helt sikkert en oplevelse, din familie aldrig vil glemme. Fra en dag med at udforske alt, hvad din campingplads har at byde på, til en aften, hvor du kan stege s'mores rundt om bålet, vil disse minder vare evigt. Plus, chancen for at lære nye færdigheder og opleve nye ting holder os alle unge i hjertet!
                    <br>
                    <br>
                    Familieforbindelser: Camping giver dig og din familie en unik mulighed for at oprette forbindelse igen og bruge tid sammen. At lave mad over ilden, fortælle historier under stjernerne og slå sammen på vejen styrker båndene og giver alle en chance for at deltage.
                    <br>
                    <br>
                    Læringsmuligheder: Uanset om du laver mad udenfor for første gang, tager på en familietur eller lærer dine børn at fiske, er der uendelige muligheder for at opleve nye færdigheder og eventyr på en campingtur.</p>
            </div>
        </div>
    </main>
</asp:Content>
