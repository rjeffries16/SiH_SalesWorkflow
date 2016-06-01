<%@ Control Language="C#" ClassName="ZohoCallsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadid" runat="server" Text="Leadid:" AssociatedControlID="dataLeadid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadid" Text='<%# Bind("Leadid") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedTime" runat="server" Text="Modified Time:" AssociatedControlID="dataModifiedTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedTime" Text='<%# Bind("ModifiedTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataModifiedTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedTime" runat="server" Text="Created Time:" AssociatedControlID="dataCreatedTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedTime" Text='<%# Bind("CreatedTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataContactId" runat="server" Text="Contact Id:" AssociatedControlID="dataContactId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataContactId" Text='<%# Bind("ContactId") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedBy" runat="server" Text="Created By:" AssociatedControlID="dataCreatedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedBy" Text='<%# Bind("CreatedBy") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPotentialid" runat="server" Text="Potentialid:" AssociatedControlID="dataPotentialid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPotentialid" Text='<%# Bind("Potentialid") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTaskid" runat="server" Text="Taskid:" AssociatedControlID="dataTaskid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTaskid" Text='<%# Bind("Taskid") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWhoIdId" runat="server" Text="Who Id Id:" AssociatedControlID="dataWhoIdId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWhoIdId" Text='<%# Bind("WhoIdId") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSubject" runat="server" Text="Subject:" AssociatedControlID="dataSubject" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSubject" Text='<%# Bind("Subject") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRelatedTo" runat="server" Text="Related To:" AssociatedControlID="dataRelatedTo" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRelatedTo" Text='<%# Bind("RelatedTo") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSemodule" runat="server" Text="Semodule:" AssociatedControlID="dataSemodule" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSemodule" Text='<%# Bind("Semodule") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSafeNameCallDurationInMinutes" runat="server" Text="Call Duration(in Minutes):" AssociatedControlID="dataSafeNameCallDurationInMinutes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSafeNameCallDurationInMinutes" Text='<%# Bind("SafeNameCallDurationInMinutes") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSafeNameCallDurationInMinutes" runat="server" Display="Dynamic" ControlToValidate="dataSafeNameCallDurationInMinutes" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSafeNameCallDurationInSeconds" runat="server" Text="Call Duration(in Seconds):" AssociatedControlID="dataSafeNameCallDurationInSeconds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSafeNameCallDurationInSeconds" Text='<%# Bind("SafeNameCallDurationInSeconds") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSafeNameCallDurationInSeconds" runat="server" Display="Dynamic" ControlToValidate="dataSafeNameCallDurationInSeconds" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallDuration" runat="server" Text="Call Duration:" AssociatedControlID="dataCallDuration" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCallDuration" Text='<%# Bind("CallDuration") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAccountid" runat="server" Text="Accountid:" AssociatedControlID="dataAccountid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAccountid" Text='<%# Bind("Accountid") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillable" runat="server" Text="Billable:" AssociatedControlID="dataBillable" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBillable" Text='<%# Bind("Billable") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallOwner" runat="server" Text="Call Owner:" AssociatedControlID="dataCallOwner" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCallOwner" Text='<%# Bind("CallOwner") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallStartTime" runat="server" Text="Call Start Time:" AssociatedControlID="dataCallStartTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCallStartTime" Text='<%# Bind("CallStartTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCallStartTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallType" runat="server" Text="Call Type:" AssociatedControlID="dataCallType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCallType" Text='<%# Bind("CallType") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallResult" runat="server" Text="Call Result:" AssociatedControlID="dataCallResult" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCallResult" Text='<%# Bind("CallResult") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallOwnerId" runat="server" Text="Call Owner Id:" AssociatedControlID="dataCallOwnerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCallOwnerId" Text='<%# Bind("CallOwnerId") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallPurpose" runat="server" Text="Call Purpose:" AssociatedControlID="dataCallPurpose" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCallPurpose" Text='<%# Bind("CallPurpose") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


