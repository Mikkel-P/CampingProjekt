<%@ Page Title="Booking" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="CampingProjekt.Pages.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BookingSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

        <br />
        <br />
       

        <div style="text-align:left" class="bookingContainer">
            <div class="calendarBox">

             
                 <h2 style="color: #FFFFFF; background-color: #C0C0C0;">Start Dato</h2>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="100px" Width="260px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>

                 

                <br /> 

            
                 <h2 style="color: #FFFFFF; background-color: #C0C0C0;" >Slut Dato</h2>
                  <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="100px" Width="260px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>

              

            </div>
            
              </div>
          
            

            <br />

           
        
                              
                     

            <asp:Image ID="Image1" runat="server" Height="98px" Width="815px" ImageUrl="https://image.freepik.com/free-vector/camping-horizontal-background-night-cartoon-style_96318-819.jpg" ImageAlign="Left"/>
             <h1 style="color: #FFFFFF; background-color: #C0C0C0;">Reservation</h1>
            <div class="textBoxManager">
                <div>
                    <asp:Label ID="Voksne" runat="server" Text="Antal voksne: "></asp:Label>
                    <asp:TextBox ID=VoksenInput runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Børn" runat="server" Text="Antal børn: "></asp:Label>
                    <asp:TextBox ID="BarnInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Hunde" runat="server" Text="Antal hunde: "></asp:Label>
                    <asp:TextBox ID="HundeInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="StorCampingplads" runat="server" Text="Antal campingpladser: (Store) "></asp:Label>
                    <asp:TextBox ID="StorCpInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="LilleCampingplads" runat="server" Text="Antal campingpladser: (Lille) "></asp:Label>
                    <asp:TextBox ID="LilleCpInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Teltpladser" runat="server" Text="Antal teltpladser: "></asp:Label>
                    <asp:TextBox ID="TeltInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="LuksusHytter" runat="server" Text="Antal luksus hytter: "></asp:Label>
                    <asp:TextBox ID="LukHytInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="StandardHytter" runat="server" Text="Antal standard hytter: "></asp:Label>
                    <asp:TextBox ID="StandHytInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="ForårsSæsonplads" runat="server" Text="Forårs sæsonplads: "></asp:Label>
                    <asp:TextBox ID="ForInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="SommerSæsonplads" runat="server" Text="Sommer sæsonplads: "></asp:Label>
                    <asp:TextBox ID="SommerInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="EfterårsSæsonplads" runat="server" Text="Efterårs sæsonplads: "></asp:Label>
                    <asp:TextBox ID="EfterInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="VinterSæsonplads" runat="server" Text="Vinter sæsonplads: "></asp:Label>
                    <asp:TextBox ID="VinterInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="BadelandVoksne" runat="server" Text="24 timers badelandsbillet: (Voksne) "></asp:Label>
                    <asp:TextBox ID="BadeVoksenInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="BadelandBørn" runat="server" Text="24 timers badelandsbillet: (Børn) "></asp:Label>
                    <asp:TextBox ID="BadeBarnInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Cykelleje" runat="server" Text="24 timers cykelleje: (Antal) "></asp:Label>
                    <asp:TextBox ID="CykelInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Rengøring" runat="server" Text="Rengøring: (Hytter) "></asp:Label>
                    <asp:TextBox ID="RenInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Sengelinned" runat="server" Text="Nyt sengelinned: (Pr. stk.) "></asp:Label>
                    <asp:TextBox ID="SengeInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="CPR" runat="server" Text="CPR Nummer: "></asp:Label>
                    <asp:TextBox ID="cprInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Fornavn" runat="server" Text="Fornavn: "></asp:Label>
                    <asp:TextBox ID="fornavnInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Efternavn" runat="server" Text="Efternavn: "></asp:Label>
                    <asp:TextBox ID="efternavnInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Vejnavn" runat="server" Text="Vejnavn: "></asp:Label>
                    <asp:TextBox ID="vejnavnInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="HusNr" runat="server" Text="Hus nr: "></asp:Label>
                    <asp:TextBox ID="husNrInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Postnummer" runat="server" Text="Postnummer: "></asp:Label>
                    <asp:TextBox ID="postNrInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Email" runat="server" Text="Email: "></asp:Label>
                    <asp:TextBox ID="emailInput" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Password" runat="server" Text="Password: "></asp:Label>
                    <asp:TextBox ID="passwordInput" runat="server"></asp:TextBox>
                </div>
            </div>
                
    </main>
</asp:Content>
