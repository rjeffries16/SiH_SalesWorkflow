<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlexList.aspx.cs" Inherits="SalesWorkflow.SalesLeads.AlexList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel runat="server" Width="90%" >
    <asp:Label ID="lblCallsToday1" runat="server" Font-Bold="true" Font-Size="Large">Instructions:&nbsp;&nbsp;</asp:Label>
    <br />
    <asp:Label runat="server" ID ="Label2">1. Click on the "Open Next Lead" Link a new browser window will open with a lead in Zoho.</asp:Label><br />
    <asp:Label runat="server" ID ="Label3">2. Read the lead history and determine if a call is appropriate.</asp:Label><br />
    <asp:Label runat="server" ID ="Label4">3. If a call is not appropriate make a note and set a new status that will exclude the lead.</asp:Label><br />
    <asp:Label runat="server" ID ="Label5">4. After the work on the lead is complete <b><u>close that window</u></b> and in this window, log the lead as called or defered.</asp:Label><br />
    <asp:Label runat="server" ID ="Label6">5. Repeat from step 1.</asp:Label><br />
    <br /><br />

    <asp:Label runat="server" ID ="lblCallsToday0"  Font-Bold="true" Font-Size="Large">Calls today via workflow:&nbsp;&nbsp;</asp:Label><asp:Label Font-Size="Large" runat="server" ID ="lblCallsTodayCount"></asp:Label>
    <br /><br />
    <asp:Label runat="server" ID ="Label1" Font-Bold="true" Font-Size="Large">Calls defered via workflow:&nbsp;</asp:Label><asp:Label  Font-Size="Large" runat="server" ID ="lblDeferTodayCount"></asp:Label>
    <br /><br />
    <asp:Label ID="lblCompleteLast" runat="server"   Font-Bold="true" Font-Size="Large" ForeColor="Red" Text="Complete Last Lead" Visible="False"></asp:Label>
    <asp:LinkButton ID ="lbNextLead" runat="server"  Font-Bold="true" Font-Size="Large" Text="Open Next Lead" OnClick="lbNextLead_Click" ></asp:LinkButton>
    <br />
    <br />
    <asp:Label runat="server" ID ="lblLeadName">Lead Name:&nbsp;&nbsp;</asp:Label><asp:Label runat="server" ID ="lblFullName"></asp:Label>
    <br /><br />
    <asp:CheckBox ID="chkBoxComplete" runat="server" AutoPostBack="true" Text ="Check When Lead Called" OnCheckedChanged="chkBoxComplete_CheckedChanged" />
    <br />
    <br />
    <asp:CheckBox ID="chkBoxDefer" runat="server" AutoPostBack="true" Text ="Check When Lead Defered (Please Note Why)" OnCheckedChanged="chkBoxDefer_CheckedChanged" />
    <br />
    <br />
        
    <asp:Table ID="tblActions" runat="server" Width="194px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCalledLeads" runat="server">Today's Called Leads</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblDeferedLeads" runat="server">Today's Defered Leads</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:ListBox ID="lbCalledLeads" runat="server" Width="530px" Height="600px"></asp:ListBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="lbDeferedLeads" runat="server" Width="530px" Height="600px"></asp:ListBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        
    
</asp:Panel>
    <asp:HiddenField runat="server" ID="hdLeadId" />
</asp:Content>
