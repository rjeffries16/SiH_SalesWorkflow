<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LeadHoldAndCall.aspx.cs" Inherits="LeadHoldAndCall" Title="LeadHoldAndCall List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lead Hold And Call List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LeadHoldAndCallDataSource"
				DataKeyNames="LeadHoldAndCallPk"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_LeadHoldAndCall.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:BoundRadioButtonField DataField="LeadCalled" HeaderText="Lead Called" SortExpression="[LeadCalled]"  />
				<data:BoundRadioButtonField DataField="LeadDefered" HeaderText="Lead Defered" SortExpression="[LeadDefered]"  />
				<asp:BoundField DataField="LeadActionDts" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Lead Action Dts" SortExpression="[LeadActionDts]"  />
				<asp:BoundField DataField="Leadid" HeaderText="Leadid" SortExpression="[LEADID]"  />
				<asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="[USER_ID]"  />
				<asp:BoundField DataField="LeadHoldDts" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Lead Hold Dts" SortExpression="[LeadHoldDts]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No LeadHoldAndCall Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLeadHoldAndCall" OnClientClick="javascript:location.href='LeadHoldAndCallEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LeadHoldAndCallDataSource ID="LeadHoldAndCallDataSource" runat="server"
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
		</data:LeadHoldAndCallDataSource>
	    		
</asp:Content>



