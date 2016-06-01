<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LeadHoldAndCallEdit.aspx.cs" Inherits="LeadHoldAndCallEdit" Title="LeadHoldAndCall Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lead Hold And Call - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="LeadHoldAndCallPk" runat="server" DataSourceID="LeadHoldAndCallDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LeadHoldAndCallFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LeadHoldAndCallFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>LeadHoldAndCall not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LeadHoldAndCallDataSource ID="LeadHoldAndCallDataSource" runat="server"
			SelectMethod="GetByLeadHoldAndCallPk"
		>
			<Parameters>
				<asp:QueryStringParameter Name="LeadHoldAndCallPk" QueryStringField="LeadHoldAndCallPk" Type="String" />

			</Parameters>
		</data:LeadHoldAndCallDataSource>
		
		<br />

		

</asp:Content>

