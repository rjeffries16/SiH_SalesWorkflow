<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ZohoCalls.aspx.cs" Inherits="ZohoCalls" Title="ZohoCalls List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Zoho Calls List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ZohoCallsDataSource"
				DataKeyNames="CallPk"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ZohoCalls.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Leadid" HeaderText="Leadid" SortExpression="[LEADID]"  />
				<asp:BoundField DataField="ModifiedTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Time" SortExpression="[Modified Time]"  />
				<asp:BoundField DataField="CreatedTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Time" SortExpression="[Created Time]"  />
				<asp:BoundField DataField="ContactId" HeaderText="Contact Id" SortExpression="[ContactID]"  />
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]"  />
				<asp:BoundField DataField="Potentialid" HeaderText="Potentialid" SortExpression="[POTENTIALID]"  />
				<asp:BoundField DataField="Taskid" HeaderText="Taskid" SortExpression="[TASKID]"  />
				<asp:BoundField DataField="WhoIdId" HeaderText="Who Id Id" SortExpression="[Who Id Id]"  />
				<asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="[Subject]"  />
				<asp:BoundField DataField="RelatedTo" HeaderText="Related To" SortExpression="[RELATED To]"  />
				<asp:BoundField DataField="Semodule" HeaderText="Semodule" SortExpression="[SEMODULE]"  />
				<asp:BoundField DataField="SafeNameCallDurationInMinutes" HeaderText="Call Duration(in Minutes)" SortExpression="[Call Duration (in minutes)]"  />
				<asp:BoundField DataField="SafeNameCallDurationInSeconds" HeaderText="Call Duration(in Seconds)" SortExpression="[Call Duration (in seconds)]"  />
				<asp:BoundField DataField="CallDuration" HeaderText="Call Duration" SortExpression="[Call Duration]"  />
				<asp:BoundField DataField="Accountid" HeaderText="Accountid" SortExpression="[ACCOUNTID]"  />
				<asp:BoundField DataField="Billable" HeaderText="Billable" SortExpression="[Billable]"  />
				<asp:BoundField DataField="CallOwner" HeaderText="Call Owner" SortExpression="[Call Owner]"  />
				<asp:BoundField DataField="CallStartTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Call Start Time" SortExpression="[Call Start Time]"  />
				<asp:BoundField DataField="CallType" HeaderText="Call Type" SortExpression="[Call Type]"  />
				<asp:BoundField DataField="CallResult" HeaderText="Call Result" SortExpression="[Call Result]"  />
				<asp:BoundField DataField="CallOwnerId" HeaderText="Call Owner Id" SortExpression="[Call Owner Id]"  />
				<asp:BoundField DataField="CallPurpose" HeaderText="Call Purpose" SortExpression="[Call Purpose]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ZohoCalls Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnZohoCalls" OnClientClick="javascript:location.href='ZohoCallsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ZohoCallsDataSource ID="ZohoCallsDataSource" runat="server"
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
		</data:ZohoCallsDataSource>
	    		
</asp:Content>



