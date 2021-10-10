<%@ Page Title="Opret Bruger" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="CampingProjekt.Pages.CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/CreateUserSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/RootSS.css" rel="stylesheet" type="text/css" />
    <link href="CSS/MasterSS.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="createUserBox">
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </div>
    </main>
</asp:Content>
