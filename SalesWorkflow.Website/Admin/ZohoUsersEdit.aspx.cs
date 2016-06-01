﻿#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SalesWorkflow.Web.UI;
#endregion

public partial class ZohoUsersEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ZohoUsersEdit.aspx?{0}", ZohoUsersDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ZohoUsersEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ZohoUsers.aspx");
		FormUtil.SetDefaultMode(FormView1, "Userpk");
	}
}


