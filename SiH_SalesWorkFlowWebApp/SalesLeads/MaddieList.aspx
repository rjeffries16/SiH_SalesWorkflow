<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaddieList.aspx.cs" Inherits="SiH_SalesWorkFlowWebApp.SalesLeads.MaddieList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" Width="90%" >
    <asp:Label ID="lblCallsToday1" runat="server" Font-Bold="true" Font-Size="Large">Instructions:&nbsp;&nbsp;</asp:Label>
    <br />
    <asp:Label runat="server" ID ="Label2">1. Click on the "Open Next Lead" Link a new browser window will open with a lead in Zoho.</asp:Label><br />
    <asp:Label runat="server" ID ="Label3">2. Read the lead history and determine if a contact has been made.</asp:Label><br />
    <asp:Label runat="server" ID ="Label5">3. After the work on the lead is complete <b><u>close that window</u></b> and in this window, log the lead as called or defered.</asp:Label><br />
    <asp:Label runat="server" ID ="Label6">4. Repeat from step 1.</asp:Label><br />
    <br /><br />

    <asp:Label runat="server" ID ="lblCallsToday"  Font-Bold="true" Font-Size="Large">Calls today via workflow:&nbsp;&nbsp;</asp:Label><asp:Label Font-Size="Large" runat="server" ID ="lblCallsTodayCount"></asp:Label>
    <br /><br />
    <asp:Label ID="lblCompleteLast" runat="server"   Font-Bold="true" Font-Size="Large" ForeColor="Red" Text="Complete Last Lead" Visible="False"></asp:Label>
    <asp:LinkButton ID ="lbNextLead" runat="server"  Font-Bold="true" Font-Size="Large" Text="Open Next Lead" OnClick="lbNextLead_Click" ></asp:LinkButton>
    <br />
    <br />
    <asp:Label runat="server" ID ="lblLeadName">Lead Name:&nbsp;&nbsp;</asp:Label><asp:Label runat="server" ID ="lblFullName"></asp:Label>
    <br /><br />
    <asp:CheckBox ID="chkBoxNotConnected" runat="server" AutoPostBack="true" Text ="Check If Lead Has Not Conntected" OnCheckedChanged="chkBoxNotConnected_CheckedChanged" />
    
    <br /><br />
    <asp:Label runat="server" ID ="Label1">First Connect Date:&nbsp;</asp:Label><asp:TextBox ID="txtContactDate" runat="server"></asp:TextBox>
    
    <br /><br />
    <asp:CheckBox ID="chkBoxConnectedByPhone" runat="server" AutoPostBack="true" Text ="Check If Lead FIRST Connected by Phone" OnCheckedChanged="chkBoxConnectedByPhone_CheckedChanged" />
    <br />
    <br />
    <asp:CheckBox ID="chkConnectedByEmail" runat="server" AutoPostBack="true" Text ="Check If Lead FIRST Connected by Email" OnCheckedChanged="chkConnectedByEmail_CheckedChanged" />
    <br />
    <br />
        
    <asp:Table ID="tblActions" runat="server" Width="194px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCalledLeads" runat="server">Today's Called Leads</asp:Label>
            </asp:TableCell>
            
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:ListBox ID="lbCalledLeads" runat="server" Width="530px" Height="600px"></asp:ListBox>
            </asp:TableCell>
            
        </asp:TableRow>
    </asp:Table>
        
    
</asp:Panel>
    <asp:HiddenField runat="server" ID="hdLeadId" />
</asp:Content>
