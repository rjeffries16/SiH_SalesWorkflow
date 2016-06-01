#region Imports...
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

public partial class ZohoCallsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ZohoCallsEdit.aspx?{0}", ZohoCallsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ZohoCallsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ZohoCalls.aspx");
		FormUtil.SetDefaultMode(FormView1, "CallPk");
	}
}


