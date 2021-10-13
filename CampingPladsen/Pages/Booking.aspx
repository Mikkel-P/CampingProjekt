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
        
        <div class="row">
                <div class="col-xs-6">
            
                    
              


        <div style="text-align:left" class="bookingContainer">
            <div class="calendarBox">

             
                 <h2 style="color: #FFFFFF; background-color: #C0C0C0;">Start Dato</h2>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="118px" OnSelectionChanged="Calendar2_SelectionChanged" Width="260px">
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
                  <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="98px" OnSelectionChanged="Calendar1_SelectionChanged" Width="263px">
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
            </div>
            

            <br />

           
        
                <div class="col-xs-6">                 
                     

            <asp:Image ID="Image1" runat="server" Height="98px" Width="815px" ImageUrl="https://image.freepik.com/free-vector/camping-horizontal-background-night-cartoon-style_96318-819.jpg" ImageAlign="Left"/>
             <h1 style="color: #FFFFFF; background-color: #C0C0C0;">Reservation</h1>
            <div class="textBoxManager">
                <div>
                    <asp:Label ID="Voksne" runat="server" Text="Antal voksne: "></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Børn" runat="server" Text="Antal børn: "></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Hunde" runat="server" Text="Antal hunde: "></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                </div> 
                <div>
                    <asp:Label ID="StorCampingplads" runat="server" Text="Antal campingpladser: (Store) "></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="LilleCampingplads" runat="server" Text="Antal campingpladser: (Lille) "></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Teltpladser" runat="server" Text="Antal teltpladser: "></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="LuksusHytter" runat="server" Text="Antal luksus hytter: "></asp:Label>
                    <asp:TextBox ID="TextBox7" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="StandardHytter" runat="server" Text="Antal standard hytter: "></asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
                                <div>
                    <asp:Label ID="Sengelinned" runat="server" Text="Sengelinned: "></asp:Label>
                    <asp:TextBox ID="TextBox9" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
                                <div>
                    <asp:Label ID="Slutrengøring" runat="server" Text="Slutrengøring: "></asp:Label>
                    <asp:TextBox ID="TextBox10" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
                                <div>
                    <asp:Label ID="Cykelleje" runat="server" Text="Cykelleje: "></asp:Label>
                    <asp:TextBox ID="TextBox11" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
                                <div>
                    <asp:Label ID="BadelandVoksne" runat="server" Text="24 timers badelandsbillet: (Voksne) "></asp:Label>
                    <asp:TextBox ID="TextBox12" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
                                <div>
                    <asp:Label ID="BadelandBørn" runat="server" Text="24 timers badelandsbillet: (Børn) "></asp:Label>
                    <asp:TextBox ID="TextBox13" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="CPR" runat="server" Text="CPR Nummer"></asp:Label>
                    <asp:TextBox ID="TextBox14" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Fornavn" runat="server" Text="Fornavn"></asp:Label>
                    <asp:TextBox ID="TextBox15" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Efternavn" runat="server" Text="Efternavn"></asp:Label>
                    <asp:TextBox ID="TextBox16" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Adresse" runat="server" Text="Adresse"></asp:Label>
                    <asp:TextBox ID="TextBox17" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                </div>
            </div>
             
                </div>
            </div>

           <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        runat="server">
        
        <columns>
          <asp:boundfield datafield="CustomerID" headertext="Customer ID"/>
          <asp:boundfield datafield="CompanyName" headertext="Company Name"/>
          <asp:boundfield datafield="Address" headertext="Address"/>
          <asp:boundfield datafield="City" headertext="City"/>
          <asp:boundfield datafield="PostalCode" headertext="Postal Code"/>
          <asp:boundfield datafield="Country" headertext="Country"/>
        </columns>
                
      </asp:gridview>

             <div class="row">
                <div class="col-xs-6">
                    <h1 style="color: #FFFFFF; background-color: #C0C0C0;">Prisliste</h1>
            <img src="../Images/Camping%20picture2.PNG" />
                    <asp:TextBox type="text" class="form-control" ID="email" runat="server" />
                </div>
                <div class="col-xs-6">
                    
                    <asp:TextBox type="text" class="form-control" ID="number" runat="server" />
                </div>
            </div>

 

     
        
    </main>
</asp:Content>
