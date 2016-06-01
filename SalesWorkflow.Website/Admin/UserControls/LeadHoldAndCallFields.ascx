<%@ Control Language="C#" ClassName="LeadHoldAndCallFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadCalled" runat="server" Text="Lead Called:" AssociatedControlID="dataLeadCalled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataLeadCalled" SelectedValue='<%# Bind("LeadCalled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadDefered" runat="server" Text="Lead Defered:" AssociatedControlID="dataLeadDefered" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataLeadDefered" SelectedValue='<%# Bind("LeadDefered") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadActionDts" runat="server" Text="Lead Action Dts:" AssociatedControlID="dataLeadActionDts" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadActionDts" Text='<%# Bind("LeadActionDts", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLeadActionDts" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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
        <td class="literal"><asp:Label ID="lbldataLeadHoldDts" runat="server" Text="Lead Hold Dts:" AssociatedControlID="dataLeadHoldDts" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadHoldDts" Text='<%# Bind("LeadHoldDts", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLeadHoldDts" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLeadHoldDts" runat="server" Display="Dynamic" ControlToValidate="dataLeadHoldDts" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


