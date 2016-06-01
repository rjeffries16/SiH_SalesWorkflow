<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataCleanup.aspx.cs" Inherits="SalesWorkflow.SalesLeads.DataCleanup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" Width="90%" >
        <asp:TextBox ID="txtWhereClause" runat="server" Height="57px" Rows="4" Width="310px"></asp:TextBox>
        <br />
    <asp:Label ID="lblCompleteLast" runat="server" Text="Complete Last Lead" Visible="False"></asp:Label>
    <asp:LinkButton ID ="lbNextLead" runat="server" Text="Open Lead" OnClick="lbNextLead_Click" ></asp:LinkButton>
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
        
    
        
    
</asp:Panel>
    <asp:HiddenField runat="server" ID="hdLeadId" />
</asp:Content>
