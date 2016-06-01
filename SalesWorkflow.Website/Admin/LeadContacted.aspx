<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LeadContacted.aspx.cs" Inherits="LeadContacted" Title="LeadContacted List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lead Contacted List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LeadContactedDataSource"
				DataKeyNames="LeadContactedPk"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_LeadContacted.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:BoundRadioButtonField DataField="LeadContactEmail" HeaderText="Lead Contact Email" SortExpression="[LeadContactEmail]"  />
				<asp:BoundField DataField="LeadContactDts" HeaderText="Lead Contact Dts" SortExpression="[LeadContactDts]"  />
				<asp:BoundField DataField="ThisEventDts" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="This Event Dts" SortExpression="[ThisEventDts]"  />
				<asp:BoundField DataField="Leadid" HeaderText="Leadid" SortExpression="[LEADID]"  />
				<asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="[USER_ID]"  />
				<data:BoundRadioButtonField DataField="LeadContactPhone" HeaderText="Lead Contact Phone" SortExpression="[LeadContactPhone]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No LeadContacted Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLeadContacted" OnClientClick="javascript:location.href='LeadContactedEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LeadContactedDataSource ID="LeadContactedDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:LeadContactedDataSource>
	    		
</asp:Content>



