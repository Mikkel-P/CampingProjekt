<%@ Page Title="Booking" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="CampingProjekt.Pages.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BookingSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="bookingContainer">
            <div class="calendarBox">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="98px" OnSelectionChanged="Calendar1_SelectionChanged" Width="21px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="115px" OnSelectionChanged="Calendar2_SelectionChanged" Width="77px">
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
            </div>
        </div>
    </main>
</asp:Content>
