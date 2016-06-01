<%@ Control Language="C#" ClassName="ZohoLeadsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTimeZone" runat="server" Text="Time Zone:" AssociatedControlID="dataTimeZone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTimeZone" Text='<%# Bind("TimeZone") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTasksInvolved" runat="server" Text="Tasks Involved:" AssociatedControlID="dataTasksInvolved" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataTasksInvolved" SelectedValue='<%# Bind("TasksInvolved") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSubmittedOn" runat="server" Text="Submitted On:" AssociatedControlID="dataSubmittedOn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSubmittedOn" Text='<%# Bind("SubmittedOn", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataSubmittedOn" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWorries" runat="server" Text="Worries:" AssociatedControlID="dataWorries" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWorries" Text='<%# Bind("Worries") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebsite" runat="server" Text="Website:" AssociatedControlID="dataWebsite" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebsite" Text='<%# Bind("Website") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUrl" runat="server" Text="Url:" AssociatedControlID="dataUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUrl" Text='<%# Bind("Url") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRating" runat="server" Text="Rating:" AssociatedControlID="dataRating" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRating" Text='<%# Bind("Rating") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhone" runat="server" Text="Phone:" AssociatedControlID="dataPhone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedTime" runat="server" Text="Modified Time:" AssociatedControlID="dataModifiedTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedTime" Text='<%# Bind("ModifiedTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModifiedTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSubmissionTime" runat="server" Text="Submission Time:" AssociatedControlID="dataSubmissionTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSubmissionTime" Text='<%# Bind("SubmissionTime") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataState" runat="server" Text="State:" AssociatedControlID="dataState" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataState" Text='<%# Bind("State") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecondaryEmail" runat="server" Text="Secondary Email:" AssociatedControlID="dataSecondaryEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecondaryEmail" Text='<%# Bind("SecondaryEmail") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSun811" runat="server" Text="Sun811:" AssociatedControlID="dataSun811" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSun811" Text='<%# Bind("Sun811") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSun811" runat="server" Display="Dynamic" ControlToValidate="dataSun811" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSat58" runat="server" Text="Sat58:" AssociatedControlID="dataSat58" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSat58" Text='<%# Bind("Sat58") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSat58" runat="server" Display="Dynamic" ControlToValidate="dataSat58" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSat25" runat="server" Text="Sat25:" AssociatedControlID="dataSat25" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSat25" Text='<%# Bind("Sat25") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSat25" runat="server" Display="Dynamic" ControlToValidate="dataSat25" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSun58" runat="server" Text="Sun58:" AssociatedControlID="dataSun58" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSun58" Text='<%# Bind("Sun58") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSun58" runat="server" Display="Dynamic" ControlToValidate="dataSun58" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSun25" runat="server" Text="Sun25:" AssociatedControlID="dataSun25" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSun25" Text='<%# Bind("Sun25") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSun25" runat="server" Display="Dynamic" ControlToValidate="dataSun25" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSun112" runat="server" Text="Sun112:" AssociatedControlID="dataSun112" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSun112" Text='<%# Bind("Sun112") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSun112" runat="server" Display="Dynamic" ControlToValidate="dataSun112" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWday25" runat="server" Text="Wday25:" AssociatedControlID="dataWday25" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWday25" Text='<%# Bind("Wday25") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWday25" runat="server" Display="Dynamic" ControlToValidate="dataWday25" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWday112" runat="server" Text="Wday112:" AssociatedControlID="dataWday112" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWday112" Text='<%# Bind("Wday112") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWday112" runat="server" Display="Dynamic" ControlToValidate="dataWday112" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWday811" runat="server" Text="Wday811:" AssociatedControlID="dataWday811" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWday811" Text='<%# Bind("Wday811") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWday811" runat="server" Display="Dynamic" ControlToValidate="dataWday811" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSat112" runat="server" Text="Sat112:" AssociatedControlID="dataSat112" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSat112" Text='<%# Bind("Sat112") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSat112" runat="server" Display="Dynamic" ControlToValidate="dataSat112" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSat811" runat="server" Text="Sat811:" AssociatedControlID="dataSat811" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSat811" Text='<%# Bind("Sat811") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSat811" runat="server" Display="Dynamic" ControlToValidate="dataSat811" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWday58" runat="server" Text="Wday58:" AssociatedControlID="dataWday58" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWday58" Text='<%# Bind("Wday58") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWday58" runat="server" Display="Dynamic" ControlToValidate="dataWday58" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventsInvolved" runat="server" Text="Events Involved:" AssociatedControlID="dataEventsInvolved" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEventsInvolved" SelectedValue='<%# Bind("EventsInvolved") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailOptOut" runat="server" Text="Email Opt Out:" AssociatedControlID="dataEmailOptOut" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEmailOptOut" SelectedValue='<%# Bind("EmailOptOut") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSafeNameFirstTimeCallerNewLead" runat="server" Text="First Time Caller(new Lead):" AssociatedControlID="dataSafeNameFirstTimeCallerNewLead" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSafeNameFirstTimeCallerNewLead" SelectedValue='<%# Bind("SafeNameFirstTimeCallerNewLead") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstName" runat="server" Text="First Name:" AssociatedControlID="dataFirstName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstName" Text='<%# Bind("FirstName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeaturesOfInterest" runat="server" Text="Features Of Interest:" AssociatedControlID="dataFeaturesOfInterest" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFeaturesOfInterest" Text='<%# Bind("FeaturesOfInterest") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompany" runat="server" Text="Company:" AssociatedControlID="dataCompany" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompany" Text='<%# Bind("Company") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallsInvolved" runat="server" Text="Calls Involved:" AssociatedControlID="dataCallsInvolved" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataCallsInvolved" SelectedValue='<%# Bind("CallsInvolved") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActivitiesInvolved" runat="server" Text="Activities Involved:" AssociatedControlID="dataActivitiesInvolved" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataActivitiesInvolved" SelectedValue='<%# Bind("ActivitiesInvolved") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedTime" runat="server" Text="Created Time:" AssociatedControlID="dataCreatedTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedTime" Text='<%# Bind("CreatedTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedBy" runat="server" Text="Created By:" AssociatedControlID="dataCreatedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedBy" Text='<%# Bind("CreatedBy") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataConverted" runat="server" Text="Converted:" AssociatedControlID="dataConverted" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataConverted" SelectedValue='<%# Bind("Converted") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadStatus" runat="server" Text="Lead Status:" AssociatedControlID="dataLeadStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadStatus" Text='<%# Bind("LeadStatus") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadSource" runat="server" Text="Lead Source:" AssociatedControlID="dataLeadSource" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadSource" Text='<%# Bind("LeadSource") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadOwner" runat="server" Text="Lead Owner:" AssociatedControlID="dataLeadOwner" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadOwner" Text='<%# Bind("LeadOwner") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMobile" runat="server" Text="Mobile:" AssociatedControlID="dataMobile" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMobile" Text='<%# Bind("Mobile") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadid" runat="server" Text="Leadid:" AssociatedControlID="dataLeadid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadid" Text='<%# Bind("Leadid") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastActivityTime" runat="server" Text="Last Activity Time:" AssociatedControlID="dataLastActivityTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastActivityTime" Text='<%# Bind("LastActivityTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastActivityTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIndustry" runat="server" Text="Industry:" AssociatedControlID="dataIndustry" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIndustry" Text='<%# Bind("Industry") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIfNoLongerInterested" runat="server" Text="If No Longer Interested:" AssociatedControlID="dataIfNoLongerInterested" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIfNoLongerInterested" Text='<%# Bind("IfNoLongerInterested") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadOwnerId" runat="server" Text="Lead Owner Id:" AssociatedControlID="dataLeadOwnerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadOwnerId" Text='<%# Bind("LeadOwnerId") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastVisitedTime" runat="server" Text="Last Visited Time:" AssociatedControlID="dataLastVisitedTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastVisitedTime" Text='<%# Bind("LastVisitedTime") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastName" runat="server" Text="Last Name:" AssociatedControlID="dataLastName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastName" Text='<%# Bind("LastName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


