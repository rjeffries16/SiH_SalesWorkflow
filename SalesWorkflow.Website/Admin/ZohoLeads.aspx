<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ZohoLeads.aspx.cs" Inherits="ZohoLeads" Title="ZohoLeads List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Zoho Leads List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ZohoLeadsDataSource"
				DataKeyNames="Leadpk"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ZohoLeads.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="TimeZone" HeaderText="Time Zone" SortExpression="[Time Zone]"  />
				<data:BoundRadioButtonField DataField="TasksInvolved" HeaderText="Tasks Involved" SortExpression="[Tasks Involved]"  />
				<asp:BoundField DataField="SubmittedOn" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Submitted On" SortExpression="[Submitted On]"  />
				<asp:BoundField DataField="Worries" HeaderText="Worries" SortExpression="[Worries]"  />
				<asp:BoundField DataField="Website" HeaderText="Website" SortExpression="[Website]"  />
				<asp:BoundField DataField="Url" HeaderText="Url" SortExpression="[URL]"  />
				<asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="[Rating]"  />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="[Phone]"  />
				<asp:BoundField DataField="ModifiedTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Modified Time" SortExpression="[Modified Time]"  />
				<asp:BoundField DataField="SubmissionTime" HeaderText="Submission Time" SortExpression="[Submission Time]"  />
				<asp:BoundField DataField="State" HeaderText="State" SortExpression="[State]"  />
				<asp:BoundField DataField="SecondaryEmail" HeaderText="Secondary Email" SortExpression="[Secondary Email]"  />
				<asp:BoundField DataField="Sun811" HeaderText="Sun811" SortExpression="[Sun8-11]"  />
				<asp:BoundField DataField="Sat58" HeaderText="Sat58" SortExpression="[Sat5-8]"  />
				<asp:BoundField DataField="Sat25" HeaderText="Sat25" SortExpression="[Sat2-5]"  />
				<asp:BoundField DataField="Sun58" HeaderText="Sun58" SortExpression="[Sun5-8]"  />
				<asp:BoundField DataField="Sun25" HeaderText="Sun25" SortExpression="[Sun2-5]"  />
				<asp:BoundField DataField="Sun112" HeaderText="Sun112" SortExpression="[Sun11-2]"  />
				<asp:BoundField DataField="Wday25" HeaderText="Wday25" SortExpression="[WDay2-5]"  />
				<asp:BoundField DataField="Wday112" HeaderText="Wday112" SortExpression="[WDay11-2]"  />
				<asp:BoundField DataField="Wday811" HeaderText="Wday811" SortExpression="[WDay8-11]"  />
				<asp:BoundField DataField="Sat112" HeaderText="Sat112" SortExpression="[Sat11-2]"  />
				<asp:BoundField DataField="Sat811" HeaderText="Sat811" SortExpression="[Sat8-11]"  />
				<asp:BoundField DataField="Wday58" HeaderText="Wday58" SortExpression="[WDay5-8]"  />
				<data:BoundRadioButtonField DataField="EventsInvolved" HeaderText="Events Involved" SortExpression="[Events Involved]"  />
				<data:BoundRadioButtonField DataField="EmailOptOut" HeaderText="Email Opt Out" SortExpression="[Email Opt Out]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<data:BoundRadioButtonField DataField="SafeNameFirstTimeCallerNewLead" HeaderText="First Time Caller(new Lead)" SortExpression="[First Time Caller (new lead)]"  />
				<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="[First Name]"  />
				<asp:BoundField DataField="FeaturesOfInterest" HeaderText="Features Of Interest" SortExpression="[Features of Interest]"  />
				<asp:BoundField DataField="Company" HeaderText="Company" SortExpression="[Company]"  />
				<data:BoundRadioButtonField DataField="CallsInvolved" HeaderText="Calls Involved" SortExpression="[Calls Involved]"  />
				<data:BoundRadioButtonField DataField="ActivitiesInvolved" HeaderText="Activities Involved" SortExpression="[Activities Involved]"  />
				<asp:BoundField DataField="CreatedTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Time" SortExpression="[Created Time]"  />
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[Created By]"  />
				<data:BoundRadioButtonField DataField="Converted" HeaderText="Converted" SortExpression="[CONVERTED]"  />
				<asp:BoundField DataField="LeadStatus" HeaderText="Lead Status" SortExpression="[Lead Status]"  />
				<asp:BoundField DataField="LeadSource" HeaderText="Lead Source" SortExpression="[Lead Source]"  />
				<asp:BoundField DataField="LeadOwner" HeaderText="Lead Owner" SortExpression="[Lead Owner]"  />
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[Modified By]"  />
				<asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="[Mobile]"  />
				<asp:BoundField DataField="Leadid" HeaderText="Leadid" SortExpression="[LEADID]"  />
				<asp:BoundField DataField="LastActivityTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Activity Time" SortExpression="[Last Activity Time]"  />
				<asp:BoundField DataField="Industry" HeaderText="Industry" SortExpression="[Industry]"  />
				<asp:BoundField DataField="IfNoLongerInterested" HeaderText="If No Longer Interested" SortExpression="[If No Longer Interested]"  />
				<asp:BoundField DataField="LeadOwnerId" HeaderText="Lead Owner Id" SortExpression="[Lead Owner Id]"  />
				<asp:BoundField DataField="LastVisitedTime" HeaderText="Last Visited Time" SortExpression="[Last Visited Time]"  />
				<asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="[Last Name]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ZohoLeads Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnZohoLeads" OnClientClick="javascript:location.href='ZohoLeadsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ZohoLeadsDataSource ID="ZohoLeadsDataSource" runat="server"
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
		</data:ZohoLeadsDataSource>
	    		
</asp:Content>



