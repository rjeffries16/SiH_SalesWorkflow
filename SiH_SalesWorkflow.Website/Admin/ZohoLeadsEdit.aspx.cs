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
using SiH_SalesWorkflow.Web.UI;
#endregion

public partial class ZohoLeadsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ZohoLeadsEdit.aspx?{0}", ZohoLeadsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ZohoLeadsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ZohoLeads.aspx");
		FormUtil.SetDefaultMode(FormView1, "Leadpk");
	}
}


