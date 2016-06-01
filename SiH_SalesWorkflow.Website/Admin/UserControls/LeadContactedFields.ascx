<%@ Control Language="C#" ClassName="LeadContactedFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadContactEmail" runat="server" Text="Lead Contact Email:" AssociatedControlID="dataLeadContactEmail" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataLeadContactEmail" SelectedValue='<%# Bind("LeadContactEmail") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadContactDts" runat="server" Text="Lead Contact Dts:" AssociatedControlID="dataLeadContactDts" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadContactDts" Text='<%# Bind("LeadContactDts") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataThisEventDts" runat="server" Text="This Event Dts:" AssociatedControlID="dataThisEventDts" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataThisEventDts" Text='<%# Bind("ThisEventDts", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataThisEventDts" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadid" runat="server" Text="Leadid:" AssociatedControlID="dataLeadid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadid" Text='<%# Bind("Leadid") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLeadid" runat="server" Display="Dynamic" ControlToValidate="dataLeadid" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserId" Text='<%# Bind("UserId") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserId" runat="server" Display="Dynamic" ControlToValidate="dataUserId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadContactPhone" runat="server" Text="Lead Contact Phone:" AssociatedControlID="dataLeadContactPhone" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataLeadContactPhone" SelectedValue='<%# Bind("LeadContactPhone") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


